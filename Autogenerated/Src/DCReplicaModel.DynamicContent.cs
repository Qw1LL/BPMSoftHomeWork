namespace BPMSoft.Configuration.DynamicContent.Models
{
	using System;
	using System.Linq;
	using BPMSoft.Configuration.DynamicContent.DataContract;

	#region Class: DCReplicaModel

	/// <summary>
	/// Class to represent data model for <see cref="DCReplica"/> entity.
	/// </summary>
	public class DCReplicaModel
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier.
		/// </summary>
		public Guid Id { get; set; } = Guid.NewGuid();

		/// <summary>
		/// Replica's caption.
		/// </summary>
		public string Caption { get; set; }

		/// <summary>
		/// Unique identifier of template entity.
		/// </summary>
		public Guid DCTemplateId { get; set; }

		/// <summary>
		/// Unique index mask within the template as bitwise sum of block indexes for current replica.
		/// </summary>
		public int Mask { get; set; }

		/// <summary>
		/// Content for current template replica.
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// Array of blocks' indexes that are included for current replica.
		/// </summary>
		public int[] BlockIndexes { get; set; } = new int[0];

		#endregion

		#region Methods: Public

		/// <summary>
		/// Overrides explicit converting to <see cref="DCReplicaContract"/> type.
		/// Converts null to null.
		/// </summary>
		/// <param name="model">Replica model object which converted.</param>
		public static explicit operator DCReplicaContract(DCReplicaModel model) =>
			model != null
				? new DCReplicaContract {
					Id = model.Id,
					Mask = model.Mask,
					Content = model.Content,
					Caption = model.Caption,
					BlockIndexes = model.BlockIndexes.ToArray()
				}
				: null;

		#endregion

	}

	#endregion

}

