using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Model.User
{
    public class User
    {
        public User(string firstName, string surName, string cardNumber, string address, string country, string email)
        {
            FirstName = firstName;
            SurName = surName;
            CardNumber = cardNumber;
            Address = address;
            Country = country;
            Email = email;
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string SurName  { get; set; }
        public string CardNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    }
}
