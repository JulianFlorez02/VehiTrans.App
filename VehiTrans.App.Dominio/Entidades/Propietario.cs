using System;
using System.ComponentModel.DataAnnotations;
namespace VehiTrans.App.Dominio
{
    public class Propietario
    {
        [Key]
        public int PropietarioId { get; set; }
        public string? Documento { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Telefono {get;set;}
        public DateTime? FechaNacimiento {get;set;}
        public string? Usuario { get; set; }
        public string? Contraseña { get; set; }
        public string? Ciudad { get; set; }
        public string? Correo {get;set;}
    }
}