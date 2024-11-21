 namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;

	#region Class: TemplateHintService

	/// <summary>
	/// Service for getting hint during template choosing.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class TemplateHintService : BaseService
	{
		#region Class:TemplateHintServiceResponse

		/// <summary>
		/// Represents template hint response.
		/// </summary>
		[DataContract]
		public class TemplateHintServiceResponse : ConfigurationServiceResponse
		{
			[DataMember]
			public List<TemplateHint> TemplateHints {
				get; set;
			}
		}

		#endregion

		#region Class: TemplateHint

		/// <summary>
		/// Represents template hint data.
		/// </summary>
		[DataContract]
		public class TemplateHint
		{
			[DataMember(Name = "id")]
			public Guid Id {
				get; set;
			}
			[DataMember(Name = "name")]
			public string Name {
				get; set;
			}
			[DataMember(Name = "text")]
			public string Text {
				get; set;
			}
		}

		#endregion

		#region Fields: Private

		private readonly string _templateSchemaName = "EmailTemplate";
		private Guid _chatTemplateType = Guid.Parse("62215DE1-23E0-4037-88C9-65CCF72904A4");

		#endregion

		#region Methods: Private

		private void AddHintFilterToHintQuery(EntitySchemaQuery hintQuery, string hintText) {
			var filterGroup = new EntitySchemaQueryFilterCollection(hintQuery, LogicalOperationStrict.And);
			if (!string.IsNullOrEmpty(hintText)) {
				filterGroup.Add(new EntitySchemaQueryFilterCollection(hintQuery, LogicalOperationStrict.Or) {
					hintQuery.CreateFilterWithParameters(
						FilterComparisonType.Contain,
						"Name",
						hintText
					),
					hintQuery.CreateFilterWithParameters(
						FilterComparisonType.Contain,
						"Body",
						hintText
					)
				});
			}
			filterGroup.Add(hintQuery.CreateFilterWithParameters(
						FilterComparisonType.Equal,
						"TemplateType",
						_chatTemplateType
					));
			hintQuery.Filters.Add(filterGroup);
		}

		private EntityCollection GetTemplates(string text, int rowsOffset = 0, int elementsCount = 5) {
			var hintQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, _templateSchemaName);
			hintQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			hintQuery.AddColumn("Name").OrderByAsc();
			hintQuery.AddColumn("Body");
			AddHintFilterToHintQuery(hintQuery, text);
			var options = new EntitySchemaQueryOptions {
				PageableDirection = PageableSelectDirection.First,
				PageableRowCount = elementsCount,
				RowsOffset = rowsOffset,
				PageableConditionValues = new Dictionary<string, object>()
			};
			var entityCollection = hintQuery.GetEntityCollection(UserConnection, options);
			return entityCollection;
		}

		private TemplateHint GetTemplateHint(Entity entity) {
			var body = entity.GetTypedColumnValue<string>("Body");
			return new TemplateHint {
				Id = entity.GetTypedColumnValue<Guid>("Id"),
				Name = entity.GetTypedColumnValue<string>("Name"),
				Text = body.Length > 100 ? body.Substring(0, 100) : body
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Getting template hints by text.
		/// </summary>
		/// <returns><see cref="TemplateHintServiceResponse"/>Template hints.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public TemplateHintServiceResponse GetTemplateHints(string text, int rowsCount) {
			EntityCollection entityCollection = GetTemplates(text, 0, rowsCount);
			var response = new TemplateHintServiceResponse();
			response.TemplateHints = new List<TemplateHint>();
			foreach (var entity in entityCollection) {
				response.TemplateHints.Add(GetTemplateHint(entity));
			}
			return response;
		}

		/// <summary>
		/// Getting template hints by text with records skipping.
		/// </summary>
		/// <returns><see cref="TemplateHintServiceResponse"/>Template hints.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public TemplateHintServiceResponse GetNextTemplateHints(string text, int skipRows, int rowsCount) {
			EntityCollection entityCollection = GetTemplates(text, skipRows, rowsCount);
			var response = new TemplateHintServiceResponse();
			response.TemplateHints = new List<TemplateHint>();
			foreach (var entity in entityCollection) {
				response.TemplateHints.Add(GetTemplateHint(entity));
			}
			return response;
		}

		#endregion

	}

	#endregion

}
