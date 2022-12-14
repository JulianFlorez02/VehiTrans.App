using System;
using System.ComponentModel.DataAnnotations;
namespace VehiTrans.App.Dominio
{
    public class Conductor
    {
        [Key]
        public int ConductorId { get; set; }
        public string? Documento { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Telefono {get;set;}
        public DateTime? FechaNacimiento {get;set;}
        public string? Usuario { get; set; }
        public string? Contraseña { get; set; }
        public string? Licencia { get; set; }
        public string? Direccion { get; set; }
        public string? TipoEstudio {get;set;}
    }
}