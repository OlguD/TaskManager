using Microsoft.AspNetCore.Mvc;
using TaskManagerBackend.Repositories;
using TaskManagerBackend.Models;
namespace TaskManagerBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardRepository _cardRepository;
    
    public CardController(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }
    
    [HttpGet("get-card/{cardId}")]
    public async Task<IActionResult> GetCardById(int cardId)
    {
        var card = await _cardRepository.GetCardByIdAsync(cardId);
        if (card == null)
        {
            return NotFound();
        }
        return Ok(card);
    }
    
    [HttpGet("get-all-cards/{userId}")]
    public async Task<IActionResult> GetAllCards(int userId)
    {
        var cards = await _cardRepository.GetAllCardsAsync(userId);
        return Ok(cards);
    }
    
    
    [HttpPost("create-card/{boardId}")]
    public async Task<IActionResult> CreateCard(Card card)
    {
        if (card == null)
        {
            return BadRequest();
        }

        var createdCard = new Card
        {
            Title = card.Title,
            Description = card.Description,
            DueDate = card.DueDate,
            BoardId = card.BoardId,
            Board = card.Board
        };

        var result = await _cardRepository.AddCardAsync(createdCard);
        return Ok(result);
    }
    
    
    [HttpPut("update-card/{cardId}")]
    public async Task<IActionResult> UpdateCard(Card card)
    {
        if (card == null)
        {
            return BadRequest();
        }
        var updatedCard = await _cardRepository.UpdateCardAsync(card);
        if (updatedCard == null) return NotFound();
        return Ok(updatedCard);
    }
    
    
    [HttpDelete("delete-card/{cardId}")]
    public async Task<IActionResult> DeleteCard(int cardId)
    {
        var deletedCard = await _cardRepository.DeleteCardAsync(cardId);
        if (!deletedCard) return NotFound();
        return Ok(new { message = "Card deleted successfully" });
    }
}