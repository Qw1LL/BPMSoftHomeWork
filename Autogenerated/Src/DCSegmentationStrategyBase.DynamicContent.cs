namespace BPMSoft.Configuration.DynamicContent
{
	using System;

	#region Class: DCSegmentationStrategyBase

	/// <summary>
	/// Represents strategies that are segmenting an audience.
	/// </summary>
	public abstract class DCSegmentationStrategyBase
	{

		#region Constructors: Public

		/// <summary>
		/// Creates resolver strategy instance with a predefined context.
		/// </summary>
		/// <param name="segmentationContext">A set of predefined parameters, which are using by strategies.</param>
		public DCSegmentationStrategyBase(DCSegmentationContext segmentationContext) {
			SegmentationContext = segmentationContext;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Represents the context for instances of <see cref="DCSegmentationStrategyBase"/>.
		/// </summary>
		public DCSegmentationContext SegmentationContext { get; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Defines which replica should be sent to recipient.
		/// </summary>
		public abstract int SegmentAudience();

		/// <summary>
		/// Defines which replica should be sent to recipient.
		/// </summary>
		/// <returns>Unique identifier of <see cref="DCReplica"/> or <see cref="Guid.Empty"/>.</returns>
		public abstract Guid SegmentSingleEntity();

		/// <summary>
		/// Should remove all operational data.
		/// </summary>
		public abstract void ClearOpData();

		#endregion

	}

	#endregion

}

