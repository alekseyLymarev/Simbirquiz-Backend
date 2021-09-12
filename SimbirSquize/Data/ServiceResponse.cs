using System.Collections.Generic;

namespace SimbirSquize.Data
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public Dictionary<int, string> Errors { get; set; }
    }
}