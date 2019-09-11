using Framework.Core.Exception;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Framework.Core.Predicate
{
    public static class ExpressionBuilder
    {
        public static Expression<Func<T, bool>> strToFunc<T>(string propName, string opr, string value, Expression<Func<T, bool>> expr = null)
        {
            Expression<Func<T, bool>> func = null;
            try
            {
                var type = typeof(T);
                var prop = type.GetProperty(propName);
                ParameterExpression tpe = Expression.Parameter(typeof(T));
                Expression left = Expression.Property(tpe, prop);
                Expression right = Expression.Convert(ToExprConstant(prop, value), prop.PropertyType);
                Expression<Func<T, bool>> innerExpr = Expression.Lambda<Func<T, bool>>(ApplyFilter(opr, left, right), tpe);
                if (expr != null)
                    innerExpr = innerExpr.And(expr);
                func = innerExpr;
            }
            catch (System.Exception ex)
            {
                throw new ExpressionBuilderFailException();
            }

            return func;
        }
        private static Expression ToExprConstant(PropertyInfo prop, string value)
        {
            object val = null;

            try
            {
                switch (prop.Name)
                {
                    case "System.Guid":
                        val = Guid.NewGuid();
                        break;
                    default:
                        {
                            val = Convert.ChangeType(value, prop.PropertyType);
                            break;
                        }
                }
            }
            catch (System.Exception ex)
            {
                throw new ExpressionBuilderFailException();
            }

            return Expression.Constant(val);
        }
        private static BinaryExpression ApplyFilter(string opr, Expression left, Expression right)
        {
            BinaryExpression InnerLambda = null;
            switch (opr.ToLower())
            {
                case "==":
                case "eq":
                case "=":
                    InnerLambda = Expression.Equal(left, right);
                    break;
                case "<":
                    InnerLambda = Expression.LessThan(left, right);
                    break;
                case "gt":
                case ">":
                    InnerLambda = Expression.GreaterThan(left, right);
                    break;
                case ">=":
                case "gte":
                    InnerLambda = Expression.GreaterThanOrEqual(left, right);
                    break;
                case "lte":
                case "<=":
                    InnerLambda = Expression.LessThanOrEqual(left, right);
                    break;
                case "neq":
                case "!=":
                    InnerLambda = Expression.NotEqual(left, right);
                    break;
                case "and":
                case "&&":
                    InnerLambda = Expression.And(left, right);
                    break;
                case "or":
                case "||":
                    InnerLambda = Expression.Or(left, right);
                    break;
            }
            return InnerLambda;
        }

        public static Expression<Func<T, TResult>> And<T, TResult>(this Expression<Func<T, TResult>> expr1, Expression<Func<T, TResult>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, TResult>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Func<T, TResult> ExpressionToFunc<T, TResult>(this Expression<Func<T, TResult>> expr)
        {
            var res = expr.Compile();
            return res;
        }
    }
}
