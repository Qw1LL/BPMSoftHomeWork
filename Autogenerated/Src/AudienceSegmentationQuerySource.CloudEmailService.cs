namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: AudienceSegmentationQuerySource

	/// <summary>
	/// Class to get select-query to segment audience.
	/// </summary>
	public class AudienceSegmentationQuerySource
	{

		#region Fields: Private
		
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates instance of <see cref="AudienceSegmentationQuerySource"/>
		/// </summary>
		/// <param name="userConnection">Current user connection</param>
		public AudienceSegmentationQuerySource(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private void AddColumnsToSelect(EntitySchemaQuery esq, EntitySchema schema) {
			AddColumnWithoutDisplayValue(esq, "Contact", "ContactId");
			AddColumnWithoutDisplayValue(esq, "MandrillId", "RecipientUId");
		}

		private void AddColumnWithoutDisplayValue(EntitySchemaQuery esq, string column, string columnAlias) {
			EntitySchemaQueryExpression columnExpression =
				EntitySchemaQuery.CreateSchemaColumnQueryExpression(column, esq.RootSchema);
			columnExpression.UId = Guid.NewGuid();
			var entitySchemaQueryColumn = new EntitySchemaQueryColumn(column) {
				ValueExpression = columnExpression
			};
			entitySchemaQueryColumn.SetForcedQueryColumnValueAlias(columnAlias);
			esq.AddColumn(entitySchemaQueryColumn);
		}

		private void AddFilters(EntitySchemaQuery esq, Guid bulkEmailId) {
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "BulkEmail", bulkEmailId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "BulkEmailResponse",
				MailingConsts.BulkEmailResponseReadyToSendId));
			esq.Filters.Add(esq.CreateNotExistsFilter("[BulkEmailRecipientReplica:RecipientId:MandrillId].Id"));
		}

		private EntitySchema CreateAudienceEntitySchema() {
			return _userConnection.EntitySchemaManager.GetInstanceByName("BulkEmailTarget").Clone() as EntitySchema;
		}

		private EntitySchemaQuery CreateAudienceEntitySchemaQuery(EntitySchema schema) {
			var esq = new EntitySchemaQuery(schema) {
				UseAdminRights = false
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = false;
			return esq;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets select-query for email audience, except already segmented records.
		/// </summary>
		/// <returns></returns>
		public virtual Select GetAudienceSelect(Guid bulkEmailId) {
			EntitySchema schema = CreateAudienceEntitySchema();
			EntitySchemaQuery esq = CreateAudienceEntitySchemaQuery(schema);
			AddColumnsToSelect(esq, schema);
			AddFilters(esq, bulkEmailId);
			return esq.GetSelectQuery(_userConnection);
		}

		#endregion

	}

	#endregion
}

