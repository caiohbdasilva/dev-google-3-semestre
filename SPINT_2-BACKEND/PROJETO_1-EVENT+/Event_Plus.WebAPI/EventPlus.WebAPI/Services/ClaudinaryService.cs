using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Utils;
using Microsoft.Extensions.Options;

namespace EventPlus.WebAPI.Services;

public class ClaudinaryService : IClaudinaryService
{

    private readonly Cloudinary _cloudinary;

    public ClaudinaryService(IOptions<CloudinarySettings> options)
    {
        var credenciais = options.Value;

        // Account = "carteira" com as três credenciais necessárias para acessar a API do Cloudinary
        var account = new Account(credenciais.CloudName, credenciais.ApiKey, credenciais.ApiSecret);


        //Cria o cliente de fato já autenticado com as credenciais
        _cloudinary = new Cloudinary(account);

        //Determina que as URLs geradas para as imagens serão HTTPS (mais seguro)
        _cloudinary.Api.Secure = true;


    }
    public async Task<string> UploadImagem(IFormFile arquivoImagem)
    {
        //Abre um fluxo de leitura do arquivo enviado pelo usuário

        //using = Garante que o fluxo será fechado e liberado da memória assim que terminar de ser usado
        using var stream = arquivoImagem.OpenReadStream();

        var UploadParams = new ImageUploadParams()
        {
            //O arquivo será enviado para o Cloudinary com o nome original do arquivo e o fluxo de leitura
            File = new FileDescription(arquivoImagem.FileName, stream),

            //Pasta no Cloudinary onde a imagem será armazenada
            Folder = "eventplus/eventos"
        };

        //Envia a mensagem para o Cloudinary e aguarda a resposta dos dados do upload (URL, tamanho, etc)
        var resultado = await _cloudinary.UploadAsync(UploadParams);


        //Retorna a URL completa da imagem armazenada no Cloudinary
        // URI = Uniform Resource Identifier (Identificador Uniforme de Recursos) é um padrão que define como identificar recursos na web, como páginas, imagens, vídeos, etc.
        return resultado.SecureUrl.AbsoluteUri;

    }
}

