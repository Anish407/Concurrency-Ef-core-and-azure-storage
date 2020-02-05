using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorage.Blob
{
    public class BlobRepo : ITodoRepo
    {
        public BlobRepo(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<bool> CreateNewBlobContainer(string containerName)
        {
            try
            {
                string constring = "DefaultEndpointsProtocol=https;AccountName=anishstoragedemo;AccountKey=KRohowEAfydP3O7KtPlXqlyoUPyPlJI5cp9dQ5cPpmkncnQpPNVDGszUH6p7FptXqn23D6/sRI1mKdtFwgX1qw==;EndpointSuffix=core.windows.net";
                //this.Configuration.GetSection("AllowedHosts").Value;
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(constring);

                var blobClient = storageAccount.CreateCloudBlobClient();

                var container = blobClient.GetContainerReference("images");
                return await container.CreateIfNotExistsAsync();
            }
         
            catch (Exception ex)
            {

              
            }
            return false;
        }

        //public async Task<bool> UploadToBlob()
        //{

        //}
    }
}
