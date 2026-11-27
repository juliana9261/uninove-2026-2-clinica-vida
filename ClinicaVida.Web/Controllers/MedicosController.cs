using ClinicaVida.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVida.Web.Controllers;

public class MedicosController : Controller
{
    // GET /Medicos e /Medicos?especialidadeId=1
    public IActionResult Index(int? especialidadeId)
    {
        var medicos = ClinicaEmMemoria.Medicos.AsEnumerable();

        if (especialidadeId is not null)
        {
            medicos = medicos.Where(m => m.EspecialidadeId == especialidadeId);
        }

        ViewBag.Especialidades = ClinicaEmMemoria.Especialidades;
        ViewBag.EspecialidadeSelecionada = especialidadeId;
        return View(medicos.OrderBy(m => m.Nome).ToList());
    }

    // GET /Medicos/Details/5
    public IActionResult Details(int id)
    {
        var medico = ClinicaEmMemoria.Medicos.FirstOrDefault(m => m.Id == id);
        if (medico is null) return NotFound();

        medico.Especialidade = ClinicaEmMemoria.Especialidades
            .FirstOrDefault(e => e.Id == medico.EspecialidadeId);

        return View(medico);
    }
}
