using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using OData_Demo.Models;

namespace OData_Demo.Controllers
{
    public class ActorController : ODataController
    {
        private readonly MovieCollectionContext context;
        public ActorController(MovieCollectionContext context)
        {
            this.context = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(context.Actors.Include(a => a.ActedIns).ToList());
        }

        [EnableQuery]
        public IActionResult Get(Guid key)
        {
            return Ok(context.Actors.Where(a => a.ActorId == key).Include(a => a.ActedIns).ToList());
        }
    }
}
