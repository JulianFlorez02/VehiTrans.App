using System;
using System.ComponentModel.DataAnnotations;

namespace VehiTrans.App.Dominio
{
    public class VehiculoOpcionales
    {
        public int VehiculoOpcionalesId  { get; set; }
        [MaxLength(30),MinLength(1)]
        public string? PaisOrigen { get; set; }
        public string? AireAcondicionado { get; set; }
        public string? Televisor { get; set; }
        public string? Otros { get; set; }
        public int VehiculoId { get; set; }  //* foranea a Vehiculo *//
        public Vehiculo? Vehiculo { get; set; }
        
    }
}