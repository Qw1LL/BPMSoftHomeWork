namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ICategoryFromSupportMailBoxSchema

	/// <exclude/>
	public class ICategoryFromSupportMailBoxSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICategoryFromSupportMailBoxSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICategoryFromSupportMailBoxSchema(ICategoryFromSupportMailBoxSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f9f6082f-e4c2-4b11-b02e-75f27d626477");
			Name = "ICategoryFromSupportMailBox";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,145,193,106,195,48,12,134,207,11,228,29,116,220,96,36,15,176,144,67,59,22,118,40,20,114,216,217,77,148,86,52,182,131,100,183,13,163,239,62,187,73,187,178,13,118,50,146,63,255,250,127,217,40,141,50,168,6,97,177,94,213,182,115,217,210,154,142,182,158,149,35,107,210,228,51,77,30,188,144,217,66,61,138,67,253,242,163,14,124,223,99,19,97,201,42,52,200,212,4,38,80,121,158,67,33,94,107,197,99,57,215,107,182,7,106,17,196,15,131,101,7,90,81,15,27,123,66,129,35,185,29,52,202,225,214,242,152,93,223,231,119,2,131,223,244,212,0,25,135,220,69,203,239,203,25,127,99,171,235,73,114,21,20,23,246,20,240,232,252,151,137,75,163,66,247,175,3,232,130,38,200,148,241,166,116,111,103,234,48,58,207,70,202,87,186,236,32,220,193,113,135,140,176,199,17,72,254,154,163,218,150,81,194,105,90,56,168,222,99,228,110,201,139,252,42,25,103,124,203,22,226,56,172,253,25,42,79,109,25,51,204,81,81,62,130,241,121,21,132,242,248,20,255,232,156,38,231,47,130,202,136,39,221,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f9f6082f-e4c2-4b11-b02e-75f27d626477"));
		}

		#endregion

	}

	#endregion

}

