using System.Collections.Generic;
using System.Linq;
using VehiTrans.App.Dominio;

namespace VehiTrans.App.Persistencia
{
    public class RepositorioVehiculoTipo : IRepositorioVehiculoTipo
    {

        ///<summary>
        ///Referencia al contexto de VehiculoTipo
        ///</summary>

        private readonly AppContext _appContext;
        ///<summary>
        ///Metodo Constructos 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        ///</summary>
        ///<param name="appContext"></param>//

        public RepositorioVehiculoTipo(AppContext appContext)
        {
            _appContext = appContext;
        }

        VehiculoTipo IRepositorioVehiculoTipo.AddVehiculoTipo(VehiculoTipo vvehiculoTipo)
        {
            var vvehiculoTipoAdicionado = _appContext.VehiculoTipos.Add(vvehiculoTipo);
            _appContext.SaveChanges();
            return vvehiculoTipoAdicionado.Entity;
        }

        void IRepositorioVehiculoTipo.DeleteVehiculoTipo(int vvehiculoTipoId)
        {

            var vvehiculoTipoEncontrado = _appContext.VehiculoTipos.FirstOrDefault(p => p.VehiculoTipoId == vvehiculoTipoId);
            if (vvehiculoTipoEncontrado == null)
                return;
            _appContext.VehiculoTipos.Remove(vvehiculoTipoEncontrado);
            _appContext.SaveChanges();
        }


        IEnumerable<VehiculoTipo> IRepositorioVehiculoTipo.GetAllVehiculoTipos()
        {
            return _appContext.VehiculoTipos;
        }


        VehiculoTipo IRepositorioVehiculoTipo.GetVehiculoTipo(int vvehiculoTipoId)
        {
            return _appContext.VehiculoTipos.FirstOrDefault(p => p.VehiculoTipoId == vvehiculoTipoId);
        }

        VehiculoTipo IRepositorioVehiculoTipo.UpdateVehiculoTipo(VehiculoTipo vvehiculoTipo)
        {
            var vvehiculoTipoEncontrado = _appContext.VehiculoTipos.FirstOrDefault(p => p.VehiculoTipoId == vvehiculoTipo.VehiculoTipoId);
            if (vvehiculoTipoEncontrado != null)
            {
                vvehiculoTipoEncontrado.Descripcion = vvehiculoTipo.Descripcion;
                
                _appContext.SaveChanges();

            }
            return vvehiculoTipoEncontrado;

        }

    }

}