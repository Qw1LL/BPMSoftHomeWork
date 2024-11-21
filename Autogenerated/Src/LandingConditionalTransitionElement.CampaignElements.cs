 namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using CoreCampaignSchema = BPMSoft.Core.Campaign.CampaignSchema;

	#region Class: LandingConditionalTransitionElement

	/// <summary>
	/// Schema element for landing conditional transition.
	/// </summary>
	public class LandingConditionalTransitionElement : ConditionalSequenceFlowElement
	{

		#region Constructors: Public

		/// <summary>
		/// Default consructor.
		/// </summary>
		public LandingConditionalTransitionElement() {
		}

		/// <summary>
		/// Constructor of the clone.
		/// </summary>
		/// <param name="source">Instance of <see cref="LandingConditionalTransitionElement"/>.</param>
		public LandingConditionalTransitionElement(LandingConditionalTransitionElement source)
			: this(source, null, null) {
		}

		/// <summary>
		/// Constructor of the copy.
		/// </summary>
		/// <param name="source">Instance of <see cref="LandingConditionalTransitionElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public LandingConditionalTransitionElement(LandingConditionalTransitionElement source,
				Dictionary<Guid, Guid> dictToRebind, CoreCampaignSchema parentSchema)
					: base(source, dictToRebind, parentSchema) {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the LandingConditionalTransitionElement.</returns>
		public override object Clone() {
			return new LandingConditionalTransitionElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the LandingConditionalTransitionElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new LandingConditionalTransitionElement(this, dictToRebind, parentSchema);
		}

		#endregion

	}

	#endregion

}

