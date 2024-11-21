namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: AudienceMacroDataSource

	public class AudienceMacroDataSource
	{

		#region Constants: Private

		private const int QueryBatchSize = 1000;

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public AudienceMacroDataSource(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private static void AddFilters(EntitySchemaQuery esq, Guid bulkEmailId, Guid replicaId) {
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "BulkEmail", bulkEmailId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[BulkEmailRecipientReplica:RecipientId:MandrillId].DCReplica", replicaId));
			esq.Filters.Add(esq.CreateNotExistsFilter("[BulkEmailRecipientMacro:RecipientUId:MandrillId].Id"));
			esq.RowCount = QueryBatchSize;
		}

		private void AddColumns(EntitySchemaQuery esq) {
			AddColumnWithoutDisplayValue(esq, esq.RootSchema, "Contact");
			esq.AddColumn("LinkedEntityId");
			esq.AddColumn("MandrillId");
			esq.AddColumn("[BulkEmailRecipientReplica:RecipientId:MandrillId].Id");
		}

		private void AddColumnWithoutDisplayValue(EntitySchemaQuery esq, EntitySchema schema, string column) {
			EntitySchemaQueryExpression columnExpression =
				EntitySchemaQuery.CreateSchemaColumnQueryExpression(column, schema);
			columnExpression.UId = Guid.NewGuid();
			esq.AddColumn(new EntitySchemaQueryColumn(column) {
				ValueExpression = columnExpression
			});
		}

		private EntitySchemaQuery GetEntitySchemaQuery() {
			var schema =
				_userConnection.EntitySchemaManager.GetInstanceByName("BulkEmailTarget").Clone() as EntitySchema;
			var esq = new EntitySchemaQuery(schema) {
				UseAdminRights = false
			};
			return esq;
		}

		#endregion

		#region Methods: Public

		public virtual EntityCollection GetAudience(Guid bulkEmailId, Guid replicaId) {
			EntitySchemaQuery esq = GetEntitySchemaQuery();
			AddColumns(esq);
			AddFilters(esq, bulkEmailId, replicaId);
			return esq.GetEntityCollection(_userConnection);
		}

		#endregion

	}

	#endregion

}

