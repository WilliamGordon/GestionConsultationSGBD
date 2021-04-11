using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CustomErrors
{
    public class NoLocalAvailable : Exception
    {
        public NoLocalAvailable(string message) : base(message)
        {
        }
    }
}