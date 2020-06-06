using Rosentis.Extensions;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Rosentis.Core
{
    [Serializable]
    public class NotEqualCriteria : Criteria
    {
        protected override Expression CreateExpression(ParameterExpression parameter)
        {
            return ExpressionHelper.CreateConditionalExpression(parameter, this.FirstOprand.ToString(), ObjectType, this.SecondOperand, this.SecondOperand.GetType(), new NotEqualConditionExpressionBuilder());
        }
    }

}
