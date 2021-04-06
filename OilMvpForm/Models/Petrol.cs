using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilMvpForm.Models
{
    public class Petrol
    {
        public int PetrolId { get; set; }
        public string Benzin { get; set; }
        public double Price { get; set; }
        public double Choice { get; set; }
        public double Total { get; set; }

        public override string ToString()
        {
            return $"{Benzin}-{Price}-{Total}";
        }
    }
}
