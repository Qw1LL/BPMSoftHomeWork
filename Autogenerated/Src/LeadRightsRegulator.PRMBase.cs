namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.AsyncOperations;
	using BPMSoft.Core.Entities.AsyncOperations.Interfaces;

	#region Class: LeadEntityEventAsyncOperationArgs

	public class LeadEntityEventAsyncOperationArgs : EntityEventAsyncOperationArgs
	{
		public LeadEntityEventAsyncOperationArgs(Entity entity, EventArgs eventArgs)
			: base(entity, eventArgs) {
			SalesChannel = entity.SafeGetColumnValue<Guid>("SalesChannelId");
		}

		public Guid SalesChannel {
			get;
		}
	}

	#endregion

	#region Class: LeadRightsRegulator

	/// <summary>
	/// Class, which is manage lead record rights.
	/// </summary>
	public class LeadRightsRegulator : IEntityEventAsyncOperation
	{

		#region Fields: Private

		private readonly Guid _partnerSaleOpportunityType = new Guid("C4505EFC-6CF5-4B0C-B984-55076BC235F0");
		private SspEntityRightsRegulator _rightsRegulator;

		#endregion

		#region Methods: Private

		private void ManageLeadOrganizationRights(EntityEventAsyncOperationArgs arguments) {
			_rightsRegulator.ManageEntityOrganizationRights(arguments.EntityId,
				arguments.EntityColumnValues.GetTypedValue<Guid>("PartnerId"),
				arguments.OldEntityColumnValues.GetTypedValue<Guid>("PartnerId"));
		}

		private void ManageLeadOwnerRights(LeadEntityEventAsyncOperationArgs arguments) {
			if (arguments.SalesChannel != _partnerSaleOpportunityType) {
				return;
			}
			_rightsRegulator.ManageEntityOwnerRights(
				arguments.EntityId,
				arguments.EntityColumnValues.GetTypedValue<Guid>("OwnerId"),
				arguments.OldEntityColumnValues.GetTypedValue<Guid>("OwnerId")); ;
		}

		#endregion

		#region Methods: Public

		public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments) {
			_rightsRegulator = new SspEntityRightsRegulator(userConnection, arguments.EntitySchemaName);
			ManageLeadOrganizationRights(arguments);
			ManageLeadOwnerRights((LeadEntityEventAsyncOperationArgs)arguments);
		}

		#endregion

	}

	#endregion

}

