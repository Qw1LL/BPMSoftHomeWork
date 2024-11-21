namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities.AsyncOperations;
	using BPMSoft.Core.Entities.AsyncOperations.Interfaces;

	#region Class: OpportunityRightsRegulator

	/// <summary>
	/// Class which executes operation for changing rights on opportunity. 
	/// </summary>
	public class OpportunityRightsAsyncRegulator : IEntityEventAsyncOperation
	{

		#region Fields: Private

		private SspEntityRightsRegulator _rightsRegulator;

		#endregion

		#region Methods: Private

		private void ManageOpportunityOrganizationRights(EntityEventAsyncOperationArgs arguments) {
			_rightsRegulator.ManageEntityOrganizationRights(arguments.EntityId,
				arguments.EntityColumnValues.GetTypedValue<Guid>("PartnerId"),
				arguments.OldEntityColumnValues.GetTypedValue<Guid>("PartnerId"));
		}

		private void ManageOpportunityOwnerRights(EntityEventAsyncOperationArgs arguments) {
			_rightsRegulator.ManageEntityOwnerRights(
				arguments.EntityId,
				arguments.EntityColumnValues.GetTypedValue<Guid>("OwnerId"),
				arguments.OldEntityColumnValues.GetTypedValue<Guid>("OwnerId")); ;
		}
		#endregion

		#region Methods: Public

		public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments) {
			_rightsRegulator = new SspEntityRightsRegulator(userConnection, arguments.EntitySchemaName);
			ManageOpportunityOrganizationRights(arguments);
			ManageOpportunityOwnerRights(arguments);
		}

		#endregion

	}

	#endregion

}

