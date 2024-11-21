namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: JunkFilterConstsSchema

	/// <exclude/>
	public class JunkFilterConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public JunkFilterConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public JunkFilterConstsSchema(JunkFilterConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2a61b393-d894-421c-9a81-38a44ebfda70");
			Name = "JunkFilterConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("59955e0a-90db-4796-8f0c-f9403b7d622f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,145,61,11,194,48,16,134,103,11,253,15,161,83,139,80,156,21,65,172,138,8,74,65,113,17,135,24,79,9,166,151,146,143,161,72,255,187,215,170,96,135,130,235,147,247,121,115,151,32,47,192,150,92,0,155,231,219,189,190,185,52,211,120,147,119,111,184,147,26,195,224,25,6,131,210,95,148,20,204,58,98,130,9,197,173,101,27,143,143,149,84,14,12,9,214,89,138,53,209,111,86,52,144,12,35,241,206,150,5,151,234,80,149,144,233,43,176,41,139,90,16,77,250,242,11,77,231,248,43,44,90,210,111,44,209,153,170,115,67,3,250,243,107,224,87,48,185,209,37,24,87,29,185,242,96,115,238,104,27,36,123,22,197,207,81,157,156,166,227,115,156,14,147,78,205,231,17,12,21,104,84,85,119,228,223,138,89,156,38,195,127,212,61,32,205,146,105,229,11,220,209,119,52,227,191,89,107,215,97,80,191,0,220,89,109,173,166,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2a61b393-d894-421c-9a81-38a44ebfda70"));
		}

		#endregion

	}

	#endregion

}

