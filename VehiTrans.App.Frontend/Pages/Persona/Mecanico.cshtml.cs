using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class MecanicoModel : PageModel
    {
        private static IRepositorioMecanico _repoMecanico= new RepositorioMecanico(new Persistencia.AppContext());
        public IEnumerable<Mecanico> ListaMecanicos {get; set;}
        public void OnGet()
        {
            ListaMecanicos =  _repoMecanico.GetAllMecanicos();
        }

                       
        public IActionResult OnPostDelete(int Id)
        {
            //Console.WriteLine("Borrando web: "+ Id);
            _repoMecanico.DeleteMecanico(Id);
            return RedirectToAction("Get");
        }
    }
}