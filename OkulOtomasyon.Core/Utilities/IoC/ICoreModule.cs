using Microsoft.Extensions.DependencyInjection;

namespace OkulOtomasyon.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
