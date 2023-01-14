using Microsoft.AspNetCore.Mvc;

public class NavMenuViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string pageName)
    {
        var links = GetLinksForPage(pageName);
        return View(links);
    }

    private Dictionary<string, string> GetLinksForPage(string pageName)
    {
        Dictionary<string, string> links = null;
        switch (pageName)
        {
            case "Admin":
                links = new Dictionary<string, string> {};

                break;

            case "connected":
                links = new Dictionary<string, string> {
                    { "search", "" },
                    { "profile", "../Profile/ProfileDetails" },
                    { "signout", "" },
                };

                break;
            case "disconnected":
                links = new Dictionary<string, string> {
                 { "Sign in", "../Home/Signin" },
                 { "Sign up", "..Home/Signup" },
                };

                break;

        }


        return links;
    }
}