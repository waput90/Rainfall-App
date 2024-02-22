using Rainfall.API.Models;

namespace Rainfall.API.Services.Abstract
{
    public interface IRainfallService
    {
        Task<RainfallResponse> GetRainfallResponse(string stationId);
    }
}
