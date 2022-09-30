using System;
using System.Collections.Generic;

namespace OData_Demo.Models
{
    public partial class Actor
    {
        public Actor()
        {
            ActedIns = new HashSet<ActedIn>();
        }
        public Guid ActorId { get; set; }
        public string ActorName { get; set; } = null!;
        public byte Age { get; set; }
        public decimal AverageMovieSalary { get; set; }
        public string Nationality { get; set; } = null!;

        public virtual ICollection<ActedIn> ActedIns { get; set; }
    }
}
