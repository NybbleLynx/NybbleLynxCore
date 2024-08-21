using System;

namespace NybbleLynxLib.Hosting
{
    public interface IContainer
    {
        #region Service Add() Methods

        IContainer AddService<TInterface, TConcrete>(ServiceScope serviceScope) where TConcrete : class, TInterface;
        IContainer AddFactoryService<TFactory>() where TFactory : class;
        IContainer AddInstance<TConcrete>(TConcrete configValue);
        IContainer AddTargetedService<TInterface, TConcrete, TTarget>(bool allowDerivedTypes) where TConcrete : class, TInterface where TTarget : class;

        #endregion

        #region Implementation

        TService GetService<TService>();
        void AddConfig<TConfig>(TConfig configValue);

        void BuildContainer(); 
        bool IsBuilt { get; }

        #endregion

        #region Host Configuration

        IContainer AddHostName(string name);
        IContainer AddHostIdentifier(Guid identifier);

        string HostName { get; }
        Guid HostIdentifier { get; }

        #endregion
    }
}