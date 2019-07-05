namespace Shared.DomainModels
{
    using System;

    public class BaseDomain
    {
        public int Id { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
