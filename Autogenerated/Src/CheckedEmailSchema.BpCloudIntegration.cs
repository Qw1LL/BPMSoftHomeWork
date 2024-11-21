namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CheckedEmailSchema

	/// <exclude/>
	public class CheckedEmailSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CheckedEmailSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CheckedEmailSchema(CheckedEmailSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("29627a54-240f-4b4f-a2e5-afc88eca3ba7");
			Name = "CheckedEmail";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,144,49,79,195,48,16,133,231,70,202,127,56,181,11,44,201,78,128,129,80,33,134,160,168,25,17,66,142,115,77,45,98,59,242,93,134,82,241,223,113,156,22,218,194,0,227,189,123,207,247,249,25,161,145,122,33,17,238,202,162,178,107,78,114,107,214,170,29,156,96,101,77,146,47,171,194,54,216,81,28,237,226,40,142,102,3,41,211,66,181,37,70,157,172,6,195,74,99,82,161,83,162,83,239,33,147,5,223,194,97,235,7,200,59,65,116,5,249,6,229,27,54,75,45,84,23,246,105,154,194,53,13,90,11,183,189,221,207,43,236,29,18,26,38,224,13,2,142,102,80,254,16,16,11,198,228,16,75,143,114,207,247,130,133,103,102,39,36,191,120,161,31,234,78,73,144,227,221,179,179,179,233,11,95,108,165,179,61,58,86,232,1,203,16,155,246,231,108,65,120,64,143,101,29,16,30,227,141,76,63,161,102,129,170,64,93,163,187,120,242,21,195,13,204,131,127,126,57,50,30,32,137,221,216,102,192,131,29,180,200,217,248,126,6,31,255,6,249,174,232,143,56,138,94,229,212,206,41,83,109,109,7,143,180,111,238,55,170,5,154,102,106,48,204,147,122,42,122,237,19,1,38,227,25,90,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("29627a54-240f-4b4f-a2e5-afc88eca3ba7"));
		}

		#endregion

	}

	#endregion

}

