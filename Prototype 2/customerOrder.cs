using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_2
{
    public class customerOrder
    {
        public String size, crust, topping;

        public customerOrder(string size, string crust, string topping)
        {
            this.size = size;
            this.crust = crust;
            this.topping = topping;
        }

        public override string ToString()
        {
            return size + ", " + crust + ", " + topping + "Pizza";
        }
    }
}
