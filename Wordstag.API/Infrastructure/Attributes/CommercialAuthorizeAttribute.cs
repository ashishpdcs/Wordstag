namespace Wordstag.API.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CommercialAuthorizeAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {
        public string Name { get; }
        public CommercialAuthorizeAttribute(string name = null) : base("Permission")
        {
            Name = name;
        }
    }
}
