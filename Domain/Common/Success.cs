using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Common
{
    public class Success<T> 
        : Result<T>
    {
        public Success(T data) 
        {
            _value = data;
        }

        public new T Value { get => _value; set => _value = value; }
        public new Exception Exception { get => null; }
        public override bool IsSuccess { get => true; }
    }
}
