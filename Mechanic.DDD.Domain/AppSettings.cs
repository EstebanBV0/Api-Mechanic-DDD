using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Domain.HelperObjectUtils
{
    public class AppSettings
    {
        public ShoppingCart ShoppingCart { get; set; }
    }

    public class ShoppingCart
    {
        public string ServerUrl { get; set; }
        public string Abandoned { get; set; }
    }


}
