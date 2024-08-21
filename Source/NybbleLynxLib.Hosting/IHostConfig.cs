using System;

namespace NybbleLynxLib.Hosting
{
    public interface IHostConfig
    {
        IHostConfig Register<TInterface, TConcrete>() where TConcrete : class, TInterface;
        IHostConfig RegisterSingleton<TInterface, TConcrete>() where TConcrete : class, TInterface;
        IHostConfig RegisterFactory<TFactory>() where TFactory : class;
        IHostConfig RegisterSpecific<TInterface, TConcrete, TTarget>(bool allowDerivedTypes = false) where TConcrete : class, TInterface where TTarget : class;
        IHostConfig RegisterConstant<TConcrete>(TConcrete value);

        IHostConfig Named(string name);
        IHostConfig IdentifiedAs(Guid identifier);
    }
}