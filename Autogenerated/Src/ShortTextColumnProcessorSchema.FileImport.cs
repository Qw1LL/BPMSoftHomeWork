namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ShortTextColumnProcessorSchema

	/// <exclude/>
	public class ShortTextColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ShortTextColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ShortTextColumnProcessorSchema(ShortTextColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0e75194b-c61b-4a32-9829-7c88737e87a4");
			Name = "ShortTextColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("560ff4eb-7ab5-4d8f-8733-4031e1e3144b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,193,110,219,48,12,134,207,41,208,119,32,178,75,2,12,246,189,107,2,44,41,58,228,208,33,64,154,93,134,29,20,153,78,8,216,146,75,73,197,130,161,239,62,90,138,219,57,141,7,244,98,91,244,207,159,228,39,201,168,26,93,163,52,194,98,253,176,177,165,207,150,214,148,180,15,172,60,89,147,221,83,133,171,186,177,236,175,175,254,92,95,141,130,35,179,135,205,209,121,172,191,188,174,223,114,25,47,71,179,123,165,189,101,66,39,255,69,241,137,113,47,254,176,172,148,115,55,176,57,72,133,71,252,237,151,182,10,181,89,179,213,232,156,229,168,205,243,28,110,201,28,144,201,23,86,131,102,44,103,227,11,234,113,62,239,228,46,212,181,226,99,183,254,106,128,140,243,202,200,160,182,4,127,32,7,186,45,13,242,193,66,192,26,71,187,10,161,180,12,77,242,139,131,118,125,129,142,165,224,89,85,1,93,214,149,201,255,169,243,243,14,75,21,42,191,32,83,72,238,196,31,27,180,229,100,117,214,228,244,51,124,23,232,48,3,35,47,17,12,205,62,157,254,18,215,38,236,42,210,167,102,135,164,112,3,23,225,141,100,203,228,249,70,91,198,244,28,218,157,16,232,235,104,157,20,31,100,252,14,114,12,44,25,149,71,215,71,45,20,68,137,120,178,28,26,65,124,91,170,239,177,166,72,163,88,213,145,216,108,28,28,178,76,98,80,183,71,116,60,223,202,90,246,167,11,100,183,121,84,199,228,19,190,161,170,147,109,207,11,250,214,83,225,186,83,14,39,231,225,246,38,140,94,78,108,209,20,9,111,159,181,212,104,144,189,156,120,33,205,214,75,46,22,255,131,189,144,74,31,128,125,167,188,74,199,49,49,14,134,158,228,155,10,52,158,74,66,30,192,41,167,59,245,2,246,25,153,69,15,223,2,21,209,239,71,107,247,40,110,219,85,1,179,121,63,150,189,66,60,151,166,43,125,78,34,241,233,7,95,254,2,44,5,205,63,112,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0e75194b-c61b-4a32-9829-7c88737e87a4"));
		}

		#endregion

	}

	#endregion

}

