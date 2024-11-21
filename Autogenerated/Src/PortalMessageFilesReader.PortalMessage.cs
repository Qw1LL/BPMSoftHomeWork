namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Nui.ServiceModel.DataContract;

	#region  Class: PortalMessageFilesReader

	/// <summary>
	/// Class for reading Portal Message files.
	/// </summary>
	public class PortalMessageFilesReader : IPortalMessageFileReader
	{
		#region Constants: Private 

		private readonly string _portalMessageFileAlias = "pmf";
		private readonly string _portalMessageFileIdAlias = "PortalMessageFileId";

		#endregion

		#region Properties: Protected

		protected UserConnection userConnection;

		#endregion

		#region Properties: Public

		private RightsHelper _rightsHelper;
		public RightsHelper RightsHelper =>
			_rightsHelper ?? (_rightsHelper = new RightsHelper(userConnection));

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize PortalMessageFilesReader.
		/// </summary>
		/// <param name="userConnection">UserConnection  <see cref="ReadingUserConnectionOptions"/>.</param>
		public PortalMessageFilesReader(UserConnection userConnection) {
			this.userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Select GetPortalMessageFilesSelect(string portalMessageId) {
			return new Select(userConnection)
				.Column(_portalMessageFileAlias, "Id").As(_portalMessageFileIdAlias)
				.Column(_portalMessageFileAlias, "CreatedById")
				.Column(_portalMessageFileAlias, "CreatedOn")
				.Column(_portalMessageFileAlias, "Notes")
				.Column(_portalMessageFileAlias, "TypeId")
				.Column(_portalMessageFileAlias, "Version")
				.Column(_portalMessageFileAlias, "Name")
				.Column(_portalMessageFileAlias, "Size")
				.Column("ft", "Name").As("FileTypeName")
				.Column("pm", "EntityId")
				.Column("pm", "EntitySchemaUId")
				.From("PortalMessageFile", _portalMessageFileAlias)
				.LeftOuterJoin("PortalMessage").As("pm")
				.On("pm", "Id").IsEqual(_portalMessageFileAlias, "PortalMessageId")
				.LeftOuterJoin("FileType").As("ft")
				.On(_portalMessageFileAlias, "TypeId").IsEqual("ft", "Id")
				.Where(_portalMessageFileAlias, "PortalMessageId").IsEqual(Column.Parameter(Guid.Parse(portalMessageId)))
				.And("pm", "HideOnPortal").IsEqual(Column.Const(false)) as Select;
		}

		private bool CheckIfUserCanReadFiles(Guid entitySchemaUId, Guid entityId, out bool canReadData) {
			if (entitySchemaUId != default(Guid)) {
				var schemaName = userConnection.EntitySchemaManager.GetInstanceByUId(entitySchemaUId).Name;
				canReadData = RightsHelper.GetCanReadSchemaRecordRight(schemaName, entityId);
			} else {
				canReadData = true;
			}
			return canReadData;
		}

		private PortalMessageFileDTO CreatePortalMessageDTO(IDataReader reader) {
			return new PortalMessageFileDTO {
				Id = reader.GetColumnValue<Guid>(_portalMessageFileIdAlias),
				CreatedBy = reader.GetColumnValue<Guid>("CreatedById"),
				CreatedOn = reader.GetColumnValue<string>("CreatedOn"),
				Name = reader.GetColumnValue<string>("Name"),
				Size = reader.GetColumnValue<int>("Size"),
				Notes = reader.GetColumnValue<string>("Notes"),
				Type = GetPortalMessageTypeLookUpValue(reader),
				Version = reader.GetColumnValue<int>("Version")
			};
		}

		private LookupColumn GetPortalMessageTypeLookUpValue(IDataReader reader) {
			return new LookupColumn {
				DisplayValue = reader.GetColumnValue<string>("FileTypeName"),
				PrimaryImageValue = string.Empty,
				Value = reader.GetColumnValue<Guid>("TypeId")
			};
		}

		private PageableSelectOptions GetPageableOptions(ReadingOptions readingOptions) {
			var idExpression = new QueryColumnExpression(_portalMessageFileAlias, "Id");
			idExpression.Alias = _portalMessageFileIdAlias;
			var lastValueParameter = new QueryParameter("IdLastValue", readingOptions.LastValue);
			var pageableSelectCondition = new PageableSelectCondition {
				LastValueParameter = lastValueParameter,
				LeftExpression = idExpression,
				OrderByItem = new OrderByItem(idExpression, OrderDirectionStrict.Ascending)
			};
			return new PageableSelectOptions(pageableSelectCondition, readingOptions.RowCount, PageableSelectDirection.Next);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get portal message files.
		/// </summary>
		/// <param name="PortalMessageId">Portal message uniqueidentifier.</param>
		/// <param name="readingOptions">Readin message options <see cref="ReadingOptions"/>.</param>
		/// <returns>Container with Portal message files collection <see cref="PortalFileServiceResponse"/>.</returns>
		public IEnumerable<PortalMessageFileDTO> GetPortalMessageFiles(string portalMessageId, ReadingOptions readingOptions) {
			var options = GetPageableOptions(readingOptions);
			var portalMessageFileSelect = GetPortalMessageFilesSelect(portalMessageId).ToPageable(options);
			var files = new List<PortalMessageFileDTO>();
			using (DBExecutor dbExec = userConnection.EnsureDBConnection()) {
				using (IDataReader reader = portalMessageFileSelect.ExecuteReader(dbExec)) {
					var canReadData = false;
					while (reader.Read() && ((canReadData || CheckIfUserCanReadFiles(reader.GetColumnValue<Guid>("EntitySchemaUId"),
						reader.GetColumnValue<Guid>("EntityId"), out canReadData)))) {
						files.Add(CreatePortalMessageDTO(reader));
					}
				}
			}
			return files;
		}

		#endregion
	}

	#endregion

}
