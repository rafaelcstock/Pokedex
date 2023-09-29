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
        public Pokemon Post(int Id, string Name, string Description, string Type)
        {
            Pokemon pokemon = _pokedex.Create(Id, Name, Description, Type);

            return pokemon;
        }

        // PUT api/<PokedexController>/5
        [HttpPut]
        public Pokemon Put(int Id, string Name, string Description, string Type)
        {
            Pokemon pokemonNew = new Pokemon();
            pokemonNew.Id = Id;
            pokemonNew.Name = Name;
            pokemonNew.Description = Description;
            pokemonNew.Type = Type;
            Pokemon pokemon = _pokedex.Update(pokemonNew);
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
