using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreSandbox.Controllers
{
    public class IndexController : Controller
    {
        // GET
        public Test Index(string id)
        {
            Test test = new Test();
            test.one = "id = " + id;
            test.two = "nuff said";
            return test;
        }
    }

    public class Test
    {
        public string one { get; set; }
        public string two { get; set; }
    }
}