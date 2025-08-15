using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

using DTOs;
using Services;

[Route("api/[controller]")]
[ApiController]
public class PostsController : Controller
{
    private readonly IPostsService _titleService;

    public PostsController(IPostsService titleService)
    {
        this._titleService = titleService;
    }

    [HttpGet]
    public async Task<IEnumerable<PostDto>> Get()
    {
        return await this._titleService.Get();
    }
}