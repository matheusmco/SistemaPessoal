namespace SistemaPessoal.Helpers
{
    static class Extensions
    {
        public static bool IsNullEmptyOrWhiteSpace(this string value) => string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);

        public static bool IsZeroOrNull(this int value) => value == 0;
    }
}