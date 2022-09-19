using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class RegPropietarioModel : PageModel
    {
        private static IRepositorioPropietario _repoPropietario= new RepositorioPropietario(new Persistencia.AppContext());
       
        [BindProperty]
        public Propietario NewPropietario { get; set; } = new();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Console.WriteLine("Borrando web: "+ NewPropietario.TipoEstudioId);
            _repoPropietario.AddPropietario(NewPropietario);
            return Page();
        }
    }
}
