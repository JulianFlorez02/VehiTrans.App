using System;
using System.ComponentModel.DataAnnotations;

namespace VehiTrans.App.Dominio
{
    public class TipoEstudio
    {
        public int TipoEstudioId  { get; set; }
        [MaxLength(30),MinLength(1)]
        public string? Descripcion { get; set; }
        
    }
}