namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IPortalMessageFileReaderSchema

	/// <exclude/>
	public class IPortalMessageFileReaderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IPortalMessageFileReaderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IPortalMessageFileReaderSchema(IPortalMessageFileReaderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("036d92f0-de76-43ba-9d4d-3a87133b254f");
			Name = "IPortalMessageFileReader";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c85d2d65-6230-4aeb-9934-bfac9785d42f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,148,77,79,227,48,16,134,207,32,241,31,70,112,1,105,149,222,129,229,64,187,84,145,182,180,162,136,11,218,131,27,79,130,181,142,29,249,3,41,32,254,251,218,78,90,66,226,160,236,37,145,61,243,62,51,30,143,71,144,18,117,69,50,132,219,205,106,43,115,147,204,165,200,89,97,21,49,76,138,147,227,247,147,227,35,171,153,40,96,91,107,131,229,85,111,237,252,57,199,204,59,235,100,137,2,21,203,6,62,15,86,24,86,98,178,117,86,194,217,91,96,127,122,237,67,223,91,230,93,94,89,134,43,73,145,39,11,98,136,203,199,40,146,25,231,238,4,103,10,11,167,5,152,115,162,245,37,108,164,50,132,175,80,107,82,224,29,227,184,120,92,7,199,231,174,246,143,219,168,236,142,179,12,50,175,27,145,29,249,195,30,66,108,148,172,80,25,134,62,76,16,7,112,67,94,97,185,67,117,126,239,202,7,63,225,52,165,167,23,62,200,62,202,210,50,10,41,133,119,40,208,92,129,246,159,143,113,249,92,33,49,72,111,235,8,229,96,251,79,216,90,124,133,105,163,124,173,15,214,169,56,255,143,146,130,195,68,200,150,189,245,32,76,24,240,187,147,211,144,6,117,60,15,111,153,138,121,172,171,94,34,191,165,252,107,43,215,197,182,20,224,205,83,81,79,168,180,235,147,225,177,90,67,140,115,134,130,54,237,229,86,205,94,119,43,210,224,221,244,130,195,108,54,131,107,109,203,146,168,250,166,93,7,95,48,47,196,128,194,74,161,70,151,6,15,74,200,130,52,217,43,103,29,233,247,111,228,107,228,230,109,196,234,64,153,174,56,169,159,8,183,241,70,89,116,28,250,69,137,35,43,197,124,142,105,233,94,231,56,119,211,247,154,6,127,29,2,195,67,139,35,190,189,164,84,24,84,185,155,158,151,144,14,70,202,3,18,138,106,244,206,210,189,22,114,169,124,80,227,207,84,5,10,184,161,236,49,144,59,14,80,119,134,232,253,125,246,92,75,26,75,2,194,229,165,191,132,45,81,145,29,199,235,216,0,188,129,37,154,129,65,159,183,229,110,82,107,45,41,253,1,158,237,12,235,42,12,127,215,121,221,229,133,31,239,177,226,125,252,3,178,247,104,147,115,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("036d92f0-de76-43ba-9d4d-3a87133b254f"));
		}

		#endregion

	}

	#endregion

}

