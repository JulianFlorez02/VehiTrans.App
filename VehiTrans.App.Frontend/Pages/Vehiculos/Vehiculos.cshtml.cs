using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend
{
    public class VehiculosModel : PageModel
    { 
        private static IRepositorioVehiculo _repoVehiculo= new RepositorioVehiculo(new Persistencia.AppContext());
        private static IRepositorioVehiculoTipo _repoVehiculoTipo= new RepositorioVehiculoTipo(new Persistencia.AppContext());
        public IEnumerable<Vehiculo> ListaVehiculos {get; set;}
        public void OnGet()
        {
            ListaVehiculos =  _repoVehiculo.GetAllVehiculos();
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
