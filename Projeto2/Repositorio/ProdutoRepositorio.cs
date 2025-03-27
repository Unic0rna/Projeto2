using Projeto2.Models;

namespace Projeto2.Repositorio
{
    public class ProdutoRepositorio
    {
        public readonly string _connectionString;

        public ProdutoRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AdicionarProduto(Produto produto)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "INSERT INTO Usuario (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha)";
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@Preco", produto.Preco);
                cmd.ExecuteNonQuery();
            }
        }

        public Produto ObterProduto (string nome)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Produto WHERE Nome == @Nome";
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.ExecuteNonQuery();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Produto
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Descricao = reader.GetString("Descricao"),
                            Preco = reader.GetDecimal("Preco"),
                        };
                    }
                }
                return null;
            }
        }
    }
}
