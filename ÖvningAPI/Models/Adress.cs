using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ÖvningAPI.Models
{
    public class Adress
    {
        [Key]
        public int AdressId { get; set; }
        public string Kommun { get; set; }
        public string GatuNamn { get; set; }
        public string PostCode { get; set; }


        public ICollection<Person> Persons { get; set; }

    }
}
