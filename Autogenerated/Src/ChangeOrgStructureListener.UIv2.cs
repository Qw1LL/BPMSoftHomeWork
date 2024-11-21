namespace BPMSoft.Configuration
{
	using System;
	using Core;
	using Core.Entities;
	using Core.Entities.AsyncOperations;
	using Core.Entities.AsyncOperations.Interfaces;
	using Core.Entities.Events;
	using Core.Factories;
	using Core.OrgStructure;

	#region Class: ActualizeSysAdminUnitInRoleAsyncOperation

	/// <inheritdoc />
	public class ActualizeSysAdminUnitInRoleAsyncOperation : IEntityEventAsyncOperation
	{

		#region Methods: Public

		/// <inheritdoc />
		public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments) {
			BPMSoft.Core.OrgStructure.IOrgStructureManager orgStructureManager = new OrgStructureManager(userConnection);
			orgStructureManager.ActualizeSysAdminUnitInRole();
		}

		#endregion

	}

	#endregion

	#region Class: ChangeOrgStructureListener

	[EntityEventListener(SchemaName = "SysUserInRole")]
	[EntityEventListener(SchemaName = "SysAdminUnitGrantedRight")]
	[EntityEventListener(SchemaName = "SysFuncRoleInOrgRole")]
	public class ChangeOrgStructureListener : BaseEntityEventListener
	{

		#region Methods: Private

		private static void ExecuteActualizeSysAdminUnitInRoleAsyncOperation(Entity entity) {
			if (!BPMSoft.Core.GlobalAppSettings.EnableImediateActualizeSysAdminUnitInRole ||
					!GlobalAppSettings.UseOrgStructureManagerForActualizeUsersRoles) {
				return;
			}
			var asyncExecutor = ClassFactory.Get<IEntityEventAsyncExecutor>(
				new ConstructorArgument("userConnection", entity.UserConnection));
			var operationArgs = new EntityEventAsyncOperationArgs(entity, null);
			asyncExecutor.ExecuteAsync<ActualizeSysAdminUnitInRoleAsyncOperation>(operationArgs);
		}

		#endregion

		#region Methods: Public

		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			var entity = (Entity)sender;
			ExecuteActualizeSysAdminUnitInRoleAsyncOperation(entity);
		}

		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			var entity = (Entity)sender;
			ExecuteActualizeSysAdminUnitInRoleAsyncOperation(entity);
		}

		#endregion

	}

	#endregion

}

