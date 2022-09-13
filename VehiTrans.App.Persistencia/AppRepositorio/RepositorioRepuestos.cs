using System.Collections.Generic;
using System.Linq;
using VehiTrans.App.Dominio;

namespace VehiTrans.App.Persistencia
{
    public class RepositorioRepuestos : IRepositorioRepuestos
    {

        ///<summary>
        ///Referencia al contexto de 
        ///</summary>

        private readonly AppContext _appContext;
        ///<summary>
        ///Metodo Constructos 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        ///</summary>
        ///<param name="appContext"></param>//

        public RepositorioRepuestos(AppContext appContext)
        {
            _appContext = appContext;
        }


        // Repuestos IRepositorioRepuestos.AddRepuestos(Repuestos repuestos)
        // {
        //     var repuestosAdicionado = _appContext.Repuestos.Add(repuestos);
        //     _appContext.SaveChanges();
        //     return repuestosAdicionado.Entity;
        // }

        void IRepositorioRepuestos.DeleteRepuestos(int IdRepuestos)
        {

            var repuestosEncontrado = _appContext.Repuestos.FirstOrDefault(p => p.RepuestosId == IdRepuestos);
            if (repuestosEncontrado == null)
                return;
            _appContext.Repuestos.Remove(repuestosEncontrado);
            _appContext.SaveChanges();
        }


        IEnumerable<Repuestos> IRepositorioRepuestos.GetAllRepuestos()
        {
            return _appContext.Repuestos;
        }


        /*Repuestos IRepositorioRepuestos.GetRepuestos(int IdRepuestos)
        {
            return _appContext.Repuestos.FirstOrDefault(p => p.RepuestosId == IdRepuestos);
        }*/

        // Repuestos IRepositorioRepuestos.UpdateRepuestos(Repuestos repuestos)
        // {
        //     var repuestosEncontrado = _appContext.Repuestos.FirstOrDefault(p => p.RepuestosId == repuestos.RepuestosId);
        //     if (repuestosEncontrado != null)
        //     {
        //         repuestosEncontrado.IdCompraRepuestos = repuestos.IdCompraRepuestos;
        //         repuestosEncontrado.RepuestosIdRepuestos = repuestos.RepuestosIdRepuestos;
        //         repuestosEncontrado.RepuestosNombre = repuestos.Nombre;
        //         repuestosEncontrado.Repuestoscosto = repuestos.costo;
        //         repuestosEncontrado.RevisionIdRevision= repuestos.RevisionIdRevision;
        //         repuestosEncontrado.RepuestosTexto = repuestos.RepuestosTexto;
        //         repuestosEncontrado.RepuestosFechaCompra = Repuestos.RepuestosFechacompra;
        //         repuestosEncontrado.RepuestosFechaCambio = Repuestos.RepuestosFechacambio;
        //         repuestosEncontrado.RepuestosPlacaVehiculo = Repuestos.RepuestosPlacaVehiculo;
                                
        //         _appContext.SaveChanges();

        //     }
        //     return repuestosEncontrado;

        // }

    }

}