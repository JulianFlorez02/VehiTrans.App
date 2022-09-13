using System.Collections.Generic;
using System.Linq;
using VehiTrans.App.Dominio;

namespace VehiTrans.App.Persistencia
{
    public class RepositorioSeguro : IRepositorioSeguro
    {

        ///<summary>
        ///Referencia al contexto de Seguro
        ///</summary>

        private readonly AppContext _appContext;
        ///<summary>
        ///Metodo Constructos 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        ///</summary>
        ///<param name="appContext"></param>//

        public RepositorioSeguro(AppContext appContext)
        {
            _appContext = appContext;
        }


        Seguro IRepositorioSeguro.AddSeguro(Seguro vseguro)
        {
            var vseguroAdicionado = _appContext.Seguros.Add(vseguro);
            _appContext.SaveChanges();
            return vseguroAdicionado.Entity;
        }

        void IRepositorioSeguro.DeleteSeguro(int vSeguroId)
        {

            var vseguroEncontrado = _appContext.Seguros.FirstOrDefault(p => p.SeguroId == vSeguroId);
            if (vseguroEncontrado == null)
                return;
            _appContext.Seguros.Remove(vseguroEncontrado);
            _appContext.SaveChanges();
        }


        IEnumerable<Seguro> IRepositorioSeguro.GetAllSeguros()
        {
            return _appContext.Seguros;
        }


        Seguro IRepositorioSeguro.GetSeguro(int SeguroId)
        {
            return _appContext.Seguros.FirstOrDefault(p => p.SeguroId == SeguroId);
        }

        Seguro IRepositorioSeguro.UpdateSeguro(Seguro vseguro)
        {
            var vseguroEncontrado = _appContext.Seguros.FirstOrDefault(p => p.SeguroId == vseguro.SeguroId);
            if (vseguroEncontrado != null)
            {
                vseguroEncontrado.CodigoSeguro = vseguro.CodigoSeguro;
                vseguroEncontrado.FechaCompra = vseguro.FechaCompra;
                vseguroEncontrado.FechaVencimiento = vseguro.FechaVencimiento;
                vseguroEncontrado.TipoSeguroId = vseguro.TipoSeguroId;
                vseguroEncontrado.VehiculoId = vseguro.VehiculoId;
                                
                _appContext.SaveChanges();

            }
            return vseguroEncontrado;

        }

    }

}