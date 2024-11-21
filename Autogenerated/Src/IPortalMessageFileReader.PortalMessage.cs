namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using BPMSoft.Nui.ServiceModel.DataContract;

	#region  Class: PortalMessageFileDTO

	[DataContract]
	public class PortalMessageFileDTO
	{
		#region Properties: Public

		[DataMember(Name = "Id")]
		public Guid Id { get; set; }

		[DataMember(Name = "CreatedBy")]
		public Guid CreatedBy { get; set; }

		[DataMember(Name = "CreatedOn")]
		public string CreatedOn { get; set; }

		[DataMember(Name = "Name")]
		public string Name { get; set; }

		[DataMember(Name = "Size")]
		public int Size { get; set; }

		[DataMember(Name = "Notes")]
		public string Notes { get; set; }

		[DataMember(Name = "Type")]
		public LookupColumn Type { get; set; }

		[DataMember(Name = "Version")]
		public int Version { get; set; }

		#endregion
	}

	#endregion

	#region  Class: LookupColumn

	/// <summary>
	/// Class that represent lookup column.
	/// </summary>
	[DataContract]
	public class LookupColumn
	{
		[DataMember(Name = "displayValue")]
		public string DisplayValue { get; set; }
		[DataMember(Name = "primaryImageValue")]
		public string PrimaryImageValue { get; set; }
		[DataMember(Name = "value")]
		public Guid Value { get; set; }
	}

	#endregion

	#region Interface: IPortalMessageFileReader

	/// <summary>
	/// Interface for getting portal message file data.
	/// </summary>
	public interface IPortalMessageFileReader {
		IEnumerable<PortalMessageFileDTO> GetPortalMessageFiles(string portalMessageId, ReadingOptions readingOptions);
	}

	#endregion

}
