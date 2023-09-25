using Microsoft.AspNetCore.Mvc;
using TesteTecnico.Context;
using TesteTecnico.Models;

namespace TesteTecnico.Controllers;

[Route("[controller]")]
[ApiController]
public class EscolaridadesController : ControllerBase
{
    private readonly AppDbContext _context;

	public EscolaridadesController(AppDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public ActionResult<IEnumerable<Escolaridade>> Todas()
	{
		var escolaridades = _context.Escolaridades.ToList();

		if (escolaridades == null)
			return NotFound("Nenhuma escolaridade cadastrada.");

		return escolaridades;
	}
}
