namespace Company.TxTool.Application.AccountOpenRequest.Queries.Common
{
    public abstract class BaseAccountOpenRequestDto
    {
        protected BaseAccountOpenRequestDto()
        {
            RequestedBy = default!;
            Status = default!;
            RowVersion = default!;
        }

        public Guid Guid
        {
            get; set;
        }

        public string RequestedBy
        {
            get; set;
        }

        public int RequestedById
        {
            get; set;
        }

        public string? ReviewedBy
        {
            get; set;
        }

        public int? ReviewedById
        {
            get; set;
        }

        public DateTime? RequestedOn
        {
            get; set;
        }

        public DateTime? ReviewedOn
        {
            get; set;
        }

        public string Status
        {
            get; set;
        }

        public byte[] RowVersion
        {
            get; set;
        }
    }
}
