using ClassLibraryAccessoAiDati;
using System.Web.Http;

namespace WebApplicationAPI.Controllers
{
    public class ClassiController : ApiController
    {
        public IHttpActionResult GetClassi() {
            DataList.GetAllClassi();

            return Json(content: DataList.Classes);
        }
    }
}
