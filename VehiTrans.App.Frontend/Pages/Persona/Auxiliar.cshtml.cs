using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class AuxiliarModel : PageModel
    {
        private readonly IRepositorioAuxiliar _repoAuxiliar= new RepositorioAuxiliar(new Persistencia.AppContext());
        public IEnumerable<Auxiliar> ListaAuxiliars {get; set;}
        [BindProperty(SupportsGet =true)]
        public string FiltroBusqueda{get;set;}
        public void OnGet(string filtroBusqueda)
        {
            if (filtroBusqueda==null)
            {
                ListaAuxiliars =  _repoAuxiliar.GetAllAuxiliares();
            }
            else
            {
                ListaAuxiliars = _repoAuxiliar.BuscarAuxiliar(filtroBusqueda);
            }
            //FiltroBusqueda=filtroBusqueda;
            
            //return RedirectToAction("Get");
        }

        public IActionResult OnPost(int Id)
        {
            //Console.WriteLine("Borrando web: "+ Id);
            _repoAuxiliar.DeleteAuxiliar(Id);
            return RedirectToAction("Get");
        }
    }
}
