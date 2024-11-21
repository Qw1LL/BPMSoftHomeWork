namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LongTextColumnProcessorSchema

	/// <exclude/>
	public class LongTextColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LongTextColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LongTextColumnProcessorSchema(LongTextColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9c7c9656-e810-4ae6-bd3f-7aa194ca6b08");
			Name = "LongTextColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("560ff4eb-7ab5-4d8f-8733-4031e1e3144b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,65,75,235,64,16,199,207,21,252,14,67,223,165,5,73,238,106,11,182,162,20,84,10,218,119,17,15,219,205,164,46,36,187,113,118,86,44,15,191,251,155,100,27,53,181,17,188,36,217,201,127,254,51,243,219,93,171,74,244,149,210,8,179,229,237,189,203,57,153,59,155,155,77,32,197,198,217,228,202,20,184,40,43,71,124,124,244,239,248,104,16,188,177,27,184,223,122,198,242,236,99,253,153,75,120,56,154,92,41,205,142,12,122,249,47,138,63,132,27,241,135,121,161,188,63,133,27,103,55,15,248,198,115,87,132,210,46,201,105,244,222,81,35,77,211,20,206,141,125,70,50,156,57,13,154,48,159,12,15,168,135,233,180,149,251,80,150,138,182,237,250,194,130,177,158,149,149,57,93,14,252,108,60,232,186,50,200,7,9,0,103,189,89,23,8,185,35,168,162,95,61,65,219,22,232,166,18,188,170,34,160,79,218,42,233,151,50,143,151,152,171,80,240,204,216,76,82,71,188,173,208,229,163,197,94,143,227,19,184,19,228,48,1,43,47,17,244,76,62,30,63,137,105,21,214,133,209,187,86,123,148,112,10,7,201,13,100,187,228,249,73,90,102,100,10,245,46,8,240,101,227,28,21,191,4,252,141,112,19,152,19,42,70,223,229,44,12,68,137,184,179,236,153,64,108,107,164,223,153,198,72,165,72,149,13,174,201,48,120,36,25,196,162,174,79,231,112,186,146,181,108,78,27,72,206,211,70,221,36,239,224,245,20,29,173,58,86,208,117,30,11,213,181,242,56,218,15,215,119,96,240,190,35,139,54,139,112,187,164,165,70,133,196,114,214,133,51,57,150,92,204,126,66,61,147,74,191,64,125,169,88,197,163,24,9,7,107,94,228,219,100,104,217,228,6,169,135,166,28,236,216,11,184,87,36,18,61,92,7,147,53,126,127,107,187,7,113,91,45,50,152,76,187,177,164,101,184,175,140,119,121,31,68,196,211,13,190,255,7,167,218,198,197,105,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9c7c9656-e810-4ae6-bd3f-7aa194ca6b08"));
		}

		#endregion

	}

	#endregion

}

