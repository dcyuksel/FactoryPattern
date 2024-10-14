using FactoryPattern.Interfaces;

namespace FactoryPattern.Factories;
public interface IErrorsDisplayerFactory
{
    IErrorsDisplayer Create(ErrorDisplayerType type);
}
