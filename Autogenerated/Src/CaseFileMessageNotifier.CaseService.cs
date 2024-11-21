using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.DB;
using BPMSoft.Core.Entities;
using BPMSoft.WebApp;

namespace BPMSoft.Configuration
{

	#region Class: CaseFileMessageNotifier

	public class CaseFileMessageNotifier : BaseMessageNotifier
	{

		#region Struct: Private

		private struct LinkedEntityData
		{
			public string entitySchemaName;
			public Guid recordId;
		}

		#endregion

		#region Constants: Private

		private const string FileUrlTemplate = "<a href=\'../rest/FileService/GetFile/{0}/{1}\'>{2}</a>";
		private const string LinkUrlTemplate = "<a href=\"{0}\" target=\"_blank\" title=\"{1}\">{1}</a>";
		private const string EntityLinkUrlTemplate = "<a href=\"../{0}\" target=\"_self\" title=\"{1}\">{1}</a>";

		#endregion

		#region Fields: Private

		private readonly Guid _caseSchemaUid = Guid.Parse("117D32F9-8275-4534-8411-1C66115CE9CD");

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize new instance of <see cref="CaseFileMessageNotifier" />.
		/// </summary>
		/// <param name="entity">CaseFile entity.</param>
		public CaseFileMessageNotifier(Entity entity, UserConnection userConnection = null) {
			UserConnection = userConnection;
			MessageInfo = new MessageInfo {
				Message = GetTypedLink(entity),
				CreatedById = entity.GetTypedColumnValue<Guid>("CreatedById"),
				CreatedOn = entity.GetTypedColumnValue<DateTime>("CreatedOn"),
				HasAttachment = false,
				NotifierRecordId = entity.PrimaryColumnValue,
				SchemaUId = entity.Schema.UId,
				ListenersData = new Dictionary<Guid, Guid> {
					{ _caseSchemaUid, entity.GetTypedColumnValue<Guid>("CaseId") }
				}
			};
		}

		#endregion

		#region Properties: Public

		public UserConnection UserConnection
		{
			get;
		}

		#endregion

		#region Methods: Private

		private LinkedEntityData GetLinkedEntityData(Entity entity) {
			string jsonStringData = System.Text.Encoding.UTF8.GetString((byte[])entity.GetColumnValue("Data"));
			JObject jsonData = JObject.Parse(jsonStringData);
			return new LinkedEntityData() {
				entitySchemaName = (string)jsonData["entitySchemaName"],
				recordId = (Guid)jsonData["recordId"]
			};
		}

		private string GetEditPageName(string typeColumnName, Guid recordId, EntitySchema linkedEntitySchema) {
			Select select = new Select(UserConnection)
				.Top(1).Column("SysSchema", "Name")
				.From("SysSchema")
				.InnerJoin("SysModuleEdit")
					.On("SysModuleEdit", "CardSchemaUId")
						.IsEqual("SysSchema", "UId")
				.InnerJoin("SysModuleEntity")
					.On("SysModuleEntity", "Id")
						.IsEqual("SysModuleEdit", "SysModuleEntityId")
				.Where("SysModuleEntity", "SysEntitySchemaUId")
					.IsEqual(Column.Parameter(linkedEntitySchema.UId)) as Select;
			if (typeColumnName.IsNotNullOrEmpty()) {
				select.AddCondition("SysModuleEdit", "TypeColumnValue", LogicalOperation.And).IsEqual(
					new Select(UserConnection)
						.Column(typeColumnName)
						.From(linkedEntitySchema.Name)
						.Where(linkedEntitySchema.PrimaryColumn.Name)
						.IsEqual(Column.Parameter(recordId)));
			}
			select.ExecuteSingleRecord(reader => reader.GetColumnValue<string>("Name"), out string pageName);
			return pageName;
		}

		private string AddProtocolPrefix(string link) {
			var rg = new Regex(@"((ftp|http|https|file)://).+", RegexOptions.IgnoreCase);
			return rg.IsMatch(link) ? link : "http://" + link;
		}

		private string GetTypeColumnName(EntitySchema schema) {
			Select select = new Select(UserConnection)
				.Column("SysModuleEntity", "TypeColumnUId").As("TypeColumnUId")
				.Column("SysModuleEntity", "Id").As("SysModuleEntityId")
				.From("SysModuleEntity")
				.Where("SysModuleEntity", "SysEntitySchemaUId").IsEqual(Column.Parameter(schema.UId)) as Select;
			select.ExecuteSingleRecord(reader => reader.GetColumnValue<Guid>("TypeColumnUId"), out Guid typeColumnUId);
			return typeColumnUId.IsEmpty() ? "" : schema.Columns.GetByUId(typeColumnUId).Name;
		}

		#endregion

		#region Methods: protected
		/// <summary>
		/// Get link for CaseFile entity dependent on it's type.
		/// </summary>
		/// <param name="entity">CaseFile entity</param>
		/// <returns></returns>
		protected string GetTypedLink(Entity entity) {
			var entityType = entity.GetTypedColumnValue<Guid>("TypeId");
			if (entityType == FileConsts.FileTypeUId) {
				return GetFileLink(entity);
			} else if (entityType == FileConsts.LinkTypeUId) {
				return GetHttpLink(entity);
			} else if (entityType == FileConsts.EntityLinkTypeUId) {
				return GetEntityLink(entity);
			}
			return string.Empty;
		}

		/// <summary>
		/// Get http link for CaseFile entity with "Link" type.
		/// </summary>
		/// <param name="entity">CaseFile entity.</param>
		/// <returns></returns>
		protected string GetHttpLink(Entity entity) {
			string url = entity.GetTypedColumnValue<string>("Name");
			return string.Format(LinkUrlTemplate, AddProtocolPrefix(url), url);
		}

		/// <summary>
		/// Get file link for CaseFile entity with "File" type.
		/// </summary>
		/// <param name="entity">CaseFile entity.</param>
		/// <returns></returns>
		protected string GetFileLink(Entity entity) {
			return string.Format(FileUrlTemplate, entity.Schema.UId, entity.PrimaryColumnValue, entity.GetTypedColumnValue<string>("Name"));
		}

		/// <summary>
		/// Get http link for CaseFile entity with "EntityLink" type.
		/// </summary>
		/// <param name="entity">CaseFile entity.</param>
		/// <returns></returns>
		protected string GetEntityLink(Entity entity) {
			const string uriTemplate = "Nui/ViewModule.aspx#CardModuleV2/{0}/edit/{1}";
			LinkedEntityData data = GetLinkedEntityData(entity);
			EntitySchema linkedEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(data.entitySchemaName);
			string typeColumnName = GetTypeColumnName(linkedEntitySchema);
			string pageName = GetEditPageName(typeColumnName, data.recordId, linkedEntitySchema);
			string url = string.Format(uriTemplate, pageName, data.recordId);
			return string.Format(EntityLinkUrlTemplate, url, entity.GetTypedColumnValue<string>("Name"));
		}

		#endregion

	}

	#endregion

}


