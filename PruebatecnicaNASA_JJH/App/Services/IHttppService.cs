namespace PruebatecnicaNASA_JJH.App.Services
{
    public interface IHttppService
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}
