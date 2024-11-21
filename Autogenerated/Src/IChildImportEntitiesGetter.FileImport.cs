namespace BPMSoft.Configuration.FileImport
{
	using System.Collections.Generic;
	using BPMSoft.Core.Entities;

	public interface IChildImportEntitiesGetter
	{
		/// <summary>
		/// Gets child entities.
		/// </summary>
		/// <param name="parameters">Import parameters.</param>
		/// <returns>Child entities.</returns>
		IEnumerable<Entity> Get(ImportParameters parameters);
	}
}
