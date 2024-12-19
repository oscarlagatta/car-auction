namespace AuctionService.Entities;

public class Auction    
{
    public Guid Id { get; set; }

    public int ReservePrice { get; set; } = 0;
    
    public string Seller { get; set; }
    
    public string Winner { get; set; }

    public int? SoldAmount { get; set; }
    
    public int? CurrentHighBid   { get; set; }
    
    /// <summary>
    /// Gets or sets the creation timestamp of the auction entity.
    /// This property is initialized to the current UTC time when the auction is instantiated.
    /// UtcNow is an international time format. 
    /// The timestamp is stored in and retrieved using the UTC format as per database requirements.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime AuctionEnd { get; set; } = DateTime.UtcNow;

    public Status Status { get; set; }

    public Item Item { get; set; }
}