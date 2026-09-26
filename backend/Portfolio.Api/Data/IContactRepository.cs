using Portfolio.Api.DTOs;

namespace Portfolio.Api.Data;

public interface IContactRepository
{
    Task<int> CreateContactMessageAsync(
        CreateContactMessageRequest request);
}