using ClassLibraryAccessoAiDati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationAPI.Controllers
{
    public class ClassiController : ApiController
    {
        public IHttpActionResult getClassi() {
            DataList.getAllClassi();

            return Json(content: DataList.Classes);
        }
    }
}
