using EventManagement.Domain;
using Newtonsoft.Json;
using RestSharp;
using System.Web.Mvc;

namespace EventManagement.Web.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            if (Session["Username"] == null) {
                return RedirectToAction("Login");
            }

            return View();
        }

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user) {
            if (!ModelState.IsValid) {
                return View();
            }

            var baseUrl = @"https://localhost:44331/";
            var serviceUrl = @"api/Users/Login";

            var client = new RestClient(baseUrl);
            var request = new RestRequest(serviceUrl, Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new User {
                Username = user.Username,
                Password = user.Password
            });
            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<User>(response.Content);

            Session["Username"] = content.Username;
            Session["Role"] = content.RoleName;

            return RedirectToAction("Index", "Dashboard");
        }
    }
}