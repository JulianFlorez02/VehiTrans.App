using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend
{
    public class RegVehiculosModel : PageModel
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
        public Vehiculo NewVehiculo { get; set; } = new();
        public IEnumerable<Vehiculo> BuscaVehiculo {get; set;}

        public int existe {get;set;}
        
        public string vvplaca {get;set;}
        public void OnGet()
        {
             ListaTipoVehiculo = _repoVehiculoTipo.GetAllVehiculoTipos();
             ListaPropietario = _repoPropietario.GetAllPropietario();
             ListaConductor = _repoConductor.GetAllConductores();
             ListaMecanico = _repoMecanico.GetAllMecanicos();
             existe=0;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repoVehiculo.AddVehiculo(NewVehiculo);
            return RedirectToPage("./Vehiculos");

            // vvplaca = NewVehiculo.Placa;
            // //vplaca = NewVehiculo.Placa;
            // //vvplaca = "ABC";
            // //Console.WriteLine("Borrando web: "+ vvplaca);

            // BuscaVehiculo = _repoVehiculo.BuscarVehiculo(vvplaca);
            // //BuscaVehiculo = NewVehiculo;
            // if (BuscaVehiculo == null)
            // {
            //     _repoVehiculo.AddVehiculo(NewVehiculo);
            //     return RedirectToPage("./Vehiculos");
            // }
            // else
            // {
            //     existe = 1;
            //     return RedirectToPage("./RegVehiculo");
            // }
            
            
        }
    }
}
