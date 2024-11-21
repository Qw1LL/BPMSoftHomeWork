namespace BPMSoft.Configuration.DynamicContent.DataContract
{
	using System;
	using System.Runtime.Serialization;
	using BPMSoft.Configuration.DynamicContent.Models;

	#region Class: DCTemplateGroupContract

	/// <summary>
	/// Class to represent data contract for <see cref="DCTemplateGroup"/> entity.
	/// </summary>
	[DataContract]
	public class DCTemplateGroupContract
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

		#endregion

		#region Methods: Public

		/// <summary>
		/// Overrides explicit converting to <see cref="DCTemplateGroupModel"/> type.
		/// Converts null to null.
		/// </summary>
		/// <param name="contract">Template contract object which converted.</param>
		public static explicit operator DCTemplateGroupModel(DCTemplateGroupContract contract) =>
			contract != null
				? new DCTemplateGroupModel {
					Id = contract.Id == default(Guid) ? Guid.NewGuid() : contract.Id,
					Index = contract.Index
				}
				: null;

		#endregion

	}

	#endregion

}
