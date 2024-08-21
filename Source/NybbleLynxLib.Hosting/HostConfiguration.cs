using System;

namespace NybbleLynxLib.Hosting
{
    public class HostConfiguration : IHostConfig
    {
        private readonly IContainer container;

        public HostConfiguration(IContainer container)
        {
            this.container = container ?? throw new ArgumentNullException(nameof(container));
        }

        /// <inheritdoc />
        public IHostConfig Register<TInterface, TConcrete>() 
            where TConcrete : class, TInterface
        {
            container.AddService<TInterface, TConcrete>(ServiceScope.Transient);
            return this;
        }

        /// <inheritdoc />
        public IHostConfig RegisterSingleton<TInterface, TConcrete>() 
            where TConcrete : class, TInterface
        {
            container.AddService<TInterface, TConcrete>(ServiceScope.Singleton);
            return this;
        }

        /// <inheritdoc />
        public IHostConfig RegisterFactory<TFactory>() 
            where TFactory : class
        {
            container.AddFactoryService<TFactory>();
            return this;
        }

        /// <inheritdoc />
        public IHostConfig RegisterSpecific<TInterface, TConcrete, TTarget>(bool allowDerivedTypes = false)
            where TConcrete : class, TInterface where TTarget : class
        {
            container.AddTargetedService<TInterface, TConcrete, TTarget>(allowDerivedTypes);
            return this;
        }

        /// <inheritdoc />
        public IHostConfig RegisterConstant<TConcrete>(TConcrete value)
        {
            container.AddInstance(value);
            return this;
        }

        /// <inheritdoc />
        public IHostConfig Named(string name)
        {
            container.AddHostName(name);
            return this;
        }

        /// <inheritdoc />
        public IHostConfig IdentifiedAs(Guid identifier)
        {
            container.AddHostIdentifier(identifier);
            return this;
        }
    }
}