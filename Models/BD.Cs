using System.Data.SqlClient;
using Dapper;

public class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=PreguntadORT;Trusted_Connection=True;";
    private static List<Categoria> _ListadoCategorias = new List<Categoria>();
    private static List<Dificultades> _ListadoDificultades = new List<Dificultades>();
    private static List<Pregunta> _ListadoPreguntas = new List<Pregunta>();
    private static List<Respuestas> _ListadoRespuestas = new List<Respuestas>();
    public static List<Categoria> ObtenerCategorias()
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Categorias";
            _ListadoCategorias = db.Query<Categoria>(sql).ToList();
        }
        return _ListadoCategorias;
    }
    public static List<Dificultades> ObtenerDificultades()
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Dificultades";
            _ListadoDificultades = db.Query<Dificultades>(sql).ToList();
        }
        return _ListadoDificultades;
    }
    public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria)
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "";
            if(dificultad == -1)
            {
                if(categoria == -1)
                {
                    sql = "SELECT * FROM Preguntas";
                }
                else
                {
                    sql = "SELECT * FROM Preguntas WHERE IdCategoria = categoria";
                }
            }
            else if (categoria == -1)
            {
                sql = "SELECT * FROM Preguntas WHERE IdDificultad = dificultad";
            }
            else
            {
                sql = "SELECT * FROM Preguntas WHERE IdCategoria = categoria and IdDificultad = dificultad";
            }
             _ListadoPreguntas = db.Query<Pregunta>(sql, new {dificultad = dificultad, categoria = categoria}).ToList();
        }
        return _ListadoPreguntas;
    }


    // Esto revisemoslo todo el grupo juntos, porque si bien esta en la receta, cionviene hacerlo de otra forma
    public static List<Respuestas> ObtenerRespuestas(List<Pregunta> preguntas)
    {
        //Mal
        // Preguntas es una lista.. lo estas queriendo llevar 
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Respuestas INNER JOIN Preguntas on Respuestas.IdPregunta = Preguntas.IdPregunta WHERE Preguntas.Enunciado = preguntas";
            _ListadoRespuestas = db.Query<Respuestas>(sql, new {preguntas = preguntas}).ToList();
        }
        return _ListadoRespuestas;    
    }
}