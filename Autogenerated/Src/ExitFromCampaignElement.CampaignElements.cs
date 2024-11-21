namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Interfaces;
	using BPMSoft.Core.Process;

	#region Class: ExitFromCampaignElement

	/// <summary>
	/// Element that excludes participants from campaign.
	/// </summary>
	[DesignModeProperty(Name = "IsCampaignGoal",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = IsCampaignGoalPropertyName)]
	public class ExitFromCampaignElement : BaseCampaignAudienceElement, IExtendableElement
	{

		#region Constants: Private

		private const string IsCampaignGoalPropertyName = "IsCampaignGoal";
		private const string ExitFromCampaignExtensionSuffix = "MoveAudience";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="ExitFromCampaignElement"/>.
		/// </summary>
		public ExitFromCampaignElement() {
			ElementType = CampaignSchemaElementType.FinalizeAudience;
		}

		/// <summary>
		/// Constructor for <see cref="ExitFromCampaignElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="ExitFromCampaignElement"/>.</param>
		public ExitFromCampaignElement(ExitFromCampaignElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="ExitFromCampaignElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="ExitFromCampaignElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public ExitFromCampaignElement(ExitFromCampaignElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			IsCampaignGoal = source.IsCampaignGoal;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action => IsCampaignGoal
			? CampaignConsts.CampaignLogTypeReachCampaignGoal
			: CampaignConsts.CampaignLogTypeExitFromCampaign;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Flag which indicates that element is campaign's goal or not.
		/// </summary>
		[MetaTypeProperty("{7FEF3690-6FD6-4836-8662-883A2D199FC6}")]
		public bool IsCampaignGoal { get; set; }

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Reads MetaData values to properties.
		/// </summary>
		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case IsCampaignGoalPropertyName:
					IsCampaignGoal = reader.GetBoolValue();
					break;
				default:
					break;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Writes meta data values.
		/// </summary>
		/// <param name="writer">Instance of the <see cref="DataWriter"/> type.</param>
		public override void WriteMetaData(DataWriter writer) {
			base.WriteMetaData(writer);
			writer.WriteValue(IsCampaignGoalPropertyName, IsCampaignGoal, false);
		}

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the ExitFromCampaignElement.</returns>
		public override object Clone() {
			return new ExitFromCampaignElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the ExitFromCampaignElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new ExitFromCampaignElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new ExcludeCampaignAudienceElement {
				IsCampaignGoal = IsCampaignGoal,
				UserConnection = userConnection
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		/// <summary>
		/// Returns extends for <see cref="ExitFromCampaignElement"/>.
		/// </summary>
		public IEnumerable<CampaignSchemaElement> CreateElementExtensions() {
			if (FolderId.IsNotEmpty() || HasFilter) {
				yield return new MoveAudienceToExitElement {
					UId = Guid.NewGuid(),
					ParentUId = UId,
					ParentSchema = ParentSchema,
					Name = this.Name + ExitFromCampaignExtensionSuffix,
					IsCampaignGoal = IsCampaignGoal,
					FolderId = FolderId,
					HasFilter = HasFilter,
					Filter = Filter
				};
			}
		}

		#endregion

	}

	#endregion

}

