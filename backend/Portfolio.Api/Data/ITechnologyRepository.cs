using Portfolio.Api.DTOs;

namespace Portfolio.Api.Data;

public interface ITechnologyRepository
{
    Task<List<TechnologyDto>> GetTechnologiesAsync();
}