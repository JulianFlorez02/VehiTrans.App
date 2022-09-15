using System.Collections.Generic;
using System.Linq;
using VehiTrans.App.Dominio;

namespace VehiTrans.App.Persistencia
{
    public class RepositorioMecanico : IRepositorioMecanico
    {

        ///<summary>
        ///Referencia al contexto de Mecanico
        ///</summary>

        private readonly AppContext _appContext;
        ///<summary>
        ///Metodo Constructos 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        ///</summary>
        ///<param name="appContext"></param>//

        public RepositorioMecanico(AppContext appContext)
        {
            _appContext = appContext;
        }


        Mecanico IRepositorioMecanico.AddMecanico(Mecanico Mecanico)
        {
            var MecanicoAdicionado = _appContext.Mecanicos.Add(Mecanico);
            _appContext.SaveChanges();
            return MecanicoAdicionado.Entity;
        }

        void IRepositorioMecanico.DeleteMecanico(int idMecanico)
        {

            var MecanicoEncontrado = _appContext.Mecanicos.FirstOrDefault(p => p.MecanicoId == idMecanico);
            if (MecanicoEncontrado == null)
                return;
            _appContext.Mecanicos.Remove(MecanicoEncontrado);
            _appContext.SaveChanges();
        }


        IEnumerable<Mecanico> IRepositorioMecanico.GetAllMecanicos()
        {

            return _appContext.Mecanicos;
        }


        Mecanico IRepositorioMecanico.GetMecanico(int idMecanico)
        {

            return _appContext.Mecanicos.FirstOrDefault(p => p.MecanicoId == idMecanico);
        }

        Mecanico IRepositorioMecanico.UpdateMecanico(Mecanico Mecanico)
        {
            var MecanicoEncontrado = _appContext.Mecanicos.FirstOrDefault(p => p.MecanicoId == Mecanico.MecanicoId);
            if (MecanicoEncontrado != null)
            {
                MecanicoEncontrado.Documento = Mecanico.Documento;
                MecanicoEncontrado.Nombre = Mecanico.Nombre;
                MecanicoEncontrado.Apellidos = Mecanico.Apellidos;
                MecanicoEncontrado.Telefono = Mecanico.Telefono;
                MecanicoEncontrado.FechaNacimiento = Mecanico.FechaNacimiento;
                MecanicoEncontrado.Usuario = Mecanico.Usuario;
                MecanicoEncontrado.Contraseña = Mecanico.Contraseña;
                MecanicoEncontrado.Direccion = Mecanico.Direccion;
                MecanicoEncontrado.NivelEstudio = Mecanico.NivelEstudio;

                _appContext.SaveChanges();

            }
            return MecanicoEncontrado;

        }

        IEnumerable<Mecanico> IRepositorioMecanico.BuscarMecanico(string filtro = null) // la asignación filtro=null indica que el parámetro filtro es opcional
        {
            return _appContext.Mecanicos.Where(m => m.Documento.Contains(filtro) || m.Nombre.Contains(filtro) || m.Apellidos.Contains(filtro));;
        }

    }

}