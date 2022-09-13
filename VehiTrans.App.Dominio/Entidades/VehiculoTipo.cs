using System;
using System.ComponentModel.DataAnnotations;

namespace VehiTrans.App.Dominio
{
    public class VehiculoTipo
    {
        public int VehiculoTipoId  { get; set; }
        [MaxLength(30),MinLength(1)]
        public string? Descripcion { get; set; }
        
    }
}