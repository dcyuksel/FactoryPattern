using FactoryPattern.Interfaces;
using FactoryPattern.Models;

namespace FactoryPattern.Services;

public class AdvancedErrorsDisplayer : IErrorsDisplayer
{
    public void Write(IReadOnlyList<Error> errors)
    {
        for (var i = 0; i < errors.Count; i++)
        {
            var message = $"{i + 1} - {nameof(Error.Code)}: '{errors[i].Code}', {nameof(Error.Message)}: '{errors[i].Message}'.";
            Console.WriteLine(message);
        }
    }
}
