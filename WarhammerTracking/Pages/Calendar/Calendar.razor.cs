using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using FluentDateTime;

namespace WarhammerTracking.Pages.Calendar
{
	public class CalendarPage : BasePage
	{
		protected static IEnumerable<DayOfWeek> Days
		{
			get
			{
				var days = new List<DayOfWeek>();
				var firstDay = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
				for (var dayIndex = 0; dayIndex < 7; dayIndex++)
				{
					days.Add((DayOfWeek)(((int) firstDay + dayIndex) % 7));
				}
				return days;
			}	
		}
		protected List<DateTime> Dates { get; set; }
		protected DateTime CurrentDate { get; set; }
		protected Data.Models.Game[] Games { get; set; }
		protected Data.Models.GameRequest[] GameRequests { get; set; }
		protected Data.Models.Objective[] Objectives { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Games = await GameRepository.GetList();
			GameRequests = await GameRequestRepository.GetList();
			Objectives = await ObjectiveRepository.GetList();
			CurrentDate = DateTime.Today;
			GetDates();
		}

		private void GetDates()
		{
			Dates = new List<DateTime>();
			var firstday = CurrentDate.FirstDayOfMonth().Previous(CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
			var lastday = CurrentDate.LastDayOfMonth().Previous(CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek).AddDays(6);
			for (var date = firstday; date <= lastday; date = date.AddDays(1))
			{
				Dates.Add(date);
			}
		}

		protected void PreviousMonth()
		{
			CurrentDate = CurrentDate.AddMonths(-1);
			GetDates();
			StateHasChanged();
		}

		protected void NextMonth()
		{
			CurrentDate = CurrentDate.AddMonths(1);
			GetDates();
			StateHasChanged();
		}

		protected IEnumerable<Data.Models.Game> GetGames(DateTime date)
		{
			return Games.Where(g => g.Date.Date == date.Date);
		}

		protected IEnumerable<Data.Models.GameRequest> GetGameRequests(DateTime date)
		{
			return GameRequests.Where(g => g.Date.Date == date.Date);
		}

		protected IEnumerable<Data.Models.Objective> GetObjectives(DateTime date)
		{
			return Objectives.Where(g => g.Date.Date == date.Date);
		}
	}
}