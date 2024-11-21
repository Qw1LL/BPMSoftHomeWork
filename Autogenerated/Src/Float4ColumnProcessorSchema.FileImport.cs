namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: Float4ColumnProcessorSchema

	/// <exclude/>
	public class Float4ColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public Float4ColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public Float4ColumnProcessorSchema(Float4ColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e45599cf-db78-4a8d-b5e2-31927002be8f");
			Name = "Float4ColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("560ff4eb-7ab5-4d8f-8733-4031e1e3144b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,193,110,219,48,12,134,207,41,208,119,32,178,75,2,12,246,161,61,181,77,128,37,69,138,28,54,4,104,179,203,176,131,34,211,41,1,91,242,40,169,64,48,244,221,75,75,73,83,59,217,128,94,108,137,254,245,147,252,68,27,85,163,107,148,70,152,173,190,63,218,210,103,115,107,74,218,6,86,158,172,201,22,84,225,178,110,44,251,203,139,191,151,23,131,224,200,108,225,113,231,60,214,183,239,251,227,89,198,243,209,108,161,180,183,76,232,228,187,40,190,48,110,197,31,230,149,114,238,6,22,149,85,254,106,110,171,80,155,21,91,141,206,89,142,194,60,207,225,142,204,51,50,249,194,106,208,140,229,100,24,245,61,249,48,159,30,244,46,212,181,226,221,97,255,205,0,25,231,149,145,54,109,9,254,153,28,232,54,49,200,130,165,127,107,28,109,42,132,210,50,52,201,175,109,32,85,5,58,230,129,23,85,5,116,217,33,71,254,33,201,175,123,44,85,168,252,140,76,33,7,71,126,215,160,45,71,203,94,133,227,175,240,67,120,195,4,140,188,68,16,19,92,247,85,227,223,98,217,132,77,69,122,95,230,89,29,236,177,157,80,27,200,69,201,243,200,88,218,243,28,90,254,130,122,21,141,147,226,179,112,79,232,198,192,156,81,121,116,93,198,66,64,148,136,31,61,175,79,77,91,156,167,60,83,164,81,172,234,136,106,50,12,14,89,250,48,168,219,177,28,78,215,178,151,139,57,4,178,187,60,170,227,225,61,186,179,41,71,235,142,17,116,125,199,194,116,163,28,142,250,225,118,244,7,175,123,172,104,138,68,182,139,89,114,52,200,94,70,92,32,179,245,114,22,139,255,113,158,73,166,79,96,190,87,94,165,33,76,116,131,161,63,178,166,2,141,167,146,144,255,193,82,6,58,213,2,246,5,153,69,15,15,129,138,232,247,179,181,123,18,183,245,178,128,201,180,27,203,18,193,190,46,253,192,125,12,9,78,55,248,250,6,246,60,41,198,94,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e45599cf-db78-4a8d-b5e2-31927002be8f"));
		}

		#endregion

	}

	#endregion

}

