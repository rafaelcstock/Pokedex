using Pokedex.API.Data;

namespace Pokedex.API
{
    public class Pokedex
    {
        private List<Pokemon> _pokemons;

        private DatabaseConnector _connector;

        public Pokedex()
        { 
            _connector = new DatabaseConnector();
        }

        public Pokemon Create(Pokemon pokemon)
        {
            _connector.Create(pokemon);

            return pokemon;

        }

        public List<Pokemon> Read()
        {
            return _connector.Read();
        }

        public Pokemon Read(int Id)
        {
            return _connector.Read(Id);
        }

        public Pokemon Update(Pokemon pokemon)
        {
            return _connector.Update(pokemon);
        }

        public void Delete(int Id)
        {
            _connector.Delete(Id);   
        }
    }
}