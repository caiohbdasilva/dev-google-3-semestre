namespace EventPlus.WebAPI.Utils;


/// <summary>
/// Utilitário estático responsável pelas operações de criptografia e hashing de senhas na API.
/// </summary>

public static class Criptografia
{
    // método estático (static): pertence a uma própria classe e não a uma instância específica da classe. 
    // Isso significa que você pode chamar o método diretamente na classe, sem precisar criar um objeto dela.

    public static string GerarHash(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }

    public static bool CompararHash(string senhaInformada, string senhaBanco)
    {
        if (string.IsNullOrEmpty(senhaInformada) || string.IsNullOrEmpty(senhaBanco))
        {
            return false;
        }

        try
        {
            return BCrypt.Net.BCrypt.Verify(senhaInformada, senhaBanco);
        }
        catch (BCrypt.Net.SaltParseException)
        {
            return false;
        }
    }
}
