namespace BPMSoft.Configuration
{
	using System.Collections.Generic;

	#region Interface: IFullPipelineDataRetriever

	/// <summary>
	/// Provides interface of retrieval full pipeline data.
	/// </summary>
	public interface IFullPipelineDataRetriever
	{

		#region Methods: Public

		/// <summary>
		/// Retrieve data.
		/// </summary>
		/// <param name="pipelineEntityConfigs">The pipeline entity configurations.</param>
		/// <returns>Collection of <see cref="FullPipelineRow"/></returns>
		IEnumerable<FullPipelineRow> DataRetrieve(IEnumerable<FullPipelineEntityConfig> pipelineEntityConfigs);

		#endregion

	}

	#endregion

}
