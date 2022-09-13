using System;
using System.ComponentModel.DataAnnotations;

namespace VehiTrans.App.Dominio
{
    public class Vehiculo
    {
        public int VehiculoId  { get; set; }
        //[MaxLength(7),MinLength(1)]
        [Required]
        public string? Placa { get; set; }
        //[MaxLength(30),MinLength(1)]
        [Required]
        public string? Marca { get; set; }
        //[MaxLength(30),MinLength(1)]
        public string? Modelo { get; set; }
        public int VehiculoTipoId  { get; set; }
        public VehiculoTipo? VehiculoTipo { get; set; }
        [Required]
        public int CantidadPasajeros { get; set; }
        public int CilindrajeMotor { get; set; }
        public int PropietarioId { get; set; }
        public Propietario? Propietario { get; set; }
        public int ConductorId { get; set; }
        public Conductor? Conductor { get; set; }
        public int MecanicoId { get; set; }
        public Mecanico? Mecanico { get; set; }
    }
}