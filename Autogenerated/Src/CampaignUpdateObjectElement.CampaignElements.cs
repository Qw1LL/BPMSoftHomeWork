namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Process;

	#region Class: CampaignUpdateObjectElement

	/// <summary>
	/// Campaign schema element to update existing objects
	/// for selected entity schema name with specified column values.
	/// </summary>
	public class CampaignUpdateObjectElement : CampaignBaseCrudObjectElement
	{

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="CampaignUpdateObjectElement"/>.
		/// </summary>
		public CampaignUpdateObjectElement() {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignUpdateObjectElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignUpdateObjectElement"/>.</param>
		public CampaignUpdateObjectElement(CampaignUpdateObjectElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignUpdateObjectElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignUpdateObjectElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignUpdateObjectElement(CampaignUpdateObjectElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action {
			get {
				return CampaignConsts.CampaignLogTypeUpdateObject;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the MarketingEmailElement.</returns>
		public override object Clone() {
			return new CampaignUpdateObjectElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the MarketingEmailElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new CampaignUpdateObjectElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignUpdateObjectFlowElement {
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
