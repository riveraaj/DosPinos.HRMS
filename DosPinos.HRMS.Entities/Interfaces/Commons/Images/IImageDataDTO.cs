namespace DosPinos.HRMS.Entities.Interfaces.Commons.Images;

/// <summary>
/// Interface for save image data.
/// </summary>
public interface IImageDataDTO : IEntityDTO
{
    byte[] Data { get; }
    string Name { get; }
}