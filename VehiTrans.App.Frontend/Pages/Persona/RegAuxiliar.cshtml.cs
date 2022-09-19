using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class RegAuxiliarModel : PageModel
    {
        private static IRepositorioAuxiliar _repoAuxiliar= new RepositorioAuxiliar(new Persistencia.AppContext());
       
        [BindProperty]
        public Auxiliar NewAuxiliar { get; set; } = new();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Console.WriteLine("Borrando web: "+ NewAuxiliar.TipoEstudioId);
            _repoAuxiliar.AddAuxiliar(NewAuxiliar);
            return Page();
        }
    }
}
