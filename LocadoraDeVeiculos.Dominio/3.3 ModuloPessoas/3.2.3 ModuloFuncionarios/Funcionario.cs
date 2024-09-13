using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloPessoas;

public class Funcionario : EntidadeBase
{
    public Funcionario(){}
    public Funcionario(
        DateTime dataAdimissao,
        string nome, 
        string email,
        decimal salario,
        int empresaId
)
    {
        DataAdimissao = dataAdimissao;
        Nome = nome;
        Email = email;
        Salario = salario;
        EmpresaId = empresaId;
    }
    public string Nome { get; set; }
    public string Email { get; set; }
    public int UsuarioId { get; set; }
    public decimal Salario { get; set; }
    public DateTime DataAdimissao { get; set; }
}
