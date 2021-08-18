using System.Collections.Generic;

namespace Altaliza.Domain.Entities
{
    public class Character : BaseEntity
    {
        public string Name { get; set; }

        public float Wallet { get; set; }
    }
}
