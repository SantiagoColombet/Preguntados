public class Juegos
{
    static string username {get; set;}
    static int puntajeActual {get; set;}
    static int cantidadPreguntasCorrectas {get; set;}
    static List<Pregunta> preguntas {get; set;}
    static List<Respuestas> respuestas {get; set;}


    public static void InicializarJuego()
    {
        username = "";
        puntajeActual = 0;
        cantidadPreguntasCorrectas = 0;
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
    public static void CargarPartida(string username, int dificultad, int categoria)
    {
        Juegos.preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        Juegos.respuestas = BD.ObtenerRespuestas(preguntas);    
    }

}