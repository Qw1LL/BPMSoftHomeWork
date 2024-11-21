namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: MultiUnlinkWorker

	public class MultiUnlinkWorker : BaseRecordsOperationWorker
	{

		#region Properties: Protected

		protected virtual Dictionary<string, HashSet<string>> UnlinkConstraints => new Dictionary<string, HashSet<string>> {
			{
				"SysAdminUnit", new HashSet<string> { "ContactId" }
			}
		};

		#endregion

		#region Constructors: Public

		public MultiUnlinkWorker(UserConnection userConnection, IDictionary<string, object> parameters)
			: base(userConnection, parameters) {
			OperationExecutor = new RecordUnlinker(userConnection, parameters);
		}

		#endregion

		#region Methods: Protected
		
		protected virtual bool CanUnlink(Entity entity, string lookupColumnName) {
			return UnlinkConstraints.Count(x => x.Key == entity.SchemaName && x.Value.Contains(lookupColumnName)) == 0;
		}

		protected override Entity GetPreparedEntity(Entity entity) {
			IEnumerable<string> columns = (IEnumerable<string>)Parameters["Columns"];
			IEnumerable<Guid> recordReferenceIds = (IEnumerable<Guid>)Parameters["RecordReferenceIds"];
			foreach (string columnName in columns) {
				string columnLookupName = columnName + "Id";
				if (!CanUnlink(entity, columnLookupName)) {
					continue;
				}
				Guid value = entity.GetTypedColumnValue<Guid>(columnLookupName);
				if (recordReferenceIds.Any(a => a.Equals(value))) {
					entity.SetColumnValue(columnLookupName, null);
				}
			}
			return entity;
		}

		protected override Exception GetOperationException() {
			RecordUnlinker recordUnlinker = (RecordUnlinker)OperationExecutor;
			return recordUnlinker.OperationException;
		}

		#endregion

	}

	#endregion

}

