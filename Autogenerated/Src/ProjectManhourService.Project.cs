namespace BPMSoft.Configuration.ProjectManhourService
{
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using System;
	using System.Data;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using BPMSoft.Web.Common;

	#region DataContract

	[DataContract]
	
	public class CanDeleteResponse {
		[DataMember]
		public bool Success { get; set; }
		[DataMember]
		public int Code { get; set; }
	}
	
	#endregion
	
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ProjectManhourService : BaseService {

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CheckChildProjectManhours", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public int CheckChildProjectManhours(Guid projectId, Guid roleId, Guid oldRoleId, decimal planningWork, decimal oldPlanningWork, bool isNew) {
			var result = 0;
			var canUpdate = true;
			var canChange = true;
			if (!roleId.Equals(oldRoleId)) {
				canChange = GetCanUpdateManhour(projectId, oldRoleId, 0);
			}
			if (canChange) {
				canUpdate = GetCanUpdateManhour(projectId, oldRoleId, planningWork);
			}
			if (!canUpdate) {
				result = 1;
			}
			if (!canChange) {
				result = 2;
			}
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetChildProjectManhoursSum", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public int GetChildProjectManhoursSum(Guid projectId, Guid roleId) {
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
			return childProjectManhoursSelect.ExecuteScalar<int>();
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RoleInProjectExists", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool RoleInProjectExists(Guid projectId, Guid roleId, Guid oldRoleId, decimal planningWork, decimal oldPlanningWork, bool isNew) {
			var duplicate = false;
			var projectManhourSelect = new Select(UserConnection)
					.Column(Func.Count(Column.Parameter(1)))
				.From("ProjectManhour")
				.Where("ProjectId")
					.IsEqual(Column.Parameter(projectId))
				.And("RoleId")
					.IsEqual(Column.Parameter(roleId)) as Select;
			if (!roleId.Equals(oldRoleId) || isNew) {
				duplicate = projectManhourSelect.ExecuteScalar<int>() == 1;
			}
			return duplicate;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SyncronizeParents", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SyncronizeParents(Guid projectId, Guid roleId, Guid oldRoleId, decimal planningWork, decimal oldPlanningWork, bool isNew) {
			var parentProjects = GetParentProjects(projectId);
			if (parentProjects.Count == 0) {
				return;
			}
			foreach(var parentProjectId in parentProjects) {
				if (parentProjectId.Equals(projectId)) {
					continue;
				}
				var parentManhourId = GetParentManhourId(parentProjectId, roleId); 
				if (parentManhourId.Equals(Guid.Empty)) {
					InsertProjectManhour(parentProjectId, roleId, planningWork);
				} else {
					var childProjectManhoursSum = GetChildProjectManhoursSum(parentProjectId, roleId);
					if (childProjectManhoursSum > 0) {
						UpdateProjectManhour(parentManhourId, childProjectManhoursSum);
						UpdateProject(parentProjectId, roleId, childProjectManhoursSum);
					} else {
						DeleteProjectManhour(parentManhourId);
						ClearProject(parentProjectId, roleId);
					}
				}
				if (!roleId.Equals(oldRoleId)) {
					var oldParentManhourId = GetParentManhourId(parentProjectId, oldRoleId); 
					if (oldParentManhourId.Equals(Guid.Empty)) {
//						InsertProjectManhour();
					} else {
						var oldChildProjectManhoursSum = GetChildProjectManhoursSum(parentProjectId, oldRoleId);
						if (oldChildProjectManhoursSum > 0) {
							UpdateProjectManhour(oldParentManhourId, oldChildProjectManhoursSum);
							UpdateProject(parentProjectId, oldRoleId, oldChildProjectManhoursSum);
						} else {
							DeleteProjectManhour(oldParentManhourId);
							ClearProject(parentProjectId, oldRoleId);
						}
					}
				}
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SyncronizeProject", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SyncronizeProject(Guid projectId, Guid roleId, Guid oldRoleId, decimal planningWork, decimal oldPlanningWork, bool isNew) {
			(new Update(UserConnection, "Project")
				.Set("PlanningWork", Column.Parameter(planningWork))
				.Set("RoleInProjectId", Column.Parameter(roleId))
				.Where("Id")
					.IsEqual(Column.Parameter(projectId))
				.And("RoleInProjectId")
					.IsEqual(Column.Parameter(oldRoleId))
				.And("PlanningWork")
					.IsEqual(Column.Parameter(oldPlanningWork)) as Update).Execute();
		}

		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public CanDeleteResponse GetCanDelete(List<Guid> projectResources) {
			CanDeleteResponse result = new CanDeleteResponse();
			result.Success = true;
			foreach (var projectResourceId in projectResources) {
				if (result.Success) {
					result = GetCanDeleteByProjectResourceId(projectResourceId);
				}
			}
			return result;
		}
		
		private CanDeleteResponse GetCanDeleteByProjectResourceId(Guid projectResourceId) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			CanDeleteResponse result = new CanDeleteResponse();
			result.Success = true;
			var esqWork = new EntitySchemaQuery(entitySchemaManager, "WorkResourceElement");
			esqWork.AddColumn("Id");
			var projectResFilter = esqWork.CreateFilterWithParameters(FilterComparisonType.Equal, "ProjectResourceElement", projectResourceId);
			esqWork.Filters.Add(projectResFilter);
			var workEntities = esqWork.GetEntityCollection(UserConnection);
			if (workEntities.Count > 0) {
				result.Success = false;
				result.Code = 200;
				return result;
			}
			var projectResourceElementSchema = entitySchemaManager.GetInstanceByName("ProjectResourceElement");
			var projectResourceEntity = projectResourceElementSchema.CreateEntity(UserConnection);
			if (!projectResourceEntity.FetchFromDB(projectResourceElementSchema.GetPrimaryColumnName(), projectResourceId)) {
				return result;
			}
			var projectId = projectResourceEntity.GetTypedColumnValue<Guid>(projectResourceElementSchema.Columns.FindByName("Project").ColumnValueName);
			var contactId = projectResourceEntity.GetTypedColumnValue<Guid>(projectResourceElementSchema.Columns.FindByName("Contact").ColumnValueName);
			if (projectId == null || projectId == Guid.Empty || contactId == null || contactId == Guid.Empty) {
				return result;
			}
			var esqActivity = new EntitySchemaQuery(entitySchemaManager, "Activity");
			esqActivity.AddColumn("Id");
			var projects = HierarchicalProjectUtilities.GetChildProjectsIDs(projectId, UserConnection);
			var projectFilter = esqActivity.CreateFilterWithParameters(FilterComparisonType.Equal, "Project", projects.Select(x => (object)x).ToArray());
			esqActivity.Filters.Add(projectFilter);
			var ownerFilter = esqActivity.CreateFilterWithParameters(FilterComparisonType.Equal, "Owner", contactId);
			esqActivity.Filters.Add(ownerFilter);
			var activityEntities = esqActivity.GetEntityCollection(UserConnection);
			if (activityEntities.Count > 0) {
				result.Success = false;
				result.Code = 300;
				return result;
			}
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ClearManhourInformation", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ClearManhourInformation(List<Guid> projectManhours) {
			var projectSelect = new Select(UserConnection)
					.Column("ProjectId")
				.From("ProjectManhour")
				.Where("Id")
					.IsEqual(Column.Parameter(projectManhours.First())) as Select;
			var rolesSelect = new Select(UserConnection)
					.Column("RoleId")
				.From("ProjectManhour")
				.Where("Id")
					.In(projectManhours.Select(x => new QueryParameter(x))) as Select;
			(new Update(UserConnection, "Project")
				.Set("PlanningWork", Column.Const(0))
				.Set("RoleInProjectId", Column.Const(null))
				.Where("Id")
					.IsEqual(projectSelect)
				.And("RoleInProjectId")
					.In(rolesSelect) as Update).Execute();
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "InsertProjectManhour", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void InsertProjectManhour(Guid projectId, Guid roleId, decimal planningWork) {
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
				.Set("ProjectId", Column.Parameter(projectId))
				.Set("RoleId", Column.Parameter(roleId))
				.Set("PlanningWork", Column.Parameter(planningWork))
				.Set("InternalRate", internalRateSelect)
				.Set("ExternalRate", externalRateSelect) as Insert).Execute();
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public decimal RestProjectManhourByRole(Guid projectId, Guid roleId) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			decimal manhour = 0m;
			var esqManhour = new EntitySchemaQuery(entitySchemaManager, "ProjectManhour");
			var workManhourColumn = esqManhour.AddColumn("PlanningWork");
			var manhourRoleFilter = esqManhour.CreateFilterWithParameters(FilterComparisonType.Equal, "Role", roleId);
			esqManhour.Filters.Add(manhourRoleFilter);
			var manhourProjectFilter = esqManhour.CreateFilterWithParameters(FilterComparisonType.Equal, "Project", projectId);
			esqManhour.Filters.Add(manhourProjectFilter);
			var manhourEntities = esqManhour.GetEntityCollection(UserConnection);
			if (manhourEntities.Count > 0) {
				manhour = manhourEntities[0].GetTypedColumnValue<decimal>(workManhourColumn.Name);
			}
			if (manhour <= 0) {
				return 0m;
			}
			List<Guid> childrens = HierarchicalProjectUtilities.GetChildProjectsIDs(projectId, UserConnection);
			var esqTemp = new EntitySchemaQuery(entitySchemaManager, "ProjectTeamParticipant");
			var workTeamColumn = esqTemp.AddColumn("PlanningWork");
			var teamRoleFilter = esqTemp.CreateFilterWithParameters(FilterComparisonType.Equal, "Role", roleId);
			esqTemp.Filters.Add(teamRoleFilter);
			var teamProjectFilter = esqTemp.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"Project", childrens.Select(x => (object)x).ToArray());
			esqTemp.Filters.Add(teamProjectFilter);
			var teamEntities = esqTemp.GetEntityCollection(UserConnection);
			if (teamEntities.Count > 0) {
				foreach(var teamEntity in teamEntities) {
					manhour -= teamEntity.GetTypedColumnValue<decimal>(workTeamColumn.Name);
				}
			}
			if (manhour > 0) {
				return manhour;
			} else {
				return 0m;
			}
		}

		private List<Guid> GetParentProjects(Guid projectId) {
			var projects = new List<Guid>();
			var projectSelect = new Select(UserConnection)
					.Column("Id").As("Id")
					.Column("ParentProjectId").As("ParentProjectId")
				.From("Project") as Select;
			var options = new HierarchicalSelectOptions() {
				PrimaryColumnName = "Id",
				ParentColumnName = "ParentProjectId",
				SelectType = HierarchicalSelectType.Parents
			};
			var startingCondition = options.StartingPrimaryColumnCondition;
			startingCondition.LeftExpression = new QueryColumnExpression("Id");
			startingCondition.IsEqual(
				Column.Parameter(projectId, "ParentProjectId", BPMSoft.Common.ParameterDirection.Input));
			projectSelect.HierarchicalOptions = options;
			var parameters = new QueryParameterCollection();
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = projectSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var id = UserConnection.DBTypeConverter.DBValueToGuid(reader["Id"]);
						projects.Add(id);
					}
				}
			}
			return projects;
		}

		private bool GetCanUpdateManhour(Guid projectId, Guid roleId, decimal planningWork) {
			var sum = GetChildProjectManhoursSum(projectId, roleId);
			return planningWork >= sum;
		}

		private Guid GetParentManhourId(Guid projectId, Guid roleId) {
			var parentManhourSelect = new Select(UserConnection)
					.Column("Id")
				.From("ProjectManhour")
				.Where("ProjectId")
					.IsEqual(Column.Parameter(projectId))
				.And("RoleId")
					.IsEqual(Column.Parameter(roleId)) as Select;
			return parentManhourSelect.ExecuteScalar<Guid>();
		}

		private void UpdateProjectManhour(Guid projectManhourId, decimal planningWork) {
			(new Update(UserConnection, "ProjectManhour")
				.Set("PlanningWork", Column.Parameter(planningWork))
				.Where("Id")
					.IsEqual(Column.Parameter(projectManhourId)) as Update).Execute();
		}

		private void UpdateProject(Guid projectId, Guid roleId, decimal planningWork) {
			(new Update(UserConnection, "Project")
				.Set("PlanningWork", Column.Parameter(planningWork))
				.Where("Id")
					.IsEqual(Column.Parameter(projectId))
				.And("RoleInProjectId")
					.IsEqual(Column.Parameter(roleId)) as Update).Execute();
		}

		private void DeleteProjectManhour(Guid projectManhourId) {
			(new Delete(UserConnection)
				.From("ProjectManhour")
				.Where("Id")
					.IsEqual(Column.Parameter(projectManhourId)) as Delete).Execute();
		}

		private void ClearProject(Guid projectId, Guid roleId) {
			(new Update(UserConnection, "Project")
				.Set("PlanningWork", Column.Const(0))
				.Set("RoleInProjectId", Column.Const(null))
				.Where("Id")
					.IsEqual(Column.Parameter(projectId))
				.And("RoleInProjectId")
					.IsEqual(Column.Parameter(roleId)) as Update).Execute();
		}

	}

}

