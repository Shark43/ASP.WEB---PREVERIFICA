using System.Web.Http;
using ClassLibraryAccessoAiDati;

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
