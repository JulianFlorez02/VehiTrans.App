using System.Collections.Generic;
using System.Linq;
using VehiTrans.App.Dominio;

namespace VehiTrans.App.Persistencia
{
    public class RepositorioTipoSeguro : IRepositorioTipoSeguro
    {

        ///<summary>
        ///Referencia al contexto de TipoSeguro
        ///</summary>

        private readonly AppContext _appContext;
        ///<summary>
        ///Metodo Constructos 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        ///</summary>
        ///<param name="appContext"></param>//

        public RepositorioTipoSeguro(AppContext appContext)
        {
            _appContext = appContext;
        }


        TipoSeguro IRepositorioTipoSeguro.AddTipoSeguro(TipoSeguro tiposeguro)
        {
            var VtiposeguroAdicionado = _appContext.Tiposeguros.Add(tiposeguro);
            _appContext.SaveChanges();
            return VtiposeguroAdicionado.Entity;
        }

        void IRepositorioTipoSeguro.DeleteTipoSeguro(int TipoSeguroId)
        {

            var VtiposeguroEncontrado = _appContext.Tiposeguros.FirstOrDefault(p => p.TipoSeguroId == TipoSeguroId);
            if (VtiposeguroEncontrado == null)
                return;
            _appContext.Tiposeguros.Remove(VtiposeguroEncontrado);
            _appContext.SaveChanges();
        }


        IEnumerable<TipoSeguro> IRepositorioTipoSeguro.GetAllTipoSeguros()
        {

            return _appContext.Tiposeguros;
        }


        TipoSeguro IRepositorioTipoSeguro.GetTipoSeguro(int VTipoSeguroId)
        {
            return _appContext.Tiposeguros.FirstOrDefault(p => p.TipoSeguroId == VTipoSeguroId);
        }

        TipoSeguro IRepositorioTipoSeguro.UpdateTipoSeguro(TipoSeguro Vtiposeguro)
        {
            var VtiposeguroEncontrado = _appContext.Tiposeguros.FirstOrDefault(p => p.TipoSeguroId == Vtiposeguro.TipoSeguroId);
            if (VtiposeguroEncontrado != null)
            {
                VtiposeguroEncontrado.Descripcion = Vtiposeguro.Descripcion;
                
                _appContext.SaveChanges();

            }
            return VtiposeguroEncontrado;

        }

    }

}