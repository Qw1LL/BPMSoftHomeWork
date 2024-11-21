namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Store;

	#region Class: ChatQueueSettings

	/// <summary>
	/// DTO for chat's queue settings.
	/// </summary>
	[Serializable]
	public class ChatQueueSettings
	{
		public Guid Id { get; set; }

		public Guid RoutingRuleId { get; set; }

		public int Simultaneous { get; set; }

		public int Timeout { get; set; }
	}

	#endregion

	#region Class: OmniChatAction

	/// <summary>
	/// DTO for chat action.
	/// </summary>
	[DataContract]
	public class OmniChatAction {

		#region Fields: Public

		/// <summary>
		/// Process schema name.
		/// </summary>
		[DataMember]
		public string ProcessName { get; set; }

		/// <summary>
		/// Action caption.
		/// </summary>
		[DataMember]
		public string Caption { get; set; }

		#endregion

	}

	#endregion

	#region Class: ChatQueueRepository

	/// <summary>
	/// Repository of ChatQueue.
	/// </summary>
	public class ChatQueueRepository
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public ChatQueueRepository(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private ChatQueueSettings LoadSettings(Guid chatQueueId) {
			var settings = new ChatQueueSettings();
			Select channelSelect = new Select(_userConnection)
				.Column("Id")
				.Column("OperatorRoutingRuleId")
				.Column("SimultaneousChats")
				.Column("ChatTimeout")
				.From("ChatQueue")
				.Where("Id").IsEqual(Column.Parameter(chatQueueId)) as Select;
			channelSelect.ExecuteReader(reader => {
				settings.Id = reader.GetColumnValue<Guid>("Id");
				settings.RoutingRuleId = reader.GetColumnValue<Guid>("OperatorRoutingRuleId");
				settings.Simultaneous = reader.GetColumnValue<int>("SimultaneousChats");
				settings.Timeout = reader.GetColumnValue<int>("ChatTimeout");
			});
			SaveToCache(chatQueueId, settings);
			return settings;
		}

		private void SaveToCache(Guid chatQueueId, ChatQueueSettings settings) {
			_userConnection.ApplicationCache.SetOrRemoveValue(GetCacheKey(chatQueueId), settings);
		}

		private ChatQueueSettings GetFromCache(Guid chatQueueId) {
			return _userConnection.ApplicationCache.GetValue<ChatQueueSettings>(GetCacheKey(chatQueueId));
		}

		private string GetCacheKey(Guid chatQueueId) {
			return string.Format(OmnichannelMessagingConsts.ChatQueueCacheKeyMask, chatQueueId);
		}

		private EntitySchemaQuery GetQueueActionsEsq(Guid chatQueueId, out string processNameColumn) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "OmniChatAction");
			processNameColumn = esq.AddColumn("[VwProcessLib:Id:ProcessSchemaId].Name").Name;
			esq.AddColumn("Caption");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"ChatQueue", chatQueueId));
			return esq;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns settigns by identifier.
		/// </summary>
		/// <param name="chatQueueId">Identifier</param>
		/// <returns>Settings of chat queue.</returns>
		public virtual ChatQueueSettings GetSettings(Guid chatQueueId) {
			return GetFromCache(chatQueueId) ?? LoadSettings(chatQueueId);
		}

		/// <summary>
		/// Returns chat actions list for <paramref name="chatQueueId"/>.
		/// </summary>
		/// <param name="chatQueueId"><see cref="ChatQueue"/> identifier.</param>
		/// <returns><see cref="OmniChatAction"/> list.</returns>
		public List<OmniChatAction> GetQueueActions(Guid chatQueueId) {
			 var esq= GetQueueActionsEsq(chatQueueId, out string processNameColumn);
			var  collection =  esq.GetEntityCollection(_userConnection);
			if (!collection.Any()) { 
				return new List<OmniChatAction>();
			}
			return collection.Select(entity => new OmniChatAction {
				ProcessName = entity.GetTypedColumnValue<string>(processNameColumn),
				Caption = entity.GetTypedColumnValue<string>("Caption")
			}).ToList();
		}

		/// <summary>
		/// Check if queue exists
		/// </summary>
		/// <param name="queueId">Queue ID for check</param>
		/// <returns>True if queue exists, otherwise false</returns>
		public bool IsQueueExists(Guid queueId) {
			var select = new Select(_userConnection).Top(1)
					.Count("Id")
					.From("ChatQueue")
				.Where("Id").IsEqual(Column.Parameter(queueId))
				as Select; 
			
			return select.ExecuteScalar<int>() > 0;
		}

		#endregion

	}

	#endregion

}
