namespace BPMSoft.Configuration.DynamicContent.DataContract
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using BPMSoft.Configuration.DynamicContent.Models;

	#region Class: DCTemplateContract

	/// <summary>
	/// Base data contract for CRUD-operations in <see cref="DCTemplateService"/>.
	/// </summary>
	[DataContract]
	public class DCTemplateContract
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Unique identifier of linked entity.
		/// </summary>
		[DataMember(IsRequired = true)]
		public Guid RecordId { get; set; }

		/// <summary>
		/// Collection of replica contracts for current template.
		/// </summary>
		[DataMember(IsRequired = true)]
		public IEnumerable<DCReplicaContract> Replicas { get; set; } = new List<DCReplicaContract>();

		/// <summary>
		/// Collection of template group contracts for current template.
		/// </summary>
		[DataMember(IsRequired = true)]
		public IEnumerable<DCTemplateGroupContract> Groups { get; set; } = new List<DCTemplateGroupContract>();

		/// <summary>
		/// Collection of template block contracts for current template.
		/// </summary>
		[DataMember(IsRequired = true)]
		public IEnumerable<DCTemplateBlockContract> Blocks { get; set; } = new List<DCTemplateBlockContract>();

		/// <summary>
		/// Collection of attribute contracts for current template.
		/// </summary>
		[DataMember(IsRequired = true)]
		public IEnumerable<DCAttributeContract> Attributes { get; set; } = new List<DCAttributeContract>();

		#endregion

		#region Method: Public

		/// <summary>
		/// Overrides explicit converting to <see cref="DCTemplateModel"/> type.
		/// Converts null to null.
		/// </summary>
		/// <param name="contract">Template contract object which converted.</param>
		public static explicit operator DCTemplateModel(DCTemplateContract contract) => 
			contract != null 
				? new DCTemplateModel {
					Id = contract.Id,
					RecordId = contract.RecordId,
					Replicas = contract.Replicas?.Select(x => (DCReplicaModel)x).ToList(),
					Groups = contract.Groups?.Select(x => (DCTemplateGroupModel)x).ToList(),
					Blocks = contract.Blocks?.Select(x => (DCTemplateBlockModel)x).ToList(),
					Attributes = contract.Attributes?.Select(x => (DCAttributeModel)x).ToList()
				}
				: null;

		#endregion

	}

	#endregion

}

