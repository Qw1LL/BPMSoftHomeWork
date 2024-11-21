namespace BPMSoft.Configuration.DynamicContent.DataContract
{
	using System;
	using System.Linq;
	using System.Runtime.Serialization;
	using BPMSoft.Configuration.DynamicContent.Models;

	#region Class: DCReplicaContract

	/// <summary>
	/// Class to represent data contract for <see cref="DCReplica"/> entity.
	/// </summary>
	[DataContract]
	public class DCReplicaContract
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier.
		/// </summary>
		[DataMember]
		public Guid Id { get; set; }

		/// <summary>
		/// Replica's caption.
		/// </summary>
		[DataMember]
		public string Caption { get; set; }

		/// <summary>
		/// Unique index mask within the template as bitwise sum of block indexes for current replica.
		/// </summary>
		[DataMember(IsRequired = true)]
		public int Mask { get; set; }

		/// <summary>
		/// Content for current template replica.
		/// </summary>
		[DataMember(IsRequired = true)]
		public string Content { get; set; }

		/// <summary>
		/// Array of blocks' indexes that are included for current replica.
		/// </summary>
		[DataMember(IsRequired = true)]
		public int[] BlockIndexes { get; set; } = new int[0];


		#endregion

		#region Methods: Public

		/// <summary>
		/// Overrides explicit converting to <see cref="DCReplicaModel"/> type.
		/// Converts null to null.
		/// </summary>
		/// <param name="contract">Replica contract object which converted.</param>
		public static explicit operator DCReplicaModel(DCReplicaContract contract) =>
			contract != null
				? new DCReplicaModel {
					Id = contract.Id == default(Guid) ? Guid.NewGuid() : contract.Id,
					Mask = contract.Mask,
					Content = contract.Content,
					Caption = contract.Caption,
					BlockIndexes = contract.BlockIndexes.ToArray()
				}
				: null;

		#endregion

	}

	#endregion

}

