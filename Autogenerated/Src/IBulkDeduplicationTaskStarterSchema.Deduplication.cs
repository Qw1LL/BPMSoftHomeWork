namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IBulkDeduplicationTaskStarterSchema

	/// <exclude/>
	public class IBulkDeduplicationTaskStarterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IBulkDeduplicationTaskStarterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IBulkDeduplicationTaskStarterSchema(IBulkDeduplicationTaskStarterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("34bd4c3a-5be2-45e6-81db-f052a01f9932");
			Name = "IBulkDeduplicationTaskStarter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,81,189,78,195,48,16,158,27,41,239,112,106,23,88,226,29,74,135,194,210,129,170,82,120,1,39,190,164,86,227,31,249,156,74,8,245,221,57,59,84,10,100,64,242,242,157,191,63,159,173,52,72,94,182,8,251,211,123,237,186,88,189,58,219,233,126,12,50,106,103,171,55,84,163,31,116,155,81,89,124,149,197,138,207,38,96,207,24,14,54,98,232,88,253,4,135,253,56,92,126,177,63,36,93,234,40,3,83,202,130,69,66,8,216,210,104,140,12,159,187,31,124,10,238,170,21,18,24,140,103,167,160,115,1,40,105,180,237,161,97,71,80,115,75,240,193,181,72,84,221,237,196,204,207,143,13,243,64,223,59,253,87,105,149,30,179,104,149,7,153,67,127,178,35,139,83,240,50,121,154,120,25,164,1,203,11,125,89,19,182,73,115,100,176,222,213,19,200,87,213,86,100,94,150,53,206,13,83,214,162,229,3,197,144,118,48,51,122,124,102,205,45,175,114,131,86,77,95,144,224,237,27,150,194,224,140,197,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("34bd4c3a-5be2-45e6-81db-f052a01f9932"));
		}

		#endregion

	}

	#endregion

}

