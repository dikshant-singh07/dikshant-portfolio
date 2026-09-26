using Portfolio.Api.Data;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<int> CreateContactMessageAsync(
        CreateContactMessageRequest request)
    {
        return await _contactRepository.CreateContactMessageAsync(request);
    }
}