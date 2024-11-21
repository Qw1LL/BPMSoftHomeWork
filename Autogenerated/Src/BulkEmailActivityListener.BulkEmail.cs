namespace BPMSoft.Configuration
{
	using System;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: BulkEmailActivityListener

	/// <summary>
	/// Class provides handlers for Activity events.
	/// </summary>
	/// <seealso cref="BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Activity")]
	public class BulkEmailActivityListener: BaseEntityEventListener
	{

		#region Methods: Private

		private (Guid recipientId, Guid bulkEmailId) GetDataFromEmail(string headers, string body) {
			var emptyData = (Guid.Empty, Guid.Empty);
			var autoReplyRegExp = @"Auto-Submitted\s*[:=]\s*auto-(generated|replied|notified)";
			if (!string.IsNullOrWhiteSpace(headers)) {
				var isAutoReply = Regex.IsMatch(headers, autoReplyRegExp);
				if (isAutoReply) {
					return emptyData;
				}
			}
			var recipientRegExp = "(?i)<img.+?alt=\"recipient:([{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?);email:([{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?)\"";
			var match = Regex.Match(body, recipientRegExp);
			if (!match.Success
				|| match.Groups.Count < 3
				|| !Guid.TryParse(match.Groups[1].Value, out var recipientId)
				|| !Guid.TryParse(match.Groups[2].Value, out var bulkEmailId)) {
				return emptyData;
			}
			return (recipientId, bulkEmailId);
		}

		private bool IsReplyExists((Guid recipientId, Guid bulkEmailId) emailData, UserConnection userConnection) {
			var select = new Select(userConnection)
				.Column(Func.Count(Column.Parameter(1)))
				.From("BulkEmailReply")
				.Where("BulkEmailId").IsEqual(Column.Parameter(emailData.bulkEmailId))
				.And("MandrillId").IsEqual(Column.Parameter(emailData.recipientId)) as Select;
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<int>() > 0;
		}

		private void SaveBulkEmailReply((Guid recipientId, Guid bulkEmailId) emailData, UserConnection userConnection) {
			var schema = userConnection.EntitySchemaManager.GetInstanceByName("BulkEmailReply");
			var reply = schema.CreateEntity(userConnection);
			reply.SetDefColumnValues();
			reply.SetColumnValue("BulkEmailId", emailData.bulkEmailId);
			reply.SetColumnValue("MandrillId", emailData.recipientId);
			reply.Save();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// <see cref="BaseEntityEventListener.OnSaved"/>.
		/// </summary>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			var activity = sender as Activity;
			if (activity == null) {
				return;
			}
			var userConnection = activity.UserConnection;
			if (!userConnection.GetIsFeatureEnabled("BulkEmailReplyTo")) {
				return;
			}
			var typeColumnValueName = activity.Schema.Columns.FindByName("Type").ColumnValueName;
			var activityType = activity.GetTypedColumnValue<Guid>(typeColumnValueName);
			if (activityType != ActivityConsts.EmailTypeUId) {
				return;
			}
			var emailData = GetDataFromEmail(activity.HeaderProperties, activity.Body);
			if (emailData.recipientId.IsEmpty() || emailData.bulkEmailId.IsEmpty()) {
				return;
			}
			var isReplyExists = IsReplyExists(emailData, userConnection);
			if (isReplyExists) {
				return;
			}
			SaveBulkEmailReply(emailData, userConnection);
		}

		#endregion

	}

	#endregion

}
