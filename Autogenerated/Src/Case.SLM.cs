namespace BPMSoft.Configuration
{

	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: Case_SLMEventsProcess

	public partial class Case_SLMEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		public override string GetServiceCaption() {
			var serviceItemId = Entity.GetTypedColumnValue<Guid>("ServiceItemId");
			var serviceQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ServiceItem");
			serviceQuery.AddColumn("Name"); 
			var service = serviceQuery .GetEntity(UserConnection, serviceItemId);
			if(service == null) {
				return string.Empty;
			} 
			return service.GetTypedColumnValue<string>("Name"); 
		}

		public virtual void SaveLifecycle() {
			DateTime actionDate = UserConnection.CurrentUser.GetCurrentDateTime();
			bool isNotFirstDate = ClosePreviousInterval(Entity.GetTypedColumnValue<Guid>("Id"), actionDate);
			actionDate = isNotFirstDate ? UserConnection.CurrentUser.GetCurrentDateTime() : Entity.GetTypedColumnValue<DateTime>("RegisteredOn");
			OpenNewInterval(actionDate);
		}

		public virtual List<string> GetLoggingColumns() {
			return new List<string>() {
				"StatusId",
				"PriorityId",
				"ServiceItemId",
				"OwnerId",
				"GroupId",
				"SolutionDate",
				"SolutionProvidedOn"
			};
		}

		public virtual void CloseAllIntervals(Guid CaseId) {
			Select caseIntervalsSelect = new Select(UserConnection)
				.Column("CL", "Id")
				.Column("CL", "StartDate")
				.Column("CL", "EndDate")
				.From("CaseLifecycle").As("CL")
				.Where("CL", "CaseId").IsEqual(Column.Parameter(CaseId))
				.OrderByDesc("CL", "StartDate") as Select;
			Dictionary<Guid, DateTime> caseLifecycleRecordsToClose = new Dictionary<Guid, DateTime>();
			DateTime nextStartDate = default(DateTime);
			using(DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction(IsolationLevel.ReadCommitted);
				try {
					caseIntervalsSelect.ExecuteReader(r => {
						if (r.GetColumnValue<DateTime>("EndDate") == default(DateTime) && nextStartDate != default(DateTime)) {
							caseLifecycleRecordsToClose.Add(r.GetColumnValue<Guid>("Id"), nextStartDate);
						}
						nextStartDate = r.GetColumnValue<DateTime>("StartDate");
					});
					ForceCloseCaseLifecycleRecords(caseLifecycleRecordsToClose);
					dbExecutor.CommitTransaction();
				} catch {
					dbExecutor.RollbackTransaction();
				}
			}

		}

		public virtual void ForceCloseCaseLifecycleRecords(Dictionary<Guid, DateTime> caseLifecycleRecordsToClose) {
			caseLifecycleRecordsToClose.ForEach(record => {
				new Update(UserConnection, "CaseLifecycle")
					.Set("EndDate", Column.Parameter(record.Value))
					.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
					.Where("Id").IsEqual(Column.Parameter(record.Key)).Execute();
			});
		}

		public virtual bool ClosePreviousInterval(Guid CaseId, DateTime Date) {
			var previousIntervalESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "CaseLifecycle");
			previousIntervalESQ.UseAdminRights = false;
			previousIntervalESQ.AddAllSchemaColumns();
			previousIntervalESQ.AddColumn("StartDate").OrderByDesc();
			var caseRecordFilter = previousIntervalESQ.CreateFilterWithParameters(
					FilterComparisonType.Equal, "CaseRecordId", CaseId);
			if (UserConnection.GetIsFeatureEnabled("AddCaseColumnInLifecycleFilter")) {
				previousIntervalESQ.AddColumn("Case");
				var caseFilterGroup = new EntitySchemaQueryFilterCollection(previousIntervalESQ, LogicalOperationStrict.Or) {
					caseRecordFilter,
					previousIntervalESQ.CreateFilterWithParameters(
					FilterComparisonType.Equal, "Case", CaseId)
				};
				previousIntervalESQ.Filters.Add(caseFilterGroup);
			} else {
				previousIntervalESQ.Filters.Add(caseRecordFilter);
			}
			previousIntervalESQ.Filters.Add(previousIntervalESQ.CreateIsNullFilter("EndDate"));
			var previousIntervals = previousIntervalESQ.GetEntityCollection(UserConnection);
			if (previousIntervals.Count == 0) {
				return false;
			}
			var lastInterval = previousIntervals[0];
			lastInterval.UseAdminRights = false;
			DateTime startDate = lastInterval.GetTypedColumnValue<DateTime>("StartDate");
			TimeSpan difference = (TimeSpan)(Date-startDate);
			lastInterval.SetColumnValue("EndDate", Date);
			lastInterval.SetColumnValue("StateDurationInMinutes", difference.TotalMinutes);
			lastInterval.SetColumnValue("StateDurationInHours", difference.TotalHours);
			lastInterval.SetColumnValue("StateDurationInDays", difference.TotalDays);
			lastInterval.Save();
			ClosedCaseLifeCycleId = lastInterval.GetTypedColumnValue<Guid>("Id");
			if (previousIntervals.Count > 1 && UserConnection.GetIsFeatureEnabled("CheckAndCloseAllCaseIntervals")) {
				CloseAllIntervals(CaseId);
			}
			return true;
		}

		public virtual void OpenNewInterval(DateTime Date) {
			var entitySchemaCaseLifecycle = UserConnection.EntitySchemaManager.GetInstanceByName("CaseLifecycle");
			var newCaseLifecycle = entitySchemaCaseLifecycle.CreateEntity(UserConnection);
			newCaseLifecycle.UseAdminRights = false;
			newCaseLifecycle.SetDefColumnValues();
			newCaseLifecycle.SetColumnValue("StartDate", Date);
			newCaseLifecycle.SetColumnValue("CaseRecordId", Entity.GetColumnValue("Id"));
			newCaseLifecycle.Save();
			CreatedCaseLifecycleId = newCaseLifecycle.GetTypedColumnValue<Guid>("Id");

		}

		public virtual void LogChangedColumns() {
			var entitySchemaCaseLifecycle = UserConnection.EntitySchemaManager.GetInstanceByName("CaseLifecycle");
			var entitySchemaCase = UserConnection.EntitySchemaManager.GetInstanceByName("Case");
			var newCaseLifecycle = entitySchemaCaseLifecycle.CreateEntity(UserConnection);
			newCaseLifecycle.UseAdminRights = false;
			if (newCaseLifecycle.FetchFromDB(CreatedCaseLifecycleId)) {
				newCaseLifecycle.SetDefColumnValues();
				var disableCommonColumns = new List<string>() {
					"Id",
					"CreatedOn",
					"CreatedById"
				};
				var commonColumns = entitySchemaCaseLifecycle.Columns
					.Select(c=>new {Name = c.ColumnValueName, DataValueType = c.DataValueType})
					.Intersect(entitySchemaCase.Columns.Select(c=>new {Name = c.ColumnValueName, DataValueType = c.DataValueType}))
					.Select(c => c.Name)
					.Except(disableCommonColumns);
			
				foreach(string columnName in commonColumns) {
					newCaseLifecycle.SetColumnValue(columnName, Entity.GetColumnValue(columnName));
				}
				newCaseLifecycle.SetColumnValue("CaseId", Entity.GetColumnValue("Id"));
				newCaseLifecycle.Save();
			}
		}

		public virtual bool GetIsNeedToLogLifecycle() {
			var logColumns =(IEnumerable<string>) GetLoggingColumns();
			var changedValues = Entity.GetChangedColumnValues().Where(v => 
				((v.Value != null) && !v.Value.Equals(v.OldValue)) ||
				((v.Value == null) && v.OldValue != null)
			);
			return changedValues.Select(v => v.Name).Intersect(logColumns).Any();
		}

		public virtual bool GetIsStatusActive(Guid statusId) {
			var columns = new [] {
				"IsPaused",
				"IsFinal",
				"IsResolved"
			};
			return !GetStatusIs(statusId, columns);
		}

		public virtual bool CheckIsStatusChanged() {
			var statusIdColumnName = "StatusId";
			var oldStatusId = Entity.GetTypedOldColumnValue<Guid>(statusIdColumnName);
			var statusId = Entity.GetTypedColumnValue<Guid>(statusIdColumnName);
			return oldStatusId != statusId;
		}

		public virtual void NotifyUser() {
			if (StatusChanged) {
				ICasePushNotifier notifier = ClassFactory.Get<ICasePushNotifier>(new ConstructorArgument("userConnection", UserConnection));
				notifier.NotifyNewStatus(Entity.GetTypedColumnValue<Guid>("Id"));
			}
		}

		public virtual void UpdateResponse() {
			var statusIdColumnName = "StatusId";
			var oldStatusId = Entity.GetTypedOldColumnValue<Guid>(statusIdColumnName);
			var statusId = Entity.GetTypedColumnValue<Guid>(statusIdColumnName);
			if (oldStatusId == Guid.Empty || oldStatusId == statusId) {
				return;
			}
			var respondedOnColumnName = "RespondedOn";
			var respondedOn = Entity.GetTypedColumnValue<DateTime>(respondedOnColumnName);
			if (respondedOn == default(DateTime)) {
				var dateTimeNow = GetDateTimeInCurrentTimeZone();
				Entity.SetColumnValue(respondedOnColumnName, dateTimeNow);
			}
		}

		public virtual void UpdateSolution() {
			var statusIdColumnName = "StatusId";
			var oldStatusId = Entity.GetTypedOldColumnValue<Guid>(statusIdColumnName);
			var statusId = Entity.GetTypedColumnValue<Guid>(statusIdColumnName);
			if(oldStatusId == statusId) {
				return;
			}
			DateTime? nullValue = null;
			var isNewStatusFinalOrResolved = GetIsStatusFinalOrResolved(statusId);
			if (UserConnection.GetIsFeatureEnabled("CaseRuleApplier")) {
				if (!GetIsStatusActive(oldStatusId)) {
					var isOldStatusFinalOrResolved = GetIsStatusFinalOrResolved(oldStatusId);
					DateTime? dateTimeNow;
					if (isNewStatusFinalOrResolved || GetIsStatusPaused(statusId)) {
						if (isOldStatusFinalOrResolved) {
							return;
						}
						dateTimeNow = GetDateTimeInCurrentTimeZone();
					} else {
						dateTimeNow = nullValue;
					}
					Entity.SetColumnValue("SolutionProvidedOn", dateTimeNow);
				}
				if (GetIsStatusPaused(statusId) && !GetIsStatusResolved(oldStatusId)) {
					Entity.SetColumnValue("SolutionDate", nullValue);
				}
			} else {
				if (GetIsStatusPaused(statusId)) {
					Entity.SetColumnValue("SolutionDate", nullValue);
				}
				if (!GetIsStatusFinal(statusId) && GetIsStatusResolved(oldStatusId)) {
					Entity.SetColumnValue("SolutionProvidedOn", nullValue);
					if (UserConnection.GetIsFeatureEnabled("ClearSolutionDateAfterReopenCase")) {
						Entity.SetColumnValue("SolutionDate", nullValue);
					}
				}
				if (!GetIsStatusActive(oldStatusId)) {
					var isOldStatusFinalOrResolved = GetIsStatusFinalOrResolved(oldStatusId);
					DateTime? dateTimeNow;
					if (isNewStatusFinalOrResolved) {
						if (isOldStatusFinalOrResolved) {
							return;
						}
						dateTimeNow = GetDateTimeInCurrentTimeZone();
					} else {
						dateTimeNow = nullValue;
					}
					Entity.SetColumnValue("SolutionProvidedOn", dateTimeNow);
				}
			}
			if (isNewStatusFinalOrResolved) {
				SetCurrentDateTime("FirstSolutionProvidedOn");
				SetCurrentDateTime("SolutionProvidedOn");
			}
		}

		public virtual bool GetStatusIs(Guid statusId, params string [] columns) {
			var result = false;
						if (!UserConnection.GetIsFeatureEnabled("UseCaseStatusStore")) {
							var store = new CaseStatusStore(UserConnection);
							foreach (string column in columns) {
								switch (column) {
									case "IsPaused":
										result |= store.StatusIsPaused(statusId);
										break;
									case "IsFinal":
										result |= store.StatusIsFinal(statusId);
										break;
									case "IsResolved":
										result |= store.StatusIsResolved(statusId);
										break;
								}
							}
						} else {
							var select = new Select(UserConnection)
								.From("CaseStatus")
								.Where("Id").IsEqual(Column.Parameter(statusId)) as Select;
							foreach (var column in columns) {
								select = select.Column(column);
							}
							using (var dbExecutor = UserConnection.EnsureDBConnection()) {
								using (IDataReader dr = select.ExecuteReader(dbExecutor)) {
									if (dr.Read()) {
										foreach (var column in columns) {
											result |= dr.GetColumnValue<bool>(column);
										}
									}
								}
							}
						}
			return result;
		}

		public virtual bool GetIsStatusPaused(Guid statusId) {
			return GetStatusIs(statusId, "IsPaused");
		}

		public virtual bool GetIsStatusResolved(Guid statusId) {
			return GetStatusIs(statusId, "IsResolved");
		}

		public virtual bool GetIsStatusFinal(Guid statusId) {
			return GetStatusIs(statusId, "IsFinal");
		}

		public virtual bool GetIsStatusFinalOrResolved(Guid id) {
			var columns = new [] {
				"IsFinal",
				"IsResolved"
			};
			return GetStatusIs(id, columns);
		}

		public virtual DateTime GetDateTimeInCurrentTimeZone() {
			return TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.Utc, UserConnection.CurrentUser.TimeZone);
		}

		public virtual void UpdateClosureDate() {
			var statusId = Entity.GetTypedColumnValue<Guid>("StatusId");
			var closureDate = Entity.GetTypedColumnValue<DateTime>("ClosureDate");
			if (IsStatusChanged(Entity) && GetIsStatusFinal(statusId) && closureDate == default(DateTime)) {
				var currentUserDateTime = 
				CaseTimezoneHelper.GetContactTimezone(UserConnection, UserConnection.CurrentUser.ContactId.ToString());
				if (currentUserDateTime != null) {
					Entity.SetColumnValue("ClosureDate", DateTime.Parse(currentUserDateTime));
				}
			}
		}

		public virtual void SetCurrentDateTime(string dateTimeField) {
			if (Entity.GetTypedColumnValue<DateTime>(dateTimeField) == default(DateTime)) {
				var currentUserDateTime = 
				CaseTimezoneHelper.GetContactTimezone(UserConnection, UserConnection.CurrentUser.ContactId.ToString());
				if (currentUserDateTime != null) {
					Entity.SetColumnValue(dateTimeField, DateTime.Parse(currentUserDateTime));
				}
			}
		}

		public bool NeedCalculateTerms() {
			return UserConnection.GetIsFeatureEnabled("CalculateTermOnCaseEntity") &&
				Entity.StoringState != StoringObjectState.New &&
				IsStatusChanged(Entity) &&
				Entity.GetTypedColumnValue<DateTime>("SolutionDate") == DateTime.MinValue &&
				!GetIsStatusPaused(Entity.GetTypedColumnValue<Guid>("StatusId"));
		}

		public virtual void CalculateTerms() {
			if (NeedCalculateTerms()) {
				new CaseTermCalculationManager(UserConnection).Calculate(Entity);
			}
		}

		public virtual bool GetIsStatusWaiting(Guid statusId) {
			Guid waitingForResponseId = Guid.Parse("3859C6E7-CBCB-486B-BA53-77808FE6E593"); 
			return statusId.Equals(waitingForResponseId);
		}

		#endregion

	}

	#endregion

}

