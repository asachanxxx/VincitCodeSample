using System;
using Company.TxTool.Application.Common.Exceptions;

namespace Company.TxTool.FunctionApi.Exceptions
{
    public class AnonymousRequestException : TreasuryToolApplicationException
    {
        public AnonymousRequestException() : base(ExceptionCode.AnonymousRequest, "Authentication is not configured on the function app.")
        {
        }
    }
}