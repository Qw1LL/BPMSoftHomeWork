namespace BPMSoft.Configuration.GlobalSearch
{
	using System.Collections.Generic;

	#region Class: IndexedDataConfig
	
	public class IndexedDataConfig : Dictionary<string, IndexedSectionConfig>
	{
	}
	
	#endregion
	
	#region Class: IndexedSectionConfig
	
	public class IndexedSectionConfig
	{
		public string[] IgnoredColumns;
	}

	#endregion
	
}

