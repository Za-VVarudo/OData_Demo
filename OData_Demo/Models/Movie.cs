using System;
using System.Collections.Generic;

namespace OData_Demo.Models
{
    public partial class Movie
    {
        public Movie()
        {
            ActedIns = new HashSet<ActedIn>();
        }
        public Guid MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public int Duration { get; set; }
        public byte GenreId { get; set; }
        public string Director { get; set; } = null!;
        public decimal AmountOfMoney { get; set; }
        public string? Comment { get; set; }
        public string? ImageLink { get; set; }

        public virtual Genre Genre { get; set; } = null!;
        public virtual ICollection<ActedIn> ActedIns { get; set; }
    }
}
