namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Class: EmailIndicator

	/// <summary>
	/// Represents email trouble indicator.
	/// </summary>
	[DataContract]
	public class EmailIndicator
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets indicator caption.
		/// </summary>
		[DataMember(Name = "caption")]
		public string Caption {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets benchmark value.
		/// </summary>
		[DataMember(Name = "benchmark")]
		public int Benchmark {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets actual value of the indicator.
		/// </summary>
		[DataMember(Name = "actualCount")]
		public int ActualValue {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets state of the indicator.
		/// </summary>
		/// <value>
		/// Can contains value "ok" or "error".
		/// </value>
		[DataMember(Name = "state")]
		public string State {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets list of IDs of the emails  did not match indicator.
		/// </summary>
		[DataMember(Name = "emailIdList")]
		public List<Guid> EmailIdList {
			get;
			set;
		}

		#endregion

	}

	#endregion

}

