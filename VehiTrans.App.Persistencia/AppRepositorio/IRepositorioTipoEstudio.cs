using System.Collections.Generic;
using VehiTrans.App.Dominio;


namespace VehiTrans.App.Persistencia
{

    public interface IRepositorioTipoEstudio
    {

        IEnumerable<TipoEstudio> GetAllTipoEstudios();
        TipoEstudio AddTipoEstudio(TipoEstudio VTipoEstudio);
        TipoEstudio UpdateTipoEstudio(TipoEstudio VTipoEstudio);
        void DeleteTipoEstudio(int TipoEstudioId);
        TipoEstudio GetTipoEstudio(int TipoEstudioId);

    }
}