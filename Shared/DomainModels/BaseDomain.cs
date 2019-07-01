using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DomainModels
{
   public class BaseDomain
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public DateTime ModifiedOn { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
