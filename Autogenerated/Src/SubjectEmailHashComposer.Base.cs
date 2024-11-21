namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	/// <summary>
	/// Class creates email hashes including possible converting original subject.
	/// </summary>
	[DefaultBinding(typeof(IEmailHashComposer), Name = "SubjectEmailHashComposer")]
	public class SubjectEmailHashComposer : BaseEmailHashComposer
	{

		#region Methods: Public

		public override IEnumerable<string> GetHashes(UserConnection userConnection, EmailHashDTO email) {
			List<string> hashes = new List<string>();
			var subject = ActivityUtils.FixWhitespaces(email.Subject);
			hashes.AddRange(GetHashesInternal(userConnection, new EmailHashDTO {
				Subject = subject,
				SendDate = email.SendDate,
				Body = email.Body,
				TimeZone = email.TimeZone
			}));
			return hashes;
		}

		#endregion

	}
}

