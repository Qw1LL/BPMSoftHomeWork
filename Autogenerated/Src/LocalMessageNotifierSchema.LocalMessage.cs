namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LocalMessageNotifierSchema

	/// <exclude/>
	public class LocalMessageNotifierSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LocalMessageNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LocalMessageNotifierSchema(LocalMessageNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f4f644d0-eb01-48be-be16-2d50b24a40a4");
			Name = "LocalMessageNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4a46c73e-2533-4fb4-8b08-c16580add3d1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,219,106,2,49,16,134,175,87,240,29,130,189,81,144,125,0,123,128,186,22,43,104,149,106,123,159,102,103,215,192,38,145,28,40,139,248,238,157,77,86,77,91,17,175,178,153,124,243,207,204,191,227,12,151,37,89,215,198,130,184,239,118,92,116,77,51,85,85,192,44,87,210,164,83,144,160,57,59,33,227,213,98,173,10,139,140,134,244,69,90,110,57,24,124,237,118,36,21,96,118,148,65,196,200,130,151,78,211,70,170,219,217,55,84,114,167,161,196,43,201,42,106,204,136,204,21,163,213,2,140,161,37,188,41,203,11,14,218,115,59,247,85,113,70,88,131,93,164,200,136,140,169,129,127,185,73,168,115,46,132,99,88,237,152,85,122,68,86,94,53,0,109,133,75,218,125,63,89,77,192,31,3,130,146,73,146,180,208,76,22,138,60,18,9,223,36,142,4,230,8,33,16,146,209,65,187,169,119,144,163,171,78,200,79,90,57,120,192,134,208,204,167,126,175,165,123,131,97,200,206,52,80,11,249,184,158,229,215,21,166,142,231,152,31,241,127,53,150,242,186,194,4,161,13,23,112,86,89,202,147,198,43,53,207,214,82,182,21,168,128,58,104,32,180,79,71,143,222,129,41,157,199,125,174,52,23,84,215,81,145,97,72,89,179,45,8,250,17,179,33,148,98,172,101,230,28,119,15,119,205,96,95,180,181,119,194,253,22,162,166,159,119,72,252,212,71,167,147,253,13,6,133,31,121,106,0,7,188,57,169,161,201,33,212,10,199,1,23,221,127,251,253,2,153,135,21,243,247,16,253,29,244,177,31,238,17,30,214,106,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f4f644d0-eb01-48be-be16-2d50b24a40a4"));
		}

		#endregion

	}

	#endregion

}

