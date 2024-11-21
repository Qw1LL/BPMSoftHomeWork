namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OpportunityConstantsSchema

	/// <exclude/>
	public class OpportunityConstantsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OpportunityConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OpportunityConstantsSchema(OpportunityConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ff91c21e-dcda-4052-875f-3134d07a6a12");
			Name = "OpportunityConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5ef32b22-5119-483b-953d-678c3fffad13");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,146,77,75,196,48,16,134,207,91,232,127,8,123,210,67,182,105,218,100,27,252,0,173,86,4,69,113,15,158,211,124,44,149,54,41,77,138,20,241,191,27,119,69,220,189,184,135,133,48,132,153,119,222,121,24,102,116,141,89,131,213,228,188,234,206,226,40,142,12,239,148,235,185,80,224,250,249,113,101,181,95,148,214,232,102,61,14,220,55,214,196,209,71,28,205,250,177,110,27,1,156,15,57,1,68,203,157,3,79,125,111,7,63,154,198,79,161,35,148,140,119,65,250,45,159,37,73,2,206,221,216,117,124,152,46,183,9,80,182,214,41,9,6,245,166,132,15,159,208,177,86,139,95,117,242,87,190,59,111,80,92,90,211,78,224,110,108,228,206,220,141,229,203,143,227,189,4,23,192,168,247,141,236,100,190,204,104,69,242,234,6,222,226,28,193,156,86,5,44,202,101,9,25,162,180,204,208,85,85,17,54,63,221,236,224,31,224,193,142,71,6,222,58,238,1,51,94,107,156,103,2,106,129,2,48,17,26,22,10,23,80,200,154,82,193,48,42,106,116,8,240,187,53,199,99,125,181,102,15,147,34,73,178,20,9,72,106,69,161,212,105,10,217,50,173,33,66,169,164,72,177,172,16,244,16,204,16,253,241,56,31,130,219,30,40,103,156,107,169,21,196,56,199,48,215,33,20,66,18,136,185,202,106,70,8,149,203,237,1,204,62,227,40,188,47,249,138,16,41,27,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ff91c21e-dcda-4052-875f-3134d07a6a12"));
		}

		#endregion

	}

	#endregion

}

