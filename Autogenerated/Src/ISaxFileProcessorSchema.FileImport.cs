namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISaxFileProcessorSchema

	/// <exclude/>
	public class ISaxFileProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISaxFileProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISaxFileProcessorSchema(ISaxFileProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6c7807a8-a16e-4cad-b5b6-7f795f2cb0e0");
			Name = "ISaxFileProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,83,77,79,220,48,16,61,47,18,255,97,4,23,122,217,220,33,228,80,68,183,145,138,180,34,42,119,175,61,217,88,141,199,145,61,166,187,170,248,239,181,29,178,176,219,22,42,144,184,197,163,247,102,222,135,66,194,160,31,132,68,248,188,188,105,108,203,243,43,75,173,94,7,39,88,91,154,127,209,61,214,102,176,142,143,143,126,29,31,205,130,215,180,134,102,235,25,205,197,193,59,82,251,30,101,226,249,249,2,9,157,150,17,19,81,167,14,215,113,10,53,49,186,54,94,59,135,186,17,155,180,124,233,172,68,239,173,203,192,33,172,122,45,65,79,184,191,193,102,73,199,110,229,13,114,103,149,63,135,101,166,230,45,179,162,40,160,244,193,24,225,182,213,52,120,92,129,30,214,250,30,9,122,237,25,58,20,10,157,159,239,88,197,33,173,28,132,19,6,40,6,117,121,162,115,20,203,52,193,40,209,215,234,164,170,73,225,6,226,94,159,2,43,139,140,127,162,59,228,224,200,87,223,158,159,43,139,105,156,112,245,53,5,131,78,172,122,44,199,176,99,146,193,80,5,11,228,175,35,229,108,17,180,130,63,239,127,186,120,193,242,85,135,242,7,112,39,24,218,24,34,72,75,44,52,249,73,7,8,82,224,236,207,119,249,255,167,227,125,147,247,54,234,207,130,106,159,26,189,19,189,86,111,114,245,88,228,243,26,145,88,179,142,213,182,206,26,192,141,196,254,163,42,157,78,191,218,233,117,2,110,43,184,141,217,231,239,72,122,147,255,6,25,194,16,123,179,12,94,118,104,4,172,182,160,213,255,58,78,196,38,243,190,31,246,151,75,170,73,243,237,14,51,74,220,227,76,234,78,145,212,248,27,230,247,195,248,175,239,13,31,126,3,82,145,75,69,97,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6c7807a8-a16e-4cad-b5b6-7f795f2cb0e0"));
		}

		#endregion

	}

	#endregion

}

