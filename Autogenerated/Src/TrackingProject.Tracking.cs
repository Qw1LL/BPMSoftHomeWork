namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Configuration.Tracking;
	using BPMSoft.Core.DB;

	#region Class: TrackingProject_TrackingEventsProcess

	public partial class TrackingProject_TrackingEventsProcess<TEntity>
	{

		#region Properties: Private

		private Guid EntityId {
			get {
				return Entity.GetTypedColumnValue<Guid>("Id");
			}
		}

		private bool IsDeleted {
			get {
				return Entity.GetTypedColumnValue<bool>("IsDeleted");
			}
		}

		private ProjectDataProvider ProjectDataProvider {
			get {
				return new ProjectDataProvider(UserConnection);
			}
		}

		private TenantDataProvider TenantDataProvider {
			get {
				return new TenantDataProvider(UserConnection);
			}
		}

		#endregion

		#region Methods: Private

		private void InsertedProjectToCloudTenantService() {
			try {
				ProjectDataProvider.CreateProject(EntityId);
			} catch (Exception ex) {
				throw new Exception(string.Format(DataSyncErrorMessage.Value, ex.Message));
			}
		}
		
		private void DeleteProjectInCloudTenantService() {
			try {
				ProjectDataProvider.Delete(EntityId);
			} catch (Exception ex) {
				throw new Exception(string.Format(DataSyncErrorMessage.Value, ex.Message));
			}
		}
		
		private void AfterUpdateProject() {
			if (IsDeleted) {
				DeleteProjectInCloudTenantService();
			}
		}
		
		private void BeforeUpdateProject() {
			PingCloud();
			if (IsDeleted && IsResourcesExists(EntityId)) {
				throw new Exception(DeleteEntityErrorMessage.Value);
			}
		}

		private void BeforeInsertProject() {
			PingCloud();
		}

		private void PingCloud() {
			try {
				TenantDataProvider.PingTenant();
			} catch (Exception ex) {
				throw new Exception(string.Format(DataSyncErrorMessage.Value, ex.Message));
			}
		}

		private bool IsResourcesExists(Guid projectId) {
			var select = IsActiveResourcesExists(projectId);
			var result = select.ExecuteScalar<int>();
			return result > 0;
		}

		private Select IsActiveResourcesExists(Guid projectId) {
			var select = new Select(UserConnection)
				.Count("Id")
				.From("TrackingResource")
				.Where("ProjectId")
					.IsEqual(Column.Parameter(projectId))
				.And("IsDeleted")
					.IsEqual(Column.Parameter(false)) as Select;
			return select;
		}

		#endregion

	}

	#endregion

}

