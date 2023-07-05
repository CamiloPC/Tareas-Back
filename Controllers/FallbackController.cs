using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskApi.Controllers;

public class FallbackController : ControllerBase
{

    [HttpGet]
    public ActionResult Index()
    {
        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(),
            "wwwroot", "index.html"), "text/HTML");
    }
    //[HttpGet]
    //public ActionResult Index()
    //{
    //    return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(),
    //        "wwwroot", "client", "index.html"), "text/HTML");
    //}

    //[HttpGet]

    //public ActionResult Admin()
    //{
    //    return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(),
    //        "wwwroot", "admin", "index.html"), "text/HTML");
    //}
}