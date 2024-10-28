using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCaKoi.Sevices.Interface
{
    internal interface IKoi
    {
        public string koiID { get; set; }
        public string species { get; set; }
        public int age { get; set; }
        public double size { get; set; }
        public double price { get; set; }
    }
}
