namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Mail.Sender;

	#region Class : AsyncEmailSenderExecutor

	/// <summary>
	/// Represents a asynchronous email sending job.
	/// </summary>
	public class AsyncEmailSenderExecutor : IJobExecutor 
	{

		#region Methods : Public

		/// <summary>
		/// Send email asynchronously.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Parameters.</param>
		public virtual void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			if (parameters == null) {
				throw new ArgumentNullOrEmptyException("parameters can't be null");
			}
			Guid activityId = parameters.GetValue("activityId", Guid.Empty);
			if (activityId != Guid.Empty) {
				var userConnectionArg = new ConstructorArgument("userConnection", userConnection);
				var emailClientFactory = ClassFactory.Get<EmailClientFactory>(userConnectionArg);
				var sender = userConnection.GetIsFeatureEnabled("SecureEstimation") ? new SecureActivityEmailSender(emailClientFactory, userConnection) :
					new ActivityEmailSender(emailClientFactory, userConnection);
				sender.Send(activityId);
			} else {
				throw new ArgumentException("ActivityId must be specified");
			}
		}

		#endregion

	}

	#endregion

}
