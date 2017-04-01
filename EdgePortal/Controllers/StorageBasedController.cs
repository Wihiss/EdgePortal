using EdgePortal.Infrastructure.DI;
using EdgePortal.Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EdgePortal.Api.Controllers
{
    public abstract class StorageBasedController : ApiController
    {
        protected readonly IStorage _storage;

        protected StorageBasedController()
        {
            _storage = NinjectResolver.Instance.GetBinding<IStorage>();
        }
    }
}
