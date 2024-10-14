using FactoryPattern.Interfaces;
using FactoryPattern.Models;

namespace FactoryPattern.Services;

public class BasicErrorsDisplayer : IErrorsDisplayer
{
    public void Display(IReadOnlyList<Error> errors)
    {
        var message = string.Join(" ", errors.Select(e => e.Message));
        Console.WriteLine(message);
    }
}
