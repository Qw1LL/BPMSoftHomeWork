namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PRMOrderConstantsSchema

	/// <exclude/>
	public class PRMOrderConstantsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PRMOrderConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PRMOrderConstantsSchema(PRMOrderConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ee3a9e6e-8558-427d-9613-797cab16dcc3");
			Name = "PRMOrderConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d0cf4ca6-907d-4eba-86db-4399f9ff6801");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,203,106,195,48,16,69,215,54,248,31,68,178,105,23,142,193,117,243,234,99,97,91,233,42,212,52,95,160,216,99,51,96,201,65,15,138,41,249,247,78,44,250,8,100,163,65,247,94,157,25,141,18,18,204,73,212,192,242,106,127,24,90,187,40,6,213,98,231,180,176,56,168,40,252,138,194,192,25,84,29,59,140,198,130,124,138,66,82,230,26,58,178,89,209,11,99,182,172,250,216,191,235,6,52,189,53,86,40,107,166,208,201,29,123,172,25,41,150,74,125,137,222,74,6,212,130,206,63,230,143,69,220,137,224,237,36,73,216,179,113,82,10,61,190,122,129,85,26,105,242,30,141,101,149,208,86,129,166,34,100,33,44,116,131,30,25,54,160,44,182,8,122,241,139,72,254,51,174,71,124,115,216,120,230,5,121,147,248,194,20,124,78,193,187,89,94,150,187,156,167,105,156,110,202,44,206,118,156,199,107,94,174,98,254,152,167,217,102,185,90,174,249,195,236,222,47,44,152,131,106,252,7,167,251,217,175,241,74,60,127,3,106,132,11,31,141,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ee3a9e6e-8558-427d-9613-797cab16dcc3"));
		}

		#endregion

	}

	#endregion

}

