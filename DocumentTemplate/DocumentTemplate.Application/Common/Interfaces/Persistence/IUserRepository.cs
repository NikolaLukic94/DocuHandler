using DocumentTemplate.Domain.Entities;

namespace DocumentTemplate.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}