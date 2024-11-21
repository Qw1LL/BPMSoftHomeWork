namespace BPMSoft.Mail
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: UidBasedSyncStrategy

	/// <summary>
	/// <see cref="ISyncStrategy"/> implementatiton, delivered from <see cref="DateBasedSentSinceSyncStrategy"/>.
	/// </summary>
	/// <remarks>
	/// UidBasedSyncStrategy used to select all new messages,
	/// beginning at a specified unique identifier message. rfc4549 https://tools.ietf.org/html/rfc4549
	/// </remarks>
	[DefaultBinding(typeof(ISyncStrategy), Name = "UidBasedSyncStrategy")]
	public partial class UidBasedSyncStrategy : DateBasedSentSinceSyncStrategy
	{

		#region Fields: Protected

		/// <summary>
		/// Uniqie identifier messages in mailbox folder.
		/// </summary>
		protected string CurrentMessageUidInFolder;

		#endregion

		#region Property: Protected

		/// <summary>
		/// Search expression template for only UId.
		/// </summary>
		protected string UidOnlyQuery => "UID {0}:*";

		#endregion

		#region Properties: Public

		/// <summary>
		/// Current <see cref="MailboxFoldersCorrespondence"/> instance.
		/// </summary>
		public MailboxFoldersCorrespondence CurrentFolderCorrespondence {
			get;
			set;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates new <see cref="UidBasedSyncStrategy"/> instance.
		/// </summary>
		/// <param name="userConnection">user Connection.</param>
		/// <param name="syncSettings"><see cref="MailboxSyncSettings"/> instance.</param>
		public UidBasedSyncStrategy(UserConnection userConnection, Entity syncSettings)
			: base(userConnection, syncSettings) {
			SyncSettings = syncSettings;
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Gets unique identifier messages in folder.
		/// </summary>
		/// <param name="mailboxSyncsettingsId">Unique identifier mailbox synchronization settings.</param>
		/// <param name="filterColumnPath">Mailbox folders correspondence aditional filter column path.</param>
		/// <param name="filterColumnValue">Mailbox folders correspondence aditional filter value.</param>
		/// <returns>Unique identifier messages in folder.</returns>
		private string GetsMessageUidInFolder(Guid mailboxSyncsettingsId, string filterColumnPath, string filterColumnValue) {
			Select foldersSelect =
				new Select(UserConnection).Top(1)
					.Column("UId")
				.From("MailboxFoldersCorrespondence")
				.Where("MailboxId").IsEqual(Column.Parameter(mailboxSyncsettingsId))
				.And(filterColumnPath).IsEqual(Column.Parameter(filterColumnValue)) as Select;
			return foldersSelect.ExecuteScalar<string>();
		}

		#endregion

		#region Methods: Public

		/// <summary><see cref="ISyncStrategy.GetUnsyncMsgSearchQuery"/></summary>
		public override string GetUnsyncMsgSearchQuery() {
			if (string.IsNullOrEmpty(CurrentMessageUidInFolder) || CurrentMessageUidInFolder == "0") {
				DateTime loadEmailsFromDate = LoadFromDateType.GetInstance(UserConnection).GetLoadFromDate(SyncSettings);
				return string.Format(UnsyncMsgSearchQuery, loadEmailsFromDate.ToString(_imapDateFormat, CultureInfo.InvariantCulture));
			}
			return string.Format(UidOnlyQuery, CurrentMessageUidInFolder);
		}

		#endregion
	}

	#endregion
}

