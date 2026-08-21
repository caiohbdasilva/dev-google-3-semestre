using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventPlus.WebAPI.Controllers;

/// <summary>
/// Controller responsável pela autenticacao de usuários e geração de tokens JWT.(JSON Web Token)
/// 
/// COMO FUNCIONA O JWT:
/// 1. O usuário envia suas credenciais (email e senha) para o endpoint de login. (POST /api/login)
/// 2. A API valida as credenciais no banco (email e hash Bcrypt da senha).
/// 3. Se válido, a API gera um token JWT assinado com uma chave secreta e envia de volta para o usuário.
/// 4. O cliente usa esse token no cabeçalho "Authorization: Bearer{token}" das requisições subsequentes para acessar recursos protegidos([Authorize]).
/// </summary>

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuario _usuario;

    public LoginController(IUsuario usuario)
    {
        _usuario = usuario;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDTO DTO)
    {
        // Primeiro passo: Busca o usuário pelo email e valida a senha usando Bcrypt
        var usuarioEncontrado = await _usuario.BuscarPorEmailESenha(DTO.Email, DTO.Senha);

        // Segundo passo: Se as credenciais forem inválidas, retorna 401 Unauthorized
        if (usuarioEncontrado == null)
        {
            return Unauthorized("Email ou senha inválidos.");
        }

        /// *INÍCIO DA CONFIGURAÇÃO TOKEN JWT* ///

        // Terceiro passo: Criação das listas de Claims (informações do usuário) que serão incluídas no token JWT
        // Clains são como "etiquetas" que carregam informações sobre o usuário, como ID, nome, email e tipo de usuário.

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuarioEncontrado.IdUsuario.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, usuarioEncontrado.Email),
            new Claim("nome", usuarioEncontrado.Nome),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Quarto passo: Criar a chave de segurança com base na chave secreta definida

        var chaveSecreta = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("eventos-chave-autenticacao-webapi-dev")
        );

        // Quinto passo: Definir o algoritimo e assinatura (HMACSHA256 é o padrão)
        var credenciais = new SigningCredentials(chaveSecreta, SecurityAlgorithms.HmacSha256);

        // Sexto passo: "Montar" o token JWT com as informações de claims, validade e assinatura
        var token = new JwtSecurityToken(
            issuer: "EventPlus.WebAPI", // Emissor do token (quem está emitindo)
            audience: "EventPlus.WebAPI", // Destinatário do token (quem pode usar)
            claims: claims, // Informações do usuário
            expires: DateTime.UtcNow.AddHours(8), // Validade do token (1 hora) // Tempo em que a sessão permanaece ativa, após esse tempo o usuário precisará logar novamente
            signingCredentials: credenciais // Assinatura do token
        );

        // Sétimo passo: Converter o token para string e retornar para o cliente

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new 
        { 
            Token = tokenString, 
            Expiracao = token.ValidTo,
            Usuario = new
            {
                usuarioEncontrado.IdUsuario,
                usuarioEncontrado.Nome,
                usuarioEncontrado.Email
            }
        });
    }
}
