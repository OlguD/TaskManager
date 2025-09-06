using TaskManagerBackend.Models;
namespace TaskManagerBackend.Repositories;

public interface ICardRepository
{
    Task<Card> AddCardAsync(Card card);
    Task<IEnumerable<Card>> GetAllCardsAsync(int userId);
    Task<Card?> GetCardByIdAsync(int id);
    Task<Card?> UpdateCardAsync(Card card);
    Task<bool> DeleteCardAsync(int cardId);
}