namespace BPMSoft.Configuration.RelationshipDesigner
{
	using System;
	using BPMSoft.Configuration;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using System.Collections.Generic;

	#region Class: RelationshipService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class RelationshipDesignerService : BaseService
	{

		#region Fields: Private

		private IRelationshipDiagramBuilder _relationshipBuilder;
		private IRelationshipDiagramManager _diagramManager;
		private IRelationshipDiagramGroupManager _diagramGroupManager;

		#endregion

		#region Constructors: Public

		public RelationshipDesignerService() : base() { }

		public RelationshipDesignerService(UserConnection userConnection)
			: base(userConnection) {
		}

		#endregion

		#region Properties: Private

		private IRelationshipDiagramBuilder RelationshipBuilder =>
				_relationshipBuilder ?? (_relationshipBuilder = ClassFactory.Get<IRelationshipDiagramBuilder>(
					new ConstructorArgument("userConnection", UserConnection)));

		private IRelationshipDiagramManager DiagramManager =>
			_diagramManager ?? (_diagramManager = ClassFactory.Get<IRelationshipDiagramManager>(
				new ConstructorArgument("userConnection", UserConnection)));

		private IRelationshipDiagramGroupManager DiagramGroupManager =>
			_diagramGroupManager ?? (_diagramGroupManager = ClassFactory.Get<IRelationshipDiagramGroupManager>(
				new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public RelationshipServiceResponse GetDiagram(Guid recordId, string schemaName) {
			try {
				var diagramInfo = RelationshipBuilder.GetDiagram(recordId, schemaName);
				var diagramConfig = RelationshipBuilder.GetDiagramConfig();
				return new RelationshipServiceResponse(diagramInfo, diagramConfig);
			} catch (Exception e) {
				return new RelationshipServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteEntity(Guid entityId) {
			try {
				DiagramManager.DeleteEntity(entityId);
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse CreateConnection(RelationshipEntityConnection entityConnection) {
			try {
				DiagramManager.CreateConnection(entityConnection);
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UpdateConnection(RelationshipEntityConnection entityConnection) {
			try {
				DiagramManager.UpdateConnection(entityConnection);
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteConnection(Guid connectionId) {
			try {
				DiagramManager.DeleteConnection(connectionId);
				return new ConfigurationServiceResponse();
			}
			catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public RelationshipGroupsResponse GetGroupsData() {
			try {
				var groups = DiagramGroupManager.GetGroupsData();
				return new RelationshipGroupsResponse(groups);
			}
			catch (Exception e) {
				return new RelationshipGroupsResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public RelationshipGroupsResponse GetGroupsDataForEntity(Guid entityId) {
			try {
				var groups = DiagramGroupManager.GetGroupsDataForEntity(entityId);
				return new RelationshipGroupsResponse(groups);
			}
			catch (Exception e) {
				return new RelationshipGroupsResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse CreateGroup(RelationshipDiagramGroup group) {
			try {
				DiagramGroupManager.CreateGroup(group);
				return new ConfigurationServiceResponse();
			}
			catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UpdateGroup(RelationshipDiagramGroup group) {
			try {
				DiagramGroupManager.UpdateGroup(group);
				return new ConfigurationServiceResponse();
			}
			catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteGroup(Guid groupId) {
			try {
				DiagramGroupManager.DeleteGroup(groupId);
				return new ConfigurationServiceResponse();
			}
			catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse CreateEntityInGroup(RelationshipDiagramEntityInGroup entityInGroup) {
			try {
				DiagramGroupManager.CreateEntityInGroup(entityInGroup);
				return new ConfigurationServiceResponse();
			}
			catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UpdateEntityInGroup(RelationshipDiagramEntityInGroup entityInGroup) {
			try {
				DiagramGroupManager.UpdateEntityInGroup(entityInGroup);
				return new ConfigurationServiceResponse();
			}
			catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteEntityInGroup(Guid entityId, Guid groupId) {
			try {
				DiagramGroupManager.DeleteEntityInGroup(entityId, groupId);
				return new ConfigurationServiceResponse();
			}
			catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public RelationshipRecordEntityInfoResponse GetRecordEntityInfo(Guid entityId) {
			try {
				var recordEntityInfo = DiagramManager.GetRecordEntityInfo(entityId);
				return new RelationshipRecordEntityInfoResponse(recordEntityInfo);
			}
			catch (Exception e) {
				return new RelationshipRecordEntityInfoResponse(e);
			}
		}

		#endregion

	}

	#endregion

	#region Class: RelationshipDesignerServiceResponse

	[DataContract]
	public class RelationshipServiceResponse : ConfigurationServiceResponse
	{

		#region Constructors: Public

		public RelationshipServiceResponse() : base() { }

		public RelationshipServiceResponse(Exception e) : base(e) { }

		public RelationshipServiceResponse(DiagramInfo result) : base() {
			this.DiagramInfo = result;
		}

		public RelationshipServiceResponse(DiagramConfig config) : base() {
			this.DiagramConfig = config;
		}

		public RelationshipServiceResponse(DiagramInfo result, DiagramConfig config) : base() {
			this.DiagramInfo = result;
			this.DiagramConfig = config;
		}

		#endregion

		[DataMember(Name = "data")]
		public DiagramInfo DiagramInfo {
			get; set;
		}

		[DataMember(Name = "config")]
		public DiagramConfig DiagramConfig {
			get; set;
		}

	}

	#endregion

	#region Class: RelationshipRecordEntityInfoResponse

	[DataContract]
	public class RelationshipRecordEntityInfoResponse : ConfigurationServiceResponse
	{

		#region Constructors: Public

		public RelationshipRecordEntityInfoResponse() : base() { }

		public RelationshipRecordEntityInfoResponse(Exception e) : base(e) { }

		public RelationshipRecordEntityInfoResponse(IDictionary<string, object> recordEntityInfo) : base() {
			this.RecordEntityInfo = recordEntityInfo;
		}

		#endregion

		[DataMember(Name = "recordEntityInfo")]
		public IDictionary<string, object> RecordEntityInfo {
			get; set;
		}

	}

	#endregion

	#region Class: RelationshipGroupsResponse

	[DataContract]
	public class RelationshipGroupsResponse : ConfigurationServiceResponse
	{

		#region Constructors: Public

		public RelationshipGroupsResponse() : base() { }

		public RelationshipGroupsResponse(Exception e) : base(e) { }

		public RelationshipGroupsResponse(List<RelationshipDiagramGroup> groups) : base() {
			this.Groups = groups;
		}

		#endregion

		[DataMember(Name = "groups")]
		public List<RelationshipDiagramGroup> Groups {
			get; set;
		}

	}

	#endregion

}

