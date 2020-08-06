using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class ApplicationDbContext : IdentityDbContext<User, AppRole, int>
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			
		}

		public ApplicationDbContext()
		{
		}

		

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source =.\SQLEXPRESS; Database = Kanban; Trusted_Connection = True;");
		}



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserBoards>()
								.HasKey(t => new
								{
									t.BoardId,
									t.UserId
								});

			modelBuilder.Entity<UserBoards>()
								.HasOne(ub => ub.Board)
								.WithMany(b => b.userBoards)
								.HasForeignKey(ub => ub.BoardId);

			modelBuilder.Entity<UserBoards>()
								.HasOne(ub => ub.User)
								.WithMany(b => b.userBoards)
								.HasForeignKey(ub => ub.UserId);

			modelBuilder.Entity<UserCards>()
								.HasKey(t => new
								{
									t.UserId,
									t.CardId
								});

			modelBuilder.Entity<UserCards>()
								.HasOne(uc => uc.Card)
								.WithMany(c => c.UserCards)
								.HasForeignKey(uc => uc.CardId);

			modelBuilder.Entity<UserCards>()
								.HasOne(uc => uc.User)
								.WithMany(c => c.UserCards)
								.HasForeignKey(uc => uc.UserId);

			modelBuilder.Entity<BoardRequest>()
								.HasKey(t => new
								{
									t.Id,
									t.BoardId,
									t.UserId
								});

			modelBuilder.Entity<BoardRequest>()
								.Property(f => f.Id)
								.ValueGeneratedOnAdd();

			modelBuilder.Entity<BoardRequest>()
								.HasOne(br => br.Board)
								.WithMany(b => b.BoardRequests)
								.HasForeignKey(br => br.BoardId);

			modelBuilder.Entity<BoardRequest>()
								.HasOne(br => br.User)
								.WithMany(b => b.BoardRequests)
								.HasForeignKey(br => br.UserId);


			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Board> Boards { get; set; }

		public DbSet<Column> Columns { get; set; }

		public DbSet<Card> Cards { get; set; }

		public DbSet<BoardRoles> BoardRoles { get; set; }

		public DbSet<BoardRequest> BoardRequests { get; set; }
	}
}
