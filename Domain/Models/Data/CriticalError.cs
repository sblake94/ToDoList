using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models.Data
{
    public class CriticalError<T> : Result<T>
    {
        public CriticalError(Exception exception)
        {
            if (exception is null)
            {
                exception = new ArgumentNullException(nameof(exception));
            }


            this.Exceptions.Add(exception);
            throw exception;
        }

        public override bool IsSuccess => false;
        public override T Value => default;
        public override List<Exception> Exceptions { get; } = new List<Exception>();
        public override AggregateException ThrowableException => new AggregateException(Exceptions);
    }
}
