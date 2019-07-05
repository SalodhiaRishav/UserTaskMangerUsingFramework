using System;
using System.Collections.Generic;
namespace Shared.DomainModels
{
    public class User : BaseDomain
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
