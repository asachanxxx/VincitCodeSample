namespace Company.TxTool.Application.Common.Exceptions
{
    public class TreasuryToolApplicationException : ApplicationException
    {
        public ExceptionCode Code
        {
            get; private set;
        }

        protected TreasuryToolApplicationException(ExceptionCode code, string message)
            : base(message)
        {
            Code = code;
        }
    }

    public enum ExceptionCode
    {
        BadConfiguration,
        EntityAlreadyExists,
        AnonymousRequest,
        UserNotFound,
        UserNotActive,
        EntityModifiedElsewhere,
        EntityNotFound,
        RequestAlreadyInReview
    }
}
