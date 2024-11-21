namespace BPMSoft.Configuration.DynamicContent.DataContract
{
	using System;
	using System.Runtime.Serialization;
	using BPMSoft.Configuration.DynamicContent.Models;

	#region Class: DCAttributeContract

	/// <summary>
	/// Class to represent data contract for <see cref="DCAttribute"/> entity.
	/// </summary>
	[DataContract]
	public class DCAttributeContract
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier.
		/// </summary>
		[DataMember]
		public Guid Id { get; set; }

		/// <summary>
		/// Unique index within the template.
		/// </summary>
		[DataMember(IsRequired = true)]
		public int Index { get; set; }

		/// <summary>
		/// Attribute's caption.
		/// </summary>
		[DataMember(IsRequired = true)]
		public string Caption { get; set; }

		/// <summary>
		/// Unique identifier of attribute type.
		/// </summary>
		[DataMember(IsRequired = true)]
		public Guid TypeId { get; set; }

		/// <summary>
		/// Specific value of current attribute.
		/// </summary>
		[DataMember(IsRequired = true)]
		public string Value { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Overrides explicit converting to <see cref="DCAttributeModel"/> type.
		/// Converts null to null.
		/// </summary>
		/// <param name="contract">Template contract object which converted.</param>
		public static explicit operator DCAttributeModel(DCAttributeContract contract) =>
			contract != null
				? new DCAttributeModel {
					Id = contract.Id == default(Guid) ? Guid.NewGuid() : contract.Id,
					Caption = contract.Caption,
					TypeId = contract.TypeId,
					Index = contract.Index,
					Value = contract.Value
				}
				: null;

		#endregion

	}

	#endregion

}
