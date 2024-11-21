namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using Core.DB;

	#region Interface: IFullPipelineQueryBuilder

	/// <summary>
	/// Provides method to query builder for full pipeline.
	/// </summary>
	public interface IFullPipelineQueryBuilder
	{

		#region Methods: Public

		/// <summary>
		/// Builds the query.
		/// </summary>
		/// <param name="configs">The configs.</param>
		/// <param name="schemaName">Name of the schema.</param>
		/// <returns><see cref="Select"/></returns>
		Select BuildQuery(IEnumerable<FullPipelineEntityConfig> configs, string schemaName);

		#endregion

	}

	#endregion

}

