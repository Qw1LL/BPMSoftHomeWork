namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Process;

	#region Class: CampaignAddObjectElement

	/// <summary>
	/// Campaign schema element to create new object
	/// for selected entity schema name with predefined column values.
	/// </summary>
	public class CampaignAddObjectElement : CampaignBaseCrudObjectElement
	{

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="CampaignAddObjectElement"/>.
		/// </summary>
		public CampaignAddObjectElement() {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignAddObjectElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignAddObjectElement"/>.</param>
		public CampaignAddObjectElement(CampaignAddObjectElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignAddObjectElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignAddObjectElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignAddObjectElement(CampaignAddObjectElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action {
			get {
				return CampaignConsts.CampaignLogTypeAddObject;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the MarketingEmailElement.</returns>
		public override object Clone() {
			return new CampaignAddObjectElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the MarketingEmailElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new CampaignAddObjectElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignAddObjectFlowElement {
				UserConnection = userConnection,
				EntityName = EntityName,
				ColumnValues = ColumnValues,
				TimeZoneOffset = ParentSchema.TimeZoneOffset
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}
