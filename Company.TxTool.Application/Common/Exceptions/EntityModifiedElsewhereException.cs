namespace Company.TxTool.Application.Common.Exceptions
{
    public class EntityModifiedElsewhereException : TreasuryToolApplicationException
    {
        public EntityModifiedElsewhereException() : base(ExceptionCode.EntityModifiedElsewhere, "Entity has been modified since you loaded it. Please roload before you make any changes.")
        {
        }
    }
}