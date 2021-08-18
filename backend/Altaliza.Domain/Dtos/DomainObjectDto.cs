using System.Collections.Generic;
using System.Linq;

namespace Altaliza.Domain.Entities
{
    public class DomainObjectDto<T>
    {
        public List<string> Errors { get; private set; }

        public T Data { get; set; }

        public bool HasErrors()
        {
            return !Errors.Any();
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}
