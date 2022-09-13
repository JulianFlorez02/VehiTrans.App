using System.Collections.Generic;
using System.Linq;
using VehiTrans.App.Dominio;

namespace VehiTrans.App.Persistencia
{
    public class RepositorioConductor : IRepositorioConductor
    {

        ///<summary>
        ///Referencia al contexto de Conductor
        ///</summary>

        private readonly AppContext _appContext;
        ///<summary>
        ///Metodo Constructos 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        ///</summary>
        ///<param name="appContext"></param>//

        public RepositorioConductor(AppContext appContext)
        {
            _appContext = appContext;
        }


        Conductor IRepositorioConductor.AddConductor(Conductor conductor)
        {
            var ConductorAdicionado = _appContext.Conductores.Add(conductor);
            _appContext.SaveChanges();
            return ConductorAdicionado.Entity;
        }

        void IRepositorioConductor.DeleteConductor(int idConductor)
        {

            var ConductorEncontrado = _appContext.Conductores.FirstOrDefault(p => p.ConductorId == idConductor);
            if (ConductorEncontrado == null)
                return;
            _appContext.Conductores.Remove(ConductorEncontrado);
            _appContext.SaveChanges();
        }


        IEnumerable<Conductor> IRepositorioConductor.GetAllConductores()
        {

            return _appContext.Conductores;
        }


        Conductor IRepositorioConductor.GetConductor(int idConductor)
        {

            return _appContext.Conductores.FirstOrDefault(p => p.ConductorId == idConductor);
        }

        Conductor IRepositorioConductor.UpdateConductor(Conductor conductor)
        {
            var ConductorEncontrado = _appContext.Conductores.FirstOrDefault(p => p.ConductorId == conductor.ConductorId);
            if (ConductorEncontrado != null)
            {
                ConductorEncontrado.Documento = conductor.Documento;
                ConductorEncontrado.Nombre = conductor.Nombre;
                ConductorEncontrado.Apellidos = conductor.Apellidos;
                ConductorEncontrado.Telefono = conductor.Telefono;
                ConductorEncontrado.FechaNacimiento = conductor.FechaNacimiento;
                ConductorEncontrado.Usuario = conductor.Usuario;
                ConductorEncontrado.Contraseña = conductor.Contraseña;
                ConductorEncontrado.Licencia = conductor.Licencia;
                ConductorEncontrado.Direccion = conductor.Direccion;
                ConductorEncontrado.NivelEstudio = conductor.NivelEstudio;

                _appContext.SaveChanges();

            }
            return ConductorEncontrado;

        }

    }

}