namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Quartz;
	using Quartz.Impl.Matchers;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Messaging.Common;

	#region Class : CertificatesActualizationJob

	/// <summary>
	/// A class that represents certificates actualization job.
	/// </summary>
	public class CertificatesActualizationJob : IJobExecutor
	{

		#region Methods : Public

		/// <summary>
		/// Runs actualization for all certificates in active partnerships.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Parameters.</param>
		public virtual void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			CertificateUtils.ActualizeAll(userConnection);
		}

		#endregion

	}

	#endregion

}
