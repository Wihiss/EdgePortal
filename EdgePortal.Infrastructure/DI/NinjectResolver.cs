using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Syntax;

namespace EdgePortal.Infrastructure.DI
{
    internal class NinjectResolver : IDisposable
    {
        private static readonly Lazy<NinjectResolver> resolver = new Lazy<NinjectResolver>(() => new NinjectResolver());

        private readonly IKernel _kernel;

        private NinjectResolver()
        {
            _kernel = new StandardKernel();
        }

        internal static NinjectResolver Instance => resolver.Value;

        public void Dispose()
        {
            _kernel.Dispose();
        }

        internal IBindingWhenInNamedWithOrOnSyntax<TImplementation> Bind<TInterface, TImplementation>() where TImplementation : TInterface
        {
            return _kernel.Bind<TInterface>().To<TImplementation>();
        }

        internal IBindingNamedWithOrOnSyntax<TImplementation> BindAsSingletone<TInterface, TImplementation>() where TImplementation : TInterface
        {
            return _kernel.Bind<TInterface>().To<TImplementation>().InSingletonScope();
        }

        internal T GetBinding<T>()
        {
            return _kernel.Get<T>();
        }
    }
}