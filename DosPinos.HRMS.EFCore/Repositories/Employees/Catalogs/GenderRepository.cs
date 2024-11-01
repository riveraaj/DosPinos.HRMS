namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class GenderRepository(DospinosdbContext context) : IGenderRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllGenderDTO> GetAll()
        {
            List<IGetAllGenderDTO> response = [];

            List<Gender> genderList = [.. _context.Genders];

            Parallel.ForEach(genderList, (gender) =>
            {
                response.Add(GenderMapper.MapFrom(gender));
            });

            return response;
        }
    }
}