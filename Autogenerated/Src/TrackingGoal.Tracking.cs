namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Configuration.Tracking;

	#region Class: TrackingGoal_TrackingEventsProcess

	public partial class TrackingGoal_TrackingEventsProcess<TEntity>
	{

		#region Properties: Private

		private Guid EntityId {
			get {
				return Entity.GetTypedColumnValue<Guid>("Id");
			}
		}

		private Guid ResourceId {
			get {
				return Entity.GetTypedColumnValue<Guid>("ResourceId");
			}
		}

		private bool IsActive {
			get {
				return Entity.GetTypedColumnValue<bool>("IsActive");
			}
		}

		private bool IsDeleted {
			get {
				return Entity.GetTypedColumnValue<bool>("IsDeleted");
			}
		}

		private string Settings {
			get {
				return Entity.GetTypedColumnValue<string>("Settings");
			}
		}

		#endregion

		#region Methods: Private

		private void InsertGoalToCloudTenantService() {
			try {
				var goalDataProvider = new GoalDataProvider(UserConnection);
				goalDataProvider.Create(EntityId, ResourceId, IsActive, Settings);
			} catch (Exception ex) {
				throw new Exception(string.Format(DataSyncErrorMessage.Value, ex.Message));
			}
		}

		private void UpdateGoalInCloudTenantService() {
			try {
				var goalDataProvider = new GoalDataProvider(UserConnection);
				goalDataProvider.Update(EntityId, IsActive, Settings);
			} catch (Exception ex) {
				throw new Exception(string.Format(DataSyncErrorMessage.Value, ex.Message));
			}
		}

		private void DeleteGoalInCloudTenantService() {
			try {
				var goalDataProvider = new GoalDataProvider(UserConnection);
				goalDataProvider.Delete(EntityId);
			} catch (Exception ex) {
				throw new Exception(string.Format(DataSyncErrorMessage.Value, ex.Message));
			}
		}

		private void UpdateGoal() {
			if (IsDeleted) {
				DeleteGoalInCloudTenantService();
			} else {
				UpdateGoalInCloudTenantService();
			}
		}

		#endregion

	}

	#endregion

}
