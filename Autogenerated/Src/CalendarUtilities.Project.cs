using System;
using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.DB;
using System.Linq;
using System.Collections.Generic;
using BPMSoft.Configuration;
using BPMSoft.Core.Entities;
using BPMSoft.UI.WebControls.Controls;
using System.Collections.ObjectModel;



public static class CalendarUtilities {
	public static int GetWorkingTimeBetweenDates(DateTime startDate, DateTime endDate, UserConnection userConnection) {
		return GetWorkingDays(startDate, endDate) * 8 * 60;
	}
	public static int GetWorkingDays(DateTime startDate, DateTime endDate) {
		startDate = startDate.ToLocalTime().Date;
		endDate = endDate.ToLocalTime().Date;
		
		if (startDate > endDate) {
			throw new ArgumentException("Incorrect last day " + endDate);
		}
		
		return  Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
			.Select(offset => startDate.AddDays(offset))
			.Where(day => day.DayOfWeek != System.DayOfWeek.Saturday && day.DayOfWeek != System.DayOfWeek.Sunday)
			.Count();
	}
}
