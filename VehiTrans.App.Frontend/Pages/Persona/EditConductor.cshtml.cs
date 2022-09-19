using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class EditConductorModel : PageModel
    {
        private static IRepositorioConductor _repoConductor= new RepositorioConductor(new Persistencia.AppContext());
        [BindProperty]
        public Conductor? EditConductor{get;set;}
        public IActionResult OnGet(int? ConductorId)
        {
            if(ConductorId.HasValue)
            {
                EditConductor = _repoConductor.GetConductor(ConductorId.Value);
            }
            else
            {
                EditConductor=new Conductor();
            }
            if(EditConductor==null)
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
            // if(EditConductor.ConductorId>0)
            // {
            //     EditConductor = _repoConductor.UpdateConductor(EditConductor);
            // }
            // else
            // {
            //     _repoConductor.AddConductor(EditConductor);
            // }
            // return Page();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repoConductor.UpdateConductor(EditConductor);
            return RedirectToAction("Get");
        }
    }
}
