using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DomainModels
{
    public class Task:BaseDomain
    {
        [Required]
        public int TimeSpent { get; set; }

        [Required]
        public DateTime TaskDate { get; set; }

        [Required]
        public int ExpectedTime { get; set; }

        [Required]
        public string UserStory { get; set; }

        public int UserID { get; set; }

        //public User User { get; set; }

        public int TaskCategoryID { get; set; }

        public TaskCategory TaskCategory { get; set; }

    }
}
