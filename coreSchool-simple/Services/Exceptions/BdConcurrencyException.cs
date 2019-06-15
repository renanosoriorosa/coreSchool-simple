using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreSchoolSimple.Services.Exceptions
{
    public class BdConcurrencyException : ApplicationException
    {
        public BdConcurrencyException(string message) : base(message)
        {

        }
    }
}
