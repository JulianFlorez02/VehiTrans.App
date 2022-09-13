using System.Collections.Generic;
using VehiTrans.App.Dominio;


namespace VehiTrans.App.Persistencia
{

    public interface IRepositorioMecanico
    {

        IEnumerable<Mecanico> GetAllMecanicos();
        Mecanico AddMecanico(Mecanico Mecanico);
        Mecanico UpdateMecanico(Mecanico Mecanico);
        void DeleteMecanico(int idMecanico);
        Mecanico GetMecanico(int idMecanico);

    }
}