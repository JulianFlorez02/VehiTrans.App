using System.Collections.Generic;
using VehiTrans.App.Dominio;


namespace VehiTrans.App.Persistencia
{

    public interface IRepositorioSeguro
    {

        IEnumerable<Seguro> GetAllSeguros();
        Seguro AddSeguro(Seguro VSeguro);
        Seguro UpdateSeguro(Seguro VSeguro);
        void DeleteSeguro(int SeguroId);
        Seguro GetSeguro(int SeguroId);

    }
}