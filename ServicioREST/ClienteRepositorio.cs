using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioREST
{
    public class ClienteRepositorio
    {
        private SqlConnection cn = new SqlConnection("Data Source=EQ-ESTUDIANTE\\SQL2012;Initial Catalog=Empresa;Integrated Security=True");

        public bool Registrar(ClienteEntidad entidad)
        {
            bool estado = false;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_Tb_Cliente_Registrar", cn);
                cmd.Parameters.Add(new SqlParameter("@Nom_Cliente", SqlDbType.VarChar, 100)).Value = entidad.Nom_Cliente;
                cmd.Parameters.Add(new SqlParameter("@Ape_Cliente", SqlDbType.VarChar, 100)).Value = entidad.Ape_Cliente;
                cmd.Parameters.Add(new SqlParameter("@Dir_Cliente", SqlDbType.VarChar, 100)).Value = entidad.Dir_Cliente;
                cmd.Parameters.Add(new SqlParameter("@Tel_Cliente", SqlDbType.VarChar, 15)).Value = entidad.Tel_Cliente;
                cmd.Parameters.Add(new SqlParameter("@Sexo", SqlDbType.Char, 1)).Value = entidad.Sexo;
                cmd.Parameters.Add(new SqlParameter("@Edad", SqlDbType.SmallInt)).Value = entidad.Edad;
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100)).Value = entidad.Email;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    estado = true;
                }
                return estado;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }
        }
        public bool Modificar(ClienteEntidad entidad)
        {
            bool estado = false;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_Tb_Cliente_Modificar", cn);
                cmd.Parameters.Add(new SqlParameter("@Cod_Cliente", SqlDbType.Int)).Value = entidad.Cod_Cliente;
                cmd.Parameters.Add(new SqlParameter("@Nom_Cliente", SqlDbType.VarChar, 100)).Value = entidad.Nom_Cliente;
                cmd.Parameters.Add(new SqlParameter("@Ape_Cliente", SqlDbType.VarChar, 100)).Value = entidad.Ape_Cliente;
                cmd.Parameters.Add(new SqlParameter("@Dir_Cliente", SqlDbType.VarChar, 100)).Value = entidad.Dir_Cliente;
                cmd.Parameters.Add(new SqlParameter("@Tel_Cliente", SqlDbType.VarChar, 15)).Value = entidad.Tel_Cliente;
                cmd.Parameters.Add(new SqlParameter("@Sexo", SqlDbType.Char, 1)).Value = entidad.Sexo;
                cmd.Parameters.Add(new SqlParameter("@Edad", SqlDbType.SmallInt)).Value = entidad.Edad;
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100)).Value = entidad.Email;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    estado = true;
                }
                return estado;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }
        }
        public bool Eliminar(int Cod_Cliente)
        {
            bool estado = false;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_Tb_Cliente_Eliminar", cn);
                cmd.Parameters.Add(new SqlParameter("@Cod_Cliente", SqlDbType.Int)).Value = Cod_Cliente;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    estado = true;
                }
                return estado;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }
        }
        public ClienteEntidad ObtenerbyId(int Codigo)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_Tb_Cliente_ObtenerbyId", cn);
                cmd.Parameters.Add(new SqlParameter("@Cod_Cliente", SqlDbType.Int)).Value = Codigo;
                cmd.CommandType = CommandType.StoredProcedure;
                ClienteEntidad oClienteEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oClienteEntidad = new ClienteEntidad();
                        oClienteEntidad.Cod_Cliente = reader.GetInt32(reader.GetOrdinal("Cod_Cliente"));
                        oClienteEntidad.Nom_Cliente = reader.GetString(reader.GetOrdinal("Nom_Cliente"));
                        oClienteEntidad.Ape_Cliente = reader.GetString(reader.GetOrdinal("Ape_Cliente"));
                        oClienteEntidad.Dir_Cliente = reader.GetString(reader.GetOrdinal("Dir_Cliente"));
                        oClienteEntidad.Tel_Cliente = reader.GetString(reader.GetOrdinal("Tel_Cliente"));
                        oClienteEntidad.Sexo = reader.GetString(reader.GetOrdinal("Sexo"));
                        oClienteEntidad.Edad = reader.GetInt16(reader.GetOrdinal("Edad"));
                        oClienteEntidad.Email = reader.GetString(reader.GetOrdinal("Email"));
                    }
                }
                return oClienteEntidad;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}