using FactoryPattern.Models;

namespace FactoryPattern.Interfaces;
public interface IErrorsDisplayer
{
    void Display(IReadOnlyList<Error> errors);
}
