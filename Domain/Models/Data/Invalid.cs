using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models.Data
{
    public class Invalid<T> : Result<T>
    {
        private readonly T value;

        public Invalid(T value, Exception exception)
        {
            this.value = value;
            this.Exceptions.Add(exception);
        }

        public Invalid(T value, IEnumerable<Exception> exceptions)
        {
            this.value = value;
            this.Exceptions.AddRange(exceptions);
        }

        public override bool IsSuccess => false;
        public override T Value => value;
        public override List<Exception> Exceptions { get; } = new List<Exception>();
        public override AggregateException ThrowableException => new AggregateException(Exceptions);
    }
}
