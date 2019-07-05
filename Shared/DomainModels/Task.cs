namespace Shared.DomainModels
{
    using System;

    public class Task:BaseDomain
    {
        public int TimeSpent { get; set; }

        public DateTime TaskDate { get; set; }

        public int ExpectedTime { get; set; }

        public string UserStory { get; set; }

        public int UserID { get; set; }

        public int TaskCategoryID { get; set; }

        public TaskCategory TaskCategory { get; set; }
    }
}
