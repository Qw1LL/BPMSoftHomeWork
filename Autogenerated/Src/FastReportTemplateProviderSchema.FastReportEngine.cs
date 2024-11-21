namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FastReportTemplateProviderSchema

	/// <exclude/>
	public class FastReportTemplateProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FastReportTemplateProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FastReportTemplateProviderSchema(FastReportTemplateProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("83618497-e4f6-47f6-afb0-46374352918b");
			Name = "FastReportTemplateProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("907f2de3-5104-49b3-a54a-bb8730240b72");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,201,110,194,48,16,61,7,137,127,24,137,75,122,241,7,208,69,106,81,65,28,144,16,208,115,101,146,33,88,77,236,104,108,83,161,170,255,222,113,92,160,9,139,122,137,52,203,243,91,38,90,86,104,107,153,33,188,204,103,75,179,113,98,100,244,70,21,158,164,83,70,139,5,214,134,156,210,133,24,75,235,98,245,170,11,165,177,223,251,234,247,18,111,121,6,203,189,117,88,221,119,106,177,218,18,202,60,128,87,210,126,216,211,252,255,92,151,48,132,231,221,75,88,241,188,182,142,100,22,30,15,228,12,26,16,22,92,193,168,148,214,14,225,180,187,194,170,46,165,195,57,153,157,202,145,154,237,218,175,75,149,65,22,150,111,236,194,16,166,215,94,73,56,36,254,30,137,199,10,203,156,153,231,164,118,188,24,135,117,44,32,164,101,116,185,191,192,53,147,90,22,76,245,238,218,141,104,43,25,160,206,35,67,155,142,3,230,8,124,230,12,5,210,198,207,47,103,244,118,221,85,250,102,145,24,175,177,9,16,124,171,188,131,112,253,36,233,234,129,71,208,248,121,221,64,218,121,38,92,50,249,190,109,98,134,110,107,154,208,206,245,135,31,235,129,45,242,229,159,96,130,46,157,120,149,195,65,212,52,63,232,220,73,58,118,89,99,87,182,96,232,65,105,250,7,221,200,75,8,157,39,221,112,137,49,153,106,129,214,151,238,184,119,203,68,236,182,155,220,251,1,208,200,106,64,119,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("83618497-e4f6-47f6-afb0-46374352918b"));
		}

		#endregion

	}

	#endregion

}

