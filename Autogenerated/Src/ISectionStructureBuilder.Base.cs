namespace BPMSoft.Configuration
{

	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Interface: ISectionStructureBuilder

	public interface ISectionStructureBuilder
	{
		void ApplyCustomConditions(string schemaName, Select select);
	}

	#endregion

}
