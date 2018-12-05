using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPIUploadImage.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string file)
        {
            var uniqueName = Guid.NewGuid().ToString() + ".jpeg";
            var path = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ImagePath"])
                + uniqueName;
            byte[] imageBytes = Convert.FromBase64String(file);
            File.WriteAllBytes(path, imageBytes);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        //public class MyModel
        //{
        //    public string file { get; set; }
        //}

        //[HttpPost]
        //[Route("api/uploadimage")]
        //public void UploadImage([FromBody]MyModel model)
        //{
        //    var uniqueName = Guid.NewGuid().ToString() + ".jpeg";
        //    var path = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ImagePath"])
        //        + uniqueName;
        //    byte[] imageBytes = Convert.FromBase64String(model.file);
        //    File.WriteAllBytes(path, imageBytes);
        //}

        //[HttpPost, Route("api/uploadimage")]
        //public void UploadImage([FromBody]string file)
        //{
        //    var uniqueName = Guid.NewGuid().ToString() + ".jpeg";
        //    var path = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ImagePath"])
        //        + uniqueName;
        //    byte[] imageBytes = Convert.FromBase64String(file);
        //    File.WriteAllBytes(path, imageBytes);
        //}
    }
}
