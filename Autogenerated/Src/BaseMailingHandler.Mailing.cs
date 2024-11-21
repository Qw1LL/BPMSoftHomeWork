namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Scheduler;

	#region Class: BaseMailingHandler

	/// <summary>
	/// Base mailing handler.
	/// </summary>
	public abstract class BaseMailingHandler : IMailingHandler
	{

		#region Fields: Private

		private readonly string jobGroupName = "Mailing";

		#endregion

		#region Properties: Protected

		protected abstract string ProcessName {
			get;
		}

		protected abstract string JobName {
			get;
		}

		protected virtual string JobGroupName {
			get { return jobGroupName; }
		}

		#endregion

		#region Methods: Protected

		protected virtual Dictionary<string, object> GetParameters(UserConnection userConnection) {
			return null;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates instance of the handler.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		public abstract void CreateInstance(UserConnection userConnection);

		/// <summary>
		/// Removes instance of the handler.
		/// </summary>
		public virtual void RemoveInstance() {
			AppScheduler.RemoveJob(JobName, JobGroupName);
		}

		#endregion

	}

	#endregion

}

