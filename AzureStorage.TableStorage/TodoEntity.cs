using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureStorage.TableStorage
{
    public class MyDataEntity : TableEntity
    {
        public string Comments { get; set; }
        public bool IsCompleted { get; set; }
    }
}
