using System;
using System.Collections.Generic;
using System.Text;

namespace ReportInfrastructure.Service
{
    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            State = StateEnum.UnKnown;
        }

        public void SetData(T item)
        {
            Data = item;
            State = StateEnum.Successful;
            Exception = default(Exception);
        }

        public void SetException(Exception ex)
        {
            Data = default(T);
            Exception = ex;
            State = StateEnum.Exception;
            Message = ex.Message;
        }

        public T Data { set; get; }

        public StateEnum State { set; get; }

        public string Message { set; get; }

        public Exception Exception { set; get; }
    }
}
