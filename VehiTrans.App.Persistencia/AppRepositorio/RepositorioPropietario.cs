using System.Collections.Generic;
using System.Linq;
using VehiTrans.App.Dominio;

namespace VehiTrans.App.Persistencia
{
    public class RepositorioPropietario : IRepositorioPropietario
    {

        ///<summary>
        ///Referencia al contexto de Propietario
        ///</summary>

        private readonly AppContext _appContext;
        ///<summary>
        ///Metodo Constructos 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        ///</summary>
        ///<param name="appContext"></param>//

        public RepositorioPropietario(AppContext appContext)
        {
            _appContext = appContext;
        }


        Propietario IRepositorioPropietario.AddPropietario(Propietario propietario)
        {
            var PropietarioAdicionado = _appContext.Propietarios.Add(propietario);
            _appContext.SaveChanges();
            return PropietarioAdicionado.Entity;
        }

        void IRepositorioPropietario.DeletePropietario(int idPropietario)
        {

            var PropietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.PropietarioId == idPropietario);
            if (PropietarioEncontrado == null)
                return;
            _appContext.Propietarios.Remove(PropietarioEncontrado);
            _appContext.SaveChanges();
        }


        IEnumerable<Propietario> IRepositorioPropietario.GetAllPropietario()
        {

            return _appContext.Propietarios;
        }


        Propietario IRepositorioPropietario.GetPropietario(int idPropietario)
        {

            return _appContext.Propietarios.FirstOrDefault(p => p.PropietarioId == idPropietario);
        }

        Propietario IRepositorioPropietario.UpdatePropietario(Propietario propietario)
        {
            var PropietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.PropietarioId == propietario.PropietarioId);
            if (PropietarioEncontrado != null)
            {
                PropietarioEncontrado.Documento = propietario.Documento;
                PropietarioEncontrado.Nombre = propietario.Nombre;
                PropietarioEncontrado.Apellidos = propietario.Apellidos;
                PropietarioEncontrado.Telefono = propietario.Telefono;
                PropietarioEncontrado.FechaNacimiento = propietario.FechaNacimiento;
                PropietarioEncontrado.Usuario = propietario.Usuario;
                PropietarioEncontrado.Contraseña = propietario.Contraseña;
                PropietarioEncontrado.Ciudad = propietario.Ciudad;
                PropietarioEncontrado.Correo = propietario.Correo;

                _appContext.SaveChanges();

            }
            return PropietarioEncontrado;
        }

        IEnumerable<Propietario> IRepositorioPropietario.BuscarPropietario(string filtro = null) // la asignación filtro=null indica que el parámetro filtro es opcional
        {
            return _appContext.Propietarios.Where(m => m.Documento.Contains(filtro) || m.Nombre.Contains(filtro) || m.Apellidos.Contains(filtro));
        }

    }

}