using System.Collections.Generic;
using VehiTrans.App.Dominio;


namespace VehiTrans.App.Persistencia
{

    public interface IRepositorioVehiculoTipo
    {

        IEnumerable<VehiculoTipo> GetAllVehiculoTipos();
        VehiculoTipo AddVehiculoTipo(VehiculoTipo vvehiculoTipo);
        VehiculoTipo UpdateVehiculoTipo(VehiculoTipo vvehiculoTipo);
        void DeleteVehiculoTipo(int vvehiculoTipoId);
        VehiculoTipo GetVehiculoTipo(int vvehiculoTipoId);

    }
}