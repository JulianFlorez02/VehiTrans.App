using System.Collections.Generic;
using VehiTrans.App.Dominio;


namespace VehiTrans.App.Persistencia
{

    public interface IRepositorioComprarRepuestos
    {

        IEnumerable<CompraRepuestos> GetAllComprarRepuestos();
        CompraRepuestos AddComprarRepuestos(CompraRepuestos ComprarRepuestos);
        CompraRepuestos UpdateComprarRepuestos(CompraRepuestos ComprarRepuestos);
        void DeleteComprarRepuestos(int ComprarRepuestosId);
        CompraRepuestos GetComprarRepuestos(int ComprarRepuestosId);

    }
}