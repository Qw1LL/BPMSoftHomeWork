namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: Float8ColumnProcessorSchema

	/// <exclude/>
	public class Float8ColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public Float8ColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public Float8ColumnProcessorSchema(Float8ColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("841cbf68-2096-4585-a283-015e96ff338e");
			Name = "Float8ColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,193,106,227,48,16,134,207,41,244,29,134,244,146,64,177,175,165,219,4,154,148,148,28,186,4,186,217,203,210,131,34,143,83,129,45,185,163,81,33,44,125,247,29,75,201,182,118,210,66,47,182,52,254,245,207,204,167,177,85,53,250,70,105,132,217,234,225,209,149,156,205,157,45,205,54,144,98,227,108,182,48,21,46,235,198,17,159,159,253,61,63,27,4,111,236,22,30,119,158,177,254,241,127,255,126,150,240,116,52,91,40,205,142,12,122,249,46,138,11,194,173,248,195,188,82,222,95,195,162,114,138,175,230,174,10,181,93,145,211,232,189,163,40,204,243,28,110,140,125,70,50,92,56,13,154,176,156,12,163,190,39,31,230,211,131,222,135,186,86,180,59,236,111,45,24,235,89,89,105,211,149,192,207,198,131,110,19,131,44,72,250,119,214,155,77,133,80,58,130,38,249,181,13,164,170,64,199,60,240,170,170,128,62,59,228,200,63,36,249,115,135,165,10,21,207,140,45,228,224,136,119,13,186,114,180,236,85,56,190,132,159,194,27,38,96,229,37,130,147,109,143,199,79,98,217,132,77,101,244,190,204,147,58,216,99,59,162,54,144,139,146,231,59,99,105,143,41,180,252,5,245,42,26,39,197,119,225,30,209,141,129,57,161,98,244,93,198,66,64,148,136,31,61,175,142,77,91,156,199,60,83,164,81,164,234,136,106,50,12,30,73,250,176,168,219,177,28,78,215,178,151,139,57,4,178,155,60,170,227,225,61,186,147,41,71,235,142,17,116,125,199,194,116,163,60,142,250,225,118,244,7,111,123,172,104,139,68,182,139,89,114,52,72,44,35,46,144,201,177,156,197,226,43,206,51,201,244,13,204,119,138,85,26,194,68,55,88,243,34,107,83,160,101,83,26,164,79,88,202,64,167,90,192,189,34,145,232,225,62,152,34,250,253,110,237,126,137,219,122,89,192,100,218,141,101,137,96,95,151,126,224,62,134,4,167,27,124,251,7,141,48,36,163,94,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("841cbf68-2096-4585-a283-015e96ff338e"));
		}

		#endregion

	}

	#endregion

}

