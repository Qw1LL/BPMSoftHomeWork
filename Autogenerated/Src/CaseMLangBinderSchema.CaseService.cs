namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CaseMLangBinderSchema

	/// <exclude/>
	public class CaseMLangBinderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CaseMLangBinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CaseMLangBinderSchema(CaseMLangBinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e64afc31-7e45-4a5f-b9cc-d14c8c88f3f2");
			Name = "CaseMLangBinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,81,223,107,131,48,16,126,182,208,255,225,232,94,58,24,250,222,149,66,91,44,8,90,101,149,237,57,234,213,5,52,145,36,202,202,232,255,190,75,180,163,235,94,18,114,223,143,187,251,34,88,139,186,99,37,194,46,75,78,242,108,252,189,20,103,94,247,138,25,46,197,124,246,61,159,121,189,230,162,190,35,40,244,15,172,52,82,113,212,175,255,240,15,44,136,211,182,82,16,70,104,16,64,146,190,135,144,167,176,103,26,79,168,6,78,253,182,135,60,124,131,40,201,226,48,9,143,249,54,143,210,163,239,4,79,10,107,234,13,251,134,105,189,114,162,36,102,162,222,113,81,161,154,60,3,88,235,190,109,153,186,108,166,183,229,65,219,55,134,55,68,238,89,141,80,90,7,40,156,206,191,201,130,59,93,215,23,13,47,39,222,67,163,21,108,187,46,28,80,152,152,107,131,2,213,142,8,36,162,72,232,252,29,51,65,243,41,43,26,52,115,102,35,56,25,203,1,149,226,21,194,32,121,5,169,32,199,147,97,202,44,111,214,148,182,193,47,3,229,120,63,131,205,219,243,10,234,228,223,209,111,176,77,219,243,92,48,227,15,92,124,59,236,58,178,99,219,149,35,131,244,115,82,189,184,109,30,171,155,229,194,150,23,163,207,117,218,3,69,53,174,226,222,99,245,111,241,250,3,235,209,147,43,39,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e64afc31-7e45-4a5f-b9cc-d14c8c88f3f2"));
		}

		#endregion

	}

	#endregion

}

