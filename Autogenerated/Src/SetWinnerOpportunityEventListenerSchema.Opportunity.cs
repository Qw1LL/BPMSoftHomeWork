namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SetWinnerOpportunityEventListenerSchema

	/// <exclude/>
	public class SetWinnerOpportunityEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SetWinnerOpportunityEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SetWinnerOpportunityEventListenerSchema(SetWinnerOpportunityEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("231522b7-74cb-4b33-902e-c806990f6c39");
			Name = "SetWinnerOpportunityEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5ef32b22-5119-483b-953d-678c3fffad13");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,193,110,219,48,12,61,187,64,255,129,240,46,54,80,200,247,54,41,176,116,221,118,88,155,2,198,208,67,177,131,98,51,137,6,91,50,40,217,67,48,244,223,71,73,118,144,116,105,122,177,45,146,79,124,124,143,214,178,69,219,201,10,97,241,244,80,154,181,19,119,70,175,213,166,39,233,148,209,151,23,127,47,47,146,222,42,189,57,40,32,20,247,218,41,167,208,222,156,79,139,251,1,181,243,85,92,247,137,112,195,119,194,93,35,173,189,134,18,221,179,210,26,105,217,117,134,92,175,149,219,133,242,31,202,58,228,120,0,21,69,1,51,219,183,173,164,221,237,120,254,46,117,221,32,193,218,16,28,128,129,177,225,21,122,138,9,92,188,65,207,44,162,108,172,129,138,112,61,79,207,241,22,11,105,49,196,142,153,165,80,248,219,94,78,164,178,178,218,98,43,31,89,87,152,67,122,64,47,205,127,49,166,235,87,141,170,160,242,26,124,44,1,92,195,59,20,248,42,182,134,159,123,89,31,208,109,77,205,194,62,145,113,88,57,172,99,190,155,142,48,40,238,33,27,24,140,170,125,239,131,174,145,70,22,27,141,66,230,224,205,79,146,65,18,216,19,213,203,14,227,150,240,160,65,189,175,178,114,134,188,124,193,226,120,220,137,111,232,102,229,57,252,109,22,250,36,137,198,63,255,221,100,180,117,212,251,227,103,218,244,45,83,203,210,222,34,113,66,243,88,12,79,175,70,194,226,231,81,60,207,253,118,38,201,89,238,226,139,217,127,103,227,220,1,246,58,170,139,186,142,2,191,167,118,239,13,141,201,176,94,74,111,145,148,171,77,21,183,100,178,220,12,72,164,106,140,242,47,117,41,7,254,111,50,179,250,205,116,89,96,93,35,93,65,116,96,129,188,219,24,12,231,169,45,224,228,197,138,183,65,236,177,19,8,199,73,189,83,227,79,48,135,209,204,60,22,197,130,147,166,127,60,117,140,30,7,95,255,1,129,195,47,207,59,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("231522b7-74cb-4b33-902e-c806990f6c39"));
		}

		#endregion

	}

	#endregion

}

