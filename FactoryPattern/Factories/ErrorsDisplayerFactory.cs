using FactoryPattern.Interfaces;
using FactoryPattern.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FactoryPattern.Factories;
public class ErrorsDisplayerFactory(IServiceProvider serviceProvider) : IErrorsDisplayerFactory
{
    public IErrorsDisplayer Create(ErrorDisplayerType type)
    {
        return type switch
        {
            ErrorDisplayerType.Basic => serviceProvider.GetRequiredKeyedService<IErrorsDisplayer>(nameof(BasicErrorsDisplayer)),
            ErrorDisplayerType.Pretty => serviceProvider.GetRequiredKeyedService<IErrorsDisplayer>(nameof(PrettyErrorsDisplayer)),
            ErrorDisplayerType.Advanced => serviceProvider.GetRequiredKeyedService<IErrorsDisplayer>(nameof(AdvancedErrorsDisplayer)),
            _ => throw new NotSupportedException("Not supported error displayer type.")
        };
    }
}
