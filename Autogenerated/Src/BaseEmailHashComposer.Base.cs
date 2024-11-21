namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: BaseEmailHashComposer

	/// <summary>
	/// Class creates base email hashes for email instance.
	/// </summary>
	[DefaultBinding(typeof(IEmailHashComposer), Name = "BaseEmailHashComposer")]
	public class BaseEmailHashComposer : IEmailHashComposer
	{

		#region Methods: Protected

		/// <summary>
		/// Returns date to string convert format template.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <returns>Date to string convert format template.</returns>
		protected string GetDateTimeFormat(UserConnection userConnection) {
			return userConnection.GetIsFeatureEnabled("UseSecondsInSendDate")
				? "yyyy-MM-dd HH:mm:ss"
				: "yyyy-MM-dd HH:mm";
		}

        /// <summary>
        /// Returns unique hash for email instance. Send date would be converted to UTC using user timezone.
        /// </summary>
        /// <param name="sender">Email sender.</param>
        /// <param name="sendDate">Email send date.</param>
        /// <param name="title">Email subject.</param>
        /// <param name="body">Email body.</param>
        /// <param name="timeZoneInfo">User timezone.</param>
        /// <param name="deleteWhiteSpaces">Flag, indicates if need to delete white spaces.</param>
        /// <param name="dateTimeFormat">If <paramref name="deleteWhiteSpaces"/> is true,
        ///  then this parameter used for send date serialization.</param>
        ///  <param name="fixTitleWhitespaces">Fix repeating whitespaces in title flag.</param>
        /// <returns>Unique hash for email instance.</returns>
        protected string GetEmailHash(string sender, DateTime sendDate, string title, string body, TimeZoneInfo timeZoneInfo,
				bool deleteWhiteSpaces = true, string dateTimeFormat = "yyyy-MM-dd HH:mm",
				bool fixTitleWhitespaces = true) {
			return ActivityUtils.GetEmailHash(sender, sendDate, title, body, timeZoneInfo, deleteWhiteSpaces, dateTimeFormat,
				fixTitleWhitespaces);
		}

		/// <summary>
		///  Returns hashes collection calculated by email parameters.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <param name="email">Email parameters.</param>
		/// <returns>Email hashes collection.</returns>
		protected IEnumerable<string> GetHashesInternal(UserConnection userConnection, EmailHashDTO email) {
            var sender = userConnection.GetIsFeatureEnabled("UseSenderForEmailHash")
                ? email.Sender
                : string.Empty;
            var dateTimeFormat = GetDateTimeFormat(userConnection);
			List<string> hashes = new List<string> {
				GetEmailHash(sender, email.SendDate, email.Subject, email.Body, email.TimeZone, true, dateTimeFormat),
				GetEmailHash(sender, email.SendDate, email.Subject, email.Body, email.TimeZone, false, dateTimeFormat),
				GetEmailHash(sender, email.SendDate, email.Subject, email.Body, email.TimeZone, true, dateTimeFormat, false),
				GetEmailHash(sender, email.SendDate, email.Subject, email.Body, email.TimeZone, false, dateTimeFormat, false)
			};
			if (userConnection.GetIsFeatureEnabled("UseSubjectStartForEmailHash")) {
				var subject = TrimSubject(email.Subject);
				hashes.AddRange(new List<string> {
					GetEmailHash(sender, email.SendDate, subject, email.Body, email.TimeZone, true, dateTimeFormat),
					GetEmailHash(sender, email.SendDate, subject, email.Body, email.TimeZone, false, dateTimeFormat),
					GetEmailHash(sender, email.SendDate, subject, email.Body, email.TimeZone, true, dateTimeFormat, false),
					GetEmailHash(sender, email.SendDate, subject, email.Body, email.TimeZone, false, dateTimeFormat, false)
				});
			}
			return hashes;
		}

		protected string TrimSubject(string subject) {
			var length = Math.Min(250, subject.Length);
			return subject.Substring(0, length);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IEmailHashComposer.GetHashes(UserConnection, EmailHashDTO)"/>
		public virtual IEnumerable<string> GetHashes(UserConnection userConnection, EmailHashDTO email) {
			return GetHashesInternal(userConnection, email);
		}

		/// <inheritdoc cref="IEmailHashComposer.GetDefaultHash(UserConnection, EmailHashDTO)"/>
		public virtual string GetDefaultHash(UserConnection userConnection, EmailHashDTO email) {
			var dateTimeFormat = GetDateTimeFormat(userConnection);
			var subject = userConnection.GetIsFeatureEnabled("UseSubjectStartForEmailHash")
				? TrimSubject(email.Subject)
				: email.Subject;
            var sender = userConnection.GetIsFeatureEnabled("UseSenderForEmailHash")
                ? email.Sender 
				: string.Empty;
            return GetEmailHash(sender, email.SendDate, subject, email.Body, email.TimeZone, true, dateTimeFormat);
		}

		#endregion

	}

	#endregion

}

