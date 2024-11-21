namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CertificatesActualizationJobSchema

	/// <exclude/>
	public class CertificatesActualizationJobSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CertificatesActualizationJobSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CertificatesActualizationJobSchema(CertificatesActualizationJobSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eb1f524d-141f-4a2f-b908-d3aa1a3dcdde");
			Name = "CertificatesActualizationJob";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,83,219,110,219,48,12,125,78,129,254,3,145,189,180,64,225,188,103,89,128,52,233,134,20,205,144,45,232,7,200,10,227,168,144,37,79,164,179,181,67,255,125,148,237,198,113,46,123,177,197,115,120,59,20,229,84,142,84,40,141,112,191,92,172,252,134,147,169,119,27,147,149,65,177,241,238,250,234,239,245,85,175,36,227,50,88,189,18,99,254,249,200,22,127,107,81,71,103,74,190,161,195,96,244,137,207,76,177,58,1,159,140,251,213,130,153,245,169,178,195,225,212,231,185,119,201,147,207,50,129,91,254,59,254,102,41,17,59,124,36,239,90,226,71,169,2,191,29,219,201,60,47,108,178,80,172,183,24,168,101,91,149,177,204,57,60,224,121,180,59,152,11,62,179,251,11,196,131,99,195,6,233,2,253,85,105,246,225,50,191,18,25,235,210,98,56,229,23,72,164,226,172,90,77,226,243,41,96,38,109,194,212,42,34,24,194,20,3,155,141,209,138,145,38,154,75,101,205,91,37,228,209,167,85,192,96,48,128,17,149,121,174,194,235,184,177,39,160,171,112,222,42,134,128,69,64,66,199,4,250,32,25,168,195,108,240,226,211,228,35,219,224,32,93,81,166,214,232,38,223,255,154,145,94,231,242,123,248,131,186,148,145,72,168,108,160,124,247,138,22,200,91,191,142,154,150,85,206,154,61,110,191,2,126,150,238,184,191,141,15,160,172,237,74,48,46,122,153,29,66,33,187,35,43,76,91,83,80,212,113,42,164,70,196,79,229,224,228,241,124,233,151,132,65,118,195,213,143,160,63,126,22,27,244,30,72,70,131,202,251,124,112,117,70,150,146,253,241,114,127,238,196,52,163,219,153,16,133,192,206,155,53,212,227,193,155,88,171,173,13,221,86,238,96,62,51,213,73,122,31,17,7,89,146,59,240,233,139,208,227,40,181,169,118,11,241,145,247,122,7,215,242,204,198,82,242,113,55,56,177,246,166,155,251,54,46,98,239,189,185,26,116,235,250,118,42,187,70,187,224,251,63,161,215,151,137,105,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eb1f524d-141f-4a2f-b908-d3aa1a3dcdde"));
		}

		#endregion

	}

	#endregion

}

