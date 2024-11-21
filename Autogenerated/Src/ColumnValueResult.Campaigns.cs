namespace BPMSoft.Configuration.Campaigns
{
	using System;

	#region Class: ColumnValueResult

	/// <summary>
	/// Result of column value interpreter for single column.
	/// </summary>
	public class ColumnValueResult
	{

		#region Constructors: Public

		/// <summary>
		/// Initialize <see cref="ColumnValueResult"/> instance.
		/// </summary>
		/// <param name="columnUId">Unique identifier of the column.</param>
		public ColumnValueResult(Guid columnUId) {
			ColumnUId = columnUId;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Entity column UId.
		/// </summary>
		public Guid ColumnUId { get; private set; }

		/// <summary>
		/// Column value.
		/// </summary>
		public object Value { get; set; }

		/// <summary>
		/// Processing exception if thrown.
		/// </summary>
		public Exception Exception { get; set; }

		#endregion

	}

	#endregion

}
