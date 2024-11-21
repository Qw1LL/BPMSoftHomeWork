namespace BPMSoft.Configuration.ProjectService
{
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Scheduler;
	using Quartz;
	using Quartz.Impl.Triggers;
	using System;
	using System.Data;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Web.Common;

	public class PeriodData
	{
		public DateTime startDate {get; set;}
		public DateTime endDate {get; set;}
	}

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ProjectService : BaseService
	{
		public ProjectService() : base() {}

		public ProjectService(UserConnection userConnection) : base(userConnection) {}

		#region Public: Support

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Guid GetRootProjectId(Guid projectId) {
			var children = HierarchicalProjectUtilities.GetParentProjectsIDs(projectId, UserConnection);
			return children.Last();
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void AddContactToProjectResourceElement(Guid projectId, Guid contactId, string contactName) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var projectStartDate = DateTime.Now;
			var contactInernalRate = 0;
			var contactExternalRate = 0;
			var baseProjectId = GetRootProjectId(projectId);
			var projectResourceElementSchema = UserConnection.EntitySchemaManager.FindInstanceByName("ProjectResourceElement");
			var workResourceElementSchema = UserConnection.EntitySchemaManager.FindInstanceByName("WorkResourceElement");
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Project");
			var startDateColumn = esq.AddColumn("StartDate");
			var project = esq.GetEntity(UserConnection, baseProjectId);
			if (project != null) {
				projectStartDate = project.GetTypedColumnValue<DateTime>(startDateColumn.Name);
			}
			esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactInternalRate");
			var rateColumn = esq.AddColumn("Rate");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", contactId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.LessOrEqual, "StartDate", projectStartDate));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.GreaterOrEqual, "DueDate", projectStartDate));
			var collection = esq.GetEntityCollection(UserConnection);
			if (collection.Count == 1) {
				var contactInternalRateEntity = collection.First();
				contactInernalRate = contactInternalRateEntity.GetTypedColumnValue<int>("Rate");
			}

			esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ContactExternalRate");
			rateColumn = esq.AddColumn("Rate");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", contactId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.LessOrEqual, "StartDate", projectStartDate));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.GreaterOrEqual, "DueDate", projectStartDate));
			collection = esq.GetEntityCollection(UserConnection);
			if (collection.Count == 1) {
				var contactInternalRateEntity = collection.First();
				contactExternalRate = contactInternalRateEntity.GetTypedColumnValue<int>("Rate");
			}
			esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ProjectResourceElement");
			esq.AddColumn("Id");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", contactId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Project", baseProjectId));
			collection = esq.GetEntityCollection(UserConnection);
			var projectResourceId = Guid.Empty;
			if (collection.Count == 0) {
				var projectResourceElement = projectResourceElementSchema.CreateEntity(UserConnection);
				projectResourceElement.SetDefColumnValues();
				projectResourceElement.SetColumnValue("ProjectId", baseProjectId);
				projectResourceElement.SetColumnValue("Name", contactName);
				projectResourceElement.SetColumnValue("ContactId", contactId);
				projectResourceElement.SetColumnValue("InternalRate", contactInernalRate);
				projectResourceElement.SetColumnValue("ExternalRate", contactExternalRate);
				projectResourceId = projectResourceElement.GetTypedColumnValue<Guid>("Id");
				projectResourceElement.Save();
			} else {
				var projectResourcesElement = collection.First();
				projectResourceId = projectResourcesElement.GetTypedColumnValue<Guid>("Id1");
			};
			if (projectId != baseProjectId) {
				esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WorkResourceElement");
				var Id = esq.AddColumn("Id");
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ProjectResourceElement", projectResourceId));
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", projectId));
				collection = esq.GetEntityCollection(UserConnection);
				if (collection.Count == 0) {
					var workResourceElement = workResourceElementSchema.CreateEntity(UserConnection);
					workResourceElement.SetDefColumnValues();
					workResourceElement.SetColumnValue("ProjectId", projectId);
					workResourceElement.SetColumnValue("ProjectResourceElementId", projectResourceId);
					workResourceElement.SetColumnValue("InternalRate", contactInernalRate);
					workResourceElement.SetColumnValue("ExternalRate", contactExternalRate);
					workResourceElement.SetColumnValue("PlanningWork", 0);
					workResourceElement.SetColumnValue("ActualWork", 0);
					workResourceElement.Save();
				};
			};
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool CheckOwnerInProjectActivity(Guid projectId, Guid contactId) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var baseProjectId = GetRootProjectId(projectId);
			var esq = new EntitySchemaQuery(entitySchemaManager, "ProjectResourceElement");
			var idColumn = esq.AddColumn("Id");
			var workColumn = esq.AddColumn("PlanningWork");
			var projectFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Project", baseProjectId);
			esq.Filters.Add(projectFilter);
			var contactFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", contactId);
			esq.Filters.Add(contactFilter);
			var entities = esq.GetEntityCollection(UserConnection);
			if (entities.Count > 0 && projectId != baseProjectId) {
				var projectResourcesElement = entities.First();
				var projectResourceId = projectResourcesElement.GetTypedColumnValue<Guid>("Id1");
				esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WorkResourceElement");
				esq.AddColumn("Id");
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ProjectResourceElement", projectResourceId));
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Project", projectId));
				var collection = esq.GetEntityCollection(UserConnection);
				return collection.Count > 0; 
			} else if (entities.Count > 0 && projectId == baseProjectId) {
				return true;
			} else {
				return false;
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetProjectParentsNames", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string[] GetProjectParentsNames(Guid projectId) {
			var collection = HierarchicalProjectUtilities.GetParentProjectsNames(projectId, UserConnection);
			collection.Reverse();
			return collection.ToArray();
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateProjectPosition", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool UpdateProjectPosition(Guid projectId, int offset) {
			var projectPosition = 0;
			var tableESQ = UserConnection.EntitySchemaManager.GetInstanceByName("Project");
			var entity = tableESQ.CreateEntity(UserConnection);
			if (entity.FetchFromDB(projectId)) {
				projectPosition = entity.GetTypedColumnValue<int>("Position");
			}
			projectPosition = projectPosition + offset < 0 ? 0 : projectPosition + offset;
			StoredProcedure setRecordPositionProcedure =
				new StoredProcedure(UserConnection, "tsp_SetRecordPosition")
				.WithParameter("TableName", "Project")
				.WithParameter("PrimaryColumnName", "Id")
				.WithParameter("PrimaryColumnValue", projectId)
				.WithParameter("GrouppingColumnNames", "ParentProjectId")
				.WithParameter("Position", projectPosition) as StoredProcedure;
			setRecordPositionProcedure.PackageName = UserConnection.DBEngine.SystemPackageName;
			setRecordPositionProcedure.Execute();
			return true;
		}
		
		#endregion

		#region Public: Calculate Finance

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CalculateProjectFinanceByProjectId(Guid projectId) {
			CalculateProjectFinance(projectId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CalculateProjectFinanceByProjectCollection(List<Guid> projects) {
			foreach (Guid projectId in projects) {
				CalculateProjectFinanceByProjectId(projectId);
			}
		}

		#endregion

		#region Public: CalcPlan

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CalculateProjectLaborPlanByProjectId(Guid projectId) {
			var children = HierarchicalProjectUtilities.GetParentProjectsIDs(projectId, UserConnection);
			CalculateProjectLaborPlan(projectId, children.Last());
			UpdateProjectResource(children.Last());
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CalculateProjectLaborPlanByProjectCollection(List<Guid> projects) {
			foreach (Guid projectId in projects) {
				CalculateProjectLaborPlanByProjectId(projectId);
			}
		}

		#endregion

		#region Public: CalcActual

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CalculateProjectActualWorkByProjectId(Guid projectId) {
			CalculateProjectActualWork(projectId);
			var children = HierarchicalProjectUtilities.GetParentProjectsIDs(projectId, UserConnection);
			UpdateProjectResource(children.Last());
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CalculateProjectActualWorkByProjectCollection(List<Guid> projects, bool withSheduler = false) {
			foreach (Guid projectId in projects) {
				CalculateProjectActualWorkByProjectId(projectId);
			}
			if (withSheduler) {
				StartProjectCalculateActualWorkSheduler();
			}
		}

		#endregion

		#region Public: ProjectDate

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ChangeProjectDates", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ChangeProjectDates(Guid[] records, double daysCount) {
			var projectESQ = GetProjectESQ(UserConnection);
			var projects = new List<Guid>();
			foreach(var record in records) {
				projects.AddRange(HierarchicalProjectUtilities.GetChildProjectsIDs(record, UserConnection));
			}
			var filter = projectESQ.CreateFilterWithParameters(FilterComparisonType.Equal,
				projectESQ.RootSchema.GetPrimaryColumnName(), projects.Select(x => (object)x).ToArray());
			projectESQ.Filters.Add(filter);
			ModifyProjectDates(projectESQ.GetEntityCollection(UserConnection), daysCount);
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SyncronizeProjectActualStartDate", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SyncronizeProjectActualStartDate(Guid projectId) {
			var startDate = GetProjectActivitiesMinStartDate(projectId);
			UpdateProjectActualStartDate(projectId, startDate);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SyncronizeProjectActualEndDate", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SyncronizeProjectActualEndDate(Guid projectId) {
			var isProjectStatusFinished = CheckProjectStatus(projectId);
			if (isProjectStatusFinished) {
				var endDate = GetProjectActivitiesMaxEndDate(projectId);
				UpdateProjectActualEndDate(projectId, endDate);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetActualProjectEndDate", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetActualProjectEndDate(Guid projectId) {
			return HierarchicalProjectUtilities.GetActualProjectEndDate(projectId, UserConnection).ToString("yyyy-MM-dd'T'HH:mm:ss");
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetWorkingTimeBetweenDates", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public int GetWorkingTimeBetweenDates(string data) {
			PeriodData date = (PeriodData)BPMSoft.Common.Json.Json.Deserialize(data, typeof(PeriodData));
			return CalendarUtilities.GetWorkingTimeBetweenDates(date.startDate, date.endDate, UserConnection);
		}
		
		#endregion

		#region toDELETE

		/*[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "DeleteProjectManhour", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool DeleteProjectManhour(Guid projectId, Guid roleId, decimal planningWork) {
			var canDelete = GetCanUpdateManhour(projectId, roleId, 0);
			if (canDelete) {
				(new Delete(UserConnection)
					.From("ProjectManhour")
					.Where("ProjectId")
						.IsEqual(Column.Parameter(projectId))
					.And("RoleId")
						.IsEqual(Column.Parameter(roleId))
					.And("PlanningWork")
						.IsEqual(Column.Parameter(planningWork)) as Delete).Execute();
			}
			return canDelete;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RoleInProjectExists", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool RoleInProjectExists(Guid projectId, Guid roleId, Guid oldRoleId, decimal planningWork, decimal oldPlanningWork, bool isNew) {
			var syncronized = false;
			var duplicate = false;
			var projectManhourSelect = new Select(UserConnection)
					.Column(Func.Count(Column.Parameter(1)))
				.From("ProjectManhour")
				.Where("ProjectId")
					.IsEqual(Column.Parameter(projectId))
				.And("RoleId")
					.IsEqual(Column.Parameter(oldRoleId))
				.And("PlanningWork")
					.IsEqual(Column.Parameter(oldPlanningWork)) as Select;
			syncronized = projectManhourSelect.ExecuteScalar<int>() == 1;
			if (syncronized && !roleId.Equals(oldRoleId)) {
				projectManhourSelect = new Select(UserConnection)
						.Column(Func.Count(Column.Parameter(1)))
					.From("ProjectManhour")
					.Where("ProjectId")
						.IsEqual(Column.Parameter(projectId))
					.And("RoleId")
						.IsEqual(Column.Parameter(roleId)) as Select;
				duplicate = projectManhourSelect.ExecuteScalar<int>() == 1;
			}
			if (!syncronized) {
				projectManhourSelect = new Select(UserConnection)
						.Column(Func.Count(Column.Parameter(1)))
					.From("ProjectManhour")
					.Where("ProjectId")
						.IsEqual(Column.Parameter(projectId))
					.And("RoleId")
						.IsEqual(Column.Parameter(oldRoleId))
					.And("PlanningWork")
						.Not().IsEqual(Column.Parameter(oldPlanningWork)) as Select;
				duplicate = projectManhourSelect.ExecuteScalar<int>() != 0;
			}
			return duplicate;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SyncronizeProjectManhour", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool SyncronizeProjectManhour(Guid projectId, Guid roleId, Guid oldRoleId, decimal planningWork, decimal oldPlanningWork, bool isNew) {
			if (isNew) {
				var internalRateSelect = new Select(UserConnection)
						.Column("InternalRate")
					.From("ProjectRole")
					.Where("Id")
						.IsEqual(Column.Parameter(roleId)) as Select;
				var externalRateSelect = new Select(UserConnection)
						.Column("ExternalRate")
					.From("ProjectRole")
					.Where("Id")
						.IsEqual(Column.Parameter(roleId)) as Select;
				(new Insert(UserConnection)
						.Into("ProjectManhour")
					.Set("PlanningWork", Column.Parameter(planningWork))
					.Set("InternalRate", internalRateSelect)
					.Set("ExternalRate", externalRateSelect)
					.Set("ProjectId", Column.Parameter(projectId))
					.Set("RoleId", Column.Parameter(roleId)) as Insert).Execute();
			} else {
				if (planningWork - oldPlanningWork >= 0) {
					(new Update(UserConnection, "ProjectManhour")
						.Set("PlanningWork", Column.Parameter(planningWork))
						.Set("RoleId", Column.Parameter(roleId))
						.Where("ProjectId")
							.IsEqual(Column.Parameter(projectId))
						.And("RoleId")
							.IsEqual(Column.Parameter(oldRoleId))
						.And("PlanningWork")
							.IsEqual(Column.Parameter(oldPlanningWork)) as Update).Execute();
				} else {
					var canUpdate = GetCanUpdateManhour(projectId, oldRoleId, planningWork);
					if (canUpdate) {
						(new Update(UserConnection, "ProjectManhour")
							.Set("PlanningWork", Column.Parameter(planningWork))
							.Set("RoleId", Column.Parameter(roleId))
							.Where("ProjectId")
								.IsEqual(Column.Parameter(projectId))
							.And("RoleId")
								.IsEqual(Column.Parameter(oldRoleId))
							.And("PlanningWork")
								.IsEqual(Column.Parameter(oldPlanningWork)) as Update).Execute();
					} else {
						return false;
					}
				}
			}
			return true;
		}*/

		#endregion

		#region Private: CalcActual

		public void StartProjectCalculateActualWorkSheduler() {
			string schedulerJobGroupName = "ProjectCalculateGroup";
			string jobProcessName = "CalculateProjectCollectionActualWorkSheduler";
			string schedulerJobName = "ProjectCalculateJob_" + jobProcessName;
			DateTime startTime = DateTime.Now.ToUniversalTime();
			AppScheduler.RemoveJob(schedulerJobName, schedulerJobGroupName);
			var job = AppScheduler.CreateProcessJob(schedulerJobName, schedulerJobGroupName, 
			jobProcessName, UserConnection.Workspace.Name, UserConnection.CurrentUser.Name);
			string daysStr = "MON,TUE,WED,THU,FRI,SAT,SUN";
			string cronExpression = string.Format("0 {0} {1} ? * {2}", 0, 11, daysStr);
			var trigger = new CronTriggerImpl(schedulerJobName + "Trigger", schedulerJobGroupName, cronExpression);
			trigger.MisfireInstruction = MisfireInstruction.CronTrigger.DoNothing;
			trigger.TimeZone = TimeZoneInfo.Utc;
			AppScheduler.Instance.ScheduleJob(job, trigger);
		}

		#endregion

		private void ModifyProjectDates(EntityCollection projects, double daysCount) {
			if (projects.Count > 0) {
				foreach(var project in projects) {
					var startDate = project.GetTypedColumnValue<DateTime>("StartDate");
					var endDate = project.GetTypedColumnValue<DateTime>("EndDate");
					if(startDate != DateTime.MinValue) {
						try {
							project.SetColumnValue("StartDate", startDate.AddDays(daysCount));
						} catch {}
					}
					if(endDate != DateTime.MinValue) {
						try {
							project.SetColumnValue("EndDate", endDate.AddDays(daysCount));
						} catch {}
					}
					project.Save();
				}
			}
		}

		private EntitySchemaQuery GetProjectESQ(UserConnection UserConnection) {
			var projectESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Project");
			projectESQ.AddAllSchemaColumns();
			return projectESQ;
		}

		private bool GetCanUpdateManhour(Guid projectId, Guid roleId, decimal planningWork) {
			var childProjectsSelect = new Select(UserConnection)
					.Column("Id")
				.From("Project")
				.Where("ParentProjectId")
					.IsEqual(Column.Parameter(projectId)) as Select;
			var childProjectManhoursSelect = new Select(UserConnection)
					.Column(Func.Sum("PlanningWork"))
				.From("ProjectManhour")
				.Where("ProjectId")
					.In(childProjectsSelect) 
				.And("RoleId")
					.IsEqual(Column.Parameter(roleId)) as Select;
			var sum = childProjectManhoursSelect.ExecuteScalar<int>();
			return planningWork >= sum;
		}

		private DateTime GetProjectActivitiesMinStartDate(Guid projectId) {
			var projects = HierarchicalProjectUtilities.GetChildProjectsIDs(projectId, UserConnection).Select(x => new QueryParameter(x));
			var finishedStatusesSelect = new Select(UserConnection)
					.Column("Id")
				.From("ActivityStatus")
				.Where("Code")
					.IsEqual(Column.Parameter("Finished")) as Select;
			var finishedActivitiesSelect = new Select(UserConnection)
					.Column(Func.Min("StartDate"))
				.From("Activity")
				.Where("ProjectId")
					.In(projects)
				.And("StatusId")
					.In(finishedStatusesSelect) as Select;
			return finishedActivitiesSelect.ExecuteScalar<DateTime>();
		}

		private DateTime GetProjectActivitiesMaxEndDate(Guid projectId) {
			var projects = HierarchicalProjectUtilities.GetChildProjectsIDs(projectId, UserConnection).Select(x => new QueryParameter(x));
			var finishedStatusesSelect = new Select(UserConnection)
					.Column("Id")
				.From("ActivityStatus")
				.Where("Code")
					.IsEqual(Column.Parameter("Finished")) as Select;
			var finishedActivitiesSelect = new Select(UserConnection)
					.Column(Func.Max("DueDate"))
				.From("Activity")
				.Where("ProjectId")
					.In(projects)
				.And("StatusId")
					.In(finishedStatusesSelect) as Select;
			return finishedActivitiesSelect.ExecuteScalar<DateTime>();
		}

		private void UpdateProjectActualStartDate(Guid projectId, DateTime date) {
			var projects = HierarchicalProjectUtilities.GetParentProjectsIDs(projectId, UserConnection).Select(x => new QueryParameter(x));
			if (date.Ticks == 0) {
				(new Update(UserConnection, "Project")
					.Set("ActualStartDate", Column.Const(null))
					.Where("Id")
						.In(projects) as Update).Execute();
			} else {
				(new Update(UserConnection, "Project")
					.Set("ActualStartDate", Column.Parameter(date))
					.Where("Id")
						.In(projects) as Update).Execute();
			}
		}

		private void UpdateProjectActualEndDate(Guid projectId, DateTime date) {
			var projects = HierarchicalProjectUtilities.GetParentProjectsIDs(projectId, UserConnection).Select(x => new QueryParameter(x));
			var finalProjectStatusesSelect = new Select(UserConnection)
					.Column("Id")
				.From("ProjectStatus")
				.Where("IsFinal")
					.IsEqual(Column.Const(true)) as Select;
			if (date.Ticks == 0) {
				(new Update(UserConnection, "Project")
					.Set("ActualEndDate", Column.Const(null))
					.Where("Id")
						.In(projects) as Update).Execute();
			} else {
				(new Update(UserConnection, "Project")
					.Set("ActualEndDate", Column.Parameter(date))
					.Where("Id")
						.In(projects)
					.And("StatusId")
						.In(finalProjectStatusesSelect) as Update).Execute();
			}
		}

		private bool CheckProjectStatus(Guid projectId) {
			var projectStatusSelect = new Select(UserConnection)
					.Column("StatusId")
				.From("Project")
				.Where("Id")
					.IsEqual(Column.Parameter(projectId)) as Select;
			var isProjectFinishedSelect = new Select(UserConnection)
					.Column(Func.Count(Column.Const(1)))
				.From("ProjectStatus")
				.Where("Id")
					.IsEqual(projectStatusSelect)
				.And("IsFinal")
					.IsEqual(Column.Const(true)) as Select;
			return isProjectFinishedSelect.ExecuteScalar<int>() == 1;
		}

		private void CalculateProjectFinance(Guid projectId) {
			var children = HierarchicalProjectUtilities.GetChildProjectsIDs(projectId, UserConnection);
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var activityWork = new List<FinanceActivityItem>();
			var cashflowDebitPlan = 0m;
			var cashflowDebitFact = 0m;
			var cashflowOutlayPlan = 0m;
			var cashflowOutlayFact = 0m;
			var planSmetha = 0m;
			var factSmetha = 0m;
			var planSeb = 0m;
			var factSeb = 0m;
			var estimatedCostFact = 0m;
			var costFact = 0m;
			var financeActivity = new FinanceActivity(UserConnection, projectId);

			#region Children

			/*var esq = new EntitySchemaQuery(entitySchemaManager, "Project");
			var idColumn = esq.AddColumn(esq.RootSchema.GetPrimaryColumnName());
			var parentFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ParentProject", projectId);
			esq.Filters.Add(parentFilter);
			var childEntities = esq.GetEntityCollection(UserConnection);
			if (childEntities.Count > 0) {
				foreach(var childEntity in childEntities) {
					var childId = childEntity.GetTypedColumnValue<Guid>(idColumn.Name);
					CalculateProjectFinance(childId);
				}
			}*/

			#endregion

			#region Cashflow

			var debitTypeId = new Guid("34A47BED-5CC6-4CF7-B81B-719F2915D263");
			var outlayTypeId = new Guid("D566F91A-FB87-4BFE-AA8F-0DE66F392ACE");
			var acceptStatusId = new Guid("7526510F-DEDB-42F0-BCDC-331955B0C91D");
			var budgetStatusId = new Guid("D65CD806-9092-41D3-8F4E-3C862515793A");
			var esqCashflow = new EntitySchemaQuery(entitySchemaManager, "Cashflow");
			var statusColumn = esqCashflow.AddColumn("Status");
			var typeColumn = esqCashflow.AddColumn("Type");
			var primaryAmountColumn = esqCashflow.AddColumn("PrimaryAmount");
			var projectCashflowFilter = esqCashflow.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Project", children.Select(x => (object)x).ToArray());
			esqCashflow.Filters.Add(projectCashflowFilter);
			var cashflowEntities = esqCashflow.GetEntityCollection(UserConnection);
			if (cashflowEntities.Count > 0) {
				foreach(var cashflowEntity in cashflowEntities) {
					var primaryAmount = cashflowEntity.GetTypedColumnValue<decimal>(primaryAmountColumn.Name);
					var statusSchemaColumn = cashflowEntity.Schema.Columns.GetByName(statusColumn.Name);
					var statusId = cashflowEntity.GetTypedColumnValue<Guid>(statusSchemaColumn.ColumnValueName);
					var typeSchemaColumn = cashflowEntity.Schema.Columns.GetByName(typeColumn.Name);
					var typeId = cashflowEntity.GetTypedColumnValue<Guid>(typeSchemaColumn.ColumnValueName);
					if (typeId == debitTypeId) {
						if (statusId == acceptStatusId) {
							cashflowDebitFact += primaryAmount;
						}
						if (statusId == budgetStatusId) {
							cashflowDebitPlan += primaryAmount;
						}
					} else if (typeId == outlayTypeId) {
						if (statusId == acceptStatusId) {
							cashflowOutlayFact += Math.Abs(primaryAmount);
						}
						if (statusId == budgetStatusId) {
							cashflowOutlayPlan += Math.Abs(primaryAmount);
						}
					}
				}
			}

			#endregion

			#region ProjectResourceElement

			var esqManhour = new EntitySchemaQuery(entitySchemaManager, "ProjectResourceElement");
			var manhourPlanningWorkColumn = esqManhour.AddColumn("PlanningWork");
			var manhourActualWorkColumn = esqManhour.AddColumn("ActualWork");
			var manhourExternalRateColumn = esqManhour.AddColumn("ExternalRate");
			var manhourInternalRateColumn = esqManhour.AddColumn("InternalRate");

			var projectManhourFilter = esqManhour.CreateFilterWithParameters(FilterComparisonType.Equal, "Project", projectId);
			esqManhour.Filters.Add(projectManhourFilter);
			var manhourEntities = esqManhour.GetEntityCollection(UserConnection);
			if (manhourEntities.Count > 0) {
				foreach(var manhourEntity in manhourEntities) {
					var planningWork = manhourEntity.GetTypedColumnValue<decimal>(manhourPlanningWorkColumn.Name);
					var actualWork = manhourEntity.GetTypedColumnValue<decimal>(manhourActualWorkColumn.Name);
					var externalRate = manhourEntity.GetTypedColumnValue<decimal>(manhourExternalRateColumn.Name);
					var internalRate = manhourEntity.GetTypedColumnValue<decimal>(manhourInternalRateColumn.Name);
					planSmetha += planningWork * externalRate;
					planSeb += planningWork * internalRate;
					estimatedCostFact += actualWork * externalRate;
					costFact += actualWork * internalRate;
				}
			}

			#endregion

			#region WorkResourceElement

			var workResourceElementESQ = new EntitySchemaQuery(entitySchemaManager, "WorkResourceElement");
			var teamProjectWorkColumn = workResourceElementESQ.AddColumn("Project.Id");
			var teamContactWorkColumn = workResourceElementESQ.AddColumn("ProjectResourceElement.Contact.Id");
			var teamExternalRateColumn = workResourceElementESQ.AddColumn("ProjectResourceElement.ExternalRate");
			var teamInternalRateColumn = workResourceElementESQ.AddColumn("ProjectResourceElement.InternalRate");

			var projectTeamFilter = workResourceElementESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "Project", children.Select(x => (object)x).ToArray());
			workResourceElementESQ.Filters.Add(projectTeamFilter);
			var teamEntities = workResourceElementESQ.GetEntityCollection(UserConnection);
			if (teamEntities.Count > 0) {
				foreach(var teamEntity in teamEntities) {
					var teamProjectId = teamEntity.GetTypedColumnValue<Guid>(teamProjectWorkColumn.Name);
					var teamContactId = teamEntity.GetTypedColumnValue<Guid>(teamContactWorkColumn.Name);
					var work = financeActivity.SumByProjectAndOwner(teamProjectId, teamContactId);
					if (work > 0) {
						var externalRate = teamEntity.GetTypedColumnValue<decimal>(teamExternalRateColumn.Name);
						var internalRate = teamEntity.GetTypedColumnValue<decimal>(teamInternalRateColumn.Name);
						factSmetha += work * externalRate;
						factSeb += work * internalRate;
					}
				}
			}

			#endregion

			#region ProjectActualCompletion

			UpdateProjectActualCompletion(projectId);

			#endregion

			#region Calculate & Save

			decimal debitDif = cashflowDebitFact - cashflowDebitPlan;
			decimal debitDifPercent = CalcPercent(debitDif, cashflowDebitPlan);
			decimal estimatedCostPlan = Math.Round(planSmetha, 2);
//			decimal estimatedCostFact = Math.Round(factSmetha, 2);
			decimal estimatedCostDif = estimatedCostFact - estimatedCostPlan;
			decimal estimatedCostDifPercent = CalcPercent(estimatedCostDif, estimatedCostPlan);
			decimal outlayDif = cashflowOutlayFact - cashflowOutlayPlan;
			decimal outlayDifPercent = CalcPercent(outlayDif, cashflowOutlayPlan);
			decimal costPlan = Math.Round(planSeb);
//			decimal costFact = Math.Round(factSeb);
			decimal costDif = costFact - costPlan;
			decimal costDifPercent = CalcPercent(costDif, costPlan);
			decimal marginPlan = cashflowDebitPlan - cashflowOutlayPlan - costPlan;
			decimal marginPlanPercent = CalcPercent(marginPlan, cashflowDebitPlan);
			decimal marginFact = cashflowDebitFact - cashflowOutlayFact - costFact;
			decimal marginFactPercent = CalcPercent(marginFact, cashflowDebitFact);
			decimal marginDif = marginFact - marginPlan;
			decimal marginDifPercent = CalcPercent(marginDif, marginPlan);
			var update = new Update(UserConnection, "Project")
//1
					.Set("PlanIncome", Column.Parameter(cashflowDebitPlan))
					.Set("FactIncome", Column.Parameter(cashflowDebitFact))
					.Set("IncomeDev", Column.Parameter(debitDif))
					.Set("IncomeDevPerc", Column.Parameter(debitDifPercent))
//2
					.Set("PlanExpense", Column.Parameter(cashflowOutlayPlan))
					.Set("FactExpense", Column.Parameter(cashflowOutlayFact))
					.Set("ExpenseDev", Column.Parameter(outlayDif))
					.Set("ExpenseDevPerc", Column.Parameter(outlayDifPercent))
//3
					.Set("PlanExternalCost", Column.Parameter(estimatedCostPlan))
					.Set("FactExternalCost", Column.Parameter(estimatedCostFact))
					.Set("ExternalCostDev", Column.Parameter(estimatedCostDif))
					.Set("PlanExternalDevPerc", Column.Parameter(estimatedCostDifPercent))
//4
					.Set("PlanInternalCost", Column.Parameter(costPlan))
					.Set("FactInternalCost", Column.Parameter(costFact))
					.Set("InternalCostDev", Column.Parameter(costDif))
					.Set("PlanInternalDevPerc", Column.Parameter(costDifPercent))
//5
					.Set("PlanMargin", Column.Parameter(marginPlan))
					.Set("PlanMarginPerc", Column.Parameter(marginPlanPercent))
					.Set("FactMargin", Column.Parameter(marginFact))
					.Set("FactMarginPerc", Column.Parameter(marginFactPercent))
//6
					.Set("MarginDev", Column.Parameter(marginDif))
					.Set("MarginDevPerc", Column.Parameter(marginDifPercent))

				.Where("Id").IsEqual(Column.Parameter(projectId)) as Update;
			update.Execute();

			#endregion
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		private decimal GetProjectActualCompletion(Guid projectId) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var projectEsq = new EntitySchemaQuery(entitySchemaManager, "Project");
			var projectEntryTypeColumn = projectEsq.AddColumn("ProjectEntryType.Id");
			var project = projectEsq.GetEntity(UserConnection, projectId);
			if (project != null) {
				var projectEntryTypeId = project.GetTypedColumnValue<Guid>(projectEntryTypeColumn.Name);
				var entityName = (projectEntryTypeId.Equals(Guid.Parse("6B4928D7-456A-4ACD-A863-3361D46B7649"))) ? "ProjectResourceElement" : "WorkResourceElement";
				var workResourceElementEsq = new EntitySchemaQuery(entitySchemaManager, entityName);
				var planningSum = workResourceElementEsq.CreateAggregationFunction(AggregationTypeStrict.Sum, "PlanningWork");
				var actualSum = workResourceElementEsq.CreateAggregationFunction(AggregationTypeStrict.Sum, "ActualWork");
				var planningSumColumn = workResourceElementEsq.AddColumn(planningSum);
				var actualSumColumn = workResourceElementEsq.AddColumn(actualSum);
				var projectFilter = workResourceElementEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Project", projectId);
				workResourceElementEsq.Filters.Add(projectFilter);
				var workResourceElements = workResourceElementEsq.GetEntityCollection(UserConnection);
				foreach (var workResourceElement in workResourceElements) {
					var planningWorkSum = workResourceElement.GetTypedColumnValue<decimal>(planningSumColumn.Name);
					var actualWorkSum = workResourceElement.GetTypedColumnValue<decimal>(actualSumColumn.Name);
					if (planningWorkSum == 0) {
						return planningWorkSum;
					}
					if (actualWorkSum > planningWorkSum) {
						return 100m;
					}
					return actualWorkSum / planningWorkSum * 100;
				}
			}
			return 0m;
		}

		private void UpdateProjectActualCompletion(Guid projectId) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var projectEsq = new EntitySchemaQuery(entitySchemaManager, "Project");
			var idColumn = projectEsq.AddColumn(projectEsq.RootSchema.GetPrimaryColumnName());
			var isAutoCalcCompletionColumn = projectEsq.AddColumn("IsAutoCalcCompletion");
			var projectEntryTypeColumn = projectEsq.AddColumn("ProjectEntryType.Id");
			var project = projectEsq.GetEntity(UserConnection, projectId);
			if (project != null) {
				var isAutoCalcCompletion = project.GetTypedColumnValue<bool>(isAutoCalcCompletionColumn.Name);
				if (isAutoCalcCompletion) {
					var actualCompletion = GetProjectActualCompletion(projectId);
					var update = new Update(UserConnection, "Project")
							.Set("ActualCompletion", Column.Parameter(actualCompletion))
						.Where("Id").IsEqual(Column.Parameter(projectId)) as Update;
					update.Execute();
				}
			}
		}

		private decimal CalcPercent(decimal var1, decimal var2) {
			var result = 0m;
			if (var2 != 0) {
				result = Math.Round((var1 / var2) * 100, 2);
			}
			return result;
		}

		private void CalculateProjectLaborPlan(Guid projectId, Guid rootProjectId) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var esq = new EntitySchemaQuery(entitySchemaManager, "Project");
			var idColumn = esq.AddColumn(esq.RootSchema.GetPrimaryColumnName());
			var parentFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ParentProject", projectId);
			esq.Filters.Add(parentFilter);
			var childEntities = esq.GetEntityCollection(UserConnection);
			if (childEntities.Count > 0) {
				foreach(var childEntity in childEntities) {
					var childId = childEntity.GetTypedColumnValue<Guid>(idColumn.Name);
					CalculateProjectLaborPlan(childId, rootProjectId);
				}
			}

			if (childEntities.Count > 0 && projectId != rootProjectId) {
				var childWorkResources = PlanningWorkFromWorkResourceElementByProjectId(projectId, "Project.ParentProject");
				var workResources = PlanningWorkFromWorkResourceElementByProjectId(projectId, "Project", true);

				var childKeysList = new List<Guid>(childWorkResources.Keys);
				var currentKeysList = new List<Guid>(workResources.Keys);

				var updateKeyList = currentKeysList.Intersect(childKeysList).ToList();
				var deleteKeyList = currentKeysList.Except(childKeysList).ToList();

				foreach (var projectResourceId in updateKeyList) {
					var workResource = workResources[projectResourceId];
					var childWorkResource = childWorkResources[projectResourceId];
					LaborPlanWorkResourceElementUpdate(workResource.Id, childWorkResource.work);
				}
				foreach (var projectResourceId in deleteKeyList) {
					var workResource = workResources[projectResourceId];
					if (!workResource.hasActivity) {
						LaborPlanWorkResourceElementDelete(workResource.Id);
					}
				}
			}
		}

		private Dictionary<Guid, PlanProjectResource> PlanningWorkFromWorkResourceElementByProjectId(Guid projectId, string filterPath, bool activityCheck = false) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			Dictionary<Guid, PlanProjectResource> workResources = new Dictionary<Guid, PlanProjectResource>();
			var esq = new EntitySchemaQuery(entitySchemaManager, "WorkResourceElement");
			var idColumn = esq.AddColumn("Id");
			var projectResourceColumn = esq.AddColumn("ProjectResourceElement.Id");
			var contactIdColumn = esq.AddColumn("ProjectResourceElement.Contact.Id");
			var workColumn = esq.AddColumn("PlanningWork");
			var projectFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, filterPath, projectId);
			esq.Filters.Add(projectFilter);
			var entities = esq.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				foreach(var entitiy in entities) {
					Guid recordId = entitiy.GetTypedColumnValue<Guid>(idColumn.Name);
					Guid projectResourceId = entitiy.GetTypedColumnValue<Guid>(projectResourceColumn.Name);
					Guid contactId = entitiy.GetTypedColumnValue<Guid>(contactIdColumn.Name);
					decimal work = entitiy.GetTypedColumnValue<decimal>(workColumn.Name);
					if (workResources.ContainsKey(projectResourceId)) {
						workResources[projectResourceId].work += work;
					} else {
						workResources.Add(projectResourceId, new PlanProjectResource() {
							work = work,
							Id = recordId,
							ContactId = contactId
						});
					}
				}
			}
			if (activityCheck) {
				var activityDuration = GetContactActualWorkFromActivityByProjectId(projectId, filterPath, false);
				foreach (var item in workResources) {
					if (item.Value.ContactId == null || item.Value.ContactId == Guid.Empty) {
						continue;
					}
					item.Value.hasActivity = activityDuration.ContainsKey(item.Value.ContactId);
				}
			}
			return workResources;
		}

		private void LaborPlanWorkResourceElementUpdate(Guid workResourceId, decimal PlanningWork) {
			var update = new Update(UserConnection, "WorkResourceElement")
				.Set("PlanningWork", Column.Parameter(PlanningWork))
				.Where("Id").IsEqual(Column.Parameter(workResourceId)) as Update;
			update.Execute();
		}

		private void LaborPlanWorkResourceElementDelete(Guid workResourceId) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema workResourceElementSchema = entitySchemaManager.GetInstanceByName("WorkResourceElement");
			var entityToSave = workResourceElementSchema.CreateEntity(UserConnection);
			if (entityToSave.FetchFromDB(workResourceElementSchema.GetPrimaryColumnName(), workResourceId)) {
				entityToSave.Delete();
			}
		}

		private Dictionary<Guid, decimal> GetContactActualWorkFromActivityByProjectId(Guid projectId, string filterPath = "Project", bool finishedOnly = true) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var finishedStatusId = new Guid("4BDBB88F-58E6-DF11-971B-001D60E938C6");
			var activityDuration = new Dictionary<Guid, decimal>();
			var esqActivity = new EntitySchemaQuery(entitySchemaManager, "Activity");
			var ownerActivityColumn = esqActivity.AddColumn("Owner");
			var workActivityColumn = esqActivity.AddColumn("DurationInMinutes");
			var activityProjectFilter = esqActivity.CreateFilterWithParameters(FilterComparisonType.Equal,
				filterPath, projectId);
			esqActivity.Filters.Add(activityProjectFilter);
			if (finishedOnly) {
				var activityStatusFilter = esqActivity.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Status", finishedStatusId);
				esqActivity.Filters.Add(activityStatusFilter);
			}
			var activityEntities = esqActivity.GetEntityCollection(UserConnection);
			if (activityEntities.Count > 0) {
				foreach(var activityEntity in activityEntities) {
					var ownerSchemaColumn = activityEntity.Schema.Columns.GetByName(ownerActivityColumn.Name);
					Guid contactId = activityEntity.GetTypedColumnValue<Guid>(ownerSchemaColumn.ColumnValueName);
					decimal work = activityEntity.GetTypedColumnValue<decimal>(workActivityColumn.Name);
					work = Math.Round(work / 60, 2);
					if (contactId != null && contactId != Guid.Empty) {
						if (activityDuration.ContainsKey(contactId)) {
							activityDuration[contactId] += work;
						} else {
							activityDuration.Add(contactId, work);
						}
					}
				}
			}
			return activityDuration;
		}

		public void UpdateProjectResource(Guid projectId) {

			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var resourceList = GetProjectResourceList(projectId);
			var workResList = new Dictionary<Guid, ProjectResourceItem>();
			var projectResourceElementSchema = entitySchemaManager.GetInstanceByName("ProjectResourceElement");
			var workResourceElementSchema = entitySchemaManager.GetInstanceByName("WorkResourceElement");
			var esq = new EntitySchemaQuery(entitySchemaManager, "WorkResourceElement");
			var idColumn = esq.AddColumn("ProjectResourceElement.Id");
			var planningWorkColumn = esq.AddColumn("PlanningWork");
			var actualWorkColumn = esq.AddColumn("ActualWork");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Project.ParentProject", projectId));
			var entities = esq.GetEntityCollection(UserConnection);
			foreach(var entity in entities) {
				Guid elementId = entity.GetTypedColumnValue<Guid>(idColumn.Name);
				decimal actualWork = entity.GetTypedColumnValue<decimal>(actualWorkColumn.Name);
				decimal planningWork = entity.GetTypedColumnValue<decimal>(planningWorkColumn.Name);
				if (workResList.ContainsKey(elementId)) {
					workResList[elementId].ActualWork += actualWork;
					workResList[elementId].PlanningWork += planningWork;
				} else {
					workResList.Add(elementId, new ProjectResourceItem() { 
						PlanningWork = planningWork,
						ActualWork = actualWork
					});
				}
			}

			foreach (var element in resourceList) {
				if (!workResList.ContainsKey(element.Key) && (element.Value.PlanningWork != 0m || element.Value.ActualWork != 0m)) {
					element.Value.ActualWork = 0m;
					element.Value.PlanningWork = 0m;
					element.Value.needUpdate = true;
				}
				if (workResList.ContainsKey(element.Key) && (element.Value.PlanningWork != workResList[element.Key].PlanningWork ||
					element.Value.ActualWork != workResList[element.Key].ActualWork)) {
					element.Value.ActualWork = workResList[element.Key].ActualWork;
					element.Value.PlanningWork = workResList[element.Key].PlanningWork;
					element.Value.needUpdate = true;
				}
//				if (element.Value.needUpdate) {
					var entityToSave = projectResourceElementSchema.CreateEntity(UserConnection);
					if (entityToSave.FetchFromDB(projectResourceElementSchema.GetPrimaryColumnName(), element.Key)) {
						var planningWork = element.Value.PlanningWork;
						var actualWork = element.Value.ActualWork + GetProjectActualWork(entityToSave);
						entityToSave.SetColumnValue("PlanningWork", planningWork);
						entityToSave.SetColumnValue("ActualWork", actualWork);
						entityToSave.Save();
					}
//				}
			}
		}

		private decimal GetProjectActualWork(Entity projectResourceElement) {
			var projectId = projectResourceElement.GetTypedColumnValue<Guid>("ProjectId");
			var contactId = projectResourceElement.GetTypedColumnValue<Guid>("ContactId");
			var esqActivity = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Activity");
			var esqActivityDurationInMinutesColumn = esqActivity.AddColumn("DurationInMinutes");
			var projectActivityFilter = esqActivity.CreateFilterWithParameters(FilterComparisonType.Equal, "Project", projectId);
			esqActivity.Filters.Add(projectActivityFilter);
			var ownerActivityFilter = esqActivity.CreateFilterWithParameters(FilterComparisonType.Equal, "Owner", contactId);
			esqActivity.Filters.Add(ownerActivityFilter);
			var statusFilter = esqActivity.CreateFilterWithParameters(FilterComparisonType.Equal, "Status", Guid.Parse("4BDBB88F-58E6-DF11-971B-001D60E938C6"));
			esqActivity.Filters.Add(statusFilter);
			var activityEntities = esqActivity.GetEntityCollection(UserConnection);
			var work = 0m;
			foreach(var activityEntity in activityEntities) {
				work += activityEntity.GetTypedColumnValue<decimal>(esqActivityDurationInMinutesColumn.Name);
			}
			return Math.Round(work / 60, 2);
		}

		private Dictionary<Guid, ProjectResourceItem> GetProjectResourceList(Guid projectId) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var resourceList = new Dictionary<Guid, ProjectResourceItem>();
			var esqRes = new EntitySchemaQuery(entitySchemaManager, "ProjectResourceElement");
			var idColumn = esqRes.AddColumn("Id");
			var planningWorkColumn = esqRes.AddColumn("PlanningWork");
			var actualWorkColumn = esqRes.AddColumn("ActualWork");
			esqRes.Filters.Add(esqRes.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Project", projectId));
			var entities = esqRes.GetEntityCollection(UserConnection);
			foreach(var entity in entities) {
				Guid elementId = entity.GetTypedColumnValue<Guid>(idColumn.Name);
				decimal actualWork = entity.GetTypedColumnValue<decimal>(actualWorkColumn.Name);
				decimal planningWork = entity.GetTypedColumnValue<decimal>(planningWorkColumn.Name);
				resourceList.Add(elementId, new ProjectResourceItem() { 
					PlanningWork = planningWork,
					ActualWork = actualWork
				});
			}
			return resourceList;
		}

		private void CalculateProjectActualWork(Guid projectId) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var childWorkResourceElement = new Dictionary<Guid, ActualProjectResource>();
			var activityDuration = GetContactActualWorkFromActivityByProjectId(projectId);

			#region Children

			if (true) {
				var esq = new EntitySchemaQuery(entitySchemaManager, "Project");
				var idColumn = esq.AddColumn(esq.RootSchema.GetPrimaryColumnName());
				var parentFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ParentProject", projectId);
				esq.Filters.Add(parentFilter);
				var childEntities = esq.GetEntityCollection(UserConnection);
				foreach(var childEntity in childEntities) {
					var childId = childEntity.GetTypedColumnValue<Guid>(idColumn.Name);
					CalculateProjectActualWork(childId);
				}
			}

			#endregion

			#region WorkResourceElement

			if (true) {
				var esq = new EntitySchemaQuery(entitySchemaManager, "WorkResourceElement");
				var projectResourceIdColumn = esq.AddColumn("ProjectResourceElement.Id");
				var contactIdColumn = esq.AddColumn("ProjectResourceElement.Contact.Id");
				var workColumn = esq.AddColumn("ActualWork");
				var parentChildrenManhoursFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Project.ParentProject", projectId);
				esq.Filters.Add(parentChildrenManhoursFilter);
				var entities = esq.GetEntityCollection(UserConnection);
				foreach(var entity in entities) {
					var projectResourceId = entity.GetTypedColumnValue<Guid>(projectResourceIdColumn.Name);
					var work = entity.GetTypedColumnValue<decimal>(workColumn.Name);
					var contactId = entity.GetTypedColumnValue<Guid>(contactIdColumn.Name);
					if (contactId == null || contactId == Guid.Empty) {
						continue;
					}
					if (childWorkResourceElement.ContainsKey(projectResourceId)) {
						childWorkResourceElement[projectResourceId].work += work;
					} else {
						childWorkResourceElement.Add(projectResourceId, new ActualProjectResource() { 
							ContactId = contactId,
							work = work
						});
					}
				}
			}

			#endregion

			#region Apply Changes 

			if (true) {
				var workResourceElementSchema = entitySchemaManager.GetInstanceByName("WorkResourceElement");
				var esq = new EntitySchemaQuery(entitySchemaManager, "WorkResourceElement");
				var idColumn = esq.AddColumn("Id");
				var projectResourceElementIdColumn = esq.AddColumn("ProjectResourceElement.Id");
				var contactIdColumn = esq.AddColumn("ProjectResourceElement.Contact.Id");
				var workColumn = esq.AddColumn("ActualWork");
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Project", projectId));
				var workResourceEntities = esq.GetEntityCollection(UserConnection);
				if (workResourceEntities.Count > 0) {
					foreach(var workResourceEntity in workResourceEntities) {
						Guid projectResourceElementId = workResourceEntity.GetTypedColumnValue<Guid>(projectResourceElementIdColumn.Name);
						decimal work = workResourceEntity.GetTypedColumnValue<decimal>(workColumn.Name);
						Guid contactId = workResourceEntity.GetTypedColumnValue<Guid>(contactIdColumn.Name);
						Guid recordId = workResourceEntity.GetTypedColumnValue<Guid>(idColumn.Name);
						if (contactId == null || contactId == Guid.Empty) {
							continue;
						}

						var acutalWork = 0m;
						if (childWorkResourceElement.ContainsKey(projectResourceElementId)) {
							acutalWork += childWorkResourceElement[projectResourceElementId].work;
						}
						if (activityDuration.ContainsKey(contactId)){
							acutalWork += activityDuration[contactId];
						}
						if (work != acutalWork) {
							var entityToSave = workResourceElementSchema.CreateEntity(UserConnection);
							if (entityToSave.FetchFromDB(workResourceElementSchema.GetPrimaryColumnName(), recordId)) {
								entityToSave.SetColumnValue("ActualWork", acutalWork);
								entityToSave.Save();
							}
						}
					}
				}
			}

			#endregion

			UpdateProjectActualCompletion(projectId);

		}

	}

	public class ProjectResourceItem {
		public decimal PlanningWork = 0m;
		public decimal ActualWork = 0m;
		public bool needUpdate = false;
	}

	public class ActualProjectResource {
		public Guid ContactId { get; set; }
		public decimal work = 0m;
	}

	public class PlanProjectResource {
		public Guid Id { get; set; }
		public Guid ContactId { get; set; }
		public bool hasActivity = false;
		public decimal work = 0m;
	}

	public class FinanceActivityItem {
		public Guid ProjectId { get; set; }
		public Guid OwnerId { get; set; }
		public decimal Work { get; set; }
	}

	public class FinanceActivity {
		public List<FinanceActivityItem> activityWork;
		public FinanceActivity(UserConnection UserConnection, Guid projectId, bool useChildrens = true) {
			activityWork = new List<FinanceActivityItem>();
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var esqActivity = new EntitySchemaQuery(entitySchemaManager, "Activity");
			var esqActivityOwnerColumn = esqActivity.AddColumn("Owner.Id");
			var esqActivityProjectColumn = esqActivity.AddColumn("Project.Id");
			var esqActivityDurationInMinutesColumn = esqActivity.AddColumn("DurationInMinutes");
			if (useChildrens) {
				var children = HierarchicalProjectUtilities.GetChildProjectsIDs(projectId, UserConnection);
				var projectActivityFilter = esqActivity.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Project", children.Select(x => (object)x).ToArray());
				esqActivity.Filters.Add(projectActivityFilter);
			} else {
				var projectActivityFilter = esqActivity.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Project", projectId);
				esqActivity.Filters.Add(projectActivityFilter);
			}
			var ownerActivityFilter = esqActivity.CreateFilterWithParameters(FilterComparisonType.IsNotNull, "Owner");
			esqActivity.Filters.Add(ownerActivityFilter);
			var activityEntities = esqActivity.GetEntityCollection(UserConnection);
			if (activityEntities.Count > 0) {
				foreach(var activityEntity in activityEntities) {
					Guid activityOwnerId = activityEntity.GetTypedColumnValue<Guid>(esqActivityOwnerColumn.Name);
					Guid activityProjectId = activityEntity.GetTypedColumnValue<Guid>(esqActivityProjectColumn.Name);
					decimal work = activityEntity.GetTypedColumnValue<decimal>(esqActivityDurationInMinutesColumn.Name);
					work = Math.Round(work / 60, 2);
					var activityWorkItem = Find(activityProjectId, activityOwnerId);
					if (activityWorkItem != null) {
						activityWorkItem.Work += work; 
					} else {
						var item = new FinanceActivityItem();
						item.ProjectId = activityProjectId;
						item.OwnerId = activityOwnerId;
						item.Work = work;
						activityWork.Add(item);
					}
				}
			}

		}
		
		public FinanceActivityItem Find(Guid projectId, Guid ownerId) {
			foreach (var item in activityWork) {
				if (item.ProjectId == projectId && item.OwnerId == ownerId) {
					return item;
				}
			}
			return null;
		}
		
		public decimal SumByProjectAndOwner(Guid projectId, Guid ownerId) {
			var item = Find(projectId, ownerId); 
			if (item != null) {
				return item.Work;
			}
			return 0m;
		}
		
	}
}

