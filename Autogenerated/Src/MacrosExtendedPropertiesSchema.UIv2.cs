namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MacrosExtendedPropertiesSchema

	/// <exclude/>
	public class MacrosExtendedPropertiesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MacrosExtendedPropertiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MacrosExtendedPropertiesSchema(MacrosExtendedPropertiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("002c9b1f-92d2-46e4-bb93-2ab334090c0f");
			Name = "MacrosExtendedProperties";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,81,77,107,195,48,12,61,167,208,255,32,186,123,3,59,118,91,15,43,99,27,172,16,40,219,93,181,21,87,224,56,193,178,217,202,232,127,159,227,164,217,247,197,72,79,122,122,79,150,195,134,164,67,69,112,91,109,119,109,29,150,155,214,213,108,162,199,192,173,155,207,222,231,179,34,10,59,3,187,163,4,106,174,166,252,79,194,242,57,176,149,212,148,218,46,60,153,4,193,198,162,200,10,182,168,124,43,119,111,129,156,38,93,249,182,35,31,152,36,247,150,101,9,215,18,155,6,253,113,61,230,153,7,236,20,118,18,45,6,2,212,154,123,21,180,208,77,124,120,61,176,58,128,66,7,123,130,40,164,19,39,13,35,2,229,169,190,89,12,194,15,100,19,225,229,114,81,174,151,103,193,242,139,98,23,247,150,21,168,44,250,191,215,34,125,72,122,167,229,62,107,43,168,242,136,161,254,115,161,12,60,161,51,17,13,1,107,114,129,107,38,223,123,249,109,230,236,230,62,178,158,88,143,26,250,107,20,133,161,208,159,161,40,100,12,78,163,167,228,118,176,149,243,1,253,14,158,62,0,116,54,11,227,241,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("002c9b1f-92d2-46e4-bb93-2ab334090c0f"));
		}

		#endregion

	}

	#endregion

}

