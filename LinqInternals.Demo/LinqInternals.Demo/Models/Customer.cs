using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqInternals.Demo.Models
{
    public class Customer
    {
        public string? Name { get; set; }
        public Phone[] Phones { get; set; } = null!;
    }
}
