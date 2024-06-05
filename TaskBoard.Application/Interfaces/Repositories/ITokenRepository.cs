using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Application.Interfaces.Repositories;

public interface ITokenRepository
{
    Task<Guid> Create(ConfirmToken entity);

    Task<ConfirmToken> TryGetById(Guid id);
}