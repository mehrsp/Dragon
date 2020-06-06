using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Rosentis.Core
{
    public class ContainsConditionExpressionBuilder : IConditionalExpressionBuilder
    {
        Expression IConditionalExpressionBuilder.Get(MemberExpression memberExpression, object value, Type valueType)
        {
            List<string> s = new List<string>();
            ConstantExpression keyExpression = Expression.Constant(value, valueType);
            MethodInfo containsMethod = typeof(IEnumerable<>).GetMethod("Contains", new[] { valueType });

            if (containsMethod != null)
            {
                return Expression.Call(memberExpression, containsMethod, keyExpression);
            }
            throw new Exception("");
        }
    }
}
