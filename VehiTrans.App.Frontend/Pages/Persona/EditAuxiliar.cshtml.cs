using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class EditAuxiliarModel : PageModel
    {
        private static IRepositorioAuxiliar _repoAuxiliar= new RepositorioAuxiliar(new Persistencia.AppContext());
        [BindProperty]
        public Auxiliar? EditAuxiliar{get;set;}
        public IActionResult OnGet(int? auxiliarId)
        {
            if(auxiliarId.HasValue)
            {
                EditAuxiliar = _repoAuxiliar.GetAuxiliar(auxiliarId.Value);
            }
            else
            {
                EditAuxiliar=new Auxiliar();
            }
            if(EditAuxiliar==null)
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
            // if(EditAuxiliar.AuxiliarId>0)
            // {
            //     EditAuxiliar = _repoAuxiliar.UpdateAuxiliar(EditAuxiliar);
            // }
            // else
            // {
            //     _repoAuxiliar.AddAuxiliar(EditAuxiliar);
            // }
            // return Page();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repoAuxiliar.UpdateAuxiliar(EditAuxiliar);
            return RedirectToAction("Get");
        }
    }
}
