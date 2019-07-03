using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.DomainModels
{
    public class TaskCategory : BaseDomain
    {
        public string CategoryName { get; set; }
    }
}
