using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Pages.Game
{
	public class ListGame : BasePage
	{
		protected IEnumerable<Data.Models.Game> Games;
		private ApplicationUser _user;

		protected static string[] FilterList =>
			new[] {"Player1Name", "Player2Name", "ArmyPlayer1Name", "ArmyPlayer2Name", "Date"};

		protected Expression<Func<Data.Models.Game, bool>> MyFilter
		{
			get
			{
				var param = Expression.Parameter(typeof(Data.Models.Game), "gr");
				return Expression.Lambda<Func<Data.Models.Game, bool>>(Expression.Or(Expression.Equal(
						Expression.Property(param, "Player1"),
						Expression.Constant(_user)), Expression.Equal(
						Expression.Property(param, "Player2"),
						Expression.Constant(_user)))
					, param);
			}
		}

		protected static Expression<Func<Data.Models.Game, bool>> ResetFilter
		{
			get
			{
				var param = Expression.Parameter(typeof(Data.Models.Game), "gr");
				return Expression.Lambda<Func<Data.Models.Game, bool>>(Expression.Constant(true), param);
			}
		}

		protected Expression<Func<Data.Models.Game, bool>> WinningFilter
		{
			get
			{
				var param = Expression.Parameter(typeof(Data.Models.Game), "gr");
				return Expression.Lambda<Func<Data.Models.Game, bool>>(Expression.Or(
					Expression.And(
						Expression.Equal(Expression.Property(param, "Player1Id"), Expression.Constant(_user.Id)),
						Expression.GreaterThan(Expression.Property(param, "ScorePlayer1"),
							Expression.Property(param, "ScorePlayer2"))),
					Expression.And(
						Expression.Equal(Expression.Property(param, "Player2Id"), Expression.Constant(_user.Id)),
						Expression.GreaterThan(Expression.Property(param, "ScorePlayer2"),
							Expression.Property(param, "ScorePlayer1")))
				), param);
			}
		}

		protected Expression<Func<Data.Models.Game, bool>> LosingFilter
		{
			get
			{
				var param = Expression.Parameter(typeof(Data.Models.Game), "gr");
				return Expression.Lambda<Func<Data.Models.Game, bool>>(Expression.Or(Expression.And(Expression.Equal(
							Expression.Property(param, "Player1Id"), Expression.Constant(_user.Id)),
						Expression.GreaterThan(Expression.Property(param, "ScorePlayer2"),
							Expression.Property(param, "ScorePlayer1"))),
					Expression.And(
						Expression.Equal(Expression.Property(param, "Player2Id"), Expression.Constant(_user.Id)),
						Expression.GreaterThan(Expression.Property(param, "ScorePlayer1"),
							Expression.Property(param, "ScorePlayer2")))
				), param);
			}
		}

		protected Expression<Func<Data.Models.Game, bool>> DrawFilter
		{
			get
			{
				var param = Expression.Parameter(typeof(Data.Models.Game), "gr");
				return Expression.Lambda<Func<Data.Models.Game, bool>>(Expression.Or(Expression.And(Expression.Equal(
							Expression.Property(param, "Player1Id"), Expression.Constant(_user.Id)),
						Expression.Equal(Expression.Property(param, "ScorePlayer2"),
							Expression.Property(param, "ScorePlayer1"))),
					Expression.And(
						Expression.Equal(Expression.Property(param, "Player2Id"), Expression.Constant(_user.Id)),
						Expression.Equal(Expression.Property(param, "ScorePlayer1"),
							Expression.Property(param, "ScorePlayer2")))
				), param);
			}
		}

		protected override async Task OnInitializedAsync()
		{
			_user = UserManager.Users.FirstOrDefault(u =>
				u.UserName == HttpContextAccessor.HttpContext.User.Identity.Name);
			Games = await GameRepository.GetList();
		}
	}
}