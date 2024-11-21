namespace BPMSoft.Configuration.FileImport
{
	using System.Collections.Generic;
	using BPMSoft.Core.Entities;

	public interface IChildImportEntitiesSetter
	{
		/// <summary>
		/// Sets existing entities to import entities.
		/// </summary>
		/// <param name="parameters">Import parameters.</param>
		/// <param name="entities">Existing entities.</param>
		void Set(ImportParameters parameters, IEnumerable<Entity> entities);
	}
}
