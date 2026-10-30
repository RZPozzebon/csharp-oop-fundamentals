using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace csharp_oop_fundamentals.Pages.Cliente
{
    public class ClienteModel : PageModel
    {
        // Lista temporária na memória (static = sobrevive enquanto o app roda).
        // Depois trocamos por um banco de dados.
        private static readonly List<Models.Cliente> _clientes = new()
        {
            new Models.Cliente { Id = 1, Nome = "Maria Silva", Endereco = "Rua das Flores, 100", Sexo = "F" },
            new Models.Cliente { Id = 2, Nome = "João Souza",  Endereco = "Av. Brasil, 2500",    Sexo = "M" },
        };

        // Campos vindos do formulário (ligados pelos asp-for na view).
        [BindProperty]
        public string Nome { get; set; } = "";

        [BindProperty]
        public string Endereco { get; set; } = "";

        [BindProperty]
        public string Sexo { get; set; } = "";

        // Lista exibida na tabela.
        public List<Models.Cliente> Clientes { get; set; } = new();

        public void OnGet()
        {
            Clientes = _clientes;
        }

        public IActionResult OnPost()
        {
            var novoId = _clientes.Count == 0 ? 1 : _clientes.Max(c => c.Id) + 1;

            _clientes.Add(new Models.Cliente
            {
                Id = novoId,
                Nome = Nome,
                Endereco = Endereco,
                Sexo = Sexo
            });

            // Redireciona pra própria página (padrão POST-Redirect-GET).
            return RedirectToPage();
        }
    }
}
