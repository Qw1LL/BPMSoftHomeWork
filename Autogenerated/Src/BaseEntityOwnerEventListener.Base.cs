namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core.AsyncOperations.Interfaces;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.AsyncOperations;
	using BPMSoft.Core.Entities.AsyncOperations.Interfaces;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;

	#region Class: BaseEntityOwnerEventListener

	/// <summary>
	/// Listener of the change owner event on the entity.
	/// </summary>
	public class BaseEntityOwnerEventListener : BaseEntityEventListener
	{

		#region Properties: Protected

		protected string OwnerColumnName { get; set; } = "OwnerId";

		#endregion

		#region Methods: Private

		private bool IsOwnerChanged(EntityEventAsyncOperationArgs arguments) {
			var ownerId = arguments.EntityColumnValues.GetTypedValue<Guid>(OwnerColumnName);
			var oldOwnerId = arguments.OldEntityColumnValues.GetTypedValue<Guid>(OwnerColumnName);
			return ownerId != oldOwnerId &&
				ownerId != Guid.Empty &&
				oldOwnerId != Guid.Empty;
		}

		#endregion

		#region Methods: Protected

		protected virtual void RunExecutor<T>(IEntityEventAsyncExecutor asyncExecutor, EntityOwnerEventAsyncOperationArgs operationArgs) 
				where T : IAsyncOperation {
			asyncExecutor.ExecuteAsync<T>(operationArgs);
		}

		#endregion

		#region Methods: Public

		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			Entity entity = (Entity)sender;
			var operationArgs = new EntityOwnerEventAsyncOperationArgs(entity, e);
			if (entity.UserConnection.GetIsFeatureEnabled("ChangeEntityActivitiesAndProcessOwner") &&
					IsOwnerChanged(operationArgs)) {
				operationArgs.OwnerColumnName = OwnerColumnName;
				var asyncExecutor = ClassFactory
					.Get<IEntityEventAsyncExecutor>(new ConstructorArgument("userConnection", entity.UserConnection));
				RunExecutor<EntityActivityOwnerAsyncExecutor>(asyncExecutor, operationArgs);
				RunExecutor<EntityProcessElementDataOwnerAsyncExecutor>(asyncExecutor, operationArgs);
			}
		}

		#endregion

	}

	#endregion

}

