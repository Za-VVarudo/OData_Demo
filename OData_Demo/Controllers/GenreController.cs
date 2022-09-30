using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using OData_Demo.Models;

namespace OData_Demo.Controllers
{
    public class GenreController : ODataController
    {
        private readonly MovieCollectionContext context;
        public GenreController(MovieCollectionContext context)
        {
            this.context = context;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Genres.ToList());
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get(byte key)
        {
            return Ok(context.Genres.Where(t => t.GenreId == key));
        }


        [HttpPost]
        public IActionResult PostGenre([FromForm] Genre genre)
        {
            try
            {
                context.Genres.Add(genre);
                context.SaveChanges();
                return Ok("Success");
            }
            catch
            {
                return BadRequest("Duplicate Id");
            }
        }

        [HttpPatch]
        public IActionResult PatchGenre([FromForm] Genre genre)
        {
            try
            {
                context.Genres.Update(genre);
                context.SaveChanges();
                return Ok("Success");
            }
            catch
            {
                return NotFound("Not found");
            }
        }

        [HttpDelete]
        public IActionResult DeleteGenre(byte key)
        {
            try
            {
                context.Genres.Remove(new Genre { GenreId = key });
                context.SaveChanges();
                return Ok("Success");
            }
            catch
            {
                return NotFound("Not found");
            }
        }
    }
}
