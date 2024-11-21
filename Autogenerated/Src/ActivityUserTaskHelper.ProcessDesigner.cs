namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;

	#region Class: ActivityUserTaskHelper
	
	/// <summary>
	/// Provides auxiliary methods for the activity user task.
	/// </summary>
	public static class ActivityUserTaskHelper
	{

		#region Methods: Public

		/// <summary>
		/// Fills column value of the entity.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="columnName">Column name.</param>
		/// <param name="value">Column value.</param>
		public static void SpecifyActivityLookupColumnValue(Entity entity, string columnName, Guid value) {
			if (value.IsEmpty()) {
				return;
			}
			EntitySchema activitySchema = entity.Schema;
			EntitySchemaColumnCollection columns = activitySchema.Columns;
			EntitySchemaColumn entitySchemaColumn = columns.FindByName(columnName);
			if (entitySchemaColumn != null) {
				entity.SetColumnValue(entitySchemaColumn, value);
			}
		}

		#endregion

	}

	#endregion

}

