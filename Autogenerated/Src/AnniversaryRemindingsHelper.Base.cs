namespace BPMSoft.Configuration
{
	using BPMSoft.Core.DB;

	public static class AnniversaryRemindingsHelper
	{
		
		/// <summary>
		/// Returns select with join parameters.
		/// <param name="select">Select.</param>
		/// <param name="schemaName">Current schema name.</param>
		/// <param name="anniversarySchemaName">Anniversary schema name.</param>
		/// </summary>
		public static Select JoinTable(Select select, string schemaName, string anniversarySchemaName) {
			select.Join(JoinType.Inner, anniversarySchemaName)
				.On(anniversarySchemaName, "Id").IsEqual(schemaName, anniversarySchemaName + "Id");
			return select;
		}
	}
}

