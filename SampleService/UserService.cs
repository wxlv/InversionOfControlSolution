using SampleInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleService
{
    public class UserService : IUserService
    {
        public List<dynamic> GetUserList()
        {
            List<dynamic> list = new List<dynamic>()
            {
                new { a="1",b="2"},
                new {a="11",b="22"}
            };
            return list;
        }
    }
}
