using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Common
{
    public class Failure<T>
        : Result<T>
    {
        public Failure(Exception exception)
        {
            _exception = exception;
        }

        public new T Value { get => default; }
        public new Exception Exception { get => _exception; }
        public override bool IsSuccess { get => false; }
    }
}
