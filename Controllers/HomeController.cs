using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tp07_Halac_Fridman_Colombet.Models;

namespace Tp07_Halac_Fridman_Colombet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ConfigurarJuego()
    {
        Juegos.InicializarJuego();

        ViewBag.Categorias = Juegos.ObtenerCategorias();
        ViewBag.Dificultades = Juegos.ObtenerDificultades();

        return View("ConfigurarJuego");
    }


    [HttpPost]
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
    bool esCorrecta = Juegos.VerificarRespuesta(idPregunta, idRespuesta);

    var respuestaCorrecta = Juegos.ObtenerProximasRespuestas(int idPregunta);

    ViewBag.EsCorrecta = esCorrecta;
    ViewBag.RespuestaCorrecta = respuestaCorrecta;

    return View("Respuesta");
        
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
