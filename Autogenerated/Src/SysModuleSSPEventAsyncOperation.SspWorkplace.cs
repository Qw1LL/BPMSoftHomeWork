namespace BPMSoft.Configuration.Section
{
	using System;
	using Core;
	using Core.Entities.AsyncOperations;
	using Core.Entities.AsyncOperations.Interfaces;
	using Core.Factories;
	using BPMSoft.Messaging.Common;

	#region Class: SysModuleSSPEventAsyncOperation

	/// <summary>
	/// Class implementats <see cref="IEntityEventAsyncOperation"/> interface for SysModule entity.
	/// </summary>
	public class SysModuleSSPEventAsyncOperation : IEntityEventAsyncOperation
	{

		#region Methods: Private

		/// <summary>
		/// Creates <see cref="ISectionManager"/> implementation instance.
		/// </summary>
		/// <param name="type">Section manager type.</param>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <returns><see cref="ISectionManager"/> implementation instance.</returns>
		private ISectionManager GetSectionManager(string type, UserConnection userConnection) {
			return ClassFactory.Get<ISectionManager>(new ConstructorArgument("uc", userConnection),
				new ConstructorArgument("sectionType", type));
		}

		/// <summary>
		/// Sends notification message for user.
		/// </summary>
		private void SendSocketMessage(UserConnection userConnection) {
			try {
				var sysAdminUnitId = userConnection.CurrentUser.Id;
				IMsgChannel channel = MsgChannelManager.Instance.FindItemByUId(sysAdminUnitId);
				if (channel == null) {
					return;
				}
				var simpleMessage = new SimpleMessage {
					Id = sysAdminUnitId,
					Body = string.Empty
				};
				simpleMessage.Header.Sender = "UpdateSectionInWorkplace";
				channel.PostMessage(simpleMessage);
			} catch (InvalidOperationException) {
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// <see cref="IEntityEventAsyncOperation.Execute"/>
		/// </summary>
		public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments) {
			var manager = GetSectionManager("SSP", userConnection);
			manager.Save(arguments.EntityId);
			SendSocketMessage(userConnection);
		}

		#endregion

	}

	#endregion

}

