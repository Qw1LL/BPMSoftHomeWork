namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INonPersistentColumnProcessSchema

	/// <exclude/>
	public class INonPersistentColumnProcessSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INonPersistentColumnProcessSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INonPersistentColumnProcessSchema(INonPersistentColumnProcessSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5b9b0b8a-a0c7-4250-a378-016529bb5c12");
			Name = "INonPersistentColumnProcess";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,77,107,195,48,12,134,207,9,228,63,136,246,210,65,73,238,91,86,216,186,13,122,232,8,27,236,238,198,74,106,72,228,224,143,150,50,250,223,151,216,77,151,134,174,236,102,89,122,94,235,149,76,172,70,221,176,28,225,57,91,127,202,194,196,75,73,133,40,173,98,70,72,138,223,68,133,171,186,145,202,68,225,119,20,6,141,221,84,34,7,65,6,85,209,97,171,119,73,25,42,45,180,65,50,75,89,217,154,50,37,115,212,186,45,239,144,96,170,176,108,181,96,141,102,43,185,190,135,204,137,68,97,151,76,146,4,82,109,235,154,169,195,162,191,120,226,92,131,98,123,216,177,202,34,152,45,51,176,23,85,5,27,132,198,139,35,143,207,120,50,230,211,134,41,86,3,181,230,30,39,194,181,255,74,70,152,195,100,225,205,0,186,48,78,19,87,121,29,204,157,153,51,226,195,255,32,95,93,215,35,206,91,185,77,115,212,70,144,27,252,152,30,164,226,161,198,78,10,222,141,107,230,203,189,75,24,90,158,131,79,249,213,156,244,46,47,93,191,167,140,59,207,59,233,96,88,242,242,251,254,176,151,187,135,27,91,252,176,164,47,220,235,126,121,130,202,63,182,231,252,156,254,207,172,87,159,34,113,255,135,92,124,140,194,227,15,242,37,48,32,184,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5b9b0b8a-a0c7-4250-a378-016529bb5c12"));
		}

		#endregion

	}

	#endregion

}

