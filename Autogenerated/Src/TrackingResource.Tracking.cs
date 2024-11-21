namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Configuration.Tracking;

	#region Class: TrackingResource_TrackingEventsProcess

	public partial class TrackingResource_TrackingEventsProcess<TEntity>
	{

		#region Properties: Private

		private Guid EntityId { 
			get {
				return Entity.GetTypedColumnValue<Guid>("Id");
			}
		}

		private Guid ProjectId {
			get {
				return Entity.GetTypedColumnValue<Guid>("ProjectId");
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

		private TenantDataProvider TenantDataProvider {
			get {
				return new TenantDataProvider(UserConnection);
			}
		}

		#endregion

		#region Methods: Private

		private void InsertResourceToCloudTenantService() {
			try {
				var resourceDataProvider = new ResourceDataProvider(UserConnection);
				resourceDataProvider.Create(EntityId, ProjectId, IsActive);
			} catch (Exception ex) {
				throw new Exception(string.Format(DataSyncErrorMessage.Value, ex.Message));
			}
		}

		private void UpdateResourceInCloudTenantService() {
			try {
				var resourceDataProvider = new ResourceDataProvider(UserConnection);
				resourceDataProvider.Update(EntityId, IsActive);
			} catch (Exception ex) {
				throw new Exception(string.Format(DataSyncErrorMessage.Value, ex.Message));
			}
		}

		private void DeleteResourceInCloudTenantService() {
			try {
				var resourceDataProvider = new ResourceDataProvider(UserConnection);
				resourceDataProvider.Delete(EntityId);
			} catch (Exception ex) {
				throw new Exception(string.Format(DataSyncErrorMessage.Value, ex.Message));
			}
		}

		private void BeforeInsertResource() {
			PingCloud();
		}

		private void BeforeUpdateResource() {
			PingCloud();
		}

		private void PingCloud() {
			try {
				TenantDataProvider.PingTenant();
			} catch (Exception ex) {
				throw new Exception(string.Format(DataSyncErrorMessage.Value, ex.Message));
			}
		}

		private void UpdateResource() {
			if (IsDeleted) {
				DeleteResourceInCloudTenantService();
			} else {
				UpdateResourceInCloudTenantService();
			}
		}

		#endregion

	}

	#endregion

}

