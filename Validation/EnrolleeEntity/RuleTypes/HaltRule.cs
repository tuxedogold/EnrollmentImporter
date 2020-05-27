using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Validation.EnrolleeEntity.RuleTypes
{
    public abstract class HaltRule<T> : IRule<T>
    {
        public virtual void FailureAction(T entity)
        {
            throw new InvalidDataException($"{entity} failed validation on {this}");
        }
        public abstract bool IsSatisfiedBy(T entity);

    }
}
