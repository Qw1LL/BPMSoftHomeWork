namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IWebFormImportParamsGeneratorSchema

	/// <exclude/>
	public class IWebFormImportParamsGeneratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IWebFormImportParamsGeneratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IWebFormImportParamsGeneratorSchema(IWebFormImportParamsGeneratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5288477e-ed09-40b3-890c-492633a42375");
			Name = "IWebFormImportParamsGenerator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,49,79,195,48,16,133,231,68,234,127,56,137,189,217,91,196,0,168,85,134,74,17,69,48,59,205,197,88,138,237,232,236,20,33,196,127,231,108,55,180,180,20,181,67,20,251,249,252,249,61,159,141,208,232,122,177,65,184,175,86,107,219,250,233,131,53,173,146,3,9,175,172,153,46,209,32,15,177,121,197,122,97,73,175,145,182,106,131,147,252,115,146,103,131,83,70,158,217,184,80,29,150,186,183,228,231,147,156,107,111,8,37,235,80,26,143,212,242,129,51,40,119,204,84,86,9,18,218,237,206,179,20,55,21,69,1,183,110,208,90,208,199,221,110,94,145,221,170,6,29,168,145,4,173,37,80,17,2,125,160,32,47,56,144,9,21,204,140,168,226,128,213,15,117,167,54,7,148,127,237,192,222,238,19,186,161,243,165,105,45,83,194,53,100,225,27,243,177,189,30,201,43,116,51,168,226,17,49,201,73,148,40,44,209,59,96,184,11,127,255,134,208,96,43,24,14,91,209,13,8,90,24,33,145,130,253,83,255,73,137,133,63,211,231,11,16,251,29,229,99,42,125,9,202,42,21,194,95,90,12,153,73,244,115,136,35,182,203,77,205,178,175,203,131,201,241,29,193,59,214,161,97,58,24,84,77,184,219,235,242,93,72,58,136,121,252,134,57,91,42,103,155,231,86,246,145,143,19,199,102,163,105,82,191,227,60,169,191,69,214,190,1,27,125,148,222,92,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5288477e-ed09-40b3-890c-492633a42375"));
		}

		#endregion

	}

	#endregion

}

