namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using Core.DB;

	public interface IDashboardItemSelectBuilder
	{

		/// <summary>
		/// Dictionary with columns parameters.
		/// </summary>
		Dictionary<string, object> EntityColumnsMap { get; }

		/// <summary>
		/// Builds select query for data load.
		/// </summary>
		Select Build();

	}

}
