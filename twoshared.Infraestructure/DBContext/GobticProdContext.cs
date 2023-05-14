using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace twoshared.Infraestructure.DBContext
{
    public class twosharedProdContext : DbContext
    {
        public twosharedProdContext() : base("connection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<twosharedProdContext>());
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 3600;
        }
    }
    public class Parametros
    {
        public String Nombre { get; set; }
        public Object Valor { get; set; }
        public SqlDbType TipoDato { get; set; }
        public Int32 Tamanio { get; set; }
        public ParameterDirection Direccion { get; set; }


        // Constructor

        // C.Entrada
        public Parametros(String objNombre, Object objValor)
        {
            Nombre = objNombre;
            Valor = objValor;
            Direccion = ParameterDirection.Input;
        }

        //C.Salida
        public Parametros(String objNombre, SqlDbType objTipoDato, Int32 objTamanio)
        {
            Nombre = objNombre;
            TipoDato = objTipoDato;
            Tamanio = objTamanio;
            Direccion = ParameterDirection.Output;
        }
    }
}
