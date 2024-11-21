namespace BPMSoft.Configuration.ExternalAccessPackage
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Common;

	/// <summary>
	/// Dto class for entity schema config used by <see cref="IsolatedAccessService"/>.
	/// </summary>
	[DataContract]
	public class EntitySchemaInfo
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="EntitySchemaInfo"/> class.
		/// </summary>
		/// <param name="name">Entity schema name.</param>
		/// <param name="primaryDisplayColumnName">Name of the primary display column.</param>
		public EntitySchemaInfo(string name, string primaryDisplayColumnName) {
			Name = name;
			PrimaryDisplayColumnName = primaryDisplayColumnName;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the name of the entity schema.
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the name of the primary display column.
		/// </summary>
		[DataMember(Name = "primaryDisplayColumn")]
		public string PrimaryDisplayColumnName { get; set; }

		#endregion

	}

	/// <summary>
	/// Web-service for isolated external access mode tasks.
	/// </summary>
	/// <seealso cref="BPMSoft.Web.Common.BaseService" />
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class IsolatedAccessService : BaseService
	{

		#region Methods: Public

		/// <summary>
		/// Gets information about schemas of entities created during external access session (with data isolation
		/// mode enabled).
		/// </summary>
		/// <param name="externalAccessId">The external access identifier.</param>
		/// <returns>Entity schema info list.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public List<EntitySchemaInfo> GetIsolatedSchemasInfo(Guid externalAccessId) {
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			var select = (Select)new Select(UserConnection)
				.Distinct()
					.Cols("EntitySchemaName")
				.From("SysIsolatedRecord")
				.Where("ExternalAccessId").IsEqual(Column.Parameter(externalAccessId));
			IEnumerable <EntitySchemaInfo> entitySchemaInfos = select.ExecuteEnumerable(reader => {
				string schemaName = reader.GetColumnValue<string>("EntitySchemaName");
				EntitySchema entitySchema = entitySchemaManager.GetInstanceByName(schemaName);
				string primaryDisplayColumnName = entitySchema.PrimaryDisplayColumn?.Name;
				return new EntitySchemaInfo(schemaName, primaryDisplayColumnName);
			});
			return entitySchemaInfos.ToList();
		}

		#endregion

	}
}

