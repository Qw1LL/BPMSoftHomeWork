namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FileImporterConstantsSchema

	/// <exclude/>
	public class FileImporterConstantsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FileImporterConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FileImporterConstantsSchema(FileImporterConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1dc2dd32-8b13-47cd-be30-3ed1dbba2572");
			Name = "FileImporterConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("79cdeed7-eef0-4dd8-9765-07d140cf1035");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,144,193,10,131,48,12,134,207,10,190,67,97,119,113,135,93,28,187,172,48,216,65,112,248,4,157,70,87,168,173,180,41,76,134,239,190,172,50,196,193,6,187,52,244,207,255,127,9,209,162,7,55,136,26,216,177,44,42,211,98,202,141,110,101,231,173,64,105,116,122,146,10,206,253,96,44,38,241,35,137,35,239,164,238,88,53,58,132,126,159,196,164,108,44,116,228,100,92,9,231,114,182,4,192,18,202,161,208,232,130,113,240,87,37,107,70,10,82,169,95,246,111,238,136,70,209,187,176,223,173,156,149,129,50,183,215,68,169,145,21,226,126,241,96,71,226,18,209,113,227,73,60,176,93,150,209,178,191,2,165,176,116,137,255,50,252,38,85,243,49,105,27,82,97,119,208,205,188,126,248,79,243,177,86,226,244,4,155,212,121,243,126,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1dc2dd32-8b13-47cd-be30-3ed1dbba2572"));
		}

		#endregion

	}

	#endregion

}

