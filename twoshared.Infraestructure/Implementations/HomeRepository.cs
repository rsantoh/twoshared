using twoshared.Core.Interfaces;
using twoshared.Core.Models;
using twoshared.Infraestructure.DBContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twoshared.Infraestructure.Implementations
{
    public class HomeRepository : IHomeRepository
    {
        DriverDataAccessGobticProd driverDB = new DriverDataAccessGobticProd();
        twosharedProdContext context = new twosharedProdContext();

        public List<Products> Get_Products()
        {
            return context.Database.SqlQuery<Products>("spProducts_Select"
            ).ToList();
        }

        public string Insert_Shopping_Item_Post(int idProduct, int idCustomer)
        {
            string respuesta;
            List<Parametros> lstParametros = new List<Parametros>();
            try
            {
                // Agregar los parámetros de entrada
                lstParametros.Add(new Parametros("@IdProduct", idProduct));
                lstParametros.Add(new Parametros("@IdCustomer", idCustomer));               
                // Agregar parámetro de salida
                lstParametros.Add(new Parametros("@ResultOUTPUT", SqlDbType.Int, 1));
                driverDB.EjecutarSp("spProducts_Shopping_insert", lstParametros);
                respuesta = lstParametros[2].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public List<ItemsCart> Get_Products_Customer(int idCustomer)
        {
            return context.Database.SqlQuery<ItemsCart>("spProducts_Customer_Select @IdCustomer",
                    new SqlParameter("@IdCustomer", idCustomer)
            ).ToList();
        }

        public string Shopping_Item_Delete(int id)
        {
            string respuesta;
            List<Parametros> lstParametros = new List<Parametros>();
            try
            {
                // Agregar los parámetros de entrada
                lstParametros.Add(new Parametros("@idShoppinCart", id));
                // Agregar parámetro de salida
                lstParametros.Add(new Parametros("@ResultOUTPUT", SqlDbType.Int, 1));
                driverDB.EjecutarSp("spProducts_Shopping_Delete", lstParametros);
                respuesta = lstParametros[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }


        public string Shopping_Item_tag_insert(int id, string name)
        {
            string respuesta;
            List<Parametros> lstParametros = new List<Parametros>();
            try
            {
                // Agregar los parámetros de entrada
                lstParametros.Add(new Parametros("@idShoppinCart", id));
                lstParametros.Add(new Parametros("@Name", name));
                // Agregar parámetro de salida
                lstParametros.Add(new Parametros("@ResultOUTPUT", SqlDbType.Int, 1));
                driverDB.EjecutarSp("spMyItem_Tag_Insert", lstParametros);
                respuesta = lstParametros[2].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public List<Tags> Get_Tags_Item(int item)
        {
            return context.Database.SqlQuery<Tags>("spMyItem_Tag_Select @IdItem",
                    new SqlParameter("@IdItem", item)
            ).ToList();
        }

        public string Shopping_Item_tag_delete(int id)
        {
            string respuesta;
            List<Parametros> lstParametros = new List<Parametros>();
            try
            {
                // Agregar los parámetros de entrada
                lstParametros.Add(new Parametros("@item", id));         
                // Agregar parámetro de salida
                lstParametros.Add(new Parametros("@ResultOUTPUT", SqlDbType.Int, 1));
                driverDB.EjecutarSp("spMyItem_Tag_DELETE", lstParametros);
                respuesta = lstParametros[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }
    }
}
