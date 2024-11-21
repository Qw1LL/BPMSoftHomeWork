namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	/// <summary>
	/// Represent completeness item.
	/// </summary>
	public class CompletenessItem
	{

		#region Properties: Public

		/// <summary>
		/// Get record id.
		/// </summary>
		public Guid RecordId {
			get;
		}

		/// <summary>
		/// Get schema name.
		/// </summary>
		public string SchemaName {
			get;
		}

		/// <summary>
		/// Get completeness value.
		/// </summary>
		public int Completeness {
			get;
		}

		/// <summary>
		/// Get column for update.
		/// </summary>
		public string ResultColumn {
			get;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize new instance of <see cref="CompletenessItem"/> class.
		/// </summary>
		/// <param name="recordId">Record id.</param>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="completeness">Completeness value.</param>
		/// <param name="resultColumn">Column for update.</param>
		public CompletenessItem(Guid recordId, string schemaName, int completeness, string resultColumn) {
			RecordId = recordId;
			SchemaName = schemaName;
			Completeness = completeness;
			ResultColumn = resultColumn;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Update completenses on DB.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		public virtual void Update(UserConnection userConnection) {
			var update = new Update(userConnection, SchemaName)
				.Set(ResultColumn, Column.Parameter(Completeness))
				.Where("Id").IsEqual(Column.Parameter(RecordId));
			update.Execute();
		}

		#endregion

	}
}

