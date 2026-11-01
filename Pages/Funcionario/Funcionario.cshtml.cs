using System.ComponentModel.DataAnnotations;
using csharp_oop_fundamentals.Models;
using csharp_oop_fundamentals.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace csharp_oop_fundamentals.Pages.Funcionario;

public class FuncionariosModel : PageModel
{
    // Armazenamento em memória, só para o estudo (some ao reiniciar a aplicação).
    // Depois troque por AppDbContext/Service.
    private static readonly List<FuncionarioM> _funcionarios = new();
    private static int _proximoId = 1;

    [BindProperty]
    public FuncionarioInput Input { get; set; } = new();

    public IReadOnlyList<FuncionarioM> Funcionarios => _funcionarios;

    public void OnGet() { }

    public IActionResult OnPost()
    {
        // Regras extras que as annotations não cobrem
        if (!string.IsNullOrWhiteSpace(Input.Email) &&
            _funcionarios.Any(f => string.Equals(f.Email, Input.Email, StringComparison.OrdinalIgnoreCase)))
        {
            ModelState.AddModelError("Input.Email", "Já existe um funcionário com este e-mail.");
        }

        if (!ModelState.IsValid)
            return Page(); // reexibe o formulário com os erros

        _funcionarios.Add(new FuncionarioM
        {
            Id = _proximoId++,
            Nome = Input.Nome.Trim(),
            Idade = Input.Idade!.Value,
            Sexo = Input.Sexo,
            Telefone = Input.Telefone,
            Email = Input.Email,
            Endereco = Input.Endereco.Trim(),
            Periodo = Input.Periodo!.Value,
            TipoContrato = Input.TipoContrato!.Value,
            Salario = Input.Salario!.Value
        });

        TempData["Sucesso"] = "Funcionário cadastrado com sucesso!";
        return RedirectToPage(); // evita reenvio do formulário ao apertar F5
    }

    public class FuncionarioInput
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        [Display(Name = "Nome do Funcionário")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A idade é obrigatória.")]
        [Range(16, 100, ErrorMessage = "A idade deve estar entre 16 e 100 anos.")]
        public int? Idade { get; set; }

        [Required(ErrorMessage = "Selecione o sexo.")]
        [RegularExpression("^[MF]$", ErrorMessage = "Sexo inválido.")]
        public string Sexo { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Telefone inválido.")]
        [StringLength(20)]
        public string? Telefone { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(150)]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(200, ErrorMessage = "Máximo de 200 caracteres.")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "Selecione o período.")]
        [Display(Name = "Período")]
        public Periodo? Periodo { get; set; }

        [Required(ErrorMessage = "Selecione o tipo de contrato.")]
        [Display(Name = "Tipo de Contrato")]
        public TipoContrato? TipoContrato { get; set; }

        [Required(ErrorMessage = "O salário é obrigatório.")]
        [Range(0.01, 999999.99, ErrorMessage = "O salário deve ser maior que zero.")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Salário")]
        public decimal? Salario { get; set; }
    }
}