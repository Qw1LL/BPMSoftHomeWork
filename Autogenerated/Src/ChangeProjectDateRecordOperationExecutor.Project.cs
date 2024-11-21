namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;

	#region Class: ChangeProjectDateRecordOperationExecutor

	/// <summary>
	/// Operation to adjust project dates.
	/// </summary>
	public class ChangeProjectDateRecordOperationExecutor : IRecordOperationExecutor
	{	
		#region Fields: Private

		private DateTime _rootStartDate;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="rootStartDate">Project hierarchy collection.</param>
		public ChangeProjectDateRecordOperationExecutor(DateTime rootStartDate) {
			_rootStartDate = rootStartDate;
		}

		#endregion

		#region Methods: Private

		private DateTime GetSubordinateWorkStartDate(Entity work) {
			var workStartDate = work.GetTypedColumnValue<DateTime>("StartDate");
			return DateTime.UtcNow.Add(GetDateDifference(_rootStartDate, workStartDate));
		}

		private TimeSpan GetDateDifferenceFromEntityColumns(Entity entity, string startColumn, string endColumn) {
			var startDate = entity.GetTypedColumnValue<DateTime>(startColumn);
			var endDate = entity.GetTypedColumnValue<DateTime>(endColumn);
			return GetDateDifference(startDate, endDate);
		}

		private DateTime GetEndDate(Entity work, DateTime offsetDate, string startDateColumnName, string endDateColumnName) {
			return offsetDate.Add(GetDateDifferenceFromEntityColumns(work, startDateColumnName, endDateColumnName));
		}

		private TimeSpan GetDateDifference(DateTime start, DateTime end) {
			TimeSpan span = end - start;
			return span.Ticks > 0 ? span : TimeSpan.Zero;
		}

		private void SetColumnValueIfNotDefault<TValue>(Entity entity, string columnName, TValue value) {
			if (!entity.GetTypedColumnValue<TValue>(columnName).Equals(default(TValue))) {
				entity.SetColumnValue(columnName, value);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Execute date adjustment.
		/// </summary>
		/// <param name="entity">Project entity.</param>
		public void Execute(Entity entity) {
			entity.CheckArgumentNull("entity");
			DateTime newStartDate = entity.GetTypedColumnValue<Guid>("ParentProjectId").IsEmpty() 
				? DateTime.UtcNow 
				: GetSubordinateWorkStartDate(entity);
			DateTime newEndDate = GetEndDate(entity, newStartDate, "StartDate", "EndDate");
			DateTime newDeadline = GetEndDate(entity, newStartDate, "StartDate", "Deadline");
			SetColumnValueIfNotDefault(entity, "StartDate", newStartDate);
			SetColumnValueIfNotDefault(entity, "EndDate", newEndDate);
			SetColumnValueIfNotDefault(entity, "Deadline", newDeadline);
		}

		#endregion
	}

	#endregion
}
