using System.Collections.Generic;
using System.Linq;

namespace Altaliza.Domain.Entities
{
    public class DomainResponseDto<T>
    {
        public DomainResponseDto()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public Dictionary<string, List<string>> Errors { get; private set; }
        public T Data { get; set; }

        public bool HasErrors()
        {
            return !(Errors.Count() == 0);
        }

        public DomainResponseDto<T> AddError(string key, string error)
        {
            if (Errors.ContainsKey(key))
            {
                Errors[key].Add(error);
            } else
            {
                var errorList = new List<string>
                {
                    error
                };

                Errors.Add(key, errorList);
            }

            return this;
        }

        public DomainResponseDto<T> AddErrors(string key, List<string> errorList)
        {
            Errors.Add(key, errorList);

            return this;
        }
    }
}
