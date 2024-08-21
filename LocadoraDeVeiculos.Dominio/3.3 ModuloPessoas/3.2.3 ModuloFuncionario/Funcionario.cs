using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloPessoas;

public class Funcionario : EntidadeBase
{
    public Funcionario(
        DateTime dataAdimissao,
        string nome, 
        decimal salario)
    {
        DataAdimissao = dataAdimissao;
        Nome = nome;
        Salario = salario;
    }

    public DateTime DataAdimissao { get; set; }
    public string Nome { get; set; }
    public decimal Salario { get; set; }
}
