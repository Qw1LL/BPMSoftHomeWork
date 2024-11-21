namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Store;
	using SystemSettings = Core.Configuration.SysSettings;

	/// <summary>
	/// Stores information of operator for chat transferring.
	/// </summary>
	[Serializable]
	public class TransferOperator
	{

		/// <summary>
		/// Identifier of user.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Operator contact.
		/// </summary>
		public OperatorContact Contact { get; set; }

		/// <summary>
		/// Current operator status.
		/// </summary>
		public TransferOperatorStatus Status { get; set; } = TransferOperatorStatus.InActive;

	}

	/// <summary>
	/// Dto of operator contact.
	/// </summary>
	[Serializable]
	public class OperatorContact
	{
		/// <summary>
		/// Identifier of contact.
		/// </summary>
		public Guid Id;

		/// <summary>
		/// Contact name.
		/// </summary>
		public string Name;

		/// <summary>
		/// Contact photo.
		/// </summary>
		public string Photo;
	}

	/// <summary>
	/// Stores transferring statuses.
	/// </summary>
	public enum TransferOperatorStatus
	{
		InActive = 0,
		Active = 1,
		ChatsExceeded = 2
	}

	#region Class: ChatOperatorTransferStore

	/// <summary>
	/// Stores operators for chat transferring.
	/// </summary>
	public class ChatOperatorTransferStore
	{

		#region Constants: Private

		private const string TransferringOperatorsCacheKey = "OmniChatTransferOperators";

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="ICacheStore"/> implementation instance.
		/// Represents application level cache.
		/// </summary>
		private readonly ICacheStore _applicationCache;

		/// <summary>
		/// <see cref="ChatQueueOperatorRepository"/> instance.
		/// </summary>
		private readonly ChatQueueOperatorRepository _chatQueueOperatorRepository;

		/// <summary>
		/// <see cref="ChatOperatorCache"/> instance.
		/// </summary>
		private readonly ChatOperatorCache _chatOperatorCache;

		/// <summary>
		/// <see cref="OmnichannelChatProvider"/> instance.
		/// </summary>
		private readonly OmnichannelChatProvider _omnichannelChatProvider;

		public UserConnection UserConnection { get; }

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="ChatOperatorTransferStore"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public ChatOperatorTransferStore(UserConnection userConnection) {
			_applicationCache = userConnection.ApplicationCache;
			_chatQueueOperatorRepository = new ChatQueueOperatorRepository(userConnection);
			_chatOperatorCache = new ChatOperatorCache(userConnection);
			_omnichannelChatProvider = new OmnichannelChatProvider(userConnection);
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private List<TransferOperator> InitAllOperatorsCache() {
			var collection = LoadOperators();
			_applicationCache[TransferringOperatorsCacheKey] = collection;
			return collection;
		}

		private Select GetAllChatOperatorsQuery() {
			var allOperatorsQuery = _chatQueueOperatorRepository.GetOperatorsQuery();
			allOperatorsQuery
				.Column("Contact", "Id").As("OperatorContactId")
				.Column("Contact", "Name").As("OperatorContactName")
				.Column("Contact", "PhotoId").As("OperatorContactPhoto")
				.InnerJoin("Contact")
					.On("SAUK", "ContactId").IsEqual("Contact", "Id");
			return allOperatorsQuery;
		}

		private List<TransferOperator> LoadOperators() {
			var operators = new List<TransferOperator>();
			Select allOperatorsQuery = GetAllChatOperatorsQuery();
			allOperatorsQuery.ExecuteReader(reader => {
				if (reader.GetColumnValue<Guid>("SourceAdminUnitId") == Guid.Empty) {
					var userId = reader.GetColumnValue<Guid>("SysAdminUnitId");
					if (!operators.Any(o => o.Id == userId)) {
						operators.Add(new TransferOperator {
							Id = userId,
							Contact = new OperatorContact {
								Id = reader.GetColumnValue<Guid>("OperatorContactId"),
								Name = reader.GetColumnValue<string>("OperatorContactName"),
								Photo = _omnichannelChatProvider.GetPhoto(reader.GetColumnValue<Guid>("OperatorContactPhoto"))
							}
						});
					}
				}
			});
			return operators;
		}

		private bool IsChatLimitExceeded(ChatOperator chatOperator) {
			int simultaneousChats = SystemSettings.GetValue(UserConnection, "SimultaneousChats", 0);
			var isSimultaneousChats = simultaneousChats > 0;
			return isSimultaneousChats
				&& chatOperator.DirectedChatsCount + chatOperator.ActiveChatsCount >= simultaneousChats;
		}

		private TransferOperatorStatus GetTransferringStatus(ChatOperator @operator) {
			if (IsChatLimitExceeded(@operator)) {
				return TransferOperatorStatus.ChatsExceeded;
			} else if (@operator.Active) {
				return TransferOperatorStatus.Active;
			} else {
				return TransferOperatorStatus.InActive;
			}
		}

		private List<TransferOperator> GetTransferOperators(string search) {
			var operators = _applicationCache[TransferringOperatorsCacheKey] as List<TransferOperator>;
			if (operators.IsNullOrEmpty()) {
				operators = InitAllOperatorsCache();
			}
			operators = operators.Where(o => o.Id != UserConnection.CurrentUser.Id).ToList();
			if (!string.IsNullOrEmpty(search)) {
				operators = operators.Where(o => o.Contact.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) > -1).ToList();
			}
			return operators;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets list of operators for chat transferring.
		/// </summary>
		/// <param name="search">Operators search pattern.</param>
		/// <returns>List of operators</returns>
		public List<TransferOperator> GetOperators(string search) {
			var transferOperators = GetTransferOperators(search);
			List<ChatOperator> operators = _chatOperatorCache.GetOperatorsCache();
			transferOperators.ForEach(to => {
				ChatOperator co = operators.FirstOrDefault(o => o.UserId == to.Id);
				if (co != null) {
					to.Status = GetTransferringStatus(co);
				}
			});
			return transferOperators;
		}

		/// <summary>
		/// Clears transferring operators cache.
		/// </summary>
		public void ClearCache() {
			_applicationCache.Remove(TransferringOperatorsCacheKey);
		}

		#endregion

	}

	#endregion

}
