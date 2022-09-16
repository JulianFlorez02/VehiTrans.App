using System.Collections.Generic;
using System.Linq;
using VehiTrans.App.Dominio;

namespace VehiTrans.App.Persistencia
{
    public class RepositorioTipoEstudio : IRepositorioTipoEstudio
    {

        ///<summary>
        ///Referencia al contexto de TipoEstudio
        ///</summary>

        private readonly AppContext _appContext;
        ///<summary>
        ///Metodo Constructos 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        ///</summary>
        ///<param name="appContext"></param>//

        public RepositorioTipoEstudio(AppContext appContext)
        {
            _appContext = appContext;
        }


        TipoEstudio IRepositorioTipoEstudio.AddTipoEstudio(TipoEstudio tipoEstudio)
        {
            var TipoEstudioAdicionado = _appContext.TipoEstudios.Add(tipoEstudio);
            _appContext.SaveChanges();
            return TipoEstudioAdicionado.Entity;
        }

        void IRepositorioTipoEstudio.DeleteTipoEstudio(int tipoEstudioId)
        {

            var TipoEstudioEncontrado = _appContext.TipoEstudios.FirstOrDefault(p => p.TipoEstudioId == tipoEstudioId);
            if (TipoEstudioEncontrado == null)
                return;
            _appContext.TipoEstudios.Remove(TipoEstudioEncontrado);
            _appContext.SaveChanges();
        }


        IEnumerable<TipoEstudio> IRepositorioTipoEstudio.GetAllTipoEstudios()
        {

            return _appContext.TipoEstudios;
        }


        TipoEstudio IRepositorioTipoEstudio.GetTipoEstudio(int TipoEstudioId)
        {
            return _appContext.TipoEstudios.FirstOrDefault(p => p.TipoEstudioId == TipoEstudioId);
        }

        TipoEstudio IRepositorioTipoEstudio.UpdateTipoEstudio(TipoEstudio TipoEstudio)
        {
            var TipoEstudioEncontrado = _appContext.TipoEstudios.FirstOrDefault(p => p.TipoEstudioId == TipoEstudio.TipoEstudioId);
            if (TipoEstudioEncontrado != null)
            {
                TipoEstudioEncontrado.Descripcion = TipoEstudio.Descripcion;
                
                _appContext.SaveChanges();

            }
            return TipoEstudioEncontrado;

        }

    }

}