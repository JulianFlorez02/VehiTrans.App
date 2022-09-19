using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class ConductorModel : PageModel
    {
        private readonly IRepositorioConductor _repoConductor= new RepositorioConductor(new Persistencia.AppContext());
        //private static IRepositorioTipoEstudio _repoTipoEstudio = new RepositorioTipoEstudio(new Persistencia.AppContext());
        public IEnumerable<Conductor> ListaConductores {get; set;}
        [BindProperty(SupportsGet =true)]
        public string FiltroBusqueda{get;set;}
        public void OnGet(string filtroBusqueda)
        {
            if (filtroBusqueda==null)
            {
                ListaConductores =  _repoConductor.GetAllConductores();
            }
            else
            {
                ListaConductores = _repoConductor.BuscarConductor(filtroBusqueda);
            }
            //FiltroBusqueda=filtroBusqueda;
            
            //return RedirectToAction("Get");
        }

        // public string TipoEstdudioText(int tipoEstudioId)
        // {
        //     var tipoEstudio = _repoTipoEstudio.GetTipoEstudio(tipoEstudioId);
        //     return tipoEstudio.Descripcion;
        // }

        public IActionResult OnPost(int Id)
        {
            //Console.WriteLine("Borrando web: "+ Id);
            _repoConductor.DeleteConductor(Id);
            return RedirectToAction("Get");
        }
    }
}
