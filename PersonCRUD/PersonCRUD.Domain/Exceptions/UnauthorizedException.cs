using System.Diagnostics.CodeAnalysis;

namespace PersonCRUD.Domain.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message): base(message)
        {
        }

        public UnauthorizedException(string message, Exception inner): base(message, inner)
        {
        }

        public static void ThrowIfNull([NotNull] object? argument, string? erroMsg = null)
        {
            if (argument is null)
            {
                Throw(erroMsg);
            }
        }

        [DoesNotReturn]
        internal static void Throw(string? erroMsg) =>
            throw new UnauthorizedException(erroMsg);
    }
}
