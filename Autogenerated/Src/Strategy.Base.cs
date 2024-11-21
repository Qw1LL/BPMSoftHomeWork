namespace BPMSoft.Mail
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: Strategy

	/// <summary>
	/// Implementation of <see cref="IStrategy"/>
	/// </summary>
	[DefaultBinding(typeof(IStrategy))]
	public class Strategy : IStrategy
	{

		#region Constants: Private

		/// <summary>
		/// Base synchronization strategy name.
		/// </summary>
		private const string _baseSyncStrategyName = "UidBasedSyncStrategy";

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private readonly UserConnection _userConnection;

		/// <summary>
		/// Strategy binding key.
		/// </summary>
		private readonly string _strategyName;

		#endregion

		#region Constructors: Public

		public Strategy(UserConnection userConnection, string strategyName) {
			_userConnection = userConnection;
			_strategyName = strategyName;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Get sync strategy class factory binding key.
		/// </summary>
		/// <returns>Class factory binding key.</returns>
		private string GetStrategyName() {
			return _strategyName.IsNullOrEmpty() ? _baseSyncStrategyName : _strategyName;
		}

		/// <summary>
		/// Gets mailbox synchronization settings <see cref="Entity"/> instance by sender email address.
		/// </summary>
		/// <returns><see cref="Entity"/> instance.</returns>
		private Entity GetMailboxSyncSettingsEntity(string senderEmailAddress) {
			var mailboxSynSettingsSchema = _userConnection.EntitySchemaManager.GetInstanceByName("MailboxSyncSettings");
			var mailboxSynSettingsEntity = mailboxSynSettingsSchema.CreateEntity(_userConnection);
			mailboxSynSettingsEntity.FetchFromDB("SenderEmailAddress", senderEmailAddress, false);
			return mailboxSynSettingsEntity;
		}

		/// <summary>
		/// Returns <see cref="ISyncStrategy"/> implementation instance for <paramref name="senderEmailAddress"/>.
		/// </summary>
		/// <param name="senderEmailAddress">Mailbox sender email address.</param>
		/// <returns><see cref="ISyncStrategy"/> implementation instance.</returns>
		private ISyncStrategy GetStrategy(string senderEmailAddress) {
			var strategyName = GetStrategyName();
			var mssEntity = GetMailboxSyncSettingsEntity(senderEmailAddress);
			return ClassFactory.Get<ISyncStrategy>(strategyName, new ConstructorArgument("userConnection", _userConnection),
				new ConstructorArgument("syncSettings", mssEntity));
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IStrategy.GetStrategyQuery(string)"/>
		public string GetStrategyQuery(string senderEmailAddress) {
			var syncStrategy = GetStrategy(senderEmailAddress);
			return syncStrategy.GetUnsyncMsgSearchQuery();
		}

		/// <inheritdoc cref="IStrategy.GetFailoverStrategyQuery(string, DateTime)"/>
		public string GetFailoverStrategyQuery(string senderEmailAddress, DateTime sinceDate) {
			var syncStrategy = GetStrategy(senderEmailAddress);
			return syncStrategy.GetFailoverMsgSearchQuery(sinceDate);
		}

		#endregion

	}

	#endregion

}

