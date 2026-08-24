namespace EventPlus.WebAPI.Controllers
{
    internal interface IClaudinaryService
    {
        Task<string> UploadImagem(IFormFile arquivoImagem);
    }
}