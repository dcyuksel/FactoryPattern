using FactoryPattern.Models;

namespace FactoryPattern.Interfaces;
public interface IErrorsDisplayer
{
    void Write(IReadOnlyList<Error> errors);
}
