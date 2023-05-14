using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twoshared.Core.Models
{
    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string urlPicture { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
    }
}
