using Portfolio.Api.Data;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public class TechnologyService : ITechnologyService
{
    private readonly ITechnologyRepository _technologyRepository;

    public TechnologyService(ITechnologyRepository technologyRepository)
    {
        _technologyRepository = technologyRepository;
    }

    public async Task<List<TechnologyDto>> GetTechnologiesAsync()
    {
        return await _technologyRepository.GetTechnologiesAsync();
    }
}