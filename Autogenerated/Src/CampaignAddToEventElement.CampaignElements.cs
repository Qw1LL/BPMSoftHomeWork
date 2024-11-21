namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core.Campaign;

	#region Class: CampaignAddToEventElement

	/// <summary>
	/// Add audience to event schema element in campaign.
	/// </summary>
	public class CampaignAddToEventElement : CampaignBaseEventElement
	{

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="CampaignAddToEventElement"/>.
		/// </summary>
		public CampaignAddToEventElement() {
			ElementType = CampaignSchemaElementType.AsyncTask | CampaignSchemaElementType.Sessioned;
		}

		/// <summary>
		/// Constructor for <see cref="CampaignAddToEventElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignAddToEventElement"/>.</param>
		public CampaignAddToEventElement(CampaignAddToEventElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignAddToEventElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignAddToEventElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignAddToEventElement(CampaignAddToEventElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the <see cref="CampaignAddToEventElement"/>.</returns>
		public override object Clone() {
			return new CampaignAddToEventElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the <see cref="CampaignAddToEventElement"/>.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new CampaignAddToEventElement(this, dictToRebind, parentSchema);
		}

		#endregion

	}

	#endregion

}

