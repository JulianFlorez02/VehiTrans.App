using System;
using System.ComponentModel.DataAnnotations;

namespace VehiTrans.App.Dominio
{
    public class TipoSeguro
    {
        [Key]
        public int TipoSeguroId  { get; set; }
        [MaxLength(30),MinLength(1)]
        public string? Descripcion { get; set; }
    }
}