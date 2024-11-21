 namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using global::Common.Logging;
	using Core;
	using OmnichannelMessaging;
	using OmnichannelProviders.MessageSenders;
	using System;
	using System.Collections.Generic;
	using System.Net.Http;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;

	#region Class : FacebookActualizeJob

	/// <summary>
	/// Represents Facebook tokens actualization job.
	/// </summary>
	public class FacebookActualizeJob : IJobExecutor
	{
		#region Properties: Protected

		private ILog _log;
		protected ILog Log {
			get {
				return _log ?? (_log = LogManager.GetLogger("OmnichannelMessageHandler"));
			}
		}

		#endregion

		#region Methods: Private

		private List<string> GetAllActiveFacebookChannels(UserConnection userConnection) {
			List<string> list = new List<string>();
			Select channelSelect = new Select(userConnection)
				.Column("Id")
				.From("Channel")
				.Where("ProviderId").IsEqual(Column.Parameter(OmnichannelMessagingConsts.FacebookProvider))
					.And("IsActive").IsEqual(Column.Parameter(true)) as Select;
			channelSelect.ExecuteReader(reader => {
				list.Add(reader.GetColumnValue<Guid>("Id").ToString());
			});
			return list;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Actualizes Facebook tokens.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Parameters.</param>
		public virtual void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			var channels = GetAllActiveFacebookChannels(userConnection);
			var sender = new FacebookMessageSender(new FacebookMessangerRepository(userConnection));
			channels.ForEachAsync(async channelId => { 
				HttpResponseMessage response = await sender.ActualizeToken(channelId);
				if (response.StatusCode != System.Net.HttpStatusCode.OK) {
					var content = await response.Content.ReadAsStringAsync();
					Log.ErrorFormat("Could not actualize token for channelId {0}. Result: {1}", channelId, content);
				}
			});
		}

		#endregion

	}

	#endregion

}
