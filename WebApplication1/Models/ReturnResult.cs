using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication1.Models.Enum.EnumType;

namespace WebApplication1.Models
{
    public class ReturnResult
    {
        public long ID { get; set; }

        public string Message { get; set; }

        public ResultStatus ResultStatus { get; set; }
    }

    public class DataResult<T> : ReturnResult
    {
        public T Data { get; set; }
    }
}