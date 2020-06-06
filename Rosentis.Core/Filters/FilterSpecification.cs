using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rosentis.Core
{
    public class FilterSpecification<T>
    {
        public string PropertyName { get; set; }
        public object FilterValue { get; set; }
        public FilterOperations FilterOperation { get; set; }
    }
}
