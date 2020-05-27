using System.Collections.Generic;

namespace Validation
{
    public abstract class Validator<T>
    {
        public Validator(List<IRule<T>> rules)
        {
            _rules = rules ?? new List<IRule<T>>();
        }
        public Validator()
        {
            _rules = new List<IRule<T>>();
            BuildRuleSet();
        }
        private List<IRule<T>> _rules;

        public virtual void Add(IRule<T> rule)
        {
            _rules.Add(rule);
        }

        public virtual bool  ValidateRule(T entity)
        {
            foreach(var rule in _rules)
            {
                if(!rule.IsSatisfiedBy(entity))
                {
                    rule.FailureAction(entity);
                    return false;
                }
            }
            SuccessAction(entity);

            return true;
        }

        public virtual bool ValidateAll(List<T> entities)
        {
            var valid = true;
            foreach(var entity in entities)
            {
                if (!ValidateRule(entity))
                    valid = false;
            }
            return valid;
        }

        public abstract void BuildRuleSet();

        public abstract void SuccessAction(T entity);
    }
}
