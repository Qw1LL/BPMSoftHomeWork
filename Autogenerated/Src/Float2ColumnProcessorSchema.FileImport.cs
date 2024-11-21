namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: Float2ColumnProcessorSchema

	/// <exclude/>
	public class Float2ColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public Float2ColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public Float2ColumnProcessorSchema(Float2ColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("66ad8406-fee7-4774-941e-8dbeb16b8a1a");
			Name = "Float2ColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("aaf0cd3b-b0e9-4378-a805-7163759e3c5e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,193,106,227,48,16,134,207,41,244,29,134,244,146,64,177,161,199,110,19,104,82,82,114,232,18,232,102,47,75,15,138,60,78,5,182,228,142,70,133,176,244,221,119,44,37,219,218,73,11,189,216,210,248,215,63,51,159,198,86,213,232,27,165,17,102,171,135,71,87,114,54,119,182,52,219,64,138,141,179,217,194,84,184,172,27,71,124,126,246,247,252,108,16,188,177,91,120,220,121,198,250,199,255,253,251,89,194,211,209,108,161,52,59,50,232,229,187,40,46,8,183,226,15,243,74,121,127,13,139,202,41,190,154,187,42,212,118,69,78,163,247,142,162,48,207,115,184,49,246,25,201,112,225,52,104,194,114,50,140,250,158,124,152,79,15,122,31,234,90,209,238,176,191,181,96,172,103,101,165,77,87,2,63,27,15,186,77,12,178,32,233,223,89,111,54,21,66,233,8,154,228,215,54,144,170,2,29,243,192,171,170,2,250,236,144,35,255,144,228,207,29,150,42,84,60,51,182,144,131,35,222,53,232,202,209,178,87,225,248,18,126,10,111,152,128,149,151,8,78,182,61,30,63,137,101,19,54,149,209,251,50,79,234,96,143,237,136,218,64,46,74,158,239,140,165,61,166,208,242,23,212,171,104,156,20,223,133,123,68,55,6,230,132,138,209,119,25,11,1,81,34,126,244,188,58,54,109,113,30,243,76,145,70,145,170,35,170,201,48,120,36,233,195,162,110,199,114,56,93,203,94,46,230,16,200,110,242,168,142,135,247,232,78,166,28,173,59,70,208,245,29,11,211,141,242,56,234,135,219,209,31,188,237,177,162,45,18,217,46,102,201,209,32,177,140,184,64,38,199,114,22,139,175,56,207,36,211,55,48,223,41,86,105,8,19,221,96,205,139,172,77,129,150,77,105,144,62,97,41,3,157,106,1,247,138,68,162,135,251,96,138,232,247,187,181,251,37,110,235,101,1,147,105,55,150,37,130,125,93,250,129,251,24,18,156,110,240,237,31,66,8,217,177,94,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("66ad8406-fee7-4774-941e-8dbeb16b8a1a"));
		}

		#endregion

	}

	#endregion

}

