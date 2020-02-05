using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AzureStorage.Blob
{
    public interface ITodoRepo
    {
        IConfiguration Configuration { get; }

        Task<bool> CreateNewBlobContainer(string containerName);
    }
}