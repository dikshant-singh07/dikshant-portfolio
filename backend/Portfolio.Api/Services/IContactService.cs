using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public interface IContactService
{
    Task<int> CreateContactMessageAsync(
        CreateContactMessageRequest request);
}