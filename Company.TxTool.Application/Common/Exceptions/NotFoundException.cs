namespace Company.TxTool.Application.Common.Exceptions;

public class NotFoundException : TreasuryToolApplicationException
{
    public NotFoundException(string name, object key)
        : base(ExceptionCode.EntityNotFound, $"Entity \"{name}\" ({key}) was not found.")
    {
    }
}