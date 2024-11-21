namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Interfaces;
	using BPMSoft.Core.Process;
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;

	#region Class: CampaignAddEventAudienceElement

	/// <summary>
	/// Event schema element in campaign.
	/// </summary>
	public class CampaignAddEventAudienceElement : CampaignEventElement, IElementPriority
	{

		#region Fields: Private

		private readonly Guid EventTargetSchemaUId = new Guid("FB50E79E-EDE8-4714-B6C8-C7CF4D3A9F87");

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="CampaignAddEventAudienceElement"/>.
		/// </summary>
		public CampaignAddEventAudienceElement() {
			ElementType = CampaignSchemaElementType.AddAudience;
		}
		
		/// <summary>
		/// Constructor for <see cref="CampaignAddEventAudienceElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignEventElement"/>.</param>
		public CampaignAddEventAudienceElement(CampaignEventElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignAddEventAudienceElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignEventElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignAddEventAudienceElement(CampaignEventElement source, Dictionary<Guid, Guid> dictToRebind,
				CoreCampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			EventId = source.EventId;
			ElementType = CampaignSchemaElementType.AddAudience;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action {
			get {
				return CampaignConsts.CampaignLogTypeAddEventAudience;
			}
		}

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
		/// <returns>Cloned instance of the CampaignEventElement.</returns>
		public override object Clone() {
			return new CampaignAddEventAudienceElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the CampaignEventElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, CoreCampaignSchema parentSchema) {
			return new CampaignAddEventAudienceElement(this, dictToRebind, parentSchema);
		}
		
		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignAddEventAudienceFlowElement() {
				UserConnection = userConnection,
				EventId = EventId,
				AudienceSchemaUId = EventTargetSchemaUId
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}

