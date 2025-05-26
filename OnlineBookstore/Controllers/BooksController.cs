using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Communication;
using OnlineBookstore.Data;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookContext _context;

    public BooksController(BookContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBook request)
    {
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            Stock = request.Stock
        };

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return StatusCode(201, new { message = "Book created successfully!" });
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookResponse>>> GetAllBooks()
    {
        var books = await _context.Books
            .Select(b => new BookResponse
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Genre = b.Genre,
                Price = b.Price,
                Stock = b.Stock
            })
            .ToListAsync();

        if (books.Count == 0)
            return NotFound(new { message = "No books found." });

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookResponse>> GetBookById(Guid id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
            return NotFound(new { message = $"Book with ID {id} not found." });

        return Ok(new BookResponse
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            Stock = book.Stock
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(Guid id, UpdateBook request)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
            return NotFound(new { message = $"Book with ID {id} not found." });

        book.Title = request.Title ?? book.Title;
        book.Author = request.Author ?? book.Author;
        book.Genre = request.Genre ?? book.Genre;
        book.Price = request.Price ?? book.Price;
        book.Stock = request.Stock ?? book.Stock;

        await _context.SaveChangesAsync();
        return Ok(new { message = "Book updated successfully." });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
            return NotFound(new { message = $"Book with ID {id} not found." });

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Book deleted successfully." });
    }
}
