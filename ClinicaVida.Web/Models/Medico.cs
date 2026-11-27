namespace ClinicaVida.Web.Models;

public class Medico
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Crm { get; set; } = string.Empty;

    public int EspecialidadeId { get; set; }          // a chave: o que filtramos e comparamos
    public Especialidade? Especialidade { get; set; } // o objeto inteiro: o que exibimos
}
