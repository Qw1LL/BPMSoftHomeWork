namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileImportHeadersProcessorSchema

	/// <exclude/>
	public class IFileImportHeadersProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileImportHeadersProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileImportHeadersProcessorSchema(IFileImportHeadersProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f6a6f9f3-e056-43f4-b54a-65bfa522f74f");
			Name = "IFileImportHeadersProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,81,75,106,195,48,16,93,39,144,59,12,222,180,133,98,29,160,142,23,13,105,155,69,161,16,232,94,81,70,137,64,31,51,35,21,66,233,221,43,203,78,28,104,3,2,97,205,155,247,179,151,14,185,147,10,225,249,227,125,27,116,172,87,193,107,115,72,36,163,9,190,126,49,22,55,174,11,20,225,123,49,159,37,54,254,0,219,19,71,116,25,105,45,170,30,198,245,43,122,36,163,158,46,152,137,142,176,94,251,104,162,65,238,199,249,116,105,103,141,2,227,35,146,238,181,55,147,204,27,202,61,18,175,8,101,12,84,68,103,32,132,128,134,147,115,146,78,237,229,165,96,144,193,12,254,84,176,201,121,6,157,215,58,10,10,153,113,15,199,194,119,199,240,37,109,66,174,39,62,241,135,176,233,36,73,7,62,119,178,172,40,132,184,85,71,116,178,106,27,70,4,69,168,151,85,137,114,26,7,162,229,144,40,7,224,242,93,164,85,113,117,118,83,55,162,144,222,16,81,5,245,89,172,85,237,112,131,166,224,64,231,70,254,89,38,140,137,60,183,83,247,16,116,238,230,226,111,104,49,143,51,111,246,215,136,243,70,207,177,89,251,228,144,228,206,98,115,13,108,199,46,135,242,135,55,190,191,142,10,83,29,143,61,211,77,170,146,161,29,227,15,129,30,250,223,254,179,152,231,243,11,134,137,113,225,111,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f6a6f9f3-e056-43f4-b54a-65bfa522f74f"));
		}

		#endregion

	}

	#endregion

}

