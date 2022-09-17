using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class PropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario _repoPropietario= new RepositorioPropietario(new Persistencia.AppContext());
        public IEnumerable<Propietario> ListaPropietarios {get; set;}
        [BindProperty(SupportsGet =true)]
        public string FiltroBusqueda{get;set;}
        public void OnGet(string filtroBusqueda)
        {
            if (filtroBusqueda==null)
            {
                ListaPropietarios =  _repoPropietario.GetAllPropietario();
            }
            else
            {
                ListaPropietarios = _repoPropietario.BuscarPropietario(filtroBusqueda);
            }
            //FiltroBusqueda=filtroBusqueda;
            
            //return RedirectToAction("Get");
        }

        public IActionResult OnPost(int Id)
        {
            //Console.WriteLine("Borrando web: "+ Id);
            _repoPropietario.DeletePropietario(Id);
            return RedirectToAction("Get");
        }
    }
}
