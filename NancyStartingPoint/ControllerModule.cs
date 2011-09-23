
using Nancy;
using NancyStartingPoint.Models;

namespace NancyStartingPoint
{
    public class ControllerModule : NancyModule
    {
        public ControllerModule()
        {
            Get["/"] = parameters =>
            {
                var credentials = new LoginCredentialsModel();

                //  Try:  http://localhost:8888/?username=MyName
                var usernameParam = Request.Query["username"];
                if (usernameParam.HasValue)
                    credentials.Username = usernameParam;
                
                return View["login", credentials];
            };
        }
    }
}
