using Microsoft.AspNetCore.Mvc;
using MediatR;
using bruno.Prosigliere.Application.Post.Queries;
using MapsterMapper;
using FluentResults;
using bruno.Prosigliere.WebAPI.Contracts;
using bruno.Prosigliere.Application.Post.Commands;
using bruno.Prosigliere.Application.Post;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bruno.Prosigliere.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BlogPostController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetPostListQuery();

            var response = await _mediator.Send(query);

            return Ok(response.Value);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PostRequest request)
        {
            var command = _mapper.Map<CreatePostCommand>(request);

            Result<PostResponse> result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                var response = await _mediator.Send(new GetPostListQuery());
                return Ok(response.Value);
            }

            return Problem($"Unexpected error: {result.Errors[0]}");
        }

        [HttpPost("addComment")]
        public async Task<IActionResult> CreateComment([FromBody] CommentRequest request)
        {
            var command = _mapper.Map<CreateCommentCommand>(request);

            Result<PostResponse> result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                var response = await _mediator.Send(new GetPostListQuery());
                return Ok(response.Value);
            }

            return Problem($"Unexpected error: {result.Errors[0]}");
        }

        [HttpGet("getById/{postId:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid postId)
        {
            var query = new GetPostByIdQuery(postId);

            var response = await _mediator.Send(query);

            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }

            return Problem($"Unexpected error: ");

        }
    }
}
