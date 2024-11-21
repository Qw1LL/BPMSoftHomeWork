namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SysModuleFolderUtilitiesSchema

	/// <exclude/>
	public class SysModuleFolderUtilitiesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysModuleFolderUtilitiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysModuleFolderUtilitiesSchema(SysModuleFolderUtilitiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("da6824aa-e582-4158-850d-dede529eb3c0");
			Name = "SysModuleFolderUtilities";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,82,193,138,194,48,16,61,43,248,15,193,147,130,132,189,203,30,92,65,241,224,34,186,203,30,151,152,142,110,216,54,41,201,68,16,241,223,55,77,106,181,26,165,135,181,164,73,58,153,244,189,55,111,36,203,192,228,140,3,121,91,204,87,106,131,116,172,228,70,108,173,102,40,148,236,180,15,157,118,203,26,33,183,100,181,55,8,217,176,250,62,95,200,50,37,99,113,13,241,40,93,97,56,115,167,185,93,167,130,19,131,14,143,19,158,50,99,10,164,185,74,108,10,19,149,38,160,63,81,164,2,5,24,151,94,208,137,222,25,51,254,3,51,71,240,189,80,84,100,249,212,171,92,131,186,148,18,0,204,130,33,130,150,36,36,183,182,128,167,109,75,3,90,119,210,29,107,96,8,151,132,62,216,250,251,240,114,236,22,234,220,115,244,75,152,27,96,142,120,81,217,38,200,215,87,238,128,186,233,182,42,59,37,18,178,4,3,248,165,244,175,183,216,248,26,245,102,126,241,22,16,94,109,251,37,250,57,66,151,144,169,29,244,162,141,65,253,79,42,103,104,5,226,227,83,173,108,222,31,54,32,87,218,16,152,77,173,11,155,186,249,179,100,64,30,51,222,49,29,162,39,247,201,107,89,115,58,81,58,99,216,171,247,6,189,113,127,112,11,26,200,71,170,81,67,170,36,6,227,239,137,188,242,49,38,246,153,50,235,13,119,33,246,159,101,142,36,75,247,46,100,150,144,43,141,79,236,182,81,4,169,33,201,160,252,233,12,3,64,232,235,51,51,247,186,241,7,193,38,58,222,116,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("da6824aa-e582-4158-850d-dede529eb3c0"));
		}

		#endregion

	}

	#endregion

}

