using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BBC_ComOnline.Models
{
    public class MantenimientoUsuario
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Crear(Usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("INSERT INTO Usuarios(Id, Correo, Clave, Estado, EmpresaRut) VALUES(@Id, @Correo, @Clave, @Estado, @EmpresaRut)", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters.Add("@Correo", SqlDbType.VarChar);
            comando.Parameters.Add("@Clave", SqlDbType.VarChar);
            comando.Parameters.Add("@Estado", SqlDbType.Bit);
            comando.Parameters.Add("@EmpresaRut", SqlDbType.VarChar);
            comando.Parameters["@Id"].Value = usu.Id;
            comando.Parameters["@Correo"].Value = usu.Correo;
            comando.Parameters["@Clave"].Value = usu.Clave;
            comando.Parameters["@Estado"].Value = usu.Estado;
            comando.Parameters["@EmpresaRut"].Value = usu.EmpresaRut;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public List<Usuario> LeerTodo()
        {
            Conectar();
            List<Usuario> Usuarios = new List<Usuario>();

            SqlCommand comando = new SqlCommand("SELECT Correo, Clave, Estado FROM Usuarios WHERE Estado = 'TRUE'", con);
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Usuario usu = new Usuario
                {
                    Correo = registros["Correo"].ToString(),
                    Clave = registros["Clave"].ToString()
                };
                
                Usuarios.Add(usu);
            }
            con.Close();
            return Usuarios;
        }

        public List<Usuario> LeerTodoEmpresa(string empresaRut)
        {
            Conectar();
            List<Usuario> Usuarios = new List<Usuario>();

            SqlCommand comando = new SqlCommand("SELECT Id, Correo, Estado FROM Usuarios WHERE EmpresaRut = @empresaRut", con);
            comando.Parameters.Add("@empresaRut", SqlDbType.VarChar);
            comando.Parameters["@empresaRut"].Value = empresaRut;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Usuario usu = new Usuario
                {
                    Id = Int32.Parse(registros["Id"].ToString()),
                    Correo = registros["Correo"].ToString(),
                    Estado = bool.Parse(registros["Estado"].ToString()),
                };
                Usuarios.Add(usu);
            }
            con.Close();
            return Usuarios;
        }

        public Usuario Leer(string correo)
        {
            Usuario usu = new Usuario();
            Conectar();
            SqlCommand comando = new SqlCommand("SELECT Id, Correo, Clave, Estado From Usuarios WHERE Correo = @correo", con);
            comando.Parameters.Add("@correo", SqlDbType.VarChar);
            comando.Parameters["@correo"].Value = correo;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {
                usu.Id = Int32.Parse(registros["Id"].ToString());
                usu.Correo = registros["Correo"].ToString();
                usu.Clave = registros["Clave"].ToString();
                usu.Estado = bool.Parse(registros["Estado"].ToString());
            }
            con.Close();
            return usu;
        }

        public int Modificar(Usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("UPDATE Usuarios SET Clave = @clave, Estado = @estado WHERE Id = @id OR Correo = @correo", con);
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters.Add("@correo", SqlDbType.VarChar);
            comando.Parameters.Add("@clave", SqlDbType.VarChar);
            comando.Parameters.Add("@estado", SqlDbType.Bit);
            comando.Parameters["@id"].Value = usu.Id;
            comando.Parameters["@correo"].Value = usu.Correo;
            comando.Parameters["@clave"].Value = usu.Clave;
            comando.Parameters["@estado"].Value = usu.Estado;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(Usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("UPDATE SET Estado = FALSE FROM Usuarios WHERE Id = @id OR Correo = @correo", con);
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters.Add("@correo", SqlDbType.VarChar);
            comando.Parameters["@id"].Value = usu.Id;
            comando.Parameters["@correo"].Value = usu.Correo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public bool Login(Usuario usu)
        {
            Usuario usuTemp = new Usuario();
            Debug.WriteLine("CORREO PARAMETRO->"+usu.Correo);
            Debug.WriteLine("CLAVE PARAMETRO->" + usu.Clave);
            Debug.WriteLine("CORREO->" + usuTemp.Correo);
            Debug.WriteLine("CORREO->" + usuTemp.Clave);
            usuTemp = this.Leer(usu.Correo);
            
            if (usu.Clave == usuTemp.Clave && usuTemp.Estado == true)
            {
                Debug.WriteLine("HiFIN");
                return true;
            }
            return false;
        }
    }
}