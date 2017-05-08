using Microsoft.AspNetCore.Mvc;

namespace EastGreenbushKitingClub.ViewComponents
{
    public class LoginLogoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
