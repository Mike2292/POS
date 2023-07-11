using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BBC_ComOnline.Models
{
    public class MantenimientoArticulo
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Crear(Articulo art)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("INSERT INTO Articulo(Codigo, Descripcion, Precio) VALUES(@Codigo, @Descripcion, @Precio)", con);
            comando.Parameters.Add("@Codigo", SqlDbType.VarChar);
            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            comando.Parameters.Add("@Precio", SqlDbType.Float);
            comando.Parameters["@Codigo"].Value = art.Codigo;
            comando.Parameters["@Descripcion"].Value = art.Descripcion;
            comando.Parameters["@Precio"].Value = art.Precio;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public List<Articulo> LeerTodo()
        {
            Conectar();
            List<Articulo> articulos = new List<Articulo>();

            SqlCommand comando = new SqlCommand("SELECT Codigo, Descripcion, Precio FROM Articulo", con);
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Articulo art = new Articulo
                {
                    Codigo = registros["Codigo"].ToString(),
                    Descripcion = registros["Descripcion"].ToString(),
                    Precio = float.Parse(registros["Precio"].ToString())
                };
                articulos.Add(art);
            }
            con.Close();
            return articulos;
        }

        public Articulo Leer(string codigo)
        {
            Articulo art = new Articulo();
            Conectar();
            SqlCommand comando = new SqlCommand("SELECT Codigo, Descripcion, Precio From Articulo WHERE Codigo = @Codigo", con);
            comando.Parameters.Add("@Codigo", SqlDbType.VarChar);
            comando.Parameters["@Codigo"].Value = codigo;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {
                art.Codigo = registros["Codigo"].ToString();
                art.Descripcion = registros["Descripcion"].ToString();
                art.Precio = float.Parse(registros["Precio"].ToString());
            }
            con.Close();
            return art;
        }

        public int Modificar(Articulo art)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("UPDATE Articulos SET Descripcion=@Descripcion,Precio=@Precio WHERE Codigo=@Codigo", con);
            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            comando.Parameters["@Descripcion"].Value = art.Descripcion;
            comando.Parameters.Add("@Precio", SqlDbType.Float);
            comando.Parameters["@Precio"].Value = art.Precio;
            comando.Parameters.Add("@Codigo", SqlDbType.VarChar);
            comando.Parameters["@Codigo"].Value = art.Codigo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(string codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("DELETE FROM Articulo WHERE Codigo=@Codigo", con);
            comando.Parameters.Add("@Codigo", SqlDbType.VarChar);
            comando.Parameters["@Codigo"].Value = codigo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}