using Microsoft.AspNetCore.Mvc;

namespace Pokedex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokedexController : ControllerBase
    {
        private Pokedex _pokedex;

        public PokedexController()
        {
            _pokedex = new Pokedex();
        }

        // GET: api/<PokedexController>
        [HttpGet]
        public IActionResult Get()
        {
            var pokedex = _pokedex.Read();


            var totalCount = pokedex.Count;


            Response.Headers.Add("X-Total-Count", totalCount.ToString());

            return Ok(pokedex);
        }

        // GET api/<PokedexController>/5
        [HttpGet("{Id}")]
        public Pokemon Get(int Id)
        {
            return _pokedex.Read(Id);
        }

        // POST api/<PokedexController>
        [HttpPost]
        public Pokemon Post([FromBody] Pokemon pokemon)
        {
            return _pokedex.Create(pokemon);
        }

        // PUT api/<PokedexController>/5
        [HttpPut("{Id}")]
        public Pokemon Put(int Id, [FromBody] Pokemon pokemon)
        {
            Pokemon pokemonNew = new Pokemon();
            pokemonNew.Id = Id;
            pokemonNew.Name = pokemon.Name;
            pokemonNew.Description = pokemon.Description;
            pokemonNew.Type = pokemon.Type;
            _pokedex.Update(pokemonNew);
            return pokemon;
        }

        // DELETE api/<PokedexController>/5
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _pokedex.Delete(Id);
        }
    }
}
