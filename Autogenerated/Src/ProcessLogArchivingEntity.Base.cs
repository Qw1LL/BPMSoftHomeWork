using System;

namespace BPMSoft.Configuration
{

	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	[Obsolete("7.12.2 | Class is obsolete and will be removed in upcoming releases")]
	#region Class: ProcessLogArchivingEntity

	public class ProcessLogArchivingEntity : SysProcessLogArchivingEntity
	{

		#region Constants: Private

		private const string JoinSchema = "SysProcessLog";
		private const string JoinColumn = "SysProcessId";
		private const string KeyColumn = "Id";

		#endregion

		#region Constructors: Public

		public ProcessLogArchivingEntity(UserConnection userConnection, string schemaName, string historySchemaName)
			: base(userConnection, schemaName, historySchemaName) {
		}

		#endregion

		#region Methods: Private

		private Query GetProcessLogIdsSelect() {
			var query = new Select(UserConnection).Top(GetProcessLogArchivingCount())
				.Column(KeyColumn)
				.From(JoinSchema).As(JoinSchema);
			AddBaseArchivingQueryFilters(query, JoinSchema);
			return query;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Indicates this schema is referenced schema.
		/// </summary>
		public override bool GetIsReferencedSchema() {
			return false;
		}

		protected override void AddArchivingQueryFilters(Select query) {
			query.Join(JoinType.Inner, JoinSchema).As(JoinSchema)
				.On(JoinSchema, KeyColumn)
				.IsEqual(SchemaName, JoinColumn);
			AddBaseArchivingQueryFilters(query, JoinSchema);
			query.And(SchemaName, JoinColumn).In(GetProcessLogIdsSelect());
		}

		#endregion

	}

	#endregion

}
