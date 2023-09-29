using MySql.Data.MySqlClient;

namespace Pokedex.API.Data
{

    public class DatabaseConnector
    {
        MySqlConnection Conexao;

        public DatabaseConnector() {

            string data_source = "datasource=localhost;username=root;password=;database=pokedex";

            Conexao = new MySqlConnection(data_source);
        }

        public void Create(Pokemon pokemon)
        {
            string sql =
                "INSERT INTO pokemon (id, name, description, type) " +
                "VALUES (" + pokemon.Id + ", '" + pokemon.Name + "' , '" + pokemon.Description + "', '" + pokemon.Type + "')";

            MySqlCommand comando = new MySqlCommand(sql, Conexao);

            Conexao.Open();

            comando.ExecuteReader();

            Conexao.Close();
        }

        public List<Pokemon> Read()
        {
            string sql = "select * from pokemon";

            List<Pokemon> list = new List<Pokemon>();

            MySqlCommand comando = new MySqlCommand(sql, Conexao);

            Conexao.Open();

            var dataReader = comando.ExecuteReader();

            while (dataReader.Read())
            {
                Pokemon pokemon = new Pokemon();
                pokemon.Id = dataReader.GetInt32(0);
                pokemon.Name = dataReader.GetString(1);
                pokemon.Description = dataReader.GetString(2);
                pokemon.Type = dataReader.GetString(3);

                list.Add(pokemon);
            }

            Conexao.Close();

            return list;
        }

        public Pokemon Read(int Id)
        {
            string sql = "select * from pokemon where id= "+ Id;

            MySqlCommand comando = new MySqlCommand(sql, Conexao);

            Conexao.Open();

            var dataReader = comando.ExecuteReader();

            Pokemon pokemon = new Pokemon();

            if (dataReader.Read())
            {
                pokemon.Id = dataReader.GetInt32(0);
                pokemon.Name = dataReader.GetString(1);
                pokemon.Description = dataReader.GetString(2);
                pokemon.Type = dataReader.GetString(3);
            }

            Conexao.Close();

            return pokemon;
        }

        public Pokemon Update(Pokemon pokemon)
        {
            string sql = "update pokemon set name='"+pokemon.Name+"', description = '"+pokemon.Description+"', type = '"+pokemon.Type+"' where Id ="+ pokemon.Id;

            MySqlCommand comando = new MySqlCommand(sql, Conexao);

            Conexao.Open();

            comando.ExecuteReader();

            Conexao.Close();

            return pokemon;

        }

        public void Delete(int Id) 
        {
            string sql = "delete from pokemon where Id=" + Id;

            MySqlCommand comando = new MySqlCommand(sql, Conexao);

            Conexao.Open();

            comando.ExecuteReader();

            Conexao.Close();


        }
    }
}
