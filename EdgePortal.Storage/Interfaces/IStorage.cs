using EdgePortal.Storage.Interfaces.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgePortal.Storage.Interfaces
{
    public interface IStorage : IDisposable
    {
        // IAccountManager AccountManager { get; }
        IBlogManager BlogManager { get; }
    }
}
