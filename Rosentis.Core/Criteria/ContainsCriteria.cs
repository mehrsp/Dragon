﻿using Rosentis.Extensions;
using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace Rosentis.Core
{
    [DataContract]
    public class ContainsCriteria : Criteria
    {
        protected override Expression CreateExpression(ParameterExpression parameter)
        {
            return ExpressionHelper.CreateConditionalExpression(parameter, this.FirstOprand.ToString(), ObjectType, this.SecondOperand, this.SecondOperand.GetType(), new ContainsConditionExpressionBuilder());
        }
    }
}

