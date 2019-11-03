using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Pages.Objective
{
	public class ListObjective : BasePage
	{
		protected Data.Models.Objective[] Objectives;
		private ApplicationUser _user;

		protected Expression<Func<Data.Models.Objective, bool>> AllFilter
		{
			get
			{
				var param = Expression.Parameter(typeof(Data.Models.Objective), "obj");
				return Expression.Lambda<Func<Data.Models.Objective, bool>>(Expression.And(Expression.NotEqual(
						Expression.Property(param, "Player"),
						Expression.Constant(_user)), Expression.IsFalse(Expression.Property(param, "Done")))
					, param);
			}
		}

		protected Expression<Func<Data.Models.Objective, bool>> MyFilter
		{
			get
			{
				var param = Expression.Parameter(typeof(Data.Models.Objective), "obj");
				return Expression.Lambda<Func<Data.Models.Objective, bool>>(Expression.And(Expression.Equal(
						Expression.Property(param, "Player"),
						Expression.Constant(_user)), Expression.IsFalse(Expression.Property(param, "Done")))
					, param);
			}
		}

		protected static Expression<Func<Data.Models.Objective, bool>> DoneFilter
		{
			get
			{
				var param = Expression.Parameter(typeof(Data.Models.Objective), "obj");
				return Expression.Lambda<Func<Data.Models.Objective, bool>>(Expression.IsTrue(Expression.Property(param, "Done"))
					, param);
			}
		}

		protected static Expression<Func<Data.Models.Objective, bool>> ResetFilter
		{
			get
			{
				var param = Expression.Parameter(typeof(Data.Models.Objective), "obj");
				return Expression.Lambda<Func<Data.Models.Objective, bool>>(Expression.Constant(true), param);
			}
		}

		protected override async Task OnInitializedAsync()
		{
			_user = UserManager.Users.FirstOrDefault(u =>
				u.UserName == HttpContextAccessor.HttpContext.User.Identity.Name);
			Objectives = await ObjectiveRepository.GetList();
		}
	}
}