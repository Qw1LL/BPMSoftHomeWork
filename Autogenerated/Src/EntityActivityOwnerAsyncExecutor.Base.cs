namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities.AsyncOperations;
	using BPMSoft.Core.Entities.AsyncOperations.Interfaces;

	#region Class: EntityActivityAsyncOwner

	/// <summary>
	/// Class wich executes operation for changing owner of entity activities. 
	/// </summary>
	public class EntityActivityOwnerAsyncExecutor : IEntityEventAsyncOperation
	{

		#region Methods: Public

		/// <summary>
		/// <see cref="IEntityEventAsyncOperation.Execute"/>
		/// <remarks>Executes operation by transfering activities of entity owner to the new entity owner.</remarks>
		/// </summary>
		public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments) {
			var operationArgs = (EntityOwnerEventAsyncOperationArgs)arguments;
			var ownerEntityInfo = new EntityActivitiesOwnerInfo {
				EntityId = operationArgs.EntityId,
				NewOwnerId = operationArgs.EntityColumnValues.GetTypedValue<Guid>(operationArgs.OwnerColumnName),
				OldOwnerId = operationArgs.OldEntityColumnValues.GetTypedValue<Guid>(operationArgs.OwnerColumnName),
				EntitySchemaName = operationArgs.EntitySchemaName
			};
			new EntityActivitiesOwner(userConnection).Change(ownerEntityInfo);
		}

		#endregion

	}

	#endregion

}
