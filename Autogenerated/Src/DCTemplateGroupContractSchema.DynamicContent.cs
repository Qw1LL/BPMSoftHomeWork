namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DCTemplateGroupContractSchema

	/// <exclude/>
	public class DCTemplateGroupContractSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DCTemplateGroupContractSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DCTemplateGroupContractSchema(DCTemplateGroupContractSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2a052ae9-b9e1-450f-b270-7e2a8392c61d");
			Name = "DCTemplateGroupContract";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e81fdc99-2bd3-4785-b2cd-a2accfc6f9a3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,84,193,110,218,64,16,61,19,41,255,48,37,23,144,42,251,78,98,34,5,164,136,3,45,10,237,41,234,97,241,142,97,43,123,237,236,206,150,184,81,254,189,179,107,12,14,5,5,31,188,222,241,204,155,247,102,159,173,69,129,182,18,41,194,195,98,190,44,51,138,38,165,206,212,218,25,65,170,212,209,180,214,162,80,41,7,9,53,69,83,65,194,63,27,145,210,245,213,219,245,85,207,89,165,215,176,172,45,97,113,123,180,143,158,156,38,85,96,180,68,163,68,174,254,6,204,67,214,69,45,231,165,196,220,114,17,151,221,24,92,115,10,76,114,97,237,8,166,147,31,88,84,185,32,124,52,165,171,14,196,56,53,142,99,184,179,174,40,132,169,199,187,125,40,3,42,193,96,101,208,50,58,72,22,4,233,174,16,178,210,112,17,34,164,6,179,164,127,132,223,143,199,192,53,138,234,168,109,16,119,58,60,119,135,243,139,3,149,91,229,42,133,52,116,61,203,181,199,83,228,251,94,219,194,148,21,26,82,200,2,23,1,161,121,127,44,40,4,126,106,245,226,16,148,244,188,50,133,198,51,251,159,90,195,109,142,197,10,141,103,214,82,123,116,74,194,76,194,27,172,145,110,193,250,219,251,5,237,180,196,87,216,42,218,40,13,180,65,160,157,180,207,187,15,102,246,9,95,156,50,40,33,1,50,14,135,93,66,138,143,100,22,208,79,80,186,65,45,155,33,125,156,216,28,105,83,202,75,198,245,253,15,26,195,195,178,128,175,21,167,42,242,103,207,65,242,118,100,99,156,63,252,96,67,239,0,170,171,131,206,73,83,109,65,187,60,247,0,126,61,51,133,16,169,132,17,5,176,193,49,233,183,182,235,143,219,78,7,39,150,171,223,200,203,118,163,210,77,203,17,101,116,23,7,128,113,103,100,150,248,179,73,15,130,188,123,4,177,145,79,9,24,156,177,225,190,241,16,146,0,222,219,51,249,146,4,81,33,216,187,7,141,219,147,200,224,127,6,254,98,59,37,123,184,200,239,18,144,152,9,151,211,192,251,109,8,247,193,119,209,55,220,250,117,48,132,81,55,255,107,139,19,108,208,133,242,129,230,37,27,194,47,163,192,172,249,53,28,187,163,241,204,199,224,251,63,253,212,11,176,238,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2a052ae9-b9e1-450f-b270-7e2a8392c61d"));
		}

		#endregion

	}

	#endregion

}

