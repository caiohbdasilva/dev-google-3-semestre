namespace EventPlus.WebAPI.Interfaces
{
    public interface IClaudinaryService
    {
        Task<string> UploadImagem(IFormFile arquivoImagem);
    }
}