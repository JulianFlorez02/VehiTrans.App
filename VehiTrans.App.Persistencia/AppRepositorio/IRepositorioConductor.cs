using System.Collections.Generic;
using VehiTrans.App.Dominio;


namespace VehiTrans.App.Persistencia
{

    public interface IRepositorioConductor
    {

        IEnumerable<Conductor> GetAllConductores();
        Conductor AddConductor(Conductor conductor);
        Conductor UpdateConductor(Conductor conductor);
        void DeleteConductor(int idConductor);
        Conductor GetConductor(int idConductor);

    }
}