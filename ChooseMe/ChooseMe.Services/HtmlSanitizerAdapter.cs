namespace ChooseMe.Services
{
    using Ganss.XSS;
    using ChooseMe.Services.Contracts;

    public class HtmlSanitizerAdapter : ISanitizer
    {
        public string Sanitize(string html)
        {
            var sanitizer = new HtmlSanitizer();
            var result = sanitizer.Sanitize(html);
            return result;
        }
    }
}
