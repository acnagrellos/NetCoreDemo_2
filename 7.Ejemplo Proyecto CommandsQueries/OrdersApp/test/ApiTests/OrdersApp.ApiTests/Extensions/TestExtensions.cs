using System;
using System.Linq.Expressions;
using System.Reflection;

namespace OrdersApp.ApiTests.Extensions
{
    public static class TestExtensions
    {
        public static void SetProperty<TSource, TProperty>(
            this TSource source,
            Expression<Func<TSource, TProperty>> prop,
            TProperty value)
        {
            var propertyInfo = (PropertyInfo)((MemberExpression)prop.Body).Member;
            propertyInfo.SetValue(source, value);
        }
    }
}
