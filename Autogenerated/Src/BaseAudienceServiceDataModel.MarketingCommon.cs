namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Class: BaseAudienceServiceDataModel

	/// <summary>
	/// Data model for audience services.
	/// </summary>
	[DataContract]
	public class BaseAudienceServiceDataModel
	{

		#region Properties: Public

		/// <summary>
		/// List of entity or folder identifiers.
		/// </summary>
		[DataMember(IsRequired = true)]
		public List<Guid> SourceCollection { get; set; }

		/// <summary>
		/// Audience source type.
		/// </summary>
		[DataMember(IsRequired = true)]
		public AudienceSourceType SourceType { get; set; }

		/// <summary>
		/// Estimated number of affected entities.
		/// Default value = -1.
		/// </summary>
		[DataMember(IsRequired = false)]
		public int EstimatedEntitiesCount { get; set; } = -1;

		/// <summary>
		/// Serialized ESQ. Contains JSON that can be deserialized as
		/// <see cref="BPMSoft.Nui.ServiceModel.DataContract.SelectQuery"/>.
		/// </summary>
		[DataMember(IsRequired = false)]
		public string EsqSerialized { get; set; }

		#endregion

	}

	#endregion

	#region Class: BulkEmailAudienceSourceType

	/// <summary>
	/// Audience source types.
	/// </summary>
	[DataContract]
	public enum AudienceSourceType {
		[EnumMember]
		Entity = 0,
		[EnumMember]
		Folder = 1,
		[EnumMember]
		Filter = 2,
		[EnumMember]
		Audience = 3
	}

	#endregion

	#region Class: AudienceServiceResponse

	/// <summary>
	/// Response for audience services.
	/// </summary>
	[DataContract]
	public class AudienceServiceResponse
	{

		#region Properties: Public

		/// <summary>
		/// Execution result. Success by default.
		/// </summary>
		[DataMember]
		public bool Success { get; set; } = true;

		/// <summary>
		/// Message.
		/// </summary>
		[DataMember(EmitDefaultValue = false)]
		public string Message { get; set; }

		#endregion

	}

	#endregion

	#region Class: QueueTaskEstimationResponse

	/// <summary>
	/// Estimation response for queued tasks.
	/// </summary>
	[DataContract]
	public class QueueTaskEstimationResponse : AudienceServiceResponse
	{

		#region Properties: Public

		/// <summary>
		/// Position of last task in queue for specified record.
		/// </summary>
		[DataMember]
		public int Position { get; set; }

		/// <summary>
		/// Estimated time for last task processing for specified record.
		/// </summary>
		[DataMember]
		public int EstimatedTime { get; set; }

		#endregion

	}

	#endregion

}

