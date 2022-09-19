using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class EditJefeOperacionesModel : PageModel
    {
        private static IRepositorioJefeOperaciones _repoJefeOperaciones= new RepositorioJefeOperaciones(new Persistencia.AppContext());
        [BindProperty]
        public JefeOperaciones? EditJefeOperaciones{get;set;}
        public IActionResult OnGet(int? JefeOperacionesId)
        {
            if(JefeOperacionesId.HasValue)
            {
                EditJefeOperaciones = _repoJefeOperaciones.GetJefeOperaciones(JefeOperacionesId.Value);
            }
            else
            {
                EditJefeOperaciones=new JefeOperaciones();
            }
            if(EditJefeOperaciones==null)
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
            // if(EditJefeOperaciones.JefeOperacionesId>0)
            // {
            //     EditJefeOperaciones = _repoJefeOperaciones.UpdateJefeOperaciones(EditJefeOperaciones);
            // }
            // else
            // {
            //     _repoJefeOperaciones.AddJefeOperaciones(EditJefeOperaciones);
            // }
            // return Page();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repoJefeOperaciones.UpdateJefeOperaciones(EditJefeOperaciones);
            return RedirectToAction("Get");
        }
    }
}
