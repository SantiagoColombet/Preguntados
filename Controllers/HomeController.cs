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
        ViewBag.esCorrecta = Juegos.VerificarRespuesta(idPregunta, idRespuesta);
        Pregunta p = Juegos.ObtenerProximaPregunta();
        if (p != null)
        {
            List<Respuestas> r = Juegos.ObtenerProximasRespuestas(p.IdPregunta);
            ViewBag.pregunta = p;
            ViewBag.respuestas = r;
            ViewBag.Categorias = Juegos.Categoria;
            ViewBag.Username = Juegos.username;
            ViewBag.PuntajeActual = Juegos.puntajeActual;
            return View("preguntas");
        }
        return View("final");
    }

    public IActionResult FinJuego()
    {
        BD.IngresarUsuario(Juegos.username, Juegos.puntajeActual);
        List<Usuario> ListaUsuarios = BD.TraerUsuarios();
        ViewBag.usuarios = ListaUsuarios;
        return View("ranking");
    }

    public IActionResult ContinuarJuego()
    {
        return View("Juego");
    }


    public IActionResult respuesta()
    {
        return View();
    }
    public IActionResult Datos()    
    {
        return View();
    }

    public IActionResult RecibirDatos(int dificultad, string nombreUsuario)
    {
        Juegos.username = nombreUsuario;
        Juegos.dificultad = dificultad;
        return View("Juego");
    }

    public IActionResult Comenzar(string nombrecategoria)
    {
        
        int categoria = Ruleta(nombrecategoria);
        Juegos.Categoria = nombrecategoria;

        Juegos.CargarPartida(Juegos.dificultad, categoria);
        Pregunta p = Juegos.ObtenerProximaPregunta();
        List<Respuestas> r = Juegos.ObtenerProximasRespuestas(p.IdPregunta);
        if (Juegos.preguntas != null)
        {
            ViewBag.pregunta = p;
            ViewBag.respuestas = r;
            ViewBag.Categorias = nombrecategoria;
            ViewBag.Username = Juegos.username;
            ViewBag.PuntajeActual = Juegos.puntajeActual;
            return View("preguntas");
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    private int Ruleta(string categoria_)
    {
            int id_;

        switch (categoria_)
        {
            case "Deportes":
                id_ = 1;
                break;
            case "Tecnologia":
                id_ = 2;
                break;
            case "Geografia":
                id_ = 3;
                break;
            case "Cultura":
                id_ = 4;
                break;
            case "Argentina":
                id_ = 5;
                break;
            case "Ciencias":
                id_ = 6;
                break;
            default:
                id_ = -1;
                break;
        }
        return id_;
    }
    public IActionResult Jugar()    
    {
        Pregunta proximaPregunta = Juegos.ObtenerProximaPregunta();

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