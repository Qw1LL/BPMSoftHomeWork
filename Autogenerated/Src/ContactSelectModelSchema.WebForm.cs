namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactSelectModelSchema

	/// <exclude/>
	public class ContactSelectModelSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactSelectModelSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactSelectModelSchema(ContactSelectModelSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c995aa53-261b-474b-b723-c7bbe16e4062");
			Name = "ContactSelectModel";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bb225b1d-9856-4e2d-8d05-b81de9745531");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,145,193,106,195,48,12,134,207,41,236,29,4,189,142,230,190,142,193,154,141,50,88,71,71,186,7,240,108,37,49,36,118,102,203,133,80,250,238,147,147,180,180,219,200,46,198,146,172,95,159,245,27,209,160,111,133,68,88,109,55,185,45,104,145,89,83,232,50,56,65,218,154,155,217,225,102,150,4,175,77,9,121,231,9,155,229,57,206,172,195,197,211,138,19,156,154,59,44,249,61,100,181,240,254,142,107,134,132,164,28,107,148,180,177,10,235,254,85,154,166,112,239,67,211,8,215,61,140,241,174,107,17,108,113,106,121,15,232,186,173,179,123,173,208,129,67,31,106,138,229,53,94,170,65,131,84,89,181,56,105,166,23,162,109,248,172,181,4,25,73,254,4,73,248,79,124,158,153,121,90,139,142,52,50,248,182,111,30,234,63,105,251,196,199,139,138,56,188,140,92,86,216,8,40,172,3,17,148,70,195,75,228,202,43,10,117,11,207,123,52,180,19,174,68,2,36,25,65,127,147,158,80,215,65,43,120,28,53,6,217,56,230,0,220,189,4,31,143,227,4,210,174,66,48,236,227,197,22,185,91,218,58,52,102,122,176,39,55,56,57,54,101,125,207,91,212,138,190,39,73,4,232,47,17,34,94,166,56,122,235,128,42,65,236,27,5,103,60,8,168,181,239,253,27,103,64,48,250,43,32,176,187,134,116,161,209,249,105,196,193,185,107,31,255,129,155,163,81,131,181,125,60,100,175,147,199,111,123,84,30,23,248,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c995aa53-261b-474b-b723-c7bbe16e4062"));
		}

		#endregion

	}

	#endregion

}

