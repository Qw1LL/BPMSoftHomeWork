namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CtiRightsServiceSchema

	/// <exclude/>
	public class CtiRightsServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CtiRightsServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CtiRightsServiceSchema(CtiRightsServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a6c64027-2137-42ca-b41d-24afcb039a7e");
			Name = "CtiRightsService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c124cf91-dc7b-4db8-b77e-ff0b639610dd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,111,219,48,12,61,171,64,255,131,218,67,145,0,134,127,192,190,128,36,192,218,12,205,82,196,27,122,8,122,80,108,58,17,34,75,158,72,7,48,134,253,247,81,182,227,184,89,145,238,66,65,228,227,227,123,18,173,42,0,75,149,130,156,62,45,18,151,83,60,115,54,215,219,202,43,210,206,94,95,253,190,190,18,21,106,187,149,73,141,4,5,215,141,129,52,20,49,190,7,11,94,167,31,207,49,9,248,131,78,97,225,50,48,23,139,241,51,108,46,3,38,60,234,208,104,249,7,199,189,140,69,228,90,66,138,224,4,56,122,9,136,153,43,138,166,153,171,235,142,154,61,146,87,41,189,132,220,4,203,239,64,12,43,121,204,70,27,77,245,10,126,85,218,67,1,150,112,52,188,4,77,242,179,124,167,37,160,226,46,145,141,195,144,178,218,24,157,202,212,40,68,57,35,189,210,219,29,97,167,230,131,156,42,132,238,18,201,249,10,84,182,180,166,30,122,99,14,254,9,142,98,189,44,161,253,156,161,11,177,102,175,115,123,112,123,24,45,128,118,46,99,153,183,79,203,228,199,109,36,167,46,171,19,170,77,144,206,176,5,243,170,45,244,217,248,217,171,178,132,44,10,60,34,232,6,164,175,206,23,138,94,53,180,169,248,27,58,27,201,21,175,13,175,0,92,198,53,230,143,238,55,206,25,121,15,244,19,193,63,40,236,125,60,178,109,102,26,61,106,164,79,72,158,127,240,139,116,199,42,70,109,163,198,137,173,251,158,177,12,139,41,196,65,121,233,59,41,44,130,124,213,172,129,16,185,243,160,210,157,28,5,68,79,38,181,29,48,31,73,68,51,32,221,65,186,103,45,115,155,59,166,10,42,249,133,109,187,235,49,23,30,192,112,43,47,61,189,165,190,167,29,183,2,132,206,229,232,230,21,233,221,157,188,121,219,134,16,3,19,185,50,216,185,96,105,108,99,223,93,254,200,19,243,57,241,127,240,158,30,231,140,182,57,218,232,129,42,111,251,39,109,16,92,225,163,137,28,254,2,101,119,254,139,50,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a6c64027-2137-42ca-b41d-24afcb039a7e"));
		}

		#endregion

	}

	#endregion

}

