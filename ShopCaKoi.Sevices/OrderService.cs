using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Interfaces;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.Services
{
    public class OrderService
    {
        public string orderID { get; set; }
        public Tour? tour { get; set; }
        public List<Koi> koiList { get; set; }
        public string status { get; set; }
        public Quotation? quotation { get; set; }
        public string paymentStatus { get; set; }

        // Constructor
        public OrderService()
        {
            koiList = new List<Koi>();
            status = "Pending";
            paymentStatus = "Unpaid";
        }

        // Method to update payment status
        public void UpdatePaymentStatus(string paymentStatus)
        {
            this.paymentStatus = paymentStatus;
        }

        // Method to calculate total price for all Koi in the order
        public double calculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (var koi in koiList)
            {
                totalPrice += koi.price();
            }
            return totalPrice;
        }
    }
    


    public class Tour
    {
        public string nameTour { get; set; }
    }

    public class Koi
    {
        public int ID { get; set; }
        public double size { get; set; }

        internal double price()
        {
            throw new NotImplementedException();
        }

        // Method to calculate the price for a single Koi

    }

    public class Quotation
    {
        public double price { get; set; }
    }
}
