namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: DateNotStrictEmailHashComposer

	/// <summary>
	/// Class creates email hashes including possible time delays.
	/// </summary>
	[DefaultBinding(typeof(IEmailHashComposer), Name = "DateNotStrictEmailHashComposer")]
	public class DateNotStrictEmailHashComposer : BaseEmailHashComposer
	{

		#region Methods: Public

		/// <summary>
		/// <seealso cref="IEmailHashComposer.GetHashes(UserConnection, EmailHashDTO)"/> implementation.
		/// </summary>
		public override IEnumerable<string> GetHashes(UserConnection userConnection, EmailHashDTO email) {
			List<string> hashes = new List<string>();
			if (userConnection.GetIsFeatureEnabled("UseNotStrictSendDates")) {
				var minuteBefore = email.SendDate.AddMinutes(-1);
				var minuteAfter = email.SendDate.AddMinutes(1);
				hashes.AddRange(GetHashesInternal(userConnection, new EmailHashDTO {
					Sender = email.Sender,
					Subject = email.Subject,
					SendDate = minuteBefore,
					Body = email.Body,
					TimeZone = email.TimeZone
				}));
				hashes.AddRange(GetHashesInternal(userConnection, new EmailHashDTO {
                    Sender = email.Sender,
                    Subject = email.Subject,
					SendDate = minuteAfter,
					Body = email.Body,
					TimeZone = email.TimeZone
				}));
			}
			return hashes;
		}

		#endregion

	}

	#endregion

}

