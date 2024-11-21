namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TermCalculatorCustomerServiceSchema

	/// <exclude/>
	public class TermCalculatorCustomerServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TermCalculatorCustomerServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TermCalculatorCustomerServiceSchema(TermCalculatorCustomerServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5034a0e1-cd7c-4f00-b59d-d7837cec6620");
			Name = "TermCalculatorCustomerService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("50529f8b-8504-4b8d-9a81-5bda32bd1be4");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,237,138,194,48,16,252,93,193,119,216,67,144,30,72,31,64,145,3,139,72,225,4,185,122,15,80,155,213,11,180,73,111,147,8,229,240,221,47,253,210,88,173,63,119,118,118,102,103,19,163,184,56,65,92,42,141,249,98,60,50,78,25,124,114,241,123,197,86,187,109,44,143,58,8,37,225,83,48,88,11,205,53,71,101,187,227,145,72,114,84,69,146,162,195,17,71,126,50,148,104,46,197,120,244,87,177,188,9,225,201,150,16,102,137,82,115,216,35,229,97,146,165,38,75,180,164,208,40,45,115,164,24,233,204,83,172,7,10,115,200,120,10,105,197,127,77,135,190,156,157,182,166,222,205,83,10,165,201,164,182,101,173,119,181,112,237,209,153,188,148,247,191,21,146,149,16,152,86,129,192,220,149,51,216,24,206,64,53,220,200,94,51,98,45,86,16,151,196,117,25,177,119,168,204,188,57,28,18,133,126,95,160,55,235,142,213,49,46,205,174,19,20,172,9,84,85,110,190,45,234,31,201,170,104,36,181,85,69,214,166,235,74,144,103,36,226,12,155,197,54,168,109,90,43,151,80,196,252,214,197,35,212,134,4,196,183,109,224,109,9,194,100,25,76,167,46,28,220,134,43,70,37,25,172,243,66,151,181,140,247,49,192,109,186,205,13,130,222,10,139,129,156,207,83,62,62,224,53,223,151,253,139,246,181,113,207,115,27,22,245,150,11,23,242,221,34,148,153,201,133,106,190,43,80,221,97,15,141,238,60,119,202,237,147,117,24,44,175,169,250,134,131,178,117,228,238,232,143,131,171,114,215,254,3,191,103,54,27,94,117,232,140,45,230,66,151,127,98,86,66,251,16,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5034a0e1-cd7c-4f00-b59d-d7837cec6620"));
		}

		#endregion

	}

	#endregion

}

