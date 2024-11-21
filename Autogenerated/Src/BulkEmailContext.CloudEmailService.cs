namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Configuration.CES;
	using BPMSoft.Core;

	#region Class: BulkEmailContext

	/// <summary>
	/// Information about bulk email
	/// </summary>
	public class BulkEmailContext
	{

		#region Properties: Public

		/// <summary>
		/// Instance of the <see cref="BPMSoft.Core.UserConnection"/> type.
		/// </summary>
		public UserConnection UserConnection { get; set; }

		/// <summary>
		/// Introduces API for Cloud Email Service.
		/// </summary>
		public ICESApi ServiceApi { get; set; }

		/// <summary>
		/// Collection of message ids in bulk email
		/// </summary>
		public Guid[] MessageIds { get; set; }

		/// <summary>
		/// Count of bulk email recipients
		/// </summary>
		public int RecipientCount { get; set; }

		#endregion

	}

	#endregion

}

