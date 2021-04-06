using OilMvpForm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilMvpForm.Data
{
    public class PetrolContext:DbContext
    {
        public PetrolContext():base("PetrolDb")
        {

        }
         
       public DbSet<Petrol> Petrols { get; set; }
    }
}
