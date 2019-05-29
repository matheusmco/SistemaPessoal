namespace SistemaPessoal.Helpers.Extensions
{
    static class StringExtensions
    {
        public static bool IsNullEmptyOrWhiteSpace(this string value) => string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
    }
}