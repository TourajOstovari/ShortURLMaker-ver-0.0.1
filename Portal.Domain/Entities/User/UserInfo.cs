
namespace Portal.Domain.Entities.User
{
    using System.Collections.ObjectModel;
    public class UserInfo:Portal.Domain.Common.BaseInfo
    {
        public string IP_Address { get; set; }
        public Collection<Portal.Domain.Entities.URL.URLInfo> URLS { get; set; }
        
        public long URLID { get; set; }
    }
}
