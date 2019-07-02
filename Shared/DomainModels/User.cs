using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.DomainModels
{
    public class User : BaseDomain
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Task> Tasks { get; set; }
    }
}
