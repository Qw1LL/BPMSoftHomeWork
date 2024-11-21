namespace BPMSoft.Configuration.EntitySynchronization
{

	using System.Collections.Generic;
	using BPMSoft.Core.Entities;
	using BPMSoft.Common;

	#region Interface: IEntitySynchronizationProvider

	public interface IEntitySynchronizationProvider
	{

		Entity FindEntity(string entitySchemaName, Dictionary<string, object> conditions);

		Entity CreateEntity(string entitySchemaName, bool useAdminRights = false);

		Entity FindEntity(string entitySchemaName, Dictionary<string, object> conditions,
			Dictionary<string, OrderDirection> orderByColumns);

	}

	#endregion

}

