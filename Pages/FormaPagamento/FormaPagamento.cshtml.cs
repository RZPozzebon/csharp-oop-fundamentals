using System.ComponentModel.DataAnnotations;
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
            new Models.FormaPagamento { Id = 1, NomeFormaPagamento = "DINHEIRO"},
            new Models.FormaPagamento { Id = 2, NomeFormaPagamento = "BOLETO"},
        };
        [BindProperty]
        [Required(ErrorMessage = "Favor preencher a forma de pagamento.")]
        public required string NomeFormaPagamento { get; set; }

        public List<Models.FormaPagamento> FormaPagamentoList { get; set; } = new();
        public void OnGet()
        {
            FormaPagamentoList = _FormaPagamentos;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page(); // reexibe o formulário com as mensagens de erro

            var novoId = _FormaPagamentos.Count == 0 ? 1 : _FormaPagamentos.Max(p => p.Id) + 1;

            _FormaPagamentos.Add(new Models.FormaPagamento
            {
                Id = novoId,
                NomeFormaPagamento = NomeFormaPagamento.ToUpper()
            });
            return RedirectToPage();
        }
    }
}
