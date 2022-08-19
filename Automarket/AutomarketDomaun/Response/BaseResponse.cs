using AutomarketDomaun.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomarketDomaun.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Descriprion { get;set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        string Descriprion { get; }
        StatusCode StatusCode { get; }
        T Data { get; set; }
    }
}
