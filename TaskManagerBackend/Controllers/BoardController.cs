using Microsoft.AspNetCore.Mvc;
using TaskManagerBackend.Models;
using TaskManagerBackend.Repositories;
namespace TaskManagerBackend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BoardController : ControllerBase
{
    private readonly IBoardRepository _boardRepository;

    public BoardController(IBoardRepository boardRepository)
    {
        _boardRepository = boardRepository;
    }
    
    [HttpGet("all-boards/{projectId}")]
    public async Task<IActionResult> GetBoardByProjectId(int projectId)
    {
        var boardsList = await _boardRepository.GetBoardsByProjectIdAsync(projectId);
        return Ok(boardsList);
    }

    [HttpGet("board/{boardId}")]
    public async Task<IActionResult> GetBoardById(int boardId)
    {
        var board = await _boardRepository.GetBoardByIdAsync(boardId);
        return Ok(board);
    }

    [HttpDelete("delete-board/{boardId}")]
    public async Task<IActionResult> DeleteBoard(int boardId)
    {
        var result = await _boardRepository.DeleteBoardAsync(boardId);
        if (result)
        {
            return Ok(new { message = "Board deleted successfully." });
        }
        else
        {
            return NotFound(new { message = "Board not found." });
        }
    }

    [HttpPost("create-board")]
    public async Task<IActionResult> CreateBoard([FromBody] BoardCreateRequest request)
    {
        if (string.IsNullOrEmpty(request.Title) || request.ProjectId <= 0)
        {
            return BadRequest(new { message = "Invalid title or project ID." });
        }
        var result = await _boardRepository.CreateBoardAsync(request.Title, request.ProjectId, request.Cards);
        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return StatusCode(500, new { message = "An error occurred while creating the board." });
        }
    }
}