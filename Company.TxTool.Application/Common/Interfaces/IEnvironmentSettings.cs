namespace Company.TxTool.Application.Common.Interfaces
{
    public interface IEnvironmentSettings
    {
        bool InDevelopmentEnvironment
        {
            get;
        }

        string BlobStorageContainerPrefix
        {
            get;
        }

        string MockDevUserEmail
        {
            get;
        }

        string BlobStorageConnectionString
        {
            get;
        }

        string BlobStorageSupportDocumentsFolder
        {
            get;
        }
    }
}
