namespace BPMSoft.Configuration.EntitySynchronization
{
	using System.Collections.Generic;
	using BPMSoft.Core.Entities;

	#region Interface: IColumnValuesSynchronizer

	public interface IColumnValuesSynchronizer
	{

		void SynchronizeEntities(Entity source, Entity destination,
			ICollection<SynchronizationColumnMapping> columnMappings);

		void FillDestinationEntity(Entity source, Entity destination,
			ICollection<SynchronizationColumnMapping> columnMappings);

	}

	#endregion

}
