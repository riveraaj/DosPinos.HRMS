namespace DosPinos.HRMS.Entities.DTOs.Commons.Images;

/// <summary>
/// DTO for save image data.
/// </summary>
public class ImageDataDTO(byte[] data,
                          string name) : EntityDTO, IImageDataDTO
{
    public byte[] Data => data;
    public string Name => name;
}