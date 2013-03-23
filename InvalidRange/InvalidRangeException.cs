using System;

namespace InvalidRange
{
    class InvalidRangeException<T> : ApplicationException
    {
        //Properties
        public T StartRange { get; set; }
        public T EndRange { get; set; }

        //Constructon
        public InvalidRangeException(T startRange, T endRange) 
            {
            this.StartRange = startRange;
            this.EndRange = endRange;
        }

        public InvalidRangeException(T startRange, T endRange, string message)
            : base(message) 
        {
            this.StartRange = startRange;
            this.EndRange = endRange;
        }

        public InvalidRangeException(T startRange, T endRange, string message, Exception innerException)
            : base(message, innerException)
        {
            this.StartRange = startRange;
            this.EndRange = endRange;
        }
    }
}
