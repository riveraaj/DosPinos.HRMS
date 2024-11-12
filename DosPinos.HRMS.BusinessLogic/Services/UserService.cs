using DosPinos.HRMS.BusinessObjects.Interfaces.Securities;
using DosPinos.HRMS.Entities.DTOs.Securities;
using DosPinos.HRMS.Entities.Interfaces.Securities;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class UserService(IUserRepository userRepository,
                             ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _userRepository.GetAll();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Security, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateAsync(CreateUserDTO userDTO)
        {
            IOperationResponseVO response;

            try
            {
                // Validate POCO model
                Helpers.ValidationResult validationResult = userDTO.ValidateModel();
                if (!validationResult.IsValid) return this.CustomWarning(validationResult.ErrorMessages);

                userDTO.Password = CryptographyHelper.Encrypt(userDTO.Password);

                response = await _userRepository.CreateAsync(userDTO);

                if (response.Status == ResponseStatus.Error) throw new Exception(response.Content.ToString());
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Security, ActionCategory.Create, exception, userDTO);
            }

            return response;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        public async Task<IOperationResponseVO> ProcessAsync(ILoginUserDTO userDTO)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                ILoginUserDTO credentialsUser = await _userRepository.Get(userDTO.UserName);

                if (credentialsUser == null) return this.CustomWarning("El usuario no existe. Por favor, ingrese un usuario válido.");

                bool comparePassword = CryptographyHelper.CompareEncryptedAndDecrypted(userDTO.Password, credentialsUser.Password);

                if (!comparePassword) return this.CustomWarning("La contraseña es incorrecta. Por favor, intentelo nuevamente.");

                response.Content = credentialsUser;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Security, ActionCategory.Login, exception, userDTO);
            }

            return response;
        }
    }
}