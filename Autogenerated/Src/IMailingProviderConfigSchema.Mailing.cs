namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMailingProviderConfigSchema

	/// <exclude/>
	public class IMailingProviderConfigSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMailingProviderConfigSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMailingProviderConfigSchema(IMailingProviderConfigSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6ab8d5ed-b75b-496a-b8f0-ba3fbf460468");
			Name = "IMailingProviderConfig";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5d774dd3-3f0d-4e5d-9409-9a3b17d3417e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,81,77,75,195,64,16,61,39,144,255,48,164,23,189,36,136,135,66,91,11,126,32,228,80,12,68,240,32,30,54,155,73,92,216,143,176,187,41,132,226,127,119,187,73,164,86,162,7,47,203,204,155,55,111,222,204,74,34,208,180,132,34,220,229,187,66,213,54,185,87,178,102,77,167,137,101,74,70,225,33,10,131,206,48,217,64,209,27,139,98,29,133,14,89,104,108,92,25,50,105,81,215,174,125,5,217,142,48,238,120,185,86,123,86,161,30,116,60,59,77,83,216,152,78,8,162,251,237,152,143,52,3,212,243,64,213,96,223,17,196,32,2,237,168,146,76,237,233,73,127,219,149,156,81,96,211,240,217,217,129,115,239,222,47,187,174,222,162,182,12,205,10,114,47,50,212,207,13,122,32,147,198,18,233,212,71,107,27,131,8,84,99,125,19,79,243,158,81,180,156,88,124,36,212,42,221,199,233,246,232,247,167,225,96,166,1,206,243,227,181,131,160,65,187,246,129,25,131,143,255,217,188,237,42,134,142,242,64,44,41,84,167,233,223,134,95,159,74,163,56,90,188,136,95,24,231,80,34,104,20,106,143,21,144,218,157,29,150,201,213,50,185,142,47,223,78,215,155,29,4,243,149,3,252,186,243,2,101,53,252,158,207,7,244,59,232,176,79,8,228,152,100,199,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6ab8d5ed-b75b-496a-b8f0-ba3fbf460468"));
		}

		#endregion

	}

	#endregion

}

