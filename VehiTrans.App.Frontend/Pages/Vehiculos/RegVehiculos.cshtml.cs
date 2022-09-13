using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend
{
    public class RegVehiculosModel : PageModel
    {
        private static IRepositorioVehiculo _repoVehiculo= new RepositorioVehiculo(new Persistencia.AppContext());

        [BindProperty]
        public Vehiculo NewVehiculo { get; set; } = new();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repoVehiculo.AddVehiculo(NewVehiculo);
            return Page();
        }
    }
}
