using Microsoft.AspNetCore.Mvc;
using SharedData.Models;
using WebApi.Data;

namespace WebApi.Controllers
{
	// REST (Representational State Transfer)
	// 공식 표준 스펙은 아님
	// 원래 있던 HTTP 통신에서 기능을 재사용해서 데이터 송수신 규칙을 만든 것으로 이해하면된다

	// Create
	// POST  /api/ranking
	// -- 아이템 생성 요청 (Body에 실제 정보)

	// Read
	// GET  /api/ranking
	// -- 모든 아이템 주세요
	// GET  /api/ranking/1
	// -- id=1인 아이템 주세요

	// Update
	// PUT  /api/ranking 
	// -- 아이템 갱신 요청 (Body에 실제 정보)

	// Delete
	// DELETE  /api/ranking/1
	// -- id=1인 아이템 삭제


	// ApiController 특징
	// 그냥 C# 객체를 반환해도 된다
	// null 반환하면 -> 클라이언트에 204 Response (No Content)
	// string -> text/plain
	// 나머지 (int, bool) -> application/json

	[Route("api/[controller]")]
	[ApiController]
	public class RankingController : ControllerBase
	{
		ApplicationDbContext _context;

		public RankingController(ApplicationDbContext context)
		{
			_context = context;
		}

		// Create

		// Read
		[HttpGet]
		public List<GameResult> GetGameResults()
		{
			List<GameResult> results = _context.GameResults
					.OrderByDescending(item => item.Score)
					.ToList();

			return results;
		}

		[HttpGet("{id}")]
		public GameResult GetGameResult(int id)
		{
			GameResult result = _context.GameResults
					.Where(item => item.Id == id)
					.FirstOrDefault();

			return result;
		}
		// Update

		// Delete
	}
}
