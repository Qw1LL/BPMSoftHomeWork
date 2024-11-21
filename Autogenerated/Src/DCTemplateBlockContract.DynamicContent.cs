namespace BPMSoft.Configuration.DynamicContent.DataContract
{
	using System;
	using System.Linq;
	using System.Runtime.Serialization;
	using BPMSoft.Configuration.DynamicContent.Models;

	#region Class: DCTemplateBlockContract

	/// <summary>
	/// Class to represent data contract for <see cref="DCTemplateBlock"/> entity.
	/// </summary>
	[DataContract]
	public class DCTemplateBlockContract
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier.
		/// </summary>
		[DataMember]
		public Guid Id { get; set; }

		/// <summary>
		/// Unique identifier of parent group.
		/// </summary>
		[DataMember]
		public Guid TemplateGroupId { get; set; }

		/// <summary>
		/// Unique index within the template (power of 2 - for unique bitwise mask in replica).
		/// </summary>
		[DataMember(IsRequired = true)]
		public int Index { get; set; }

		/// <summary>
		/// Index of parent group.
		/// </summary>
		[DataMember(IsRequired = true)]
		public int GroupIndex { get; set; }

		/// <summary>
		/// Flag to indicate that block is default, has min priority
		/// and would be used by default for recipients which are not suitable for filter conditions.
		/// </summary>
		[DataMember(IsRequired = true)]
		public bool IsDefault { get; set; }

		/// <summary>
		/// Weight of block within group for replicas' sendind prority.
		/// </summary>
		[DataMember(IsRequired = true)]
		public int Priority { get; set; }

		/// <summary>
		/// Array of attributes' indexes that are included for current block.
		/// </summary>
		[DataMember(IsRequired = true)]
		public int[] AttributeIndexes { get; set; } = new int[0];

		#endregion

		#region Methods: Public

		/// <summary>
		/// Overrides explicit converting to <see cref="DCTemplateBlockModel"/> type.
		/// Converts null to null.
		/// </summary>
		/// <param name="contract">Template contract object which converted.</param>
		public static explicit operator DCTemplateBlockModel(DCTemplateBlockContract contract) =>
			contract != null
				? new DCTemplateBlockModel {
					Id = contract.Id == default(Guid) ? Guid.NewGuid() : contract.Id,
					DCTemplateGroupId = contract.TemplateGroupId,
					IsDefault = contract.IsDefault,
					Priority = contract.Priority,
					GroupIndex = contract.GroupIndex,
					Index = contract.Index,
					AttributeIndexes = contract.AttributeIndexes.ToArray()
				}
				: null;

		#endregion

	}

	#endregion

}
