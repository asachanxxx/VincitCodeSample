namespace Company.TxTool.Application.Common.Exceptions
{
    public class EntityAlreadyExistsException<T> : TreasuryToolApplicationException
    {
        public T Entity
        {
            get; private set;
        }

        public EntityAlreadyExistsException(T entity) : base(ExceptionCode.EntityAlreadyExists, "Entity already exists in the system.")
        {
            Entity = entity;
        }
    }
}