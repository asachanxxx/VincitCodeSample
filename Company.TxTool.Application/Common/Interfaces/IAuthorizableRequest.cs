namespace Company.TxTool.Application.Common.Interfaces
{
    public interface IAuthorizableRequest
    {
        Task<bool> IsAuthorizedAsync();
    }
}