using System.Collections.Generic;

namespace Altaliza.Application.Dtos
{
    public class ApiResponseDto<T>
    {
        public ApiResponseDto()
        {
            Type = "success";
            Status = 200;
        }

        public string Type { get; set; }
        public int Status { get; set; }
        public T Data { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
