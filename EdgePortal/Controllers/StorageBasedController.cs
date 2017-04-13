using EdgePortal.Infrastructure.DI;
using EdgePortal.Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EdgePortal.Controllers
{
    /// <summary>
    /// Class StorageBasedController. Base class for all controllers that use IStorage interface.
    /// </summary>
    public abstract class StorageBasedController : ApiController
    {
        /// <summary>
        /// Reference to IStorage interface.
        /// </summary>
        protected IStorage _storage;

        /// <summary>
        /// Protected constructor.
        /// </summary>
        protected StorageBasedController()
        {
            // Init a reference to IStorage interface.
            _storage = NinjectResolver.Instance.GetBinding<IStorage>();
        }
    }
}