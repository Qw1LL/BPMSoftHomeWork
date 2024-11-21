namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using Core;
	using Core.Entities;
	using Core.Entities.AsyncOperations;
	using Core.Entities.AsyncOperations.Interfaces;
	using Core.Entities.Events;
	using Core.Factories;
	using Core.OrgStructure;

	#region Class: EntitySysAdminUnitListener

	[EntityEventListener(SchemaName = "SysAdminUnit")]
	public class EntitySysAdminUnitListener : BaseEntityEventListener
	{

		#region Methods: Private

		private static void ExecuteActualizeSysAdminUnitInRoleAsyncOperation(Entity entity) {
			if (!GlobalAppSettings.EnableImediateActualizeSysAdminUnitInRole ||
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

		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			if (e.ModifiedColumnValues.Any(x => x.Name == "SysAdminUnitTypeValue" || x.Name == "ConnectionType" ||
					x.Name == "ParentRoleId")) {
				var entity = (Entity)sender;
				ExecuteActualizeSysAdminUnitInRoleAsyncOperation(entity);
			}
		}

		#endregion

	}

	#endregion

}

