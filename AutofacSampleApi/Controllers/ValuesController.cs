using SampleInterface;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AutofacSampleApi.Controllers
{
    public class ValuesController : ApiController
    {
        public IUserService UserService { get; set; }

        // GET api/values
        public List<dynamic> Get()
        {
            return UserService.GetUserList();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
