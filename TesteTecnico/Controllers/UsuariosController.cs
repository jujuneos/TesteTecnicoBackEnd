using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TesteTecnico.Context;
using TesteTecnico.Models;

namespace TesteTecnico.Controllers;

[Route("[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("AdicionarUsuario")]
    public ActionResult AdicionarUsuario(Usuario usuario)
    {
        var emailValido = new EmailAddressAttribute();

        if (!emailValido.IsValid(usuario.Email))
            return BadRequest("E-mail inválido!");

        var usuarioQuery = _context
            .Usuarios
            .Any(u => u.Email == usuario.Email);

        if (usuarioQuery == true)
            return BadRequest("E-mail já cadastrado.");

        int anoAtual = DateTime.Now.Year;
        int idadeUsuario = anoAtual - usuario.DataNascimento.Year;

        if (idadeUsuario < 15)
            return BadRequest("Usuário deve ter pelo menos 15 anos.");

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        return Ok();
    }

    [HttpPut("{id:int}")]
    public ActionResult AlterarUsuario(int id, Usuario usuario)
    {
        if (id != usuario.IdUsuario)
            return BadRequest("Usuário não encontrado.");

        _context.Entry(usuario).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(usuario);
    }

    [HttpGet]
    public ActionResult<IEnumerable<dynamic>> ListarUsuarios()
    {
        var usuarios = _context.Usuarios.Include(u => u.Escolaridade).ToList();
        
        if (usuarios is null)
            return NotFound("Nenhum usuário cadastrado.");

        List<dynamic> usuariosJson = new List<dynamic>();

        foreach (var usuario in usuarios)
        {
            usuariosJson.Add(new
            {
                idUsuario = usuario.IdUsuario,
                nome = usuario.Nome,
                sobrenome = usuario.Sobrenome,
                email = usuario.Email,
                dataNascimento = usuario.DataNascimento.ToShortDateString(),
                idEscolaridade = usuario.IdEscolaridade,
                escolaridade = usuario.Escolaridade?.NomeEscolaridade
            });
        }

        return usuariosJson;
    }

    [HttpDelete("{id:int}")]
    public ActionResult ExcluirUsuario(int id)
    {
        var usuario = _context
            .Usuarios
            .FirstOrDefault(u => u.IdUsuario == id);

        if (usuario is null)
            return NotFound("Usuário não encontrado.");

        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();

        return Ok(usuario);
    }
}
