namespace BPMSoft.Configuration.WorkplaceService
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Configuration.Workplace;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using BPMSoft.Core.ServiceModelContract;

	#region Class: CreateWorkplaceRequest

	[DataContract]
	public class CreateWorkplaceRequest
	{

		#region Properties: Public

		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		[DataMember(Name = "type")]
		public WorkplaceType Type { get; set; }

		[DataMember(Name = "homePageUId")]
		public Guid? HomePageUId { get; set; }

		#endregion

	}

	#endregion

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class WorkplaceService : BaseService
	{

		#region Constants: Private

		private const string WorkplaceCacheKeyTemplate = "SysWorkplaceId_{0}";
		private const string SysSchemaUIdParameterName = "SysSchemaUId";
		private const string SysWorkspaceIdParameterName = "SysWorkspaceId";

		#endregion

		#region Properties: Protected

		/// <summary>
		/// <see cref="IWorkplaceManager"/> implementation instance.
		/// </summary>
		protected IWorkplaceManager WorkplaceManager {
			get {
				return ClassFactory.Get<IWorkplaceManager>(new ConstructorArgument("uc", UserConnection));
			}
		}

		#endregion

		#region Methods: Private

		private void ResetCache() {
			ConfigurationSectionHelper.ClearCache(UserConnection);
		}

		private string GetWorkplacesScript(Guid applicationClientTypeId) {
			ConfigurationSectionHelper helper = new ConfigurationSectionHelper(UserConnection);
			return helper.GetWorkplacesConfig(UserConnection, true, applicationClientTypeId);
		}

		private void ResetWorkplace() {
			ConfigurationSectionHelper.ResetWorkplaceCache(UserConnection);
		}

		private void SetWorkplaceId(string workplaceId) {
			if (string.IsNullOrEmpty(workplaceId)) {
				return;
			}
			Guid wId = new Guid(workplaceId);
			ConfigurationSectionHelper.SetWorkplaceCache(UserConnection, wId);
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ResetScriptCache() {
			ResetCache();
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ResetWorkplaceCache() {
			ResetWorkplace();
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void SetWorkplaceCache(string workplaceId) {
			SetWorkplaceId(workplaceId);
		}
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string RefreshWorkplace(Guid applicationClientTypeId = default(Guid)) {
			return GetWorkplacesScript(applicationClientTypeId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<string> GetWorkplacesByType(int type) {
			var result = WorkplaceManager.GetWorkplacesByType((WorkplaceType)type).Select(w => w.ToString());
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedResponse,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ValueResponse<Guid> CreateWorkplace(CreateWorkplaceRequest request) {
			var parameters = new CreateWorkplaceParameters {
				Name = request.Name, Type = request.Type, HomePageUId = request.HomePageUId
			};
			try
			{
				var workplace = WorkplaceManager.CreateWorkplace(parameters);
				return new ValueResponse<Guid>()
				{
					Value = workplace.Id
				};
			}
			catch(Exception e)
			{
                return ResponseUtils.CreateResponseWithErrorInfo<ValueResponse<Guid>>(e);
            }
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ChangeWorkplaceName(Guid workplaceId, string name) {
			WorkplaceManager.ChangeName(workplaceId, name);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ChangeWorkplacePosition(Guid workplaceId, int position) {
			WorkplaceManager.ChangePosition(workplaceId, position);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void DeleteWorkplace(Guid workplaceId) {
			WorkplaceManager.DeleteWorkplace(workplaceId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void AddSectionToWorkplace(Guid workplaceId, Guid sectionId) {
			WorkplaceManager.AddSectionToWorkplace(workplaceId, sectionId);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void RemoveSectionFromWorkplace(Guid workplaceId, Guid sectionId) {
			WorkplaceManager.RemoveSectionFromWorkplace(workplaceId, sectionId);
		}

		#endregion

	}

}
