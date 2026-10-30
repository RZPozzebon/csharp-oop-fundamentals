using csharp_oop_fundamentals;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace csharp_oop_fundamentals
{
    public class FormaPagamentoModel : PageModel
    {
        private static readonly List<Models.FormaPagamento> _FormaPagamentos = new()
        {
            new Models.FormaPagamento { Id = 1, NomeFormaPagamento = "Dinheiro"},
            new Models.FormaPagamento { Id = 2, NomeFormaPagamento = "Boleto"},
        };
        [BindProperty]
        public required string NomeFormaPagamento { get; set; }

        public List<Models.FormaPagamento> FormaPagamentoList { get; set; } = new();
        public void OnGet()
        {
            FormaPagamentoList = _FormaPagamentos;
        }

        public IActionResult onPost()
        {
            _FormaPagamentos.Add(new Models.FormaPagamento
            {
              NomeFormaPagamento = NomeFormaPagamento   
            });
            return RedirectToPage();
        }
    }
}
