namespace Portal.Services
{
    using System;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.Extensions.Caching.Memory;

    public class Service : IService
    {
        #region DependencyInjection
        public static Portal.Repository.TheShortUrl_DB dB { get; set; } //= new Repository.TheShortUrl_DB();
        public Service(Portal.Repository.TheShortUrl_DB dB_) => dB = dB_;
        #endregion

        #region Generator
        internal static class Generator
        {
            public static string Generates(ref string URL_)
            {
                Task<string> result = System.Threading.Tasks.Task.Factory.StartNew<string>(() =>
                {
                    var URLS = dB.URLS.Select(s => s.ShortUrl_);
                    Random rand = new Random();
                    Again:
                    string urlRep_ = null;
                    for (int z = 0; z < 16;)
                    {
                        int Time_ = rand.Next(1, 3);
                        switch (Time_)
                        {
                            case 1:
                                // Number Time
                                urlRep_ += rand.Next(0, 9).ToString();
                                break;
                            case 2:
                                // a-z
                                urlRep_ += (char)rand.Next(65, 90);
                                break;
                            case 3:
                                // A-Z
                                urlRep_ += (char)rand.Next(97, 122);
                                break;
                            default:
                                break;
                        }
                        z++;
                    }
                    if (!URLS.Contains(urlRep_))
                        return urlRep_;
                    else
                        goto Again;
                });
                return result.Result;
            }
        }
        #endregion
        #region MakesShortURL
        public async Task<string> Create(CreateSURLMODEL sURL)
        {
            if (Uri.TryCreate(sURL.MAINURL, UriKind.Absolute, out _))
            {
                if (Cache.MemoryCaching.GET(sURL.MAINURL) == null)
                {
                    if (dB.URLS.SingleOrDefault(z => z.MainUrl_ == sURL.MAINURL) == null)
                    {
                        #region Create&Store
                        Portal.Domain.Entities.User.UserInfo User_ = new Domain.Entities.User.UserInfo() { IP_Address = sURL.IPADDRESS };
                        var user = dB.USERS.Add(User_);
                        Portal.Domain.Entities.URL.URLInfo url_ = new Domain.Entities.URL.URLInfo();
                        string ShortName = Generator.Generates(ref sURL.MAINURL);
                        // AutoMapper
                        url_.MainUrl_ = sURL.MAINURL;
                        url_.ShortUrl_ = ShortName;
                        url_.USERID = user.Entity.id;
                        // AUTOMAPPER
                        dB.SaveChangesAsync();
                        Cache.MemoryCaching.SET(url_);
                        return await (Task.FromResult<string>(ShortName));
                        #endregion

                    }
                    else
                    {
                        var url = dB.URLS.Single(z=> z.MainUrl_ == sURL.MAINURL);
                        cache.Set(sURL.MAINURL, url.ShortUrl_); // CODE SMELL
                        return (Task.FromResult<string>(url.ShortUrl_));
                    }
                }
                else
                {
                    return (string)Cache.MemoryCaching.GET((sURL.MAINURL));
                }
            }
            else
            {
                return await Task.FromResult<string>(null); // Was not URL the input means
            }
        }
        #endregion
        #region RedirectsToMainURL
        public async Task<IAsyncResult> Redirect(string ShortURL)
        {
            return Redirect((string)Cache.MemoryCaching.GET_ShortURL(ShortURL));
        }
        #endregion
        #region TimesOfVisit
        public Task<long> VisitCount(string URL_)
        {
            if (URL_.EndsWith("+"))
            {
                // --- DO SOMETHING HERE ---
            }
            return Task.FromResult<long>(0);
        }
        #endregion
    }
}
