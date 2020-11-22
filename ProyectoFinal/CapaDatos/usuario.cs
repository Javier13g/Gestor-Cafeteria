using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaSoporte.Cache;

namespace CapaDatos
{
    public class usuario:Conexion
    {
        public bool Login(string user, string pass)
        {
            using (var con = GetConnection())
            {
                con.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM USUARIOS WHERE NOMBRELOGIN=@USER AND [PASSWORD]=@PASS";
                    comando.Parameters.AddWithValue("@USER", user);
                    comando.Parameters.AddWithValue("@PASS", pass);
                    comando.CommandType = CommandType.Text;
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            UsuarioCache.IdUsuario = reader.GetInt32(0);
                            UsuarioCache.PrimerNombre = reader.GetString(3);
                            UsuarioCache.SegundoNombre = reader.GetString(4);
                            UsuarioCache.Posicion = reader.GetString(6);
                            UsuarioCache.Email = reader.GetString(5);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        //
        
    }
}
