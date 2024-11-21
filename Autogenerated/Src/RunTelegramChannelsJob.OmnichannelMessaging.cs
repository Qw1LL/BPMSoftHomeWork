 namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using OmnichannelMessaging.Telegram;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class : RunTelegramChannelsJob

	/// <summary>
	/// Job represents a runner of Telegram channels.
	/// </summary>
	public class RunTelegramChannelsJob : IJobExecutor
	{
		#region Constants : Private

		public static string CacheChannelsName = "TelegramChannelsList";

		#endregion

		#region Properties : Private

		private UserConnection _userConnection;
		private List<string> _channelsCache;

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _log;
		private ILog Log {
			get {
				return _log ?? (_log = LogManager.GetLogger("OmnichannelMessaging"));
			}
		}

		#endregion

		#region Methods : Private

		private List<string> GetAllActiveTelegramChannels() {
			List<string> list = new List<string>();
			Select channelSelect = new Select(_userConnection)
				.Column("Id")
				.From("Channel")
				.Where("ProviderId").IsEqual(Column.Parameter(OmnichannelMessagingConsts.TelegramProvider))
					.And("IsActive").IsEqual(Column.Parameter(true)) as Select;
			channelSelect.ExecuteReader(reader => {
				list.Add(reader.GetColumnValue<Guid>("Id").ToString());
			});
			return list;
		}
		
		private List<string> GetAllActiveTelegramChannelMsgSettingsIds() {
			List<string> list = new List<string>();
			Select channelSelect = new Select(_userConnection)
				.Column("MsgSettingsId")
				.From("Channel")
				.Where("ProviderId").IsEqual(Column.Parameter(OmnichannelMessagingConsts.TelegramProvider))
				.And("IsActive").IsEqual(Column.Parameter(true)) as Select;
			channelSelect.ExecuteReader(reader => {
				list.Add(reader.GetColumnValue<Guid>("MsgSettingsId").ToString());
			});
			return list;
		}

		private void RunTelegramChannels() {
			var channels = GetAllActiveTelegramChannels();
			_channelsCache = _userConnection.ApplicationCache[CacheChannelsName] as List<string> ?? new List<string>();
			var notRanChannels = channels.Where(c => !_channelsCache.Contains(c)).ToList();
			if (notRanChannels.Count > 0) {
				AddToCache(notRanChannels);
				var activatedChannels = TelegramClientFactory.Instance.RunChannels(notRanChannels);
				if (activatedChannels.ToList().Count != notRanChannels.Count) {
					Log.ErrorFormat($"Tried to run by channel IDs [{string.Join(", ", notRanChannels)}]," +
						$" but ran only bot IDs [{string.Join(", ", activatedChannels.Select(c => c.Id))}]");
				}
			}
		}

		private void CheckTelegramChannels() {
			var clientReceivingStatuses = TelegramClientFactory.Instance.GetClientsReceivingStatus();
			List<string> msgSettingsIds = GetAllActiveTelegramChannelMsgSettingsIds();
			if (!clientReceivingStatuses.Any() && msgSettingsIds.Any() || clientReceivingStatuses.Values.Contains(false)) {
				string reason = !clientReceivingStatuses.Any() ? "is empty" : "has broken clients";
				Log.ErrorFormat($"Telegram client collection {reason}. Reactivating channels...");
				msgSettingsIds.ForEach(settingsId => {
					TelegramClientFactory.Instance.DeactivateChannel(settingsId);
					TelegramClientFactory.Instance.ActivateChannel(settingsId);
				});
			}
		}

		private void AddToCache(List<string> newChannels) {
			_channelsCache.AddRangeIfNotExists(newChannels);
			_userConnection.ApplicationCache[CacheChannelsName] = _channelsCache;
		}

		#endregion

		#region Methods : Public

		/// <summary>
		/// Run Telegram channels.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Parameters.</param>
		public virtual void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			Log.DebugFormat("RunTelegramChannelsJob have been started");
			_userConnection = userConnection;
			RunTelegramChannels();
			CheckTelegramChannels();
			Log.DebugFormat("RunTelegramChannelsJob finished");
		}

		#endregion

	}

	#endregion

}

