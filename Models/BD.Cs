using System.Data.SqlClient;
using Dapper;

public class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=0;Trusted_Connection=True;";
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
                    sql = "SELECT * FROM Preguntas ORDER BY NEWID()";
                }
                else
                {
                    sql = "SELECT * FROM Preguntas WHERE IdCategoria = categoria ORDER BY NEWID()";
                }
            }
            else if (categoria == -1)
            {
                sql = "SELECT * FROM Preguntas WHERE IdDificultad = dificultad ORDER BY NEWID()";
            }
            else
            {
                sql = "SELECT * FROM Preguntas WHERE IdCategoria = categoria AND IdDificultad = dificultad ORDER BY NEWID()";
            }
             _ListadoPreguntas = db.Query<Pregunta>(sql, new {dificultad = dificultad, categoria = categoria}).ToList();
        }
        return _ListadoPreguntas;
    }
    public static List<Respuestas> ObtenerRespuestas(List<Pregunta> ListaPreguntas)
    {
        List<Respuestas> listaRespuesta = new List<Respuestas>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            foreach(Pregunta pregunta in ListaPreguntas)
            {
                string sql = "SELECT * FROM Respuestas WHERE IdPregunta = @pIdPregunta";
                listaRespuesta = db.Query<Respuestas>(sql, new { pIdPregunta = pregunta.IdPregunta }).ToList();
                _ListadoRespuestas.AddRange(listaRespuesta);
            }
        }
        return _ListadoRespuestas;
    }
}