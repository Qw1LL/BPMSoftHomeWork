namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;

	#region Class: ChatQueueOperatorRepository

	/// <summary>
	/// Repository of ChatQueueOperator.
	/// </summary>
	public class ChatQueueOperatorRepository
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public ChatQueueOperatorRepository(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Select GetChatQueueOperatorsQuery() {
			return new Select(_userConnection)
				.Column("CQO", "ChatQueueId")
				.Column("CQO", "OperatorId")
				.Column("SAIR", "SysAdminUnitId")
				.Column("SAIR", "SourceAdminUnitId")
				.From("ChatQueueOperator", "cqo").As("CQO")
				.InnerJoin("SysAdminUnit").As("SAU")
					.On("CQO", "OperatorId").IsEqual("SAU", "Id")
					.And("SAU", "Active").IsEqual(Column.Parameter(true))
				.LeftOuterJoin("SysAdminUnitInRole").As("SAIR")
					.On("CQO", "OperatorId").IsEqual("SAIR", "SysAdminUnitRoleId")
				.LeftOuterJoin("SysAdminUnit").As("SAUK")
					.On("SAIR", "SysAdminUnitId").IsEqual("SAUK", "Id")
					.And("SAUK", "Active").IsEqual(Column.Parameter(true))
				as Select;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Loads <paramref name="chatOperator"/> fields from database.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		public void LoadOperatorState(ChatOperator chatOperator) {
			chatOperator.ChatQueues.AddRangeIfNotExists(GetQueuesByOperator(chatOperator.UserId));
		}

		/// <summary>
		/// Get IDs of all operators from chat queues.
		/// </summary>
		/// <returns><see cref="List<Guid>"/> collection of operator IDs</returns>
		public List<Guid> GetAllOperatorIds() {
			var result = new List<Guid>();
			var query = GetChatQueueOperatorsQuery().Where("SAUK", "Active").IsEqual(Column.Const(true))
					.Or("SAU", "Active").IsEqual(Column.Const(true)) as Select;
			query.ExecuteReader(reader => {
				if (reader.GetColumnValue<Guid>("SourceAdminUnitId") == Guid.Empty) {
					var sysUser = reader.GetColumnValue<Guid>("SysAdminUnitId");
					result.AddIfNotExists<Guid>(sysUser == Guid.Empty ? reader.GetColumnValue<Guid>("OperatorId") : sysUser);
				}
			});
			return result;
		}

		/// <summary>
		/// Queue operator identifier.
		/// </summary>
		/// <returns><see cref="List<Guid>"/> collection of operator queue identifiers</returns>
		public List<Guid> GetQueuesByOperator(Guid operatorId) {
			var query = GetChatQueueOperatorsQuery()
				.Where("SAIR", "SysAdminUnitId").IsEqual(Column.Parameter(operatorId))
				.Or("OperatorId").IsEqual(Column.Parameter(operatorId)).CloseBlock() as Select;
			var queueIds = new List<Guid>();
			query.ExecuteReader(reader => {
				queueIds.AddIfNotExists(reader.GetColumnValue<Guid>("ChatQueueId"));
			});
			return queueIds;
		}

		/// <summary>
		/// Returns select query to load all chat operators. 
		/// </summary>
		/// <returns>Select query.</returns>
		public Select GetOperatorsQuery() {
			return GetChatQueueOperatorsQuery();
		}

		#endregion

	}

	#endregion

}

