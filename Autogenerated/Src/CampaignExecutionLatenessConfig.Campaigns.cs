namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core.Campaign;

	#region Class: CampaignExecutionLatenessConfig

	/// <summary>
	/// Class that contains campaign lateness parameters.
	/// </summary>
	public class CampaignExecutionLatenessConfig
	{

		#region Properties: Public
		
		/// <summary>
		/// Lateness value. Instance of <see cref="TimeSpan"/>.
		/// </summary>
		public TimeSpan LatenessTime {
			get;
			set;
		}

		/// <summary>
		/// Lateness type.
		/// </summary>
		public CampaignExecutionLateness Lateness {
			get;
			set;
		}

		/// <summary>
		/// Collection of misfired elements with time condition.
		/// </summary>
		public IEnumerable<CampaignSchemaElement> MisfiredTimeConditionElements {
			get;
			set;
		}

		#endregion

	}

	#endregion

}

