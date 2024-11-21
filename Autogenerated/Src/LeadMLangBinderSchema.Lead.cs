namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LeadMLangBinderSchema

	/// <exclude/>
	public class LeadMLangBinderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LeadMLangBinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LeadMLangBinderSchema(LeadMLangBinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f319c644-f47a-4da7-b6eb-96ccd3799545");
			Name = "LeadMLangBinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("df5a8bee-e0f6-4225-b7c8-127f6fd1b1ca");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,81,203,106,195,48,16,60,59,144,127,88,210,75,10,197,190,167,33,80,135,22,2,54,13,228,208,179,108,109,92,129,37,25,61,76,67,201,191,119,37,217,37,77,47,18,218,153,157,221,25,41,38,209,14,172,69,40,143,245,73,159,93,190,215,234,44,58,111,152,19,90,45,23,223,203,69,230,173,80,221,13,193,96,254,198,90,167,141,64,251,252,15,255,192,134,56,82,106,69,24,161,15,6,59,146,130,125,207,172,221,64,133,140,215,21,83,93,41,20,71,19,41,69,81,192,214,122,41,153,185,236,166,119,224,129,244,189,19,61,145,61,235,16,218,160,0,77,236,203,231,182,226,166,111,240,77,47,218,137,119,55,8,54,240,50,12,175,35,42,87,9,235,80,161,41,153,69,234,34,139,116,254,238,89,163,251,212,156,54,61,70,181,4,78,202,122,68,99,4,71,24,181,224,240,174,72,241,228,152,113,235,89,154,210,115,248,229,160,77,247,35,132,252,178,172,161,73,249,13,125,134,67,122,89,22,147,73,137,94,242,176,237,246,16,246,14,158,15,14,233,39,180,121,138,118,238,171,187,245,42,148,87,73,231,58,249,64,197,147,149,248,78,213,191,197,235,15,67,197,231,136,247,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f319c644-f47a-4da7-b6eb-96ccd3799545"));
		}

		#endregion

	}

	#endregion

}

