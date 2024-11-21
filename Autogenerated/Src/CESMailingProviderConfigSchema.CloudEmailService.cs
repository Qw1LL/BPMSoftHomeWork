namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CESMailingProviderConfigSchema

	/// <exclude/>
	public class CESMailingProviderConfigSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CESMailingProviderConfigSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CESMailingProviderConfigSchema(CESMailingProviderConfigSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3b30ba11-e71d-45a7-abb8-9df39c11c6f4");
			Name = "CESMailingProviderConfig";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bc5abc6e-45a7-497f-b7c0-68ae441d38e3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,82,77,75,195,64,16,61,167,208,255,48,164,23,189,36,136,135,66,173,133,88,21,122,40,22,34,120,16,15,219,205,36,46,236,71,216,221,4,66,241,191,187,201,166,69,107,99,15,122,89,118,222,188,55,51,111,103,37,17,104,74,66,17,238,54,235,84,229,54,90,42,153,179,162,210,196,50,37,199,163,221,120,20,84,134,201,2,210,198,88,20,55,135,248,164,32,90,62,164,142,226,72,19,141,133,3,128,114,98,204,12,28,190,38,140,59,225,70,171,154,101,168,189,174,227,198,113,12,115,83,9,65,116,179,232,227,158,102,128,118,60,80,57,216,119,4,225,139,64,217,87,137,246,242,248,139,190,172,182,156,81,223,122,176,51,204,96,53,48,82,224,92,187,243,224,193,229,75,212,150,161,51,178,233,106,251,252,241,220,29,176,146,198,18,233,94,180,159,120,110,16,129,106,204,111,195,125,191,103,20,37,39,22,31,9,181,74,55,97,188,104,109,252,244,177,55,50,160,131,227,184,93,86,16,20,104,219,45,5,129,233,47,31,127,155,54,169,50,134,142,114,79,44,73,85,165,233,249,185,95,159,182,70,113,180,120,17,190,48,206,97,139,160,81,168,26,51,32,185,69,13,211,232,106,26,93,135,151,111,39,92,38,67,253,96,56,179,131,255,181,238,62,77,82,178,243,139,241,60,72,81,215,140,98,123,253,125,7,19,148,153,255,84,93,236,209,239,160,195,62,1,204,33,56,146,150,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3b30ba11-e71d-45a7-abb8-9df39c11c6f4"));
		}

		#endregion

	}

	#endregion

}

