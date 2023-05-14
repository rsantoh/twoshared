using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace twoshared.Infraestructure.DBContext
{
    public class DriverDataAccessGobticProd
    {
        SqlConnection _DigitalGobConnection = new SqlConnection(new twosharedProdContext().Database.Connection.ConnectionString);

        void PDConnOpen()
        {
            if (_DigitalGobConnection.State == ConnectionState.Closed)
            {
                _DigitalGobConnection.Open();
            }
        }

        void PDConnClose()
        {
            if (_DigitalGobConnection.State == ConnectionState.Open)
            {
                _DigitalGobConnection.Close();
            }
        }

        public void EjecutarSp(String nombreProcedimiento, List<Parametros> lstParametros)
        {
            SqlCommand cmd;

            try
            {
                PDConnOpen();
                cmd = new SqlCommand(nombreProcedimiento, _DigitalGobConnection) { CommandType = CommandType.StoredProcedure };
                cmd.CommandTimeout = 360;
                if (lstParametros != null)
                {
                    for (var i = 0; i < lstParametros.Count; i++)
                    {
                        if (lstParametros[i].Direccion == ParameterDirection.Input)
                        {
                            cmd.Parameters.AddWithValue(lstParametros[i].Nombre, lstParametros[i].Valor);
                        }

                        if (lstParametros[i].Direccion == ParameterDirection.Output)
                        {
                            cmd.Parameters.Add(lstParametros[i].Nombre, lstParametros[i].TipoDato, lstParametros[i].Tamanio).Direction = ParameterDirection.Output;
                        }
                    }
                    cmd.ExecuteNonQuery();

                    // recuperar parámetros de salida
                    for (var i = 0; i < lstParametros.Count; i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                        {
                            lstParametros[i].Valor = cmd.Parameters[i].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PDConnClose();
            }
        }

        public DataTable ListadoGenerico(String nombreProcedimiento, List<Parametros> lstParametros)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            try
            {
                PDConnOpen();
                da = new SqlDataAdapter(nombreProcedimiento, _DigitalGobConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (lstParametros != null)
                {
                    for (var i = 0; i < lstParametros.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(lstParametros[i].Nombre, lstParametros[i].Valor);
                    }
                }
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PDConnClose();
            }

            return dt;
        }

       

    }
}
