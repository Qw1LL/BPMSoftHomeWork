namespace BPMSoft.Configuration
{

	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.PRM;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: Lead_PRMPortalEventsProcess

	public partial class Lead_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void PartnerGrantRight() {
			Guid partnerId =Entity.GetTypedColumnValue<Guid>("PartnerId");
			PRMUtility utility = new PRMUtility(UserConnection);
			Guid recordId = Entity.GetTypedColumnValue<Guid>("Id");
			Guid partnershipRoleId = utility.GetPartnershipRoleByAccount(partnerId);
			if(partnershipRoleId != Guid.Empty) {
				RightsManagerHelper rightsHelper = new RightsManagerHelper(UserConnection, Entity.SchemaName);
				RightsParams param = new RightsParams(recordId, PRMBaseConstants.SysEntitySchemaRecRightSourceLeadPartnerOwner);
				param.SysAdminUnitId = partnershipRoleId;
				param.OperationsRights = new Dictionary<EntitySchemaRecordRightLevel, List<EntitySchemaRecordRightOperation>> { {
								EntitySchemaRecordRightLevel.Allow,
									new List<EntitySchemaRecordRightOperation> {
										EntitySchemaRecordRightOperation.Read,
										EntitySchemaRecordRightOperation.Edit,
										EntitySchemaRecordRightOperation.Delete
									}
								}
							};
				rightsHelper.GrantRightsForRecord(param);
			}
		}

		#endregion

	}

	#endregion

}

