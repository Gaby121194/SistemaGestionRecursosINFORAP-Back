using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFORAP.API.DTOs
{
    public class ServicioDTO : BaseDTO
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public int? NroContrato { get; set; }
        public string Objetivo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string MotivoBaja { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdCliente { get; set; }
        public int? IdRecursoHumano1 { get; set; }
        public int? IdRecursoHumano2 { get; set; }
        public int? IdMotivoBajaServicio { get; set; }
        public ClienteDTO Cliente { get; set; }
    }
    public class ServicioFilterDTO
    {
        public string Nombre { get; set; }
        public DateTime? FechaInicioFrom { get; set; }
        public DateTime? FechaInicioTo { get; set; }
        public DateTime? FechaFinFrom { get; set; }
        public DateTime? FechaFinTo{ get; set; }

        public ServicioFilterDTO(string name = "", DateTime? fechaInicioFrom = null, DateTime? fechaInicioTo = null, DateTime? fechaFinFrom = null, DateTime? fechaFinTo = null)
        {
            Nombre = name;
            FechaInicioFrom = fechaInicioFrom;
            FechaInicioTo = fechaInicioTo;
            FechaFinFrom = fechaFinFrom;
            FechaFinTo = fechaFinTo;
        }
    }
    public class CantidadRecursosAgrupadosMesDTO
    {
        public int Anio { get; set; }
        public int Mes{ get; set; }
        public int Cantidad{ get; set; }
    } 
    public class CantidadServiciosActivosMesDTO
    {
        public int Anio { get; set; }
        public int Mes{ get; set; }
        public int Cantidad{ get; set; }
    }
    public class ServiciosActivosInactivosDTO
    {
        public decimal Activos { get; set; }
        public decimal Inactivos{ get; set; }
        public int Total { get; set; }
    } 
    public class ServiciosInactivosMotivosDTO
    {
        public decimal FechaCumplida { get; set; }
        public decimal DecisionPropia{ get; set; }
        public decimal DecisionCliente { get; set; }
        public int Total { get; set; }
    }
}
