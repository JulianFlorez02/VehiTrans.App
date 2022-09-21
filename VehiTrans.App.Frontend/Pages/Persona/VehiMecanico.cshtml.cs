using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class VehiMecanicoModel : PageModel
    {
        private readonly IRepositorioVehiculo _repoVehiculo= new RepositorioVehiculo(new Persistencia.AppContext());
        private static IRepositorioVehiculoTipo _repoVehiculoTipo= new RepositorioVehiculoTipo(new Persistencia.AppContext());
        private readonly IRepositorioMecanico _repoMecanico= new RepositorioMecanico(new Persistencia.AppContext());
        public IEnumerable<Vehiculo> ListaVehiculos {get; set;}
        public int MecanicoId{get;set;}
        public Mecanico mecanico{get;set;}
        public void OnGet(int MecanicoId)
        {
            ListaVehiculos =  _repoVehiculo.GetVehiculoMecanico(MecanicoId);
            mecanico = _repoMecanico.GetMecanico(MecanicoId);
        
        }

        public string TipoVehiculoText(int vtipovehiculo)
        {
            var vvehiculotipo = _repoVehiculoTipo.GetVehiculoTipo(vtipovehiculo);
            return vvehiculotipo.Descripcion;
        }

               
        public IActionResult OnPostDelete(int Id)
        {
            //Console.WriteLine("Borrando web: "+ Id);
            _repoVehiculo.DeleteVehiculo(Id);
            return RedirectToAction("Get");
        }
    }
}
