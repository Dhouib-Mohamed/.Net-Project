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
            case "default":
                links = new Dictionary<string, string> {
                };

                break;

            case "Admin":
                links = new Dictionary<string, string> {
                    { "search", "/admin/RestaurantsByName" },
                    { "signout", "/Admin/Signout" },
                };

                break;

            case "connected":
                links = new Dictionary<string, string> {
                    { "search", "/Restaurant/RestaurantsByName" },
                    { "profile", "../Profile/ProfileDetails" },
                    { "signout", "/Home/Signout" },
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