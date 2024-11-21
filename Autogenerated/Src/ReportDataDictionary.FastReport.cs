namespace BPMSoft.Configuration.Reporting.FastReport
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Class: ReportDataDictionary

	[Serializable]
	public class ReportDataDictionary : Dictionary<string, IEnumerable<IReadOnlyDictionary<string, object>>>
	{

		#region Constructors: Protected

		protected ReportDataDictionary(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext) {
		}

		#endregion

		#region Constructors: Public

		public ReportDataDictionary() : base() {
		}

		public ReportDataDictionary(int capacity) : base(capacity) {
		}

		public ReportDataDictionary(ReportDataDictionary dictionary) : base(dictionary) {
		}

		#endregion

	}

	#endregion

}

