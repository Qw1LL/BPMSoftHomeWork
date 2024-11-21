namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IPrimaryImportEntitiesGetterSchema

	/// <exclude/>
	public class IPrimaryImportEntitiesGetterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IPrimaryImportEntitiesGetterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IPrimaryImportEntitiesGetterSchema(IPrimaryImportEntitiesGetterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e6f63fcc-5fd6-4ac9-8d4c-acfa8b8d627e");
			Name = "IPrimaryImportEntitiesGetter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,145,65,106,195,48,16,69,215,49,248,14,67,86,45,20,233,0,117,189,104,73,131,41,5,67,78,160,152,113,16,149,198,102,36,45,76,201,221,43,89,177,29,218,238,52,154,247,245,255,71,164,44,186,81,117,8,175,237,231,105,232,189,120,27,168,215,151,192,202,235,129,196,187,54,216,216,113,96,95,22,223,101,177,11,78,211,5,78,147,243,104,35,106,12,118,137,115,226,136,132,172,187,231,149,217,222,99,20,7,242,218,107,116,113,29,129,49,156,141,238,64,147,71,238,147,119,211,178,182,138,167,236,180,192,71,244,17,136,124,50,222,73,41,161,114,193,38,174,94,46,34,226,96,204,98,192,155,78,172,184,252,205,87,163,98,101,129,98,235,151,253,124,198,104,225,246,117,118,134,237,74,84,114,30,254,151,126,225,20,203,7,75,81,250,129,19,116,121,248,43,98,244,129,201,213,183,130,91,198,74,46,171,196,54,7,10,22,89,157,13,86,115,253,169,78,221,30,114,172,118,77,117,23,240,9,238,69,25,204,153,106,216,226,61,166,15,185,150,197,245,7,188,127,145,65,233,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e6f63fcc-5fd6-4ac9-8d4c-acfa8b8d627e"));
		}

		#endregion

	}

	#endregion

}

