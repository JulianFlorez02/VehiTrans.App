using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class RegMecanicoModel : PageModel
    {
        private static IRepositorioMecanico _repoMecanico= new RepositorioMecanico(new Persistencia.AppContext());
        private static IRepositorioTipoEstudio _repoTipoEstudio = new RepositorioTipoEstudio(new Persistencia.AppContext());
        public IEnumerable<TipoEstudio> ListaTipoEstudio {get; set;}

        [BindProperty]
        public Mecanico NewMecanico { get; set; } = new();
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
            Console.WriteLine("Borrando web: "+ NewMecanico.TipoEstudioId);
            //_repoMecanico.AddMecanico(NewMecanico);
            return Page();
        }
    }
}
