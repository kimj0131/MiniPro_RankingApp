using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RankingApp.Data.Models;

namespace RankingApp.Data
{
	// DB�� �����ϴ� �߰�����
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
	{
		// ���̺� ���������ֱ� ����
		public DbSet<GameResult> GameResults { get; set; }

	}
}
