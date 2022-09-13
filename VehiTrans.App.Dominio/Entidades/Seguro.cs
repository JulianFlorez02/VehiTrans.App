using System;
using System.ComponentModel.DataAnnotations;


namespace VehiTrans.App.Dominio
{
    public class Seguro
    {
        [Key]
        public int SeguroId  { get; set; }
        public string? CodigoSeguro { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int TipoSeguroId  { get; set; }  //* foranea a Tipo Seguro *//
        //[ForeignKey("TipoSeguroId")]
        public TipoSeguro? TipoSeguro { get; set; }
        public int VehiculoId { get; set; }  //* foranea a Vehiculo *//
        //[ForeignKey("VehiculoId")]
        public Vehiculo? Vehiculo { get; set; }

    }
}

