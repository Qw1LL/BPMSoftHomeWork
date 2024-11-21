namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFolderManagerServiceSchema

	/// <exclude/>
	public class IFolderManagerServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFolderManagerServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFolderManagerServiceSchema(IFolderManagerServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c540fd1a-0f99-4be3-b6a9-232ced714c13");
			Name = "IFolderManagerService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("be1f674b-cdb4-46e4-8c46-23cae20b9205");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,84,93,75,236,48,16,125,174,224,127,8,235,203,10,75,127,128,226,139,31,87,42,84,23,171,248,176,248,16,147,233,26,76,147,58,73,87,138,248,223,157,52,109,215,85,87,184,224,133,11,125,153,153,204,153,147,115,58,49,188,2,87,115,1,236,120,158,23,182,244,233,137,53,165,90,54,200,189,178,38,253,99,181,4,204,185,225,75,192,2,112,165,4,236,238,188,238,238,36,141,83,102,201,138,214,121,168,14,63,197,4,162,53,136,128,224,210,115,48,128,74,124,57,211,163,229,86,130,254,177,152,222,193,3,29,160,35,123,8,75,194,100,153,241,128,37,177,62,96,217,247,12,19,250,22,125,68,55,242,200,133,159,94,210,101,217,17,155,124,215,50,217,191,167,150,186,121,208,74,48,53,224,111,133,15,10,140,116,114,240,143,86,186,3,54,239,218,59,170,201,226,170,134,40,226,48,63,12,72,22,116,153,204,172,236,19,76,99,91,32,52,191,42,110,38,51,118,139,234,6,170,90,115,223,209,164,190,21,160,143,12,168,124,108,101,91,248,86,135,34,161,228,224,28,145,26,179,233,29,242,186,6,57,99,97,78,114,13,207,13,56,234,198,138,251,141,142,152,74,47,156,53,51,118,77,246,147,75,240,243,185,78,156,100,101,149,100,27,172,166,231,13,165,12,188,196,48,163,225,93,166,230,8,198,175,147,206,99,48,151,114,202,183,133,120,132,138,7,51,246,15,127,75,171,204,8,221,72,56,11,3,20,184,204,252,173,106,189,92,179,127,165,221,198,90,245,255,209,208,207,182,176,159,246,178,57,219,160,128,181,108,163,158,146,72,42,19,33,215,213,238,10,27,138,211,58,54,149,9,197,1,186,27,213,246,110,149,159,125,42,149,166,5,112,145,243,239,153,116,10,26,60,73,243,127,57,243,145,213,232,200,199,228,118,27,130,122,139,123,134,32,44,74,55,8,181,7,70,198,151,129,162,183,248,112,141,41,90,206,183,119,131,131,152,52,117,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c540fd1a-0f99-4be3-b6a9-232ced714c13"));
		}

		#endregion

	}

	#endregion

}

