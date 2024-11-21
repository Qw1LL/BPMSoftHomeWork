namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FolderConstsSchema

	/// <exclude/>
	public class FolderConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FolderConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FolderConstsSchema(FolderConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("76859cd8-136b-4004-a6d6-9dceeb8425ee");
			Name = "FolderConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,208,91,107,131,48,20,7,240,103,5,191,195,161,125,89,31,82,147,57,59,101,23,168,81,199,30,10,133,238,11,164,154,150,128,38,98,148,77,70,191,251,212,218,203,38,131,177,60,157,220,206,255,199,169,181,144,123,216,52,186,226,249,131,101,90,166,100,57,215,5,75,56,4,235,213,70,237,170,57,85,114,39,246,117,201,42,161,36,88,230,103,247,204,176,109,27,30,117,157,231,172,108,158,135,253,116,88,231,226,186,134,239,231,163,135,211,249,169,171,125,213,182,168,183,153,72,64,87,109,122,2,73,198,180,134,88,101,41,47,91,150,174,116,235,49,90,144,49,242,156,64,67,4,160,11,36,66,57,19,89,23,55,206,251,17,88,114,150,42,153,53,240,82,139,20,162,238,223,49,253,173,41,248,107,10,79,32,249,123,127,121,51,9,252,251,165,235,57,11,68,104,136,81,68,8,65,62,166,11,132,49,113,221,16,187,119,20,59,147,89,63,228,63,115,47,3,58,86,255,64,175,90,243,86,125,252,202,246,125,122,235,184,132,162,24,199,222,192,14,131,229,153,77,60,76,122,182,113,176,204,195,23,224,45,115,118,48,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("76859cd8-136b-4004-a6d6-9dceeb8425ee"));
		}

		#endregion

	}

	#endregion

}

