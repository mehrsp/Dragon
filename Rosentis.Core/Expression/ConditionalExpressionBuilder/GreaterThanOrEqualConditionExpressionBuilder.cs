﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Rosentis.Core
{
    public class GreaterThanOrEqualConditionExpressionBuilder : ConditionalExpressionBuilderBase
    {
        protected override BinaryExpression GetExpression(Expression leftExpression, Expression rightExpression)
        {
            return Expression.GreaterThanOrEqual(leftExpression, rightExpression);
        }
    }
}
