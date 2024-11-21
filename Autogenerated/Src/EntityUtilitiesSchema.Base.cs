namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EntityUtilitiesSchema

	/// <exclude/>
	public class EntityUtilitiesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EntityUtilitiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EntityUtilitiesSchema(EntityUtilitiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9ecf1f84-e5da-45f4-97b4-4fa811780d5d");
			Name = "EntityUtilities";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("24c6dcbf-ddce-46c1-876f-ee548e2ae17a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,82,203,106,195,48,16,60,43,208,127,16,201,197,133,96,223,91,215,135,134,18,10,73,9,196,237,93,181,215,137,64,150,93,61,14,166,228,223,187,146,159,177,15,245,65,90,237,206,204,142,228,149,172,4,93,179,12,232,235,233,120,174,10,19,238,42,89,240,139,85,204,240,74,62,172,126,31,86,196,106,46,47,244,220,104,3,229,243,236,140,120,33,32,115,96,29,238,65,130,226,217,2,115,224,242,103,76,142,157,20,132,111,210,112,195,65,99,25,1,27,5,23,84,162,59,193,180,126,162,190,216,124,26,46,60,198,67,162,40,162,177,182,101,201,84,147,116,231,77,247,13,65,31,185,109,8,59,185,94,35,154,136,212,246,91,240,140,106,131,183,206,104,230,186,47,155,19,124,11,92,7,147,71,48,215,42,71,155,39,207,110,139,115,123,119,254,38,14,251,128,198,53,83,172,84,80,80,137,255,226,101,157,85,194,150,242,3,227,117,148,108,231,212,161,197,212,125,155,241,58,75,145,100,210,108,187,108,191,180,22,198,145,151,26,149,21,24,171,164,78,254,35,143,230,122,134,203,212,119,111,155,210,51,43,96,15,6,231,6,45,126,49,97,33,78,147,192,92,121,255,228,20,252,182,69,138,114,243,50,94,230,145,186,113,36,132,23,52,104,65,225,187,158,8,29,42,150,67,30,76,8,61,131,180,142,58,105,28,84,147,54,53,228,51,19,19,162,27,87,66,110,126,237,184,57,20,204,10,19,164,109,17,107,126,26,64,230,237,64,248,115,155,189,79,222,254,0,34,147,96,216,102,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9ecf1f84-e5da-45f4-97b4-4fa811780d5d"));
		}

		#endregion

	}

	#endregion

}

