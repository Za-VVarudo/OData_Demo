using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using OData_Demo.Models;


namespace OData_Demo.Controllers
{
    public class MovieController : ODataController
    {
        private readonly MovieCollectionContext context;
        public MovieController(MovieCollectionContext context)
        {
            this.context = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(context.Movies.ToList());
        }

        [EnableQuery]
        public IActionResult Get(Guid key)
        {
            return Ok(context.Movies.Where(t => t.MovieId == key));
        }
    }
}
