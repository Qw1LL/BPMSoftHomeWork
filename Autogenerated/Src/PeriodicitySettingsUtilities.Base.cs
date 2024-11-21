namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Scheduler;
	using Quartz;
	using Quartz.Impl.Triggers;
	using Quartz.Impl.Calendar;
	using System.Collections.Generic;

	public class PeriodicitySettingsUtilities
	{
		private UserConnection _userConnection;
		private PeriodicitySettings _periodicity;

		public PeriodicitySettingsUtilities(UserConnection userConnection, Guid periodicitySettingsRecordUId) {
			_userConnection = userConnection;
			_periodicity = new PeriodicitySettings(userConnection);
			if (!_periodicity.FetchFromDB(periodicitySettingsRecordUId)) {
				throw new BPMSoft.Configuration.ItemNotFoundException(_userConnection, 
					periodicitySettingsRecordUId.ToString(), "PeriodicitySettings");
			}
		}

		public void CreateTrigger(string jobName, string jobGroup, string processName, string solutionName,
			string userName) {
			CreateTrigger(jobName, jobGroup, processName, solutionName, userName, null);
		}

		public void CreateTrigger(string jobName, string jobGroup, string processName, string solutionName, 
				string userName, string schedulerName) {
			var scheduler = AppScheduler.GetSchedulerOrDefault(schedulerName);
			AppScheduler.RemoveJob(jobName, jobGroup, scheduler);
			IJobDetail job = AppScheduler.CreateProcessJob(jobName, jobGroup, processName, solutionName, userName);
			AbstractTrigger trigger = null;
			string triggerName = jobName + "Trigger";
			string triggerGroup = jobGroup;
			TimeSpan dailyFrom = _periodicity.CustomFrom.TimeOfDay;
			TimeSpan dailyTill = _periodicity.CustomTill.TimeOfDay;
			DateTime schedulerStart = _periodicity.SchedulerStart;
			TimeSpan schedulerStartTime = schedulerStart.TimeOfDay;
			DateTime? schedulerFinish = null;
			bool isSchedulerEndless = _periodicity.IsSchedulerEndless;
			if (!isSchedulerEndless) {
				schedulerFinish = _periodicity.SchedulerFinish;	
			}
			_periodicity.IsDaily = true; // (Temporary for beta-version)  
			bool isOncePerDay = _periodicity.IsOnce; 
			bool isManyTimesPerDay = _periodicity.IsCustom;

			const string cronAll = "*";
			const string cronLast= "L";
			const string cronNoSpecific = "?";

			TimeSpan syncTime = _periodicity.OnceAt.TimeOfDay;
			TimeSpan repeatInterval = TimeSpan.Zero;
			if (isOncePerDay) { 
				if (schedulerStartTime > syncTime) {
					DateTime schedulerStartNextDay = schedulerStart.AddDays(1);
					schedulerStart = new DateTime(schedulerStartNextDay.Year, schedulerStartNextDay.Month, schedulerStartNextDay.Day,
						syncTime.Hours, syncTime.Minutes, syncTime.Seconds);
				}
			} else if (isManyTimesPerDay) {
				if (schedulerStartTime > dailyFrom) {
					DateTime schedulerStartNextDay = schedulerStart.AddDays(1);
					schedulerStart = new DateTime(schedulerStartNextDay.Year, schedulerStartNextDay.Month, schedulerStartNextDay.Day,
						dailyFrom.Hours, dailyFrom.Minutes, dailyFrom.Seconds);
				}

				var customPeriodType = (HoursOrMinutes)_periodicity.CustomPeriodType;
				int periodCount = _periodicity.CustomPeriod;
				if (customPeriodType == HoursOrMinutes.Hours) {
					repeatInterval = new TimeSpan(0, periodCount, 0, 0);
				} else if (customPeriodType == HoursOrMinutes.Minutes) {
					repeatInterval = new TimeSpan(0, 0, periodCount, 0);
				} else {
					throw new ArgumentException("Custom interval type is invalid");
				}
			}

			int repeatToEndOfDateInterval = int.MaxValue;
			DailyCalendar dailyCalendar = null;
			const string calendarName = "FromTillPeriodicityDailyCalendar";
			if (isManyTimesPerDay) {
				bool calendarAlreadyExists = false;
				foreach (var name in scheduler.GetCalendarNames()) {
					if (name == calendarName) {
						calendarAlreadyExists = true;
						break;
					}
				}
				if (!calendarAlreadyExists) {
					//dailyCalendar = new DailyCalendar(dailyFrom.ToString("c"), dailyTill.ToString("c"));
					dailyCalendar = new DailyCalendar(_periodicity.CustomFrom.TimeOfDay.ToString("c"), _periodicity.CustomTill.TimeOfDay.ToString("c"));
					dailyCalendar.TimeZone = _userConnection.CurrentUser.TimeZone;
					scheduler.AddCalendar(calendarName, dailyCalendar, false, false);
				}
			}

			if (_periodicity.IsDaily) {	
				int daysCount = 1; // Temporary for beta-version. Must be: //int daysCount = _periodicity.DailyPeriod;
				if (isOncePerDay) {
					trigger = new SimpleTriggerImpl(triggerName, triggerGroup, 
						schedulerStart, schedulerFinish, repeatToEndOfDateInterval, new TimeSpan(daysCount, 0, 0, 0));
				} else if (isManyTimesPerDay) {
					if (daysCount == 1) {
						trigger = new SimpleTriggerImpl(triggerName, triggerGroup,
								schedulerStart, schedulerFinish, repeatToEndOfDateInterval, repeatInterval);
						trigger.CalendarName = calendarName;
					} else {
						var multiTrigger = new List<SimpleTriggerImpl>();
						DateTime currDate = schedulerStart;
						DateTime stopDate = isSchedulerEndless ? currDate.AddYears(5) : schedulerFinish.Value;
						while (currDate <= stopDate) {
							var currDateEnd = new DateTime(currDate.Year, currDate.Month, currDate.Day,
								dailyTill.Hours, dailyTill.Minutes, dailyTill.Seconds);
							if (currDateEnd > stopDate) {
								currDateEnd = stopDate;
							}
							var multiTriggerPart = new SimpleTriggerImpl(triggerName, triggerGroup,
								currDate, currDateEnd, repeatToEndOfDateInterval, repeatInterval);
							multiTriggerPart.CalendarName = calendarName;
							multiTrigger.Add(multiTriggerPart);
							if (currDate == schedulerStart) { // is first?
								// Set TimeSpan from dailyFrom:
								currDate = new DateTime(currDate.Year, currDate.Month, currDate.Day,
									dailyFrom.Hours, dailyFrom.Minutes, dailyFrom.Seconds);
							}
							currDate.AddDays(daysCount);
						}
						foreach (var multiTriggerPart in multiTrigger) {
							multiTriggerPart.MisfireInstruction = MisfireInstruction.SimpleTrigger.FireNow;
							scheduler.ScheduleJob(job, trigger);
						}
					}
				}
			} else if (_periodicity.IsWeekly) {
				if (isOncePerDay) {
					string cronDayOfWeek = (_periodicity.DayOfWeek + 1).ToString();
					string cronExpression = GetCronExpression(syncTime, cronNoSpecific, cronAll, cronDayOfWeek);
					trigger = new CronTriggerImpl(triggerName, triggerGroup, jobName, jobGroup,
						schedulerStart, schedulerFinish, cronExpression);
				} else if (isManyTimesPerDay) {
					// multitrigger???
				}
			} else if (_periodicity.IsMonthly) {
				if (_periodicity.IsMonthlyCustom) {
					if (isOncePerDay) {
						string cronExpression = GetCronExpression(syncTime, _periodicity.DayOfMonth.ToString(), cronAll, cronNoSpecific);
						trigger = new CronTriggerImpl(triggerName, triggerGroup, jobName, jobGroup,
							schedulerStart, schedulerFinish, cronExpression);
					} else if (isManyTimesPerDay) {
						// multitrigger???
					}
				} else if (_periodicity.IsMonthlyLastDay) {
					if (isOncePerDay) {
						string cronExpression = GetCronExpression(syncTime, cronLast, cronAll, cronNoSpecific);
						trigger = new CronTriggerImpl(triggerName, triggerGroup, jobName, jobGroup,
							schedulerStart, schedulerFinish, cronExpression);
					} else if (isManyTimesPerDay) {
						// multitrigger???
					}
				}
			} 

			if (trigger != null) {
				trigger.MisfireInstruction = MisfireInstruction.SimpleTrigger.FireNow; // TODO: SimpleTrigger????
				scheduler.ScheduleJob(job, trigger);
			}
		}

		private string GetCronExpression(TimeSpan time, string cronDayOfMonth, string cronMonth, string cronDayOfWeek) {
				string cronSecond = time.Seconds.ToString();
				string cronMinute = time.Minutes.ToString();
				string cronHour = time.Hours.ToString();				
				string cronExpression = string.Format("{0} {1} {2} {3} {4} {5}", 
					cronSecond, cronMinute, cronHour, cronDayOfMonth, cronMonth, cronDayOfWeek);
				return cronExpression;
		}
	}

}

