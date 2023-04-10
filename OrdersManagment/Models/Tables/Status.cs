using System.ComponentModel.DataAnnotations;

namespace OrdersManagment.Models.Tables
{
    public class Status
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
    }
}
