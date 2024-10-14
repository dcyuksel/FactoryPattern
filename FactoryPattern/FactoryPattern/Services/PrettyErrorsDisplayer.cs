using FactoryPattern.Interfaces;
using FactoryPattern.Models;

namespace FactoryPattern.Services;

public class PrettyErrorsDisplayer : IErrorsDisplayer
{
    public void Write(IReadOnlyList<Error> errors)
    {
        for (var i = 0; i < errors.Count; i++)
        {
            var message = $"{i + 1} - {errors[i].Message}";
            Console.WriteLine(message);
        }
    }
}
