namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Common;

	#region DataContract

	[DataContract]
	public class CanResponse {
		[DataMember]
		public bool Success = true;
		[DataMember]
		public int Code = 0;
		[DataMember]
		public decimal Plan = 0;
	}

	#endregion

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class WorkResourceElementService : BaseService {
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public CanResponse GetCanCreate(Guid workResourceElementId, Guid projectResourceElementId, Guid projectId) {
			var response = new CanResponse();
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var esqWork = new EntitySchemaQuery(entitySchemaManager, "WorkResourceElement");
			var idColumn = esqWork.AddColumn("Id");
			var projectFilter = esqWork.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Project", projectId);
			esqWork.Filters.Add(projectFilter);
			var resourceFilter = esqWork.CreateFilterWithParameters(FilterComparisonType.Equal,
				"ProjectResourceElement", projectResourceElementId);
			esqWork.Filters.Add(resourceFilter);
			var selfFilter = esqWork.CreateFilterWithParameters(FilterComparisonType.NotEqual,
				"Id", workResourceElementId);
			esqWork.Filters.Add(selfFilter);
			var entities = esqWork.GetEntityCollection(UserConnection);
			if (entities.Count > 0) {
				response.Success = false;
				response.Code = 1010; // duplicate ProjectResourceElement in project
				return response;
			}
			return response;
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public CanResponse GetCanEdit(Guid workResourceElementId, Guid projectResourceElementId, decimal work) {
			var response = new CanResponse();
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var esqWork = new EntitySchemaQuery(entitySchemaManager, "WorkResourceElement");
			var projectIdColumn = esqWork.AddColumn("Project.Id");
			var oldResourceIdColumn = esqWork.AddColumn("ProjectResourceElement.Id");
			var oldContactIdColumn = esqWork.AddColumn("ProjectResourceElement.Contact.Id");
			var oldPlanningWorkColumn = esqWork.AddColumn("PlanningWork");
			var workEntity = esqWork.GetEntity(UserConnection, workResourceElementId);
			if (workEntity == null) {
				response.Success = false;
				response.Code = 0; // WorkResourceElement Not Exist
				return response;
			}
			var projectId = workEntity.GetTypedColumnValue<Guid>(projectIdColumn.Name);
			var oldContactId = workEntity.GetTypedColumnValue<Guid>(oldContactIdColumn.Name);
			var oldResourceId = workEntity.GetTypedColumnValue<Guid>(oldResourceIdColumn.Name);
			var oldWork = workEntity.GetTypedColumnValue<decimal>(oldPlanningWorkColumn.Name);
			if (projectResourceElementId == oldResourceId && work == oldWork) {
				return response;
			}
			if (projectResourceElementId == oldResourceId) {
				var childsWorkList = GetChildWorkByProjectId(projectId, projectResourceElementId);
				decimal childsWork = 0m;
				if (childsWorkList.Count > 0) {
					foreach(var item in childsWorkList) {
						childsWork += item.Value.PlanningWork;
					}
				}
				if (childsWork > work) {
					response.Success = false;
					response.Code = 2110; // work in WorkResourceElement too small
					response.Plan = childsWork;
					return response;
				}
			} else {
				response = GetCanDelete(projectId, oldResourceId, oldContactId);
				if (!response.Success) {
					return response; 
				}
				response = GetCanCreate(workResourceElementId, projectResourceElementId, projectId);
				if (!response.Success) {
					return response; 
				}
			}
			return response;
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public CanResponse GetCanDelete(Guid workResourceElementId) {
			var response = new CanResponse();
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var esqWork = new EntitySchemaQuery(entitySchemaManager, "WorkResourceElement");
			var projectIdColumn = esqWork.AddColumn("Project.Id");
			var oldResourceIdColumn = esqWork.AddColumn("ProjectResourceElement.Id");
			var oldContactIdColumn = esqWork.AddColumn("ProjectResourceElement.Contact.Id");
			var workEntity = esqWork.GetEntity(UserConnection, workResourceElementId);
			if (workEntity == null) {
				response.Success = false;
				response.Code = 0; // WorkResourceElement Not Exist
				return response;
			}
			var projectId = workEntity.GetTypedColumnValue<Guid>(projectIdColumn.Name);
			var contactId = workEntity.GetTypedColumnValue<Guid>(oldContactIdColumn.Name);
			var resourceId = workEntity.GetTypedColumnValue<Guid>(oldResourceIdColumn.Name);
			response = GetCanDelete(projectId, resourceId, contactId);
			return response;
		}
		
		private CanResponse GetCanDelete(Guid projectId, Guid resourceId, Guid contactId) {
			var response = new CanResponse();
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var childsOldWorkList = GetChildWorkByProjectId(projectId, resourceId, true);
			if (childsOldWorkList.Count > 0) {
				response.Success = false;
				response.Code = 3010; // WorkResourceElement has childs
				return response;
			}
			if (contactId != null && contactId != Guid.Empty) {
				if (GetActivityByProjectAndContact(projectId, contactId)) {
					response.Success = false;
					response.Code = 3020; // WorkResourceElement has activities
					return response;
				}
			}
			return response;
		}
		
		private Dictionary<Guid, WorkElement> GetChildWorkByProjectId(Guid projectId, Guid projectResourceElementId, bool useAllChildrenLevels = false) {
			var response = new Dictionary<Guid, WorkElement>();
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var esqChildWork = new EntitySchemaQuery(entitySchemaManager, "WorkResourceElement");
			var childPlanningWorkColumn = esqChildWork.AddColumn("PlanningWork");
			var childProjectIdColumn = esqChildWork.AddColumn("Project.Id");
			if (useAllChildrenLevels) {
				var projects = HierarchicalProjectUtilities.GetChildProjectsIDs(projectId, UserConnection);
				var parentProjectFilter = esqChildWork.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Project.ParentProject", projects.Select(x => (object)x).ToArray());
				esqChildWork.Filters.Add(parentProjectFilter);
			} else {
				var parentProjectFilter = esqChildWork.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Project.ParentProject", projectId);
				esqChildWork.Filters.Add(parentProjectFilter);
			}
			var childResourceFilter = esqChildWork.CreateFilterWithParameters(FilterComparisonType.Equal,
				"ProjectResourceElement", projectResourceElementId);
			esqChildWork.Filters.Add(childResourceFilter);
			decimal childsWork = 0m;
			var childEntities = esqChildWork.GetEntityCollection(UserConnection);
			if (childEntities.Count > 0) {
				foreach(var childEntity in childEntities) {
					var childProjectId = childEntity.GetTypedColumnValue<Guid>(childProjectIdColumn.Name);
					var planningWork = childEntity.GetTypedColumnValue<decimal>(childPlanningWorkColumn.Name);
					if (response.ContainsKey(childProjectId)) {
						response[childProjectId].PlanningWork += planningWork;
					} else {
						var workElement = new WorkElement();
						workElement.PlanningWork = planningWork;
						response.Add(childProjectId, workElement);
					}
				}
			}
			return response;
		}
		
		private bool GetActivityByProjectAndContact(Guid projectId, Guid contactId, bool useAllChildrenLevels = false) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var esq = new EntitySchemaQuery(entitySchemaManager, "Activity");
			var idColumn = esq.AddColumn("Id");
			if (useAllChildrenLevels) {
				var projects = HierarchicalProjectUtilities.GetChildProjectsIDs(projectId, UserConnection);
				var projectFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Project", projects.Select(x => (object)x).ToArray());
				esq.Filters.Add(projectFilter);
			} else {
				var projectFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Project", projectId);
				esq.Filters.Add(projectFilter);
			}
			var ownerFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Owner", contactId);
			esq.Filters.Add(ownerFilter);
			var entities = esq.GetEntityCollection(UserConnection);
			return (entities.Count > 0);
		}
		
	}
	
	public class WorkElement {
		public decimal PlanningWork = 0;
	}
}
