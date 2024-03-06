using TaskBoard.Domain.Entities;

namespace TaskBoard.Domain.Interfaces;

public interface IUserRepository
{
    Task Create(UserEntity userEntity);
}