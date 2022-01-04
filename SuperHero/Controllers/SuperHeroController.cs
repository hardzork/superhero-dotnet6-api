using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly DataContext _dbContext;

        public SuperHeroController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _dbContext.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _dbContext.SuperHeroes.FindAsync(id);
            if (hero == null) return BadRequest(new { error = true, message = "Id not found" });
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _dbContext.SuperHeroes.Add(hero);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var Dbhero = await _dbContext.SuperHeroes.FindAsync(request.Id);
            if (Dbhero == null) return BadRequest(new { error = true, message = "Id not found" });

            Dbhero.Name = request.Name;
            Dbhero.FirstName = request.FirstName;
            Dbhero.LastName = request.LastName;
            Dbhero.Place = request.Place;

            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var Dbhero = await _dbContext.SuperHeroes.FindAsync(id);
            if (Dbhero == null) return BadRequest(new { error = true, message = "Id not found" });
            _dbContext.SuperHeroes.Remove(Dbhero);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.SuperHeroes.ToListAsync());
        }
    }
}