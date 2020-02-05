using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorage.TableStorage
{
    public class TableStorageRepo : ITableStorageRepo
    {
        public TableStorageRepo()
        {
            StorageAccount = CloudStorageAccount
                .Parse("DefaultEndpointsProtocol=https;AccountName=anishstoragedemo;AccountKey=KRohowEAfydP3O7KtPlXqlyoUPyPlJI5cp9dQ5cPpmkncnQpPNVDGszUH6p7FptXqn23D6/sRI1mKdtFwgX1qw==;EndpointSuffix=core.windows.net");
            CloudTableClient = StorageAccount?.CreateCloudTableClient();
            TableRef = this.CloudTableClient.GetTableReference("Todo");
        }

        public CloudStorageAccount StorageAccount { get; }
        public CloudTableClient CloudTableClient { get; }
        public CloudTable TableRef { get; }

        //public (CloudStorageAccount storageAccount, CloudTableClient cloudTableClient) ConfugureClient()
        //{
        //    var storageAcnt = CloudStorageAccount
        //        .Parse("DefaultEndpointsProtocol=https;AccountName=anishstoragedemo;AccountKey=KRohowEAfydP3O7KtPlXqlyoUPyPlJI5cp9dQ5cPpmkncnQpPNVDGszUH6p7FptXqn23D6/sRI1mKdtFwgX1qw==;EndpointSuffix=core.windows.net");
        //    return (storageAcnt,
        //        storageAcnt.CreateCloudTableClient());
        //}

        public async Task<bool> CreateTableIfNotExistAsync(string tableName)
        {
            return await TableRef.CreateIfNotExistsAsync();
        }

        public IEnumerable<MyDataEntity> GetDataEntities()
        {
            var query = new TableQuery<MyDataEntity>();
            var data = TableRef.ExecuteQuery(query);

            return data;
        }
    }
}
