using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rosentis.ExceptionManagement
{
    public static class ExceptionHelper
    {
        public static string GetDetails(Exception exception)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format("#. error at {0}.", DateTime.Now));
            while (exception != null)
            {
                stringBuilder.AppendLine(exception.Message);
                stringBuilder.AppendLine(exception.StackTrace);
                exception = exception.InnerException;
            }
            return stringBuilder.ToString();
        }
    }
}
