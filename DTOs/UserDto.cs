using Poco;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class UserDto :IPoco
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}
