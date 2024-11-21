namespace BPMSoft.Configuration.SocialLeadGen
{
	using System;
    using System.Collections.Generic;

    #region Class: LinkedInPullLeadsRestRequest

    /// <summary>
    /// Cloud request DTO with information about pull leads config
    /// </summary>
    public class LinkedInPullLeadsRestRequest
	{
		#region Properties: Public

		/// <summary>
		/// Start date
		/// </summary>
		public string StartDate { get; set; }

		/// <summary>
		/// Start date
		/// </summary>
		public string EndDate { get; set; }

		/// <summary>
		/// Include inactive ranges
		/// </summary>
		public bool IncludeInactiveRanges { get; set; }

		/// <summary>
		/// List of ignore social lead id's
		/// </summary>
		public IEnumerable<string> IgnoreSocialLeadIds { get; set; }

		/// <summary>
		/// Integration id
		/// </summary>
		public Guid? IntegrationId { get; set; }

		/// <summary>
		/// Form id
		/// </summary>
		public long? FormId { get; set; }


		#endregion

	}

	#endregion

}
