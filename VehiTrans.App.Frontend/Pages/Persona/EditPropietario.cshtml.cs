using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class EditPropietarioModel : PageModel
    {
        private static IRepositorioPropietario _repoPropietario= new RepositorioPropietario(new Persistencia.AppContext());
        [BindProperty]
        public Propietario? EditPropietario{get;set;}
        public IActionResult OnGet(int? PropietarioId)
        {
            if(PropietarioId.HasValue)
            {
                EditPropietario = _repoPropietario.GetPropietario(PropietarioId.Value);
            }
            else
            {
                EditPropietario=new Propietario();
            }
            if(EditPropietario==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }

        public IActionResult OnPost()
        {
            // if(!ModelState.IsValid)
            // {
            //     return Page();
            // }
            // if(EditPropietario.PropietarioId>0)
            // {
            //     EditPropietario = _repoPropietario.UpdatePropietario(EditPropietario);
            // }
            // else
            // {
            //     _repoPropietario.AddPropietario(EditPropietario);
            // }
            // return Page();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repoPropietario.UpdatePropietario(EditPropietario);
            return RedirectToAction("Get");
        }
    }
}
