using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Common
{
    public abstract class Result<T>
    {
        protected T _value;
        protected Exception _exception;

        public T Value { get; set; }
        public abstract bool IsSuccess { get; }
        public Exception Exception { get; set; }
    }
}
