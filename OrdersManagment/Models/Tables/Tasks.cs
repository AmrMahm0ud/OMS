using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersManagment.Models.Tables
{
    public class Tasks
    {
        [Key]
        public int orderId { get; set; }
        public double orderAmount { get; set; }
        public double COD { get; set; }
        public int? orderStatus { get; set; }
        [ForeignKey(nameof(orderStatus))]
        public Status? status { get; set; }
        public int? assinedTo { get; set; }
        [ForeignKey(nameof(assinedTo))]
        public Users? user { get; set; }
    }
}
