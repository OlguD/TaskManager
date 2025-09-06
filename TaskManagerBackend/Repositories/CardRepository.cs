using Microsoft.EntityFrameworkCore;
using TaskManagerBackend.Data;
using TaskManagerBackend.Models;

namespace TaskManagerBackend.Repositories;

public class CardRepository : ICardRepository
{
    private readonly AppDbContext _context;
    
    public CardRepository(AppDbContext context)
     {
         _context = context;
     }
    
    public async Task<Card> AddCardAsync(Card card)
    {
        _context.Cards.Add(card);
        await _context.SaveChangesAsync();
        return card;
    }

    public async Task<IEnumerable<Card>> GetAllCardsAsync(int boardId)
    {
        return await _context.Cards
            .Where(c => c.BoardId == boardId)
            .ToListAsync();
    }
    
    public async Task<Card?> GetCardByIdAsync(int id)
    {
        return await _context.Cards
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    
    
    public async Task<Card?> UpdateCardAsync(Card card)
    {
        var existingCard = await _context.Cards.FindAsync(card.Id);
        if (existingCard != null)
        {
            existingCard.Title = card.Title;
            existingCard.Description = card.Description;
            existingCard.DueDate = card.DueDate;
            existingCard.BoardId = card.BoardId;
            await _context.SaveChangesAsync();
            return existingCard;
        }
        return null;
    }
    
    public async Task<bool> DeleteCardAsync(int cardId)
    {
        var card = await _context.Cards.FindAsync(cardId);
        if (card != null)
        {
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}