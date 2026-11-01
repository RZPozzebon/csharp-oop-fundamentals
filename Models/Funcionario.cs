using csharp_oop_fundamentals.Models.Enums;

namespace csharp_oop_fundamentals.Models;

public class Funcionario : Pessoa
{
    public Periodo Periodo { get; set; }
    public TipoContrato TipoContrato { get; set; }
    public decimal Salario { get; set; }
}