using PruebatecnicaNASA_JJH.App.Dto;

namespace PruebatecnicaNASA_JJH.App.Services
{
    public interface IAsteroidService
    {
        Task<IEnumerable<AsteroidResponseDto>> GetAsteroidsAsync(int days);
    }
}
