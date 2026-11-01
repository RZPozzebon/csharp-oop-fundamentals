namespace csharp_oop_fundamentals.Models;

public class Pessoa
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public int Idade { get; set; }
    public required string Sexo { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string Endereco { get; set; } = "";

}