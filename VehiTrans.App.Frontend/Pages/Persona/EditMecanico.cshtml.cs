using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehiTrans.App.Dominio;
using VehiTrans.App.Persistencia;

namespace VehiTrans.App.Frontend.Pages
{
    public class EditMecanicoModel : PageModel
    {
        private readonly IRepositorioMecanico? repositorioMecanicos;
        [BindProperty]
        public Mecanico? EditMecanico{get;set;}
        public EditMecanicoModel(IRepositorioMecanico repositorioMecanicos)
        {
            this.repositorioMecanicos = repositorioMecanicos;
        }
        public IActionResult OnGet(int? MecanicoId)
        {
            if(MecanicoId.HasValue)
            {
                EditMecanico = repositorioMecanicos.GetMecanico(MecanicoId.Value);
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
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(EditMecanico.MecanicoId>0)
            {
                EditMecanico = repositorioMecanicos.UpdateMecanico(EditMecanico);
            }
            else
            {
                repositorioMecanicos.AddMecanico(EditMecanico);
            }
            return Page();
        }
    }
}

