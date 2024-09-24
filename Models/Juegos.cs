public class Juegos
{
    static public string username {get; set;}

    static public int puntajeActual {get; set;}

    static public List<Pregunta> preguntas {get; set;}

    static public List<Respuestas> respuestas {get; set;}

    static public string Categoria {get; set;}

    static public int dificultad {get; set;}


    public static void InicializarJuego()
    {
        username = "";
        puntajeActual = 0;
    }
    public static List<Categoria> ObtenerCategorias()
    {
        List<Categoria> ListaC = BD.ObtenerCategorias();
        return ListaC;
    }
    public static List<Dificultades> ObtenerDificultades()
    {
        List<Dificultades> ListaD = BD.ObtenerDificultades();
        return ListaD;
    }
    public static void CargarPartida( int dificultad, int categoria)
    {
        Juegos.preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        Juegos.respuestas = BD.ObtenerRespuestas(preguntas);    
    }
    public static Pregunta ObtenerProximaPregunta()
    {
        Pregunta pregunta = null;
        if(preguntas.Count()>0)
        {
            pregunta = preguntas[0];
        }
        return pregunta;
    }

    public static List<Respuestas> ObtenerProximasRespuestas(int idPregunta)
    {
        List<Respuestas> listaRespuesta = new List<Respuestas>();
        foreach(Respuestas _respuesta in respuestas)
        {
            if(_respuesta.IdPregunta == idPregunta)
            {   
                listaRespuesta.Add(_respuesta);
            }
        }
        return listaRespuesta;
    }
    public static bool VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        bool esCorrecta = false;

        foreach (Respuestas respuesta in Juegos.respuestas)
        {
            if (respuesta.IdRespuesta == idRespuesta)
            {
                if (respuesta.Correcta)
                {
                    esCorrecta = true;
                    Juegos.puntajeActual += 100; 
                }
                break;
            }
        }
        if(preguntas != null)
        {
            preguntas.RemoveAt(0);
        }
        return esCorrecta;
    }
}