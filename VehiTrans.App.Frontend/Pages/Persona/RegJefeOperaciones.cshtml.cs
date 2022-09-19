using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class RegJefeOperacionesModel : PageModel
    {
        private static IRepositorioJefeOperaciones _repoJefeOperaciones= new RepositorioJefeOperaciones(new Persistencia.AppContext());
       
        [BindProperty]
        public JefeOperaciones NewJefeOperaciones { get; set; } = new();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Console.WriteLine("Borrando web: "+ NewJefeOperaciones.TipoEstudioId);
            _repoJefeOperaciones.AddJefeOperaciones(NewJefeOperaciones);
            return Page();
        }
    }
}
