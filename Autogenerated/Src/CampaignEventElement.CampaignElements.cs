namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Interfaces;

	#region Class: CampaignEventElement

	/// <summary>
	/// Event schema element in campaign.
	/// </summary>
	public class CampaignEventElement : CampaignBaseEventElement, IExtendableElement
	{

		#region Constants: Private

		private const string AddAudienceExtensionSuffix = "AddAudience";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="CampaignEventElement"/>.
		/// </summary>
		public CampaignEventElement() {
			ElementType = CampaignSchemaElementType.AsyncTask;
		}

		/// <summary>
		/// Constructor for <see cref="CampaignEventElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignEventElement"/>.</param>
		public CampaignEventElement(CampaignEventElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignEventElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignEventElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignEventElement(CampaignEventElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the <see cref="CampaignEventElement"/>.</returns>
		public override object Clone() {
			return new CampaignEventElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the <see cref="CampaignEventElement"/>.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new CampaignEventElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Returns extends for <see cref="CampaignEventElement"/>.
		/// </summary>
		public IEnumerable<CampaignSchemaElement> CreateElementExtensions() {
			yield return new CampaignAddEventAudienceElement(this) {
				UId = Guid.NewGuid(),
				ParentUId = UId,
				ParentSchema = ParentSchema,
				Name = Name + AddAudienceExtensionSuffix
			};
		}

		#endregion

	}

	#endregion

}

