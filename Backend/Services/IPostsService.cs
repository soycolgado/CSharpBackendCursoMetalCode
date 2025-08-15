namespace Backend.Services;

using DTOs;

public interface IPostsService
{
    public Task<IEnumerable<PostDto>> Get();
}