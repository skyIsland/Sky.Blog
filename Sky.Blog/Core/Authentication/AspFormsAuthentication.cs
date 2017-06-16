using System.Web.Security;

namespace Sky.Blog.Core.Authentication
{
    public class AspFormsAuthentication : IFormsAuthentication
    {
        public void SetAuthenticationToken(string token, bool createPersistentCookie = false)
        {
            FormsAuthentication.SetAuthCookie(token, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}