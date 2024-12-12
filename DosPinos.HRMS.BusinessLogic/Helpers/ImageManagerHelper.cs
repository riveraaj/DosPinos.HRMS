using DosPinos.HRMS.BusinessObjects.Resources.Commons;

namespace DosPinos.HRMS.BusinessLogic.Helpers
{
    internal static class ImageManagerHelper
    {
        public static async Task<string> SaveAsync(byte[] imageData, string fileName)
        {

            if (imageData == null) throw new ArgumentException("El contenido de la imagen no es válido.");
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException("El nombre del archivo no es válido.");

            //Crear un nombre único para evitar colisiones
            string uniqueFileName = Guid.NewGuid() + Path.GetExtension(fileName);

            //Ruta completa para guardar el archivo
            string folderPath = Path.Combine(Commons.ImageBasePath);
            string fullPath = Path.Combine(folderPath, uniqueFileName);

            // Crear el directorio si no existe
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            // Guardar el archivo
            await File.WriteAllBytesAsync(fullPath, imageData);

            return uniqueFileName;
        }

        public static bool Delete(string filePath)
        {
            try
            {
                string fullPath = Path.Combine(Commons.ImageBasePath, filePath);
                if (filePath != null && File.Exists(fullPath)) File.Delete(fullPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}