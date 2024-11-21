namespace BPMSoft.Configuration.DynamicContent.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Configuration.DynamicContent.DataContract;

	#region Class: DCTemplateModel

	/// <summary>
	/// Class to represent data model for <see cref="DCTemplate"/> entity.
	/// </summary>
	public class DCTemplateModel
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier.
		/// </summary>
		public Guid Id { get; set; } = Guid.NewGuid();

		/// <summary>
		/// Unique identifier of linked entity.
		/// </summary>
		public Guid RecordId { get; set; }

		/// <summary>
		/// Collection of replica models for current template.
		/// </summary>
		public IEnumerable<DCReplicaModel> Replicas { get; set; }

		/// <summary>
		/// Collection of template group models for current template.
		/// </summary>
		public IEnumerable<DCTemplateGroupModel> Groups { get; set; }

		/// <summary>
		/// Collection of template block models for current template.
		/// </summary>
		public IEnumerable<DCTemplateBlockModel> Blocks { get; set; }

		/// <summary>
		/// Collection of attribute models for current template.
		/// </summary>
		public IEnumerable<DCAttributeModel> Attributes { get; set; }

		#endregion

		#region Method: Public

		/// <summary>
		/// Overrides explicit converting to <see cref="DCTemplateContract"/> type.
		/// Converts null to null.
		/// </summary>
		/// <param name="model">Template model object which converted.</param>
		public static explicit operator DCTemplateContract(DCTemplateModel model) =>
			model != null
				? new DCTemplateContract {
					Id = model.Id,
					RecordId = model.RecordId,
					Replicas = model.Replicas?.Select(x => (DCReplicaContract)x).ToList(),
					Groups = model.Groups?.Select(x => (DCTemplateGroupContract)x).ToList(),
					Blocks = model.Blocks?.Select(x => (DCTemplateBlockContract)x).ToList(),
					Attributes = model.Attributes?.Select(x => (DCAttributeContract)x).ToList()
				}
				: null;

		#endregion

	}

	#endregion

}

