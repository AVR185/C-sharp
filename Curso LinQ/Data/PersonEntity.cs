using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleLinq.Data
{
    public class PersonEntity
    {
        [Key]
        public string FiscalDoc { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public int Age { get; set; }
    }
}
