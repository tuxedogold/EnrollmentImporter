namespace Validation
{
    public interface IRule<T>
    {
       bool IsSatisfiedBy(T entity);
       void FailureAction(T entity);
    }
}