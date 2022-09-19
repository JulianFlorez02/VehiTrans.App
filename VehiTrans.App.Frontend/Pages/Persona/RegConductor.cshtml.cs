using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class RegConductorModel : PageModel
    {
        private static IRepositorioConductor _repoConductor= new RepositorioConductor(new Persistencia.AppContext());
       
        [BindProperty]
        public Conductor NewConductor { get; set; } = new();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Console.WriteLine("Borrando web: "+ NewConductor.TipoEstudioId);
            _repoConductor.AddConductor(NewConductor);
            return Page();
        }
    }
}
