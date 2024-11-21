namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;

	#region Class: ESNNotificationTextFormer

	public class ESNNotificationTextFormer: IRemindingTextFormer
	{
		#region Constants: Private

		private const string ClassName = nameof(ESNNotificationTextFormer);
		private const string CommentedLocalizableStringName = "TitleCommented";
		private const string LikedLocalizableStringName = "TitleLiked";
		private const string MentionedLocalizableStringName = "TitleMentioned";
		private const string NewMessageLocalizableStringName = "TitleNewMessage";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public ESNNotificationTextFormer(UserConnection userConnection) {
		    _userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private string GetDateEvent(DateTime value) {
			string dateMacros = _userConnection.GetLocalizableString(ClassName, "DateMacros");
			string timeMacros = _userConnection.GetLocalizableString(ClassName, "TimeMacros");
			string bodyDateEvent = _userConnection.GetLocalizableString(ClassName, "BodyDateEvent");
			var date = value.ToString(dateMacros);
			var time = value.ToString(timeMacros);
			return string.Format(bodyDateEvent, date, time);
		}

		#endregion
		
		#region Methods: Public

		public string GetBody(IDictionary<string, object> formParameters) {
			formParameters.CheckArgumentNull("formParameters");
			DateTime createdOn = (DateTime)formParameters["CreatedOn"];
			string createdByName = (string)formParameters["CreatedByName"];
			string dateTime = GetDateEvent(createdOn);
			string typeAction = (string)formParameters["Action"];
			string message = (string)formParameters["Message"];
			string clearString = message.GetClearString();
			string bodyTemplate = _userConnection.GetLocalizableString(ClassName, "BodyTemplate"); 
			return string.Format(bodyTemplate, createdByName, typeAction, clearString, dateTime);
		}

		public string GetTitle(IDictionary<string, object> formParameters) {
			formParameters.CheckArgumentNull("formParameters");
			string typeName = (string)formParameters["TypeName"];
			var item = (ESNNotificationTitle)Enum.Parse(typeof(ESNNotificationTitle), typeName);
			string titleLocalizableStringName = string.Empty;
			switch (item) {
				case ESNNotificationTitle.Commented:
					titleLocalizableStringName = CommentedLocalizableStringName;
					break;
				case ESNNotificationTitle.Liked:
					titleLocalizableStringName = LikedLocalizableStringName;
					break;
				case ESNNotificationTitle.Mentioned:
					titleLocalizableStringName = MentionedLocalizableStringName;
					break;
				case ESNNotificationTitle.NewMessage:
					titleLocalizableStringName = NewMessageLocalizableStringName;
					break;
			}
			return titleLocalizableStringName.IsNullOrEmpty()
				? string.Empty
				: _userConnection.GetLocalizableString(ClassName, titleLocalizableStringName);
		}

		#endregion
	}

	#endregion
}
