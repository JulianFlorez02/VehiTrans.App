using System.Collections.Generic;
using VehiTrans.App.Dominio;


namespace VehiTrans.App.Persistencia
{

    public interface IRepositorioPropietario
    {

        IEnumerable<Propietario> GetAllPropietario();
        Propietario AddPropietario(Propietario Propietario);
        Propietario UpdatePropietario(Propietario Propietario);
        void DeletePropietario(int idPropietario);
        Propietario GetPropietario(int idPropietario);

    }
}