using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingProject1.Models
{
    public class APIResponse<T>
    {
        public T item { get; set; }
        public APIResponseStatus status { get; set; }
    }
}