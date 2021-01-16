using Goleador.Domain.Base;
using Goleador.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Domain.Book
{
    public class ReadingStatus : ValueObject
    {
        private ReadingStatus(string value, DateTimeOffset? readingStarted = null, DateTimeOffset? readingFinished = null)
        {
            Value = value;
        }

        private ReadingStatus()
        {

        }

        public static ReadingStatus ToRead => new ReadingStatus("To read");
        public static ReadingStatus InRead => new ReadingStatus("In read");
        public static ReadingStatus Finished => new ReadingStatus("Finished");

        public string Value { get; private set; }
        
        public ReadingStatus StartReading()
        {
            if (this != ToRead)
            {
                throw new DomainException("The book is in read or has been already finished.");
            }

            return InRead;
        }

        public ReadingStatus FinishReading()
        {
            if (this != InRead)
            {
                throw new DomainException("The book has been already finished.");
            }

            return Finished;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
