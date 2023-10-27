using Book.API.ViewModel;
using Book.Service.Implements;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    #region Properties

    private readonly IBookService _bookService;
    private readonly ILogger<BookController> _logger;

    #endregion Properties

    #region Constructors

    public BookController(IBookService bookService, ILogger<BookController> logger)
    {
        _bookService = bookService;

        _logger = logger;
    }

    #endregion Constructors

    #region Methods

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookViewModel>>> GetAll()
    {
        var books = await _bookService.GetAll();

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookViewModel>> GetById(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<BookViewModel>> Create([FromBody] BookViewModel bookViewModel)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BookViewModel>> Update(Guid id, [FromBody] BookViewModel bookViewModel)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BookViewModel>> Delete(Guid id)
    {
        return Ok();
    }

    #endregion Methods
}