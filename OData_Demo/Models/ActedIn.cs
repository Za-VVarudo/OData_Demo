using System;
using System.Collections.Generic;

namespace OData_Demo.Models
{
    public partial class ActedIn
    {
        public Guid ActorId { get; set; }
        public Guid MovieId { get; set; }

        public virtual Actor Actor { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
