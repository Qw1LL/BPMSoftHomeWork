namespace BPMSoft.Configuration.Section
{
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.AsyncOperations;
	using BPMSoft.Core.Entities.AsyncOperations.Interfaces;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;

	#region Class: SysModuleSSPEventListener

	/// <summary>
	/// Class provides SysModule entity events handling.
	/// </summary>
	[EntityEventListener(SchemaName = "SysModule")]
	public class SysModuleSSPEventListener : BaseEntityEventListener
	{

		#region Methods: Protected

		/// <summary>
		/// Registers section as self-service portal if <paramref name="sysModule"/> type equals <see cref="SectionType"/> SSP.
		/// </summary>
		/// <param name="sysModule"><see cref="Entity"/> instance.</param>
		/// <param name="e"><paramref name="sysModule"/> event arguments instance.</param>
		protected void RegisterSectionAsSsp(Entity sysModule, EntityAfterEventArgs e) {
			var userConnection = sysModule.UserConnection;
			if (!sysModule.GetIsColumnValueLoaded("Type") ||
					sysModule.GetTypedColumnValue<int>("Type") != (int)SectionType.SSP) {
				return;
			}
			var asyncExecutor = ClassFactory.Get<IEntityEventAsyncExecutor>(new ConstructorArgument("userConnection", userConnection));
			var operationArgs = new EntityEventAsyncOperationArgs(sysModule, e);
			asyncExecutor.ExecuteAsync<SysModuleSSPEventAsyncOperation>(operationArgs);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// <see cref="BaseEntityEventListener.OnInserted"/>
		/// </summary>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			RegisterSectionAsSsp((Entity)sender, e);
		}

		/// <summary>
		/// <see cref="BaseEntityEventListener.OnUpdated(object, EntityAfterEventArgs)"/>
		/// </summary>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			RegisterSectionAsSsp((Entity)sender, e);
		}

		#endregion

	}

	#endregion

}

