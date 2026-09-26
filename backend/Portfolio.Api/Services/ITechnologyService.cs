using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public interface ITechnologyService
{
    Task<List<TechnologyDto>> GetTechnologiesAsync();
}