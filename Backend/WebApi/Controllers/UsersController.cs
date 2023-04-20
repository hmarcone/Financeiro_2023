﻿using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UsersController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [AllowAnonymous]
    [Produces("application/json")]
    [HttpPost("/api/AdicionaUsuario")]
    public async Task<IActionResult> AdicionaUsuario([FromBody] Login login)
    {
        if (string.IsNullOrWhiteSpace(login.Email) ||
                        string.IsNullOrWhiteSpace(login.Senha) ||
                        string.IsNullOrWhiteSpace(login.Cpf))
        {
            return Ok("Falta alguns dados");
        }

        var user = new ApplicationUser
        {
            Email = login.Email,
            UserName = login.Email,
            CPF = login.Cpf
        };

        var result = await _userManager.CreateAsync(user, login.Senha);

        if (result.Errors.Any())
        {
            return Ok(result.Errors);
        }

        // Geração de confirmação caso precise 
        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        // retorno do email 
        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

        var respose_Retorn = await _userManager.ConfirmEmailAsync(user, code);

        if (respose_Retorn.Succeeded)
        {
            return Ok("Usuário Adicionado!");
        }
        else
        {
            return Ok("erro ao confirmar cadastro de usuário!");
        }
    }
}
