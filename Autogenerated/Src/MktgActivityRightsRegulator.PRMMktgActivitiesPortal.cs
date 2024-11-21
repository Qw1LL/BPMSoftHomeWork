namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities.AsyncOperations;
	using BPMSoft.Core.Entities.AsyncOperations.Interfaces;

	#region Class: MktgActivityRightsRegulator

	/// <summary>
	/// Class which executes operation for changing rights on MktgActivity. 
	/// </summary>
	public class MktgActivityRightsRegulator : IEntityEventAsyncOperation
	{

		#region Properties: Public 

		public SspEntityRightsRegulator SspEntityRightsRegulator;

		#endregion

		#region Methods: Private

		private void ManageMktgActivityOrganizationRights(EntityEventAsyncOperationArgs arguments) {
			SspEntityRightsRegulator.ManageEntityOrganizationRights(arguments.EntityId,
				arguments.EntityColumnValues.GetTypedValue<Guid>("AccountId"),
				arguments.OldEntityColumnValues.GetTypedValue<Guid>("AccountId"));
		}

		private void ManageMktgActivityOwnerRights(EntityEventAsyncOperationArgs arguments) {
			SspEntityRightsRegulator.ManageEntityOwnerRights(
				arguments.EntityId,
				arguments.EntityColumnValues.GetTypedValue<Guid>("OwnerId"),
				arguments.OldEntityColumnValues.GetTypedValue<Guid>("OwnerId")); ;
		}

		#endregion

		#region Methods: Public

		public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments) {
			SspEntityRightsRegulator = SspEntityRightsRegulator ?? new SspEntityRightsRegulator(userConnection, arguments.EntitySchemaName);
			ManageMktgActivityOrganizationRights(arguments);
			ManageMktgActivityOwnerRights(arguments);
		}

		#endregion

	}

	#endregion

}

