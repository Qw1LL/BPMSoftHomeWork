namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: Float1ColumnProcessorSchema

	/// <exclude/>
	public class Float1ColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public Float1ColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public Float1ColumnProcessorSchema(Float1ColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7f839451-e4a5-40f4-bb65-4692bb45345c");
			Name = "Float1ColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("aaf0cd3b-b0e9-4378-a805-7163759e3c5e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,193,74,195,64,16,134,207,45,248,14,67,188,180,32,9,189,170,45,216,150,74,15,74,65,235,69,60,108,55,147,118,33,217,13,179,187,66,17,223,221,73,54,85,147,6,193,75,146,157,252,243,207,204,151,137,22,5,218,82,72,132,249,230,225,201,100,46,94,24,157,169,189,39,225,148,209,241,74,229,184,46,74,67,238,98,248,113,49,28,120,171,244,30,158,142,214,97,113,243,125,254,201,37,236,143,198,43,33,157,33,133,150,223,179,226,146,112,207,254,176,200,133,181,215,176,202,141,112,147,133,201,125,161,55,100,36,90,107,168,22,38,73,2,183,74,31,144,148,75,141,4,73,152,77,163,90,223,145,71,201,236,164,183,190,40,4,29,79,231,59,13,74,91,39,52,143,105,50,112,7,101,65,86,133,129,31,136,231,55,218,170,93,142,144,25,130,50,248,85,3,132,174,64,214,117,224,93,228,30,109,124,170,145,252,42,242,186,196,76,248,220,205,149,78,57,113,228,142,37,154,108,180,238,116,56,190,130,71,230,13,83,208,124,99,65,239,216,227,241,27,91,150,126,151,43,217,180,217,171,131,6,219,25,181,1,127,40,190,254,48,230,241,28,249,138,63,163,222,212,198,65,241,95,184,103,116,235,192,130,80,56,180,109,198,76,128,149,136,191,61,39,231,166,21,206,115,158,33,82,10,18,69,141,106,26,121,139,196,115,104,148,213,90,70,179,45,159,249,195,156,2,241,109,82,171,235,228,6,93,111,201,209,182,101,4,109,223,49,51,221,9,139,163,110,184,90,253,193,103,131,21,117,26,200,182,49,115,141,18,201,241,138,51,100,50,142,115,49,253,139,243,156,43,245,99,230,29,12,233,96,222,145,72,165,8,247,94,165,176,20,78,188,84,107,248,204,120,183,235,20,166,179,118,44,14,67,119,117,225,159,235,118,30,230,105,7,63,191,0,17,38,32,179,17,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7f839451-e4a5-40f4-bb65-4692bb45345c"));
		}

		#endregion

	}

	#endregion

}

