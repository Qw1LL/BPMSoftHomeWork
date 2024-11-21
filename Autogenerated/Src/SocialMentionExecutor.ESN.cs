namespace BPMSoft.Configuration.ESN
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using EntitySchema = BPMSoft.Core.Entities.EntitySchema;

	#region  Class: SocialMentionExecutor

	/// <inheritdoc />
	[DefaultBinding(typeof(SocialMentionExecutor))]
	public class SocialMentionExecutor: ISocialMentionExecutor
	{

		#region Constructors: Public

		public SocialMentionExecutor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Properties: Private

		private EntitySchema _socialMentionSchema;
		private EntitySchema SocialMentionSchema =>
			_socialMentionSchema ?? (_socialMentionSchema = _userConnection
				.EntitySchemaManager.GetInstanceByName("SocialMention"));

		#endregion

		#region Methods: Private
		private IEnumerable<Guid> GetMentionContactsId(Guid messageId, IEnumerable<Guid> contactIds) {
			var select = new Select(_userConnection)
				.Distinct()
				.Column("SysAdminUnit", "ContactId")
				.From("SysAdminUnit").As("SysAdminUnit")
				.Where("Active")
					.IsEqual(Column.Parameter(true))
				.And("SysAdminUnit", "ContactId")
					.In(contactIds.Select(contactId => Column.Parameter(contactId)))
				.And().Not().Exists(
					new Select(_userConnection)
						.Column("SocialMention", "ContactId")
						.From("SocialMention").As("SocialMention")
						.Where("SocialMention", "SocialMessageId")
							.IsEqual(Column.Parameter(messageId))
						.And("SocialMention", "ContactId")
							.IsEqual("SysAdminUnit", "ContactId")
				) as Select;
			return select.ExecuteEnumerable(dr => dr.GetColumnValue<Guid>("ContactId")).ToList();
		}

		private void CreateContactsMentions(Guid messageId, IEnumerable<Guid> contactIds) {
			foreach (var contactId in contactIds) {
				CreateMention(messageId, contactId);
			}
		}

		private void CreateMention(Guid messageId, Guid contactId) {
			var socialMentionEntity = SocialMentionSchema.CreateEntity(_userConnection);
			socialMentionEntity.SetDefColumnValues();
			socialMentionEntity.SetColumnValue("SocialMessageId", messageId);
			socialMentionEntity.SetColumnValue("ContactId", contactId);
			socialMentionEntity.Save(setColumnDefValue: false);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public virtual void MentionContacts(Guid messageId, string message) {
			messageId.CheckArgumentEmpty(nameof(messageId));
			if (message.IsNullOrWhiteSpace()) {
				return;
			}
			var contactIds = CommonUtilities.ParseGuidsFromString(message);
			if (!contactIds.Any()) {
				return;
			}
			var contactsForMention = GetMentionContactsId(messageId, contactIds);
			CreateContactsMentions(messageId, contactsForMention);
		}

		#endregion

	}

	#endregion

}

