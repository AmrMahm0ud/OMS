using System.ComponentModel.DataAnnotations;

namespace OrdersManagment.Models.Tables
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public bool IsAdmin { get; set; }
        public string deviceToken { get; set; }
    }
}
