using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities.URL
{
    public class URLInfo : Portal.Domain.Common.BaseInfo
    {
        public string MainUrl_ { get; set; }
        public string ShortUrl_ { get; set; }
        public long Visit { get; set; }
        public DateTime Created { get; set; }
        public Portal.Domain.Entities.User.UserInfo USERINFO { get; set; }
        public long USERID { get; set; }
    }
}
