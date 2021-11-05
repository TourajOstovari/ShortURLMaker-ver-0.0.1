namespace Portal.Services
{
    using System;
    using System.Threading.Tasks;
    public interface IService
    {
        Task<string> Create(CreateSURLMODEL sURL);
        Task<IAsyncResult> Redirect(string ShortURL);
        Task<long> VisitCount(string URL_);
    }
}
