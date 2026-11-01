using csharp_oop_fundamentals.Models.Enums;

namespace csharp_oop_fundamentals.Models;

public class FuncionarioM : Pessoa
{
    public Periodo Periodo { get; set; }
    public TipoContrato TipoContrato { get; set; }
    public decimal Salario { get; set; }
}