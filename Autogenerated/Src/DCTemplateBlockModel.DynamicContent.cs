namespace BPMSoft.Configuration.DynamicContent.Models
{
	using System;
	using System.Linq;
	using BPMSoft.Configuration.DynamicContent.DataContract;

	#region Class: DCTemplateBlockModel

	/// <summary>
	/// Class to represent data model for <see cref="DCTemplateBlock"/> entity.
	/// </summary>
	public class DCTemplateBlockModel
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier.
		/// </summary>
		public Guid Id { get; set; } = Guid.NewGuid();

		/// <summary>
		/// Unique identifier of parent group.
		/// </summary>
		public Guid DCTemplateGroupId { get; set; }

		/// <summary>
		/// Flag to indicate that block is default, has min priority
		/// and would be used by default for recipients which are not suitable for filter conditions.
		/// </summary>
		public bool IsDefault { get; set; }

		/// <summary>
		/// Weight of block within group for replicas' sendind prority.
		/// </summary>
		public int Priority { get; set; }

		/// <summary>
		/// Index of parent group.
		/// </summary>
		public int GroupIndex { get; set; }

		/// <summary>
		/// Unique index within the template (power of 2 - for unique bitwise mask in replica).
		/// </summary>
		public int Index { get; set; }

		/// <summary>
		/// Array of attributes' indexes that are included for current block.
		/// </summary>
		public int[] AttributeIndexes { get; set; } = new int[0];

		#endregion

		#region Methods: Public

		/// <summary>
		/// Overrides explicit converting to <see cref="DCTemplateBlockContract"/> type.
		/// Converts null to null.
		/// </summary>
		/// <param name="model">Template model object which converted.</param>
		public static explicit operator DCTemplateBlockContract(DCTemplateBlockModel model) =>
			model != null
				? new DCTemplateBlockContract {
					Id = model.Id,
					TemplateGroupId = model.DCTemplateGroupId,
					IsDefault = model.IsDefault,
					Priority = model.Priority,
					GroupIndex = model.GroupIndex,
					Index = model.Index,
					AttributeIndexes = model.AttributeIndexes.ToArray()
				}
				: null;

		#endregion


	}

	#endregion

}

