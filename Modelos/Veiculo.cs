

namespace api_locacao.Modelos;

public class Veiculo
{
    public int Id {get; set;} = default!;
    public string Nome {get; set;} = default!;
    public string Descricao {get; set;}  = default!;
    public string Marca {get; set;}  = default!;
    public string Modelo {get; set;} = default!;
    public string Ano {get; set;} = default!;
}