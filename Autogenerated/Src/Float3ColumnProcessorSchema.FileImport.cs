namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: Float3ColumnProcessorSchema

	/// <exclude/>
	public class Float3ColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public Float3ColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public Float3ColumnProcessorSchema(Float3ColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8ac9f761-d47f-4b4c-a8e7-4a1491cda0d9");
			Name = "Float3ColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("aaf0cd3b-b0e9-4378-a805-7163759e3c5e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,193,78,227,48,16,134,207,69,226,29,70,229,210,74,40,57,112,99,105,37,90,84,212,3,171,74,108,247,178,226,224,58,147,98,41,177,195,120,140,84,173,120,247,157,216,237,66,210,130,196,37,177,39,191,255,153,249,60,177,170,70,223,40,141,48,91,61,60,186,146,179,185,179,165,217,6,82,108,156,205,22,166,194,101,221,56,226,243,179,191,231,103,131,224,141,221,194,227,206,51,214,63,254,239,223,207,18,158,142,102,11,165,217,145,65,47,223,69,113,65,184,21,127,152,87,202,251,107,88,84,78,241,213,220,85,161,182,43,114,26,189,119,20,133,121,158,195,141,177,207,72,134,11,167,65,19,150,147,97,212,247,228,195,124,122,208,251,80,215,138,118,135,253,173,5,99,61,43,43,109,186,18,248,217,120,208,109,98,144,5,73,255,206,122,179,169,16,74,71,208,36,191,182,129,84,21,232,152,7,94,85,21,208,103,135,28,249,135,36,127,238,176,84,161,226,153,177,133,28,28,241,174,65,87,142,150,189,10,199,151,240,83,120,195,4,172,188,68,112,178,237,241,248,73,44,155,176,169,140,222,151,121,82,7,123,108,71,212,6,114,81,242,124,103,44,237,49,133,150,191,160,94,69,227,164,248,46,220,35,186,49,48,39,84,140,190,203,88,8,136,18,241,163,231,213,177,105,139,243,152,103,138,52,138,84,29,81,77,134,193,35,73,31,22,117,59,150,195,233,90,246,114,49,135,64,118,147,71,117,60,188,71,119,50,229,104,221,49,130,174,239,88,152,110,148,199,81,63,220,142,254,224,109,143,21,109,145,200,118,49,75,142,6,137,101,196,5,50,57,150,179,88,124,197,121,38,153,190,129,249,78,177,74,67,152,232,6,107,94,100,109,10,180,108,74,131,244,9,75,25,232,84,11,184,87,36,18,61,220,7,83,68,191,223,173,221,47,113,91,47,11,152,76,187,177,44,17,236,235,210,15,220,199,144,224,116,131,111,255,0,188,90,87,232,94,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8ac9f761-d47f-4b4c-a8e7-4a1491cda0d9"));
		}

		#endregion

	}

	#endregion

}

