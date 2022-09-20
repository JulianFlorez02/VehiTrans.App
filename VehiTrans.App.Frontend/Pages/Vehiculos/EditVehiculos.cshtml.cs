using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend
{
    public class EditVehiculosModel : PageModel
    {
         private readonly IRepositorioVehiculo _repoVehiculo= new RepositorioVehiculo(new Persistencia.AppContext());
        private readonly IRepositorioVehiculoTipo _repoVehiculoTipo= new RepositorioVehiculoTipo(new Persistencia.AppContext());
        public IEnumerable<VehiculoTipo>? ListaTipoVehiculo {get;set;}
        private readonly IRepositorioPropietario _repoPropietario= new RepositorioPropietario(new Persistencia.AppContext());
        public IEnumerable<Propietario>? ListaPropietario {get;set;}
        private readonly IRepositorioConductor _repoConductor= new RepositorioConductor(new Persistencia.AppContext());
        public IEnumerable<Conductor>? ListaConductor {get;set;}
        private readonly IRepositorioMecanico _repoMecanico= new RepositorioMecanico(new Persistencia.AppContext());
        public IEnumerable<Mecanico>? ListaMecanico {get;set;}

        [BindProperty]
        public Vehiculo EditVehiculo { get; set; } = new();
        public IActionResult OnGet(int? VehiculoId)
        {
            if(VehiculoId.HasValue)
            {
                EditVehiculo = _repoVehiculo.GetVehiculo(VehiculoId.Value);
                ListaTipoVehiculo = _repoVehiculoTipo.GetAllVehiculoTipos();
                ListaPropietario = _repoPropietario.GetAllPropietario();
                ListaConductor = _repoConductor.GetAllConductores();
                ListaMecanico = _repoMecanico.GetAllMecanicos();
            }
            if(EditVehiculo==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repoVehiculo.UpdateVehiculo(EditVehiculo);
            return RedirectToPage("./Vehiculos");
        }
    }
}
