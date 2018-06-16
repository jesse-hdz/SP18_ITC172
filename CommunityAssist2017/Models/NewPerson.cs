using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssist2017.Models
{
    public class NewPerson
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Apartment { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public Nullable<System.DateTime> PersonDateAdded { get; set; }

    }
}
