namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: BaseSysSettingsEventListener

	/// <summary>
	/// Class provides base logic of event handling for system settings.
	/// </summary>
	public abstract class BaseSysSettingsEventListener<TCoreEntity> : BaseEntityEventListener
		where TCoreEntity : Entity
	{

		#region Methods: Private

		private void Actualize(object source, EntityChangeType entityChangeType) {
			if (GlobalAppSettings.FeatureUseSysSettingsEngine) {
				var sourceEntity = (Entity)source;
				var userConnection = sourceEntity.UserConnection;
				TCoreEntity coreEntity = CreateCoreEntity(userConnection);
				sourceEntity.GetColumnValueNames()
					.Where(columnName => sourceEntity.IsColumnValueLoaded(columnName))
					.Join(coreEntity.GetColumnValueNames(), x => x, y => y, (x, y) => x)
					.ForEach(columnName => coreEntity.SetColumnValue(columnName, sourceEntity.GetColumnValue(columnName)));
				ActualizeCoreEntity(userConnection, coreEntity, entityChangeType);
			}
		}

		#endregion
		
		#region Methods: Protected

		protected abstract TCoreEntity CreateCoreEntity(UserConnection userConnection);

		protected abstract void ActualizeCoreEntity(UserConnection userConnection, 
			TCoreEntity coreEntity, EntityChangeType entityChangeType);

		#endregion

		#region Methods: Public

		/// <summary>
		/// <see cref="BaseEntityEventListener.OnInserted"/>
		/// </summary>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			Actualize(sender, EntityChangeType.Inserted);
		}

		/// <summary>
		/// <see cref="BaseEntityEventListener.OnUpdated"/>
		/// </summary>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			Actualize(sender, EntityChangeType.Updated);
		}

		/// <summary>
		/// <see cref="BaseEntityEventListener.OnDeleted"/>
		/// </summary>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			Actualize(sender, EntityChangeType.Deleted);
		}

		#endregion

	}

	#endregion

}
 
