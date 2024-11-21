namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core;
	using Core.DB;
	using Core.Entities;
	using Marketing.Utilities;

	#region Class: EmailCommunicationRestrictionRepository

	/// <summary>
	/// Provides methods to get initial email responses based on sending restrictions.
	/// </summary>
	public class EmailCommunicationRestrictionRepository
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly Guid _bulkEmailId;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates instance of repository for given email.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="bulkEmailId">Email identifier.</param>
		public EmailCommunicationRestrictionRepository(UserConnection userConnection, Guid bulkEmailId, Guid sessionId) {
			_userConnection = userConnection;
			_bulkEmailId = bulkEmailId;
		}

		#endregion

		#region Methods: Private

		private static void AddBulkEmailFilter(BulkEmailCountLimit rule, Query join) {
			if (rule.EmailCategoryId != Guid.Empty || rule.EmailTypeId != Guid.Empty) {
				if (rule.EmailCategoryId != Guid.Empty) {
					join.And("BulkEmail", "CategoryId").IsEqual(Column.Parameter(rule.EmailCategoryId));
				}
				if (rule.EmailTypeId != Guid.Empty) {
					join.And("BulkEmail", "TypeId").IsEqual(Column.Parameter(rule.EmailTypeId));
				}
			}
		}

		private int GetBulkEmailRId() {
			return (new Select(_userConnection)
					.Column("RId")
					.From("BulkEmail")
					.Where("Id").IsEqual(Column.Parameter(_bulkEmailId)) as Select)
				.ExecuteScalar<int>();
		}

		private Select GetBulkEmailTargetSelectQuery(BulkEmailCountLimit rule) {
			var periodStartDateTime = DateTime.UtcNow.AddDays(-rule.MailingLimitPeriod);
			var selectQuery = new Select(_userConnection)
				.Column("ContactId")
				.From("BulkEmailTarget").As("bet")
				.Where("bet", "BulkEmailResponseId")
				.IsNotEqual(Column.Parameter(MailingConsts.BulkEmailResponseLimitedId))
				.And("bet", "BulkEmailResponseId").IsNotEqual(Column.Parameter(MailingConsts.BulkEmailResponseReadyToSendId))
				.And("bet", "CreatedOn").IsGreaterOrEqual(Column.Parameter(periodStartDateTime));
			var join = selectQuery.InnerJoin("BulkEmail")
				.On("BulkEmail", "Id").IsEqual("bet", "BulkEmailId")
				.And("BulkEmail", "IsSystemEmail").IsEqual(Column.Const(false)) as Select;
			AddBulkEmailFilter(rule, join);
			return join;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Creates query to get contacts in current email for whom communication is restricted by given rule.
		/// Override this method to get custom query for restricted contacts.
		/// </summary>
		/// <param name="rule">Communication limit rule. Instance of <see cref="BulkEmailCountLimit"/>.</param>
		/// <param name="bulkEmailRId">Email identifier (RId field in BulkEmail).</param>
		/// <returns>Instance of <see cref="Select"/>. It should select single column Contact.Id.</returns>
		protected virtual Select GetContactSelectQuery(BulkEmailCountLimit rule, int bulkEmailRId) {
			var betSelect = GetBulkEmailTargetSelectQuery(rule);
			var rootSelect = new Select(_userConnection)
				.Column("ContactId")
				.From(betSelect).As("src")
				.GroupBy("ContactId")
				.Having(Func.Count("src", "ContactId")).IsGreaterOrEqual(Column.Parameter(rule.MailingLimitCount)) as Select;
			return rootSelect;
		}

		/// <summary>
		/// Returns enumeration for communication restriction rules. Override this method to get custom rule set.
		/// </summary>
		/// <returns>Enumeration for <see cref="BulkEmailCountLimit"/>.</returns>
		protected virtual IEnumerable<BulkEmailCountLimit> GetLimitRules() {
			var rulesEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "BulkEmailCountLimit");
			rulesEsq.UseAdminRights = false;
			rulesEsq.AddColumn("MailingLimitCount");
			rulesEsq.AddColumn("MailingLimitPeriod");
			rulesEsq.AddColumn("EmailCategory");
			rulesEsq.AddColumn("EmailType");
			var innerSelect = rulesEsq.GetSelectQuery(_userConnection);
			innerSelect.InnerJoin("BulkEmail")
				.On("BulkEmail", "Id").IsEqual(Column.Parameter(_bulkEmailId))
				.And()
				.OpenBlock("BulkEmail", "CategoryId").IsEqual("BulkEmailCountLimit", "EmailCategoryId")
				.Or("BulkEmailCountLimit", "EmailCategoryId").IsNull()
				.CloseBlock()
				.And()
				.OpenBlock("BulkEmail", "TypeId").IsEqual("BulkEmailCountLimit", "EmailTypeId")
				.Or("BulkEmailCountLimit", "EmailTypeId").IsNull()
				.CloseBlock();
			return rulesEsq.GetEntityCollection(_userConnection).Select(x => x as BulkEmailCountLimit);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns responses for contacts for whom comunication is restricted by limits.
		/// </summary>
		/// <returns>Dictionary with contacts identifiers and response codes.</returns>
		public virtual Dictionary<Guid, int> GetAudienceLimitResponses() {
			var rules = GetLimitRules();
			var audienceLimitResponses = new Dictionary<Guid, int>();
			if (!rules.Any()) {
				return audienceLimitResponses;
			}
			var bulkEmailRId = GetBulkEmailRId();
			Select unionSelect = null;
			foreach (var rule in rules) {
				var select = GetContactSelectQuery(rule, bulkEmailRId);
				unionSelect = unionSelect == null ? select : unionSelect.Union(select) as Select;
				
			}
			if (unionSelect != null) {
				using (var dbExecutor = _userConnection.EnsureDBConnection()) {
					using (var dr = unionSelect.ExecuteReader(dbExecutor)) {
						while (dr.Read()) {
							audienceLimitResponses[dr.GetGuid(0)] = (int)MailingResponseCode.CanceledCommunicationLimit;
						}
					}
				}
			}
			return audienceLimitResponses;
		}

		#endregion

	}

	#endregion
}
