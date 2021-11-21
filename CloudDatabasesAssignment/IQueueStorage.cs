using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudDatabasesAssignment
{
    public interface IQueueStorage
    {
        Task CreateMessage(string message);
        Task<string> PeekMessage();
        Task DeleteMessage();
    }
}
