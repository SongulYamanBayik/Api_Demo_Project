using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Demo_Project.DAL.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public bool Status { get; set; }
    }
}
