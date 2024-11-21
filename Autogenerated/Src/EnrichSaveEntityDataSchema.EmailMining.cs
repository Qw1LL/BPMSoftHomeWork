namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EnrichSaveEntityDataSchema

	/// <exclude/>
	public class EnrichSaveEntityDataSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EnrichSaveEntityDataSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EnrichSaveEntityDataSchema(EnrichSaveEntityDataSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8a0b8b3a-216a-4b0e-a0df-953fd0dac922");
			Name = "EnrichSaveEntityData";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c9ff5cbb-cb0e-4041-b483-395260757ab0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,147,77,111,194,48,12,134,207,69,218,127,176,224,178,73,19,189,51,224,48,64,211,52,177,161,85,218,5,113,8,169,129,104,77,130,146,20,209,77,251,239,115,146,130,6,251,18,92,170,216,126,237,60,182,83,197,36,218,53,227,8,183,147,113,166,23,174,61,208,106,33,150,165,97,78,104,117,209,120,191,104,36,165,21,106,9,89,101,29,74,138,23,5,114,31,180,237,59,84,104,4,191,57,214,60,151,202,9,137,237,140,162,172,16,111,161,22,169,72,215,50,184,36,3,6,5,179,182,3,35,69,249,171,140,109,112,68,41,174,26,50,199,130,46,77,83,232,218,82,74,102,170,126,109,79,140,222,136,28,45,228,164,2,174,149,99,220,193,218,232,53,221,227,200,63,23,42,247,24,11,109,0,67,101,204,233,64,133,5,69,45,219,80,176,189,43,158,126,169,62,245,247,82,231,206,80,197,25,57,214,229,188,16,28,184,167,252,5,50,161,209,208,119,223,209,36,112,248,155,58,48,9,233,49,126,220,73,237,64,4,110,112,209,107,198,154,25,177,74,54,218,58,84,150,170,69,179,153,246,65,209,134,60,243,119,232,72,61,70,57,71,115,249,72,50,232,65,51,116,91,121,171,121,229,27,217,117,98,157,241,147,137,151,5,177,223,108,146,44,209,249,245,37,137,173,15,31,127,80,223,211,114,235,49,130,54,57,154,19,192,130,254,144,73,40,7,79,222,125,54,11,215,69,41,21,108,88,81,162,61,1,38,38,28,210,12,69,120,213,148,214,141,195,186,174,135,214,135,151,32,63,135,114,180,21,214,249,113,209,251,148,244,4,145,25,190,170,177,79,1,126,197,138,126,60,159,244,211,90,167,51,120,216,11,254,193,108,161,202,227,139,13,118,244,30,58,201,247,9,236,84,81,157,24,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8a0b8b3a-216a-4b0e-a0df-953fd0dac922"));
		}

		#endregion

	}

	#endregion

}

