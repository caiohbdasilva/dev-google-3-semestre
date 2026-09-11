using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Utils;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace EventPlus.WebAPI.Services;

public class SightengineModerationService : IModerationService
    {
        private readonly HttpClient _http;
        private readonly string _apiuser;
        private readonly string _apisecret;

        //Acima deste linear, a categoria é considerada violação
        private const double Limiar = 0.5;

        public SightengineModerationService(HttpClient http, IOptions<SightengineSettings> options)
        {
            _http = http;
            _apiuser = options.Value.ApiUser;
            _apisecret = options.Value.ApiSecret;
        }


        public async Task<bool> ModerarTexto(string texto)
        {
            var form = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["text"] = texto,
                ["lang"] = "pt",
                ["mode"] = "ml",
                ["api_user"] = _apiuser,
                ["api_secret"] = _apisecret
            });

            //"text/check.json" ==> Endpoint da API externa;
            //form: dados que serão enviados junto à requisição(texto a ser moderado, etc..)
            var resposta = await _http.PostAsync("text/check.json", form);

            
            //Verifica se a resposta(http post) foi bem sucedida
            //Se o status for um erro, lança uma exception
            resposta.EnsureSuccessStatusCode();


            using var doc = JsonDocument.Parse(
                await resposta.Content.ReadAsStringAsync()
             );


            //obtém um elemento raíz do Json, tendo acesso as proriedades do Json (Arrays, etc...)
            var root = doc.RootElement;


            //obtém a propriedade "status" do json e verifica se o valor é diferente de "sucess"
            if (root.GetProperty("status").GetString() != "success")
            {
                //Tenta obter a propriedade "error" e, dentro dela, a mensagem de erro
                var msg = root.TryGetProperty("error", out var err) && err.TryGetProperty("message", out var m)
                    ? m.GetString() // Se verdadeiro
                    : "erro desconhecido"; //se falso

                throw new Exception($"Sightengine: {msg}:");
            }

            var classes = root.GetProperty("moderation_classes");

            foreach (var prop in classes.EnumerateObject())
            {
                if (prop.Name == "available") continue;
                if (prop.Value.ValueKind == JsonValueKind.Number && prop.Value.GetDouble() >= Limiar)
                    return true; //Reprovado -> Passou do limiar
            }

            return false; //Aprovado -> Não passou do limiar
        }
    }
