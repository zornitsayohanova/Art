using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtFeverShop.Exceptions
{
    public class ErrorDataException : Exception
    {
        private string message;

        public ErrorDataException() : base() { }

        public ErrorDataException(string message)
        {
            this.message = message;
        }
    }
}
