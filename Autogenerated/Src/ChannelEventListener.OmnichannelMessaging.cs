namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using OmnichannelMessaging.Telegram;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: ChannelEventListener

	/// <summary>
	/// Class provides Channel entity events handling.
	/// </summary>
	[EntityEventListener(SchemaName = "Channel")]
	public class ChannelEventListener : BaseEntityEventListener
	{

		#region Enums: Private

		enum ChannelActions
		{
			Unregister,
			Activate,
			Deactivate
		}

		#endregion

		#region Fields: Private

		private readonly Dictionary<ChannelActions, Dictionary<Guid, Action<string>>> _actions =
			new Dictionary<ChannelActions, Dictionary<Guid, Action<string>>>();

		#endregion

		#region Constructors: Public

		public ChannelEventListener() {
			InitActions();
		}

		#endregion

		#region Methods: Private

		private void InitActions() {
			_actions.Add(ChannelActions.Unregister, new Dictionary<Guid, Action<string>> {
				 { OmnichannelMessagingConsts.TelegramProvider, TelegramClientFactory.Instance.UnregisterChannel }
			});

			_actions.Add(ChannelActions.Activate, new Dictionary<Guid, Action<string>> {
				 { OmnichannelMessagingConsts.TelegramProvider, TelegramClientFactory.Instance.ActivateChannel }
			});

			_actions.Add(ChannelActions.Deactivate, new Dictionary<Guid, Action<string>> {
				 { OmnichannelMessagingConsts.TelegramProvider, TelegramClientFactory.Instance.DeactivateChannel }
			});
		}

		private void DoAction(Entity channel, ChannelActions action) {
			var providerId = channel.GetTypedColumnValue<Guid>("ProviderId");
			if (_actions.TryGetValue(action, out var actions)) {
				if (actions.TryGetValue(providerId, out var callAction)) {
					var id = channel.GetTypedColumnValue<Guid>("MsgSettingsId").ToString();
					callAction(id);
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="BaseEntityEventListener.OnDeleted"/>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			DoAction((Entity)sender, ChannelActions.Unregister);
		}

		/// <inheritdoc cref="BaseEntityEventListener.OnUpdated"/>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			var entity = (Entity)sender;
			var isActive = entity.GetChangedColumnValues().FirstOrDefault(ccv => ccv.Name == "IsActive");
			if (isActive != null) {
				if ((bool)isActive.Value == true) {
					DoAction(entity, ChannelActions.Activate);
				} else {
					DoAction(entity, ChannelActions.Deactivate);
				}
			}
		}

		#endregion

	}

	#endregion

} 
