using System;

namespace Company.TxTool.Application.Common.Exceptions
{
    public class RequestAlreadyInReviewException : TreasuryToolApplicationException
    {
        public RequestAlreadyInReviewException() : base(ExceptionCode.RequestAlreadyInReview, "Entity is already in InReview state.")
        {
        }
    }
}
