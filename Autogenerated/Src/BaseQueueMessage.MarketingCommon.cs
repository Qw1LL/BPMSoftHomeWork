namespace BPMSoft.Configuration
{
	using System;
	using Newtonsoft.Json;

	#region Class: BaseQueueMessage

	/// <summary>
	/// Base message for queue.
	/// </summary>
	public abstract class BaseQueueMessage : BaseTaskQueueMessage
	{

		#region Properties: Public

		/// <summary>
		/// Estimated entities count.
		/// </summary>
		[JsonIgnore]
		public int EstimatedRowsCount { get; set; }

		/// <summary>
		/// User information of the current user.
		/// </summary>
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UserContext { get; set; }

		#endregion

	}

	#endregion

}

