

namespace api_locacao.Modelos;

public class Administrador
{
     public int Id { get;set; } = default!;

    public string Nome { get; set; }  = default!;
     
    public string Email { get; set; }  = default!;

    public string Login { get; set; }  = default!;

    public string Senha { get; set; }  = default!;
    
    public string Regra { get; set; }  = default!;
}