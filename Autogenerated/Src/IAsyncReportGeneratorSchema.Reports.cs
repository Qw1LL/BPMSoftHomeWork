namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IAsyncReportGeneratorSchema

	/// <exclude/>
	public class IAsyncReportGeneratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IAsyncReportGeneratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IAsyncReportGeneratorSchema(IAsyncReportGeneratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fe187b0f-b6a6-426e-8401-a8fc548ff6d0");
			Name = "IAsyncReportGenerator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,84,193,78,194,64,16,61,107,226,63,76,240,162,137,161,119,81,18,245,64,56,152,16,209,15,88,218,41,108,164,187,205,236,172,166,49,254,187,179,187,20,40,84,194,165,97,223,206,188,121,239,77,139,81,21,186,90,229,8,207,179,215,185,45,121,248,98,77,169,151,158,20,107,107,174,46,127,174,46,47,188,211,102,9,243,198,49,86,163,237,121,215,64,40,168,224,215,132,75,105,130,169,97,164,82,72,239,97,250,134,181,37,158,160,65,97,180,244,228,26,147,199,226,44,203,224,193,249,170,82,212,140,55,231,25,217,47,93,160,3,21,202,86,100,141,245,110,221,0,69,18,88,38,150,48,188,244,38,15,2,213,90,115,51,108,233,178,61,190,218,47,214,58,7,221,106,129,105,156,125,160,71,10,197,161,60,183,226,95,145,87,182,112,247,48,139,4,233,242,80,108,4,230,172,136,69,235,161,60,33,97,229,62,131,170,99,89,9,169,21,169,10,140,132,255,56,240,14,73,66,55,24,13,13,198,239,43,132,128,65,190,5,129,109,203,142,155,105,195,135,44,146,244,115,230,251,75,76,148,29,232,44,66,66,246,100,92,234,38,148,210,34,26,3,91,30,91,150,246,182,62,16,116,98,150,235,247,208,23,3,235,187,185,249,232,100,16,237,239,142,119,208,183,185,206,123,218,117,119,59,58,177,181,9,110,118,230,252,154,123,173,36,147,139,70,170,92,141,185,46,181,24,151,215,210,112,248,73,231,238,53,176,164,232,255,153,192,97,7,188,81,114,58,254,157,90,117,68,243,173,121,5,44,69,105,58,97,185,39,96,90,12,178,241,190,248,211,107,122,75,115,36,163,254,155,155,222,189,166,65,109,234,215,104,138,244,45,197,243,111,250,107,232,128,130,253,1,33,153,6,52,121,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fe187b0f-b6a6-426e-8401-a8fc548ff6d0"));
		}

		#endregion

	}

	#endregion

}

