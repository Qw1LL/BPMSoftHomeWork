namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CmpgnPrtcpntEmailTargetOp

	/// <exclude/>
	public class CmpgnPrtcpntEmailTargetOp : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CmpgnPrtcpntEmailTargetOp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CmpgnPrtcpntEmailTargetOp";
		}

		public CmpgnPrtcpntEmailTargetOp(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CmpgnPrtcpntEmailTargetOp";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// MandrillRecipientUId.
		/// </summary>
		public Guid MandrillRecipientUId {
			get {
				return GetTypedColumnValue<Guid>("MandrillRecipientUId");
			}
			set {
				SetColumnValue("MandrillRecipientUId", value);
			}
		}

		public Guid CampaignParticipantId {
			get {
				return GetTypedColumnValue<Guid>("CampaignParticipantId");
			}
			set {
				SetColumnValue("CampaignParticipantId", value);
			}
		}

		/// <summary>
		/// BulkEmailId.
		/// </summary>
		public Guid BulkEmailId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailId");
			}
			set {
				SetColumnValue("BulkEmailId", value);
			}
		}

		#endregion

	}

	#endregion

}

