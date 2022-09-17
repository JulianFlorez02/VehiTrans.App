using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class JefeOperacionesModel : PageModel
    {
        private readonly IRepositorioJefeOperaciones _repoJefeOperaciones= new RepositorioJefeOperaciones(new Persistencia.AppContext());
        public IEnumerable<JefeOperaciones> ListaJefeOperaciones {get; set;}
        [BindProperty(SupportsGet =true)]
        public string FiltroBusqueda{get;set;}
        public void OnGet(string filtroBusqueda)
        {
            if (filtroBusqueda==null)
            {
                ListaJefeOperaciones =  _repoJefeOperaciones.GetAllJefeOperaciones();
            }
            else
            {
                ListaJefeOperaciones = _repoJefeOperaciones.BuscarJefeOperaciones(filtroBusqueda);
            }
            //FiltroBusqueda=filtroBusqueda;
            
            //return RedirectToAction("Get");
        }

        public IActionResult OnPost(int Id)
        {
            //Console.WriteLine("Borrando web: "+ Id);
            _repoJefeOperaciones.DeleteJefeOperaciones(Id);
            return RedirectToAction("Get");
        }
    }
}
