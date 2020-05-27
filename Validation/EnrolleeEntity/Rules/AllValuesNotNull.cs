using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Validation.EnrolleeEntity.RuleTypes;

namespace Validation.EnrolleeEntity.Rules
{
    public class AllValuesNotNull<T> : HaltRule<T> 
    {
        public override bool IsSatisfiedBy(T entity)
        {
            Type type = typeof(T);
            IEnumerable<PropertyInfo> nullProperties = type.GetProperties()
                .Where(p => p.GetValue(entity, null) == null);

            IEnumerable<FieldInfo> nullFields = type.GetFields()
                .Where(f => f.GetValue(entity) == null);

            return nullProperties.Count() == 0 && nullFields.Count() == 0;
        }
    }
}