using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Pages.GameRequest
{
	public class ListGameRequest : BasePage
	{
		protected Data.Models.GameRequest[] GameRequests;
		private ApplicationUser _user;
		protected Expression<Func<Data.Models.GameRequest, bool>> AllFilter
		{
			get
			{
				var param = Expression.Parameter(typeof(Data.Models.GameRequest), "gr");
				return Expression.Lambda<Func<Data.Models.GameRequest, bool>>(Expression.And(Expression.NotEqual(
						Expression.Property(param, "Player"),
						Expression.Constant(_user)), Expression.IsFalse(Expression.Property(param, "Expired")))
					, param);
			}
		}

		protected Expression<Func<Data.Models.GameRequest, bool>> MyFilter
		{
			get
			{
				var param = Expression.Parameter(typeof(Data.Models.GameRequest), "gr");
				return Expression.Lambda<Func<Data.Models.GameRequest, bool>>(Expression.And(Expression.Equal(
						Expression.Property(param, "Player"),
						Expression.Constant(_user)), Expression.IsFalse(Expression.Property(param, "Expired")))
					, param);
			}
		}

		protected static Expression<Func<Data.Models.GameRequest, bool>> ExpiredFilter
		{
			get
			{
				var param = Expression.Parameter(typeof(Data.Models.GameRequest), "gr");
				return Expression.Lambda<Func<Data.Models.GameRequest, bool>>(
					Expression.IsTrue(Expression.Property(param, "Expired"))
					, param);
			}
		}

		protected static Expression<Func<Data.Models.GameRequest, bool>> ResetFilter
		{
			get
			{
				var param = Expression.Parameter(typeof(Data.Models.GameRequest), "gr");
				return Expression.Lambda<Func<Data.Models.GameRequest, bool>>(Expression.Constant(true), param);
			}
		}

		protected override async Task OnInitializedAsync()
		{
			_user = UserManager.Users.FirstOrDefault(u =>
				u.UserName == HttpContextAccessor.HttpContext.User.Identity.Name);
			GameRequests = await GameRequestRepository.GetList();
		}
	}
}