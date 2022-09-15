using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class EditMecanicoModel : PageModel
    {
        private static IRepositorioMecanico _repoMecanico= new RepositorioMecanico(new Persistencia.AppContext());
        [BindProperty]
        public Mecanico? EditMecanico{get;set;}
        
        public IActionResult OnGet(int? MecanicoId)
        {
            if(MecanicoId.HasValue)
            {
                EditMecanico = _repoMecanico.GetMecanico(MecanicoId.Value);
            }
            else
            {
                EditMecanico=new Mecanico();
            }
            if(EditMecanico==null)
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
            // if(EditMecanico.MecanicoId>0)
            // {
            //     EditMecanico = _repoMecanico.UpdateMecanico(EditMecanico);
            // }
            // else
            // {
            //     _repoMecanico.AddMecanico(EditMecanico);
            // }
            // return Page();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repoMecanico.UpdateMecanico(EditMecanico);
            return Page();
        }
    }
}

