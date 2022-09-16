using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class MecanicoModel : PageModel
    {
        private readonly IRepositorioMecanico _repoMecanico= new RepositorioMecanico(new Persistencia.AppContext());
        public IEnumerable<Mecanico> ListaMecanicos {get; set;}
        [BindProperty(SupportsGet =true)]
        public string FiltroBusqueda{get;set;}
        public void OnGet(string filtroBusqueda)
        {
            if (filtroBusqueda==null)
            {
                ListaMecanicos =  _repoMecanico.GetAllMecanicos();
            }
            else
            {
                ListaMecanicos = _repoMecanico.BuscarMecanico(filtroBusqueda);
            }
            //FiltroBusqueda=filtroBusqueda;
            
            //return RedirectToAction("Get");
        }

                       
        public IActionResult OnPost(int Id)
        {
            //Console.WriteLine("Borrando web: "+ Id);
            _repoMecanico.DeleteMecanico(Id);
            return RedirectToAction("Get");
        }
    }
}
