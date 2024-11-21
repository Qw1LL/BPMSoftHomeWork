namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileProcessorSchema

	/// <exclude/>
	public class IFileProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileProcessorSchema(IFileProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4e8d1b4d-9296-459a-b005-ca3460aef8ac");
			Name = "IFileProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("79cdeed7-eef0-4dd8-9765-07d140cf1035");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,193,74,195,64,16,61,183,208,127,24,218,75,5,73,238,109,13,168,160,230,80,12,22,241,188,73,38,233,72,179,27,119,39,149,34,254,187,179,219,164,80,69,208,203,194,123,243,230,237,204,219,213,170,65,215,170,2,225,38,91,111,76,197,209,173,209,21,213,157,85,76,70,71,119,180,195,180,105,141,229,201,248,99,50,30,117,142,116,13,155,131,99,108,150,39,60,244,190,96,30,61,48,183,209,117,238,216,170,194,91,56,145,137,112,102,177,22,4,169,102,180,149,92,184,128,212,155,103,214,20,232,156,177,65,213,118,249,142,10,160,65,244,67,51,146,33,228,60,217,173,145,183,166,116,11,200,66,231,177,24,199,49,172,92,215,52,202,30,146,129,232,77,208,65,77,123,212,80,137,113,116,82,199,223,229,171,86,89,213,128,150,124,174,166,94,59,77,252,40,209,42,14,133,160,219,27,42,7,95,95,156,251,221,51,35,217,148,30,134,43,46,150,255,152,201,228,175,88,240,37,20,18,27,149,104,125,182,196,30,178,34,237,160,84,172,192,84,128,154,137,15,224,138,45,54,106,48,123,39,222,66,167,233,173,67,144,102,145,84,132,182,95,196,98,213,239,98,141,225,77,104,124,78,203,105,156,252,53,131,243,190,228,73,96,63,0,8,241,107,46,143,97,165,249,125,39,212,153,197,16,204,12,117,121,124,204,128,63,143,191,229,140,20,238,11,186,69,227,157,168,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4e8d1b4d-9296-459a-b005-ca3460aef8ac"));
		}

		#endregion

	}

	#endregion

}

