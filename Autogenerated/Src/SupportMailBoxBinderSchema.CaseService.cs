namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SupportMailBoxBinderSchema

	/// <exclude/>
	public class SupportMailBoxBinderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SupportMailBoxBinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SupportMailBoxBinderSchema(SupportMailBoxBinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bc5ec1ee-8ee0-40d6-ba02-de9f93ecefc3");
			Name = "SupportMailBoxBinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,80,203,106,195,48,16,60,59,144,127,88,210,75,10,197,190,167,169,161,14,45,20,106,26,234,67,207,178,189,118,5,177,36,86,178,137,41,249,247,174,173,184,205,163,189,72,104,103,52,59,51,74,52,104,141,40,16,146,109,154,233,202,133,27,173,42,89,183,36,156,212,106,62,251,154,207,130,214,74,85,159,16,8,195,103,81,56,77,18,237,253,21,254,129,57,115,154,70,43,198,24,189,33,172,89,10,54,59,97,237,10,178,214,24,77,46,21,114,151,232,125,34,85,137,52,242,162,40,130,181,109,155,70,80,31,31,223,30,134,74,19,67,136,80,16,86,15,139,151,115,141,119,52,218,74,182,211,47,162,56,156,148,162,19,41,211,230,59,89,64,49,56,248,211,0,172,224,209,152,167,14,149,123,149,214,161,66,74,132,69,254,202,249,249,252,9,145,162,251,212,37,199,216,142,146,30,60,202,235,14,137,100,137,208,105,89,194,155,98,197,204,9,114,203,73,154,171,117,184,119,80,248,251,22,134,114,131,32,231,77,225,9,125,130,135,106,131,96,172,205,215,221,135,131,219,245,191,241,239,46,178,253,34,241,114,113,93,150,95,112,56,6,68,85,250,140,227,219,79,207,135,135,111,61,184,233,46,45,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bc5ec1ee-8ee0-40d6-ba02-de9f93ecefc3"));
		}

		#endregion

	}

	#endregion

}

