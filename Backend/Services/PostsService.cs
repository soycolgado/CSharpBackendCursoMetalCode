namespace Backend.Services;

using System.Text.Json;
using DTOs;

public class PostsService: IPostsService
{
    private HttpClient _httpClient;

    public PostsService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }


    public async Task<IEnumerable<PostDto>> Get()
    {
        var result = await this._httpClient.GetAsync(_httpClient.BaseAddress);
        var body = await result.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };
        var post = JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options);
        return post;
    }
}