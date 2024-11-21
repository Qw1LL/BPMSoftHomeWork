 namespace BPMSoft.Configuration.GlobalSearch
{
	using System.Linq;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;
	using BPMSoft.GlobalSearch.Indexing;

	#region Class: GlobalSearchSysModuleListener

	/// <summary>
	/// Class provides SysModule entity events handling.
	/// </summary>
	[EntityEventListener(SchemaName = "SysModule")]
	public class GlobalSearchSysModuleListener : BaseEntityEventListener
	{

		#region Properties: Private

		private AvailableIndexingEntities _availableIndexingEntities;
		private AvailableIndexingEntities AvailableIndexingEntities =>
			_availableIndexingEntities ??
			(_availableIndexingEntities = ClassFactory.Get<AvailableIndexingEntities>());

		#endregion
		
		#region Methods: Private

		private void ReloadAvailableIndexingEntities(SysModule entity) {
			var isChangedGlobalSearchAvailableValue = entity.GetChangedColumnValues()
				.Any(value => value.Column.Name == nameof(entity.GlobalSearchAvailable));
			if (isChangedGlobalSearchAvailableValue) {
				AvailableIndexingEntities.ClearCache(entity.UserConnection);	
			}
		}
		
		#endregion

		#region Methods: Public

		/// <summary>
		/// <see cref="BaseEntityEventListener.OnInserted"/>
		/// </summary>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			ReloadAvailableIndexingEntities((SysModule)sender);
		}

		/// <summary>
		/// <see cref="BaseEntityEventListener.OnUpdated"/>
		/// </summary>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			ReloadAvailableIndexingEntities((SysModule)sender);
		}

		/// <summary>
		/// <see cref="BaseEntityEventListener.OnDeleted"/>
		/// </summary>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			ReloadAvailableIndexingEntities((SysModule)sender);
		}
		
		#endregion

	}

	#endregion

}

