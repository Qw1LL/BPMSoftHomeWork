namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PartnershipPrmBaseEventListenerSchema

	/// <exclude/>
	public class PartnershipPrmBaseEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PartnershipPrmBaseEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PartnershipPrmBaseEventListenerSchema(PartnershipPrmBaseEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2ec40417-7c1e-4576-891b-39fe06427885");
			Name = "PartnershipPrmBaseEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6efc2b6b-5901-4b9d-a21e-e587e5c1977b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,193,142,218,48,16,61,179,210,254,195,40,189,128,132,146,59,5,36,160,43,186,82,183,139,128,246,82,245,96,146,33,113,149,140,35,219,161,162,85,255,189,19,155,44,9,11,187,23,75,30,191,153,247,252,102,134,68,129,166,20,49,194,124,245,180,81,123,27,46,20,237,101,90,105,97,165,162,251,187,191,247,119,189,202,72,74,97,115,52,22,139,143,47,247,115,66,81,40,186,22,215,216,173,118,3,243,105,126,227,225,129,172,180,18,205,59,207,225,195,1,201,214,40,198,125,208,152,50,21,44,114,97,204,8,86,66,91,66,109,50,89,174,116,49,23,6,29,248,139,228,191,112,220,165,68,81,4,99,83,21,133,208,199,233,233,222,0,96,175,116,187,8,112,178,180,71,64,71,25,54,217,209,69,250,216,32,138,220,40,136,53,238,39,193,91,178,67,39,202,85,237,72,11,32,170,171,253,184,242,212,223,196,25,22,226,43,247,14,38,16,180,228,5,131,159,156,83,86,187,92,198,16,215,22,188,231,0,140,224,134,0,46,196,205,231,243,197,211,39,180,153,74,106,87,29,129,127,188,116,207,5,62,11,74,114,52,141,91,143,100,80,91,76,188,109,181,107,175,109,243,145,82,104,81,0,241,207,38,129,65,74,216,135,169,83,5,254,22,142,35,7,185,158,129,193,116,155,161,115,255,228,252,118,116,195,123,39,108,182,183,168,93,249,153,78,77,237,56,72,50,86,16,239,67,172,200,10,73,245,212,217,12,27,58,247,1,72,132,21,29,37,39,199,213,1,181,150,9,194,65,201,4,158,169,249,119,95,237,126,97,220,252,97,8,215,216,1,7,80,47,91,175,183,227,126,132,173,228,38,11,7,245,34,244,122,7,161,129,169,89,149,31,201,9,244,125,193,129,71,158,81,90,166,153,53,107,76,171,92,88,30,228,9,16,254,134,141,41,61,126,221,125,238,183,138,134,223,152,156,151,151,88,54,183,126,216,38,12,207,227,119,82,116,193,19,46,181,32,251,172,83,65,242,143,219,252,53,138,196,179,117,72,86,90,214,237,95,168,188,42,232,187,200,43,28,186,122,108,104,11,181,68,187,61,150,152,180,96,227,101,37,147,105,63,152,197,177,170,200,62,38,193,192,75,249,119,154,88,54,194,15,173,187,251,104,55,200,177,255,126,55,48,135,253,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2ec40417-7c1e-4576-891b-39fe06427885"));
		}

		#endregion

	}

	#endregion

}

