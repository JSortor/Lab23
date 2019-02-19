using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab23.Models
{
    public class Awesomeness
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set;}
        public float Average { get; set; }
    }

    public class AwesomenessDBContext : DbContext
    {
      public DbSet<Awesomeness> Users { get; set; }
    }
}