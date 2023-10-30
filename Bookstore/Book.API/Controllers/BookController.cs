using Book.API.ViewModel;
using Book.Infra.CrossCutting.Dtos;
using Book.Service.Implements;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    #region Properties

    private readonly IBookService _bookService;
    private readonly IValidator<BookFilterDto> _validator;

    private readonly ILogger<BookController> _logger;

    #endregion Properties

    #region Constructors

    public BookController(IBookService bookService, IValidator<BookFilterDto> validator, ILogger<BookController> logger)
    {
        _bookService = bookService ?? throw  new ArgumentException(nameof(bookService));
        _validator = validator ?? throw  new ArgumentException(nameof(validator));

        _logger = logger ?? throw new ArgumentException((nameof(logger)));
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
    public ActionResult<Domain.Book?> GetById(string id)
    {
        return _bookService.GetBookByIsbnCompiled(id);
    }

    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<Domain.Book>>> FilterBooks([FromQuery] BookFilterDto dto)
    {
        var bookValidator = _validator.Validate(dto);
        
        if (!bookValidator.IsValid)
        {
            return BadRequest(bookValidator.Errors.Select(x => x.ErrorMessage));
        }

        var books = await _bookService.GetBooksByFilter(dto);

        return Ok(books);
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