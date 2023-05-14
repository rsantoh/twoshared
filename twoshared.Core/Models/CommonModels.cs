using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twoshared.Core.Models
{
    public class CommonModels
    {
    }

    public class GenericDropDownList
    {
        public int Id { get; set; }

        public string Texto { get; set; }
    }

    public class GenericDropDownListMultipleId
    {
        public string Id { get; set; }

        public string Texto { get; set; }
    }
}
