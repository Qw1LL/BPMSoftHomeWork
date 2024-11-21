namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Interfaces;
	using BPMSoft.Core.Process;
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;

	#region Class: CampaignAddLandingAudienceElement

	/// <summary>
	/// Landing schema element extension that serves audience flow element.
	/// </summary>
	public class CampaignAddLandingAudienceElement : CampaignLandingElement, IElementPriority
	{

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="CampaignAddLandingAudienceElement"/>.
		/// </summary>
		public CampaignAddLandingAudienceElement() {
			ElementType = CampaignSchemaElementType.AddAudience;
		}

		/// <summary>
		/// Constructor for <see cref="CampaignAddLandingAudienceElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignLandingElement"/>.</param>
		public CampaignAddLandingAudienceElement(CampaignLandingElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignAddLandingAudienceElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignLandingElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignAddLandingAudienceElement(CampaignLandingElement source, Dictionary<Guid, Guid> dictToRebind,
				CoreCampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			LandingId = source.LandingId;
			ElementType = CampaignSchemaElementType.AddAudience;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action => CampaignConsts.CampaignLogTypeAddLandingAudience;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Defines priority between elements of the same type <see cref="CampaignSchemaElementType"/> for the
		/// <see cref="Core.Campaign.FlowGenerator.CampaignFlowSchemaGenerator"/>.
		/// </summary>
		public int Priority => -1;

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the CampaignLandingElement.</returns>
		public override object Clone() {
			return new CampaignAddLandingAudienceElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema element's ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the CampaignLandingElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, CoreCampaignSchema parentSchema) {
			return new CampaignAddLandingAudienceElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignAddLandingAudienceFlowElement() {
				UserConnection = userConnection,
				LandingId = LandingId
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}

