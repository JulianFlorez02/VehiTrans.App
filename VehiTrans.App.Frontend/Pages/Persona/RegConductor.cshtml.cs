using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class RegConductorModel : PageModel
    {
        private static IRepositorioConductor _repoConductor= new RepositorioConductor(new Persistencia.AppContext());
        private static IRepositorioTipoEstudio _repoTipoEstudio = new RepositorioTipoEstudio(new Persistencia.AppContext());
        public IEnumerable<TipoEstudio>? ListaTipoEstudio {get;set;}
        [BindProperty]
        public Conductor NewConductor { get; set; } = new();
        public void OnGet()
        {
            ListaTipoEstudio = _repoTipoEstudio.GetAllTipoEstudios();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Console.WriteLine("Borrando web: "+ NewConductor.TipoEstudioId);
            _repoConductor.AddConductor(NewConductor);
            return RedirectToPage("/Persona/Conductor");
        }
    }
}
