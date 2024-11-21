namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMailingProviderConfigFactorySchema

	/// <exclude/>
	public class IMailingProviderConfigFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMailingProviderConfigFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMailingProviderConfigFactorySchema(IMailingProviderConfigFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e17ee573-06a4-435b-80a1-7eb5968f81d8");
			Name = "IMailingProviderConfigFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5d774dd3-3f0d-4e5d-9409-9a3b17d3417e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,146,207,74,196,48,16,198,207,45,236,59,132,238,69,47,155,251,218,237,193,5,161,135,66,81,124,128,152,78,187,129,109,82,38,137,176,136,239,238,52,105,181,213,5,209,75,67,230,207,247,253,166,19,45,122,176,131,144,192,238,235,234,201,180,110,119,52,186,85,157,71,225,148,209,155,244,109,147,38,222,42,221,45,10,16,238,54,41,197,183,8,29,21,177,82,59,192,150,68,246,172,172,132,58,83,117,141,230,85,53,128,81,237,65,72,103,240,18,154,56,231,44,183,190,239,5,94,138,233,62,85,91,214,131,59,153,198,178,214,32,147,8,196,64,198,74,91,39,180,84,148,55,45,115,39,160,126,128,49,223,30,178,235,134,25,47,118,179,23,95,152,13,254,229,172,36,41,78,192,191,241,38,52,62,125,63,39,173,34,223,158,213,65,40,38,191,79,20,2,199,145,158,136,39,120,248,43,250,79,246,24,25,4,138,158,105,90,219,33,243,54,52,105,144,227,174,178,162,92,120,45,124,158,215,101,164,159,243,32,243,165,138,224,60,106,91,60,198,243,127,212,57,159,101,70,221,235,117,211,127,153,73,111,214,108,108,61,209,109,124,102,201,22,116,19,23,16,238,239,241,241,173,130,20,251,0,159,180,250,206,203,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e17ee573-06a4-435b-80a1-7eb5968f81d8"));
		}

		#endregion

	}

	#endregion

}

