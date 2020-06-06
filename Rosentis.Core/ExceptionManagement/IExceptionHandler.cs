using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rosentis.Core.ExceptionManagement
{
    public interface IExceptionHandler
    {
        void Handle(Exception exception);
    }
}
