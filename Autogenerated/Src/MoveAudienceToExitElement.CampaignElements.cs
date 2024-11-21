namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Interfaces;
	using BPMSoft.Core.Process;

	#region Class: MoveAudienceToExitElement

	/// <summary>
	/// Element that moves participants to current campaign item by specified folder.
	/// </summary>
	[DesignModeProperty(Name = "IsCampaignGoal",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = IsCampaignGoalPropertyName)]
	public class MoveAudienceToExitElement : BaseCampaignAudienceElement, IElementPriority
	{

		#region Constants: Private

		private const string IsCampaignGoalPropertyName = "IsCampaignGoal";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="MoveAudienceToExitElement"/>.
		/// </summary>
		public MoveAudienceToExitElement() {
			ElementType = CampaignSchemaElementType.MoveAudience;
		}

		/// <summary>
		/// Constructor for <see cref="MoveAudienceToExitElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="MoveAudienceToExitElement"/>.</param>
		public MoveAudienceToExitElement(MoveAudienceToExitElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="MoveAudienceToExitElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="MoveAudienceToExitElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public MoveAudienceToExitElement(MoveAudienceToExitElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			IsCampaignGoal = source.IsCampaignGoal;
			ElementType = CampaignSchemaElementType.MoveAudience;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action => CampaignConsts.CampaignLogTypeMoveAudience;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Flag which indicates that element is campaign's goal or not.
		/// </summary>
		[MetaTypeProperty("{2B875674-EB89-4FED-B52C-97B7A1CA775D}")]
		public bool IsCampaignGoal { get; set; }

		/// <summary>
		/// Priority of move campaign audience element execution.
		/// </summary>
		public int Priority => IsCampaignGoal ? 1 : 0;

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the <see cref="MoveAudienceToExitElement"/>.</returns>
		public override object Clone() {
			return new MoveAudienceToExitElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the <see cref="MoveAudienceToExitElement"/>.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new MoveAudienceToExitElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new MoveAudienceToExitFlowElement {
				FolderRecordId = FolderId,
				IsCampaignGoal = IsCampaignGoal,
				UserConnection = userConnection,
				Filter = Filter,
				HasFilter = HasFilter
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}

