using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorage.TableStorage
{
    public interface ITableStorageRepo
    {
        Task<bool> CreateTableIfNotExistAsync(string tableName);

        IEnumerable<MyDataEntity> GetDataEntities();
    }
}
