using api_locacao.Repositorios.Interface;
using api_locacao.Modelos;
using MySql.Data.MySqlClient;

namespace api_locacao.Repositorios;

public class VeiculoRepositorio : IServico<Veiculo>
{

    public VeiculoRepositorio()
    {
        conexao = Environment.GetEnvironmentVariable("DATABASE_URL_CDF");
        if(conexao is null) conexao = "Server=localhost;Database=apiLocacao;Uid=root;Pwd=root;";
    }
    async Task<List<Veiculo>> IServico<Veiculo>.TodosAsync()
    {
        var listaVeiculos = new List<Veiculo>();
        using(var conn = new MySqlConnection(conexao))
        {
            conn.Open();
            var query = $"select * from veiculos";
            var command = new MySqlCommand(query, conn);
            var dr = await command.ExecuteReaderAsync();
            while(dr.Read())
            {
                listaVeiculos.Add(new Veiculo{
                    Id = Convert.ToInt32(dr["id"]),
                    Nome = dr["nome"].ToString() ?? "",
                    Marca = dr["marca"].ToString() ?? "",
                    Modelo= dr["modelo"].ToString() ?? "",
                    Descricao= dr["descricao"].ToString() ?? "",
                    Ano = dr["ano"].ToString() ?? ""
                });
            }
            conn.Close();
        }

        return listaVeiculos;
    }

    public string? conexao = null;
    async Task IServico<Veiculo>.ApagarAsync(Veiculo veiculo)
    {
        using(var conn = new MySqlConnection(conexao))
        {
            conn.Open();
            var query = $"delete from veiculos where id=@id;";
            var command = new MySqlCommand(query, conn);
            command.Parameters.Add(new MySqlParameter("@id", veiculo.Id));
            await command.ExecuteNonQueryAsync();
            conn.Close();
        }
    }

    async Task<Veiculo> IServico<Veiculo>.AtualizarAsync(Veiculo veiculo)
    {
         using(var conn = new MySqlConnection(conexao))
        {
            conn.Open();
            var query = $"update veiculos set nome=@nome,marca=@marca,modelo=@modelo,descricao=@descricao,ano=@ano where id = @id;";
            var command = new MySqlCommand(query, conn);
            command.Parameters.Add(new MySqlParameter("@id", veiculo.Id));
            command.Parameters.Add(new MySqlParameter("@nome", veiculo.Nome));
            command.Parameters.Add(new MySqlParameter("@telefone", veiculo.Marca));
            command.Parameters.Add(new MySqlParameter("@email", veiculo.Modelo));
            command.Parameters.Add(new MySqlParameter("@descricao", veiculo.Descricao));
            command.Parameters.Add(new MySqlParameter("@ano", veiculo.Ano));
            await command.ExecuteNonQueryAsync();
            conn.Close();
        }

        return veiculo;
    }

   async Task IServico<Veiculo>.IncluirAsync(Veiculo veiculo)
    {
        using(var conn = new MySqlConnection(conexao))
        {
            conn.Open();
            var query = $"insert into veiculos(nome,marca,modelo,descricao,ano) values(@nome,@marca,@modelo,@descricao,@ano);";
            var command = new MySqlCommand(query, conn);
            command.Parameters.Add(new MySqlParameter("@nome", veiculo.Nome));
            command.Parameters.Add(new MySqlParameter("@marca", veiculo.Marca));
            command.Parameters.Add(new MySqlParameter("@modelo", veiculo.Modelo));
            command.Parameters.Add(new MySqlParameter("@descricao", veiculo.Descricao));
            command.Parameters.Add(new MySqlParameter("@ano", veiculo.Ano));
            await command.ExecuteNonQueryAsync();
            conn.Close();
        }
    }

}