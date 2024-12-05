using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RankingApp.Data.Models;

namespace RankingApp.Data
{
	// DB와 연결하는 중간역할
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
	{
		// 테이블에 연동시켜주기 위함
		public DbSet<GameResult> GameResults { get; set; }

	}
}
