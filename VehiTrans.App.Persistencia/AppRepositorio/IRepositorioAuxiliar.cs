using System.Collections.Generic;
using VehiTrans.App.Dominio;


namespace VehiTrans.App.Persistencia
{

    public interface IRepositorioAuxiliar
    {

        IEnumerable<Auxiliar> GetAllAuxiliares();
        Auxiliar AddAuxiliar(Auxiliar auxiliar);
        Auxiliar UpdateAuxiliar(Auxiliar auxiliar);
        void DeleteAuxiliar(int idAuxiliar);
        Auxiliar GetAuxiliar(int idAuxiliar);

    }
}