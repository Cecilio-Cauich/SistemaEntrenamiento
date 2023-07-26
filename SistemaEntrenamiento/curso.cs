using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Windows.Forms;
using static SistemaEntrenamiento.cursoDB;

namespace SistemaEntrenamiento
{
    public class cursoDB
    {
        private string cadenaConexion = "Server=LAPTOP-VKDEVLK3\\SQLEXPRESS;Database=sistemaentrenamientoCC;TrustServerCertificate=True;User Id=sa;Password=Welcome1;";


        //Método para obtener la lista de curso en la bdd
        public List<Curso> GetCursos()
        {
            List<Curso> listacursos = new List<Curso>();
            string SqlConsulta = "select curso_id,titulo,descripcion,duracion,nivel from curso;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                
                SqlCommand comando = new SqlCommand(SqlConsulta, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Curso oCurso = new Curso();
                        oCurso.curso_id = reader.GetInt32(0);
                        oCurso.titulo = reader.GetString(1);
                        oCurso.descripcion = reader.GetString(2);
                        oCurso.duracion = reader.GetInt32(3);
                        oCurso.nivel = reader.GetString(4);
                        listacursos.Add(oCurso);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error con el query " + ex);
                }

                return listacursos;
            }


        }
       
        //Método para obtener ID de un curso para realizar la actualización
        public Curso GetCurso(int Id)
        {
            string SqlConsulta = "select curso_id,titulo,descripcion,duracion,nivel from curso where curso_id = @id";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {

                SqlCommand comando = new SqlCommand(SqlConsulta, conexion);
                comando.Parameters.AddWithValue("id", Id);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    reader.Read();     
                    
                    Curso oCurso = new Curso();
                    oCurso.curso_id = reader.GetInt32(0);
                    oCurso.titulo = reader.GetString(1);
                    oCurso.descripcion = reader.GetString(2);
                    oCurso.duracion = reader.GetInt32(3);
                    oCurso.nivel = reader.GetString(4);
                     
                    reader.Close();
                    conexion.Close();
                    return oCurso;

                }
                catch (Exception ex)
                {
                    throw new Exception("Errr " + ex);
                }
            }


        }

        //Método para agregar datos la tabla de programa
        public void AddCurso(string Titulo, string Descripcion, int Duracion, string Nivel)
        {
            string SqlConsulta = "INSERT INTO curso(titulo,descripcion,duracion,nivel) values (@titulo,@descripcion,@duracion,@nivel)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(SqlConsulta, conexion);
                comando.Parameters.AddWithValue("@titulo",Titulo);
                comando.Parameters.AddWithValue("@descripcion", Descripcion);
                comando.Parameters.AddWithValue("@duracion", Duracion);
                comando.Parameters.AddWithValue("@nivel", Nivel);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    conexion.Close();
                }catch(Exception ex) 
                {
                    throw new Exception("Hay un error: "+ex.Message);
                }
            }
        }

        //Método para editar una fila de tabla programa
        public void editarCurso(string Titulo, string Descripcion, int Duracion, string Nivel, int Curso_id)
        {
            string SQLConsulta = "UPDATE CURSO SET titulo = @titulo, descripcion = @descripcion, duracion = @duracion, nivel = @nivel where curso_id =@curso_id";
            
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(SQLConsulta, conexion);
                comando.Parameters.AddWithValue("@curso_id", Curso_id);
                comando.Parameters.AddWithValue("@titulo", Titulo);
                comando.Parameters.AddWithValue("@descripcion", Descripcion);
                comando.Parameters.AddWithValue("@duracion", Duracion);
                comando.Parameters.AddWithValue("@nivel", Nivel);

                try
                {
                    conexion.Open ();
                    comando.ExecuteNonQuery();

                    conexion.Close();

                }catch(Exception ex)
                {
                    throw new Exception("Hay un error "+ex);
                }

            }
        }
       
        //Método para borrar una fila de la base de datos
        public void eliminarCurso(int curso_id)
        {
            string SqlConsulta = "delete from curso where curso_id = @curso_id";

            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(SqlConsulta, conexion);
                comando.Parameters.AddWithValue("@curso_id", curso_id);

                try
                {
                    conexion.Open ();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Elemento eliminado");

                }
                catch(Exception ex)
                {
                    throw new Exception("Hay un error" + ex);
                }
            }
        }
    }
    public class Curso
    {
        public int curso_id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int duracion { get; set; }
        public string nivel { get; set; }

    }

}
