﻿namespace OnlineBookstore.Communication;

public class BookResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
