using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace csharp_oop_fundamentals.Pages.Produto
{
    public class ProdutoModel : PageModel
    {
        // Lista temporária na memória (static = sobrevive enquanto o app roda).
        // Depois trocamos por um banco de dados.
        private static readonly List<Models.Produto> _produtos = new()
        {
            new Models.Produto { Id = 1, Nome = "Teclado Mecânico", Valor = 250.00m },
            new Models.Produto { Id = 2, Nome = "Mouse Gamer",      Valor = 150.00m },
        };

        // Campos vindos do formulário (ligados pelos asp-for na view).
        [BindProperty]
        [Required(ErrorMessage = "Nome do Produto é obrigatório.")]
        public string Nome { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Valor do produto é obrigatório.")]
        [Range(0.01, 999999.99, ErrorMessage = "O preço deve ser maior que zero.")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Valor { get; set; }

        // Lista exibida na tabela.
        public List<Models.Produto> Produtos { get; set; } = new();

        public void OnGet()
        {
            Produtos = _produtos;
        }

        public IActionResult OnPost()
        {
            if (Valor == 0)
            {
                ModelState.AddModelError("Valor", "O preço deve ser maior que zero.");
            }
            if (!ModelState.IsValid)
                return Page();

            var novoId = _produtos.Count == 0 ? 1 : _produtos.Max(p => p.Id) + 1;

            _produtos.Add(new Models.Produto
            {
                Id = novoId,
                Nome = Nome,
                Valor = Valor
            });

            // Redireciona pra própria página (padrão POST-Redirect-GET).
            return RedirectToPage();
        }
    }
}
