using System.Collections.Generic;
using System.Web.Http;
using ClassLibraryAccessoAiDati;
namespace WebApplicationAPI.Controllers
{
    //IMPOSTA IN MANIERA STATICA IL PATH PER ACCEDERE ALLA RISORSA
    //API/TEST
    //[Route("api/test")]
    //API/STUDENTI
    //[Route("api/studenti")]
    public class StudentiController : ApiController
    {
        public IHttpActionResult GetStudentis() {
            DataList.GetAllStudenti();
            return Json(content: DataList.Studentis);
        }
        //public List<Studenti> GetStudentis() {
        //    Studenti studenti = new Studenti();
        //    studenti.Nome = "prova";
        //    return (new List<Studenti>() { studenti });
        //}

        public IHttpActionResult GetStudente(int id) {
            return Json(content: DataList.GetStudenteFromDb(id));
        }

        public IHttpActionResult DeleteStudente(int id) {
            return Json(DataList.DeleteStudentis(id));
        }

        //PER GESTIRE INSERIMENTO DI ARRAY DI STUDENTI
        [HttpPost]
        [Route("api/studenti/multiple")]
        public IHttpActionResult InsertStudenti(List<Studenti> studenti) {
            return Json(DataList.InsertStudentis(studenti));
        }
        public IHttpActionResult InsertStudente(Studenti studente) {
            return Json(DataList.InsertStudentis(studente));
        }

        [HttpPut]
        [Route("api/studenti/multiple")]
        public IHttpActionResult UpdateStudenti(List<Studenti> studenti) {
            return Json(DataList.UpdatesStudentis(studenti));
        }
        [HttpPut]
        public IHttpActionResult UpdateStudenti(Studenti studente) {
            return Json(DataList.UpdatesStudentis(studente));
        }

        //Ricerche avanzate con query custom con parametri dinamici No sql-Injectio guys :( 
        [HttpGet]
        public IHttpActionResult GetStudentiByName(string Name)
        {
            return Json(DataList.GetStudentiByName(Name));
        }
        //GET: API/STUDENTI/TEST
        //[Route("studenti/test")]
        //public IHttpActionResult GetStudentis2() {
        //    DataList.getAllStudenti();
        //    return Json(content: DataList.Studentis);
        //}
    }
}
