namespace BPMSoft.Configuration.ESN
{
	using System;
	using System.Runtime.Serialization;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Nui.ServiceModel.DataContract;

	#region  Enum: SortedMessageColumn

	public enum SortedMessageColumn
	{
		CreatedOn = 0,
		LastActionOn = 1
	}

	#endregion

	#region  Class: EsnReadMessageOptions

	/// <summary>
	/// Reading messages options.
	/// </summary>
	[DataContract]
	public class EsnReadMessageOptions
	{
		#region Constructors: Public

		public EsnReadMessageOptions() {
			ReadMessageCount = 15;
			SortedBy = SortedMessageColumn.CreatedOn;
			OrderDirection = OrderDirection.Descending;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Count of messages to be retrieved.
		/// </summary>
		[DataMember(Name = "ReadMessageCount")]
		public int ReadMessageCount { get; set; }

		/// <summary>
		/// Indicates whether all nested comments should be loaded.
		/// </summary>
		[DataMember(Name = "IncludeComments")]
		public bool IncludeComments { get; set; }

		/// <summary>
		/// Skip message where sorted column value less than.
		/// </summary>
		[IgnoreDataMember]
		public DateTime OffsetDate { get; set; }

		[DataMember(Name = "OffsetDate")]
		private string _offsetDate { 
			get { 
				return DateTimeDataValueType.Serialize(OffsetDate, TimeZoneInfo.Utc);
			}
			set {
				var decodet = Json.Deserialize(value);
				OffsetDate = DataTypeUtilities.ValueAsType<DateTime>(decodet);
			}
		}

		/// <summary>
		/// Sorted message by <see cref="SortedMessageColumn" />.
		/// </summary>
		[DataMember(Name = "SortedBy")]
		public SortedMessageColumn SortedBy { get; set; }

		/// <summary>
		/// Order direction <see cref="OrderDirection" />.
		/// </summary>
		[IgnoreDataMember]
		public OrderDirection OrderDirection { get; set; }

		[DataMember(Name = "OrderDirection")]
		private int? _orderDirection { get; set; }

		/// <summary>
		/// Additional filters.
		/// </summary>
		[IgnoreDataMember]
		public Filters Filters { get; set; }

		[DataMember(Name = "Filters")]
		private string _filters {
			get {
				return JsonConvert.SerializeObject(Filters);
			}
			set {
				if (!string.IsNullOrEmpty(value)) {
					Filters = JsonConvert.DeserializeObject<Filters>(value);
				}
			}
		}

		#endregion

		#region Methods: Private

		[OnDeserialized]
		private void OnDeserialized(StreamingContext c) {
			OrderDirection = _orderDirection == null ? OrderDirection.Descending : (OrderDirection)_orderDirection;
		}

		#endregion

	}

	#endregion

}

