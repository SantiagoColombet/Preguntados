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

    public void ConfigurarJuego()
    {
        Juegos.InicializarJuego();

        ViewBag.Categorias = Juegos.ObtenerCategorias();
        ViewBag.Dificultades = Juegos.ObtenerDificultades();
    }


    [HttpPost]
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        ViewBag.respuestaCorrecta = Juegos.ObtenerProximasRespuestas(idPregunta);
        ViewBag.esCorrecta = Juegos.VerificarRespuesta(idPregunta, idRespuesta);

        return View("Respuesta");
            
    }



    public IActionResult Comenzar(string username, int dificultad, int categoria = -1 )
    {
        Juegos.CargarPartida(username, dificultad, -1);

        if (Juegos.preguntas != null && categoria == -1)
        {
            return RedirectToAction("Jugar");
        }
        else
        {
            return RedirectToAction("ConfigurarJuego");
        }
    }

    public IActionResult Ruleta(string categoria_)
    {
            int id_ = 0;

        switch (categoria_)
        {
            case "Tecnologia":
                id_ = 1;
                break;
            case "Geografia":
                id_ = 2;
                break;
            case "Argentina":
                id_ = 3;
                break;
            case "Cultura General":
                id_ = 4;
                break;
            case "Deportes":
                id_ = 5;
                break;
            case "Ciencias":
                id_ = 6;
                break;
            default:
                id_ = -1;
                break;
        }
        ViewBag.id = id_;
        return View("Index");
    }
    public IActionResult Dificultad (int dificultad_)
    {
        ViewBag.dificultad = dificultad_;
        return View("Index");
    }

    public IActionResult Jugar()    
    {
        Pregunta proximaPregunta = Juegos.ObtenerProximaPregunta();

        return View("Juego");
        if (proximaPregunta == null)
        {
            return View("Fin");
        }
        else
        {
            ViewBag.PreguntaActual = proximaPregunta;
            ViewBag.RespuestasActuales = Juegos.ObtenerProximasRespuestas(proximaPregunta.IdPregunta);

            return View("Juego");
        }
        
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