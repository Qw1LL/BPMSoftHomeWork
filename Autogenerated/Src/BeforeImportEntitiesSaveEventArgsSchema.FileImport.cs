namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BeforeImportEntitiesSaveEventArgsSchema

	/// <exclude/>
	public class BeforeImportEntitiesSaveEventArgsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BeforeImportEntitiesSaveEventArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BeforeImportEntitiesSaveEventArgsSchema(BeforeImportEntitiesSaveEventArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ccd3636d-c0d8-49cf-8899-16272e80dadf");
			Name = "BeforeImportEntitiesSaveEventArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1101e5cd-b945-4f88-8001-faccb4fdb24c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,142,209,106,195,48,12,69,159,27,200,63,8,250,158,15,72,199,160,45,93,9,172,16,150,245,3,60,71,113,5,142,29,44,165,48,202,254,125,118,178,149,174,20,246,34,164,203,61,186,215,169,30,121,80,26,97,83,31,26,223,73,177,245,174,35,51,6,37,228,93,241,66,22,171,126,240,65,242,236,146,103,139,145,201,25,104,62,89,176,95,221,221,17,181,22,117,226,184,216,163,195,64,58,122,162,107,25,208,68,21,182,86,49,151,176,193,206,135,159,183,59,39,36,132,220,168,51,238,206,232,100,29,12,79,208,48,126,88,210,160,19,243,63,2,37,84,174,243,7,100,86,230,246,211,34,213,190,54,168,131,31,48,36,186,132,122,10,152,178,126,195,246,35,181,240,230,189,52,250,132,189,58,86,45,92,192,160,172,128,211,248,250,99,126,37,150,167,185,210,187,50,207,112,93,249,17,180,68,215,206,37,226,53,107,183,82,158,69,237,27,137,110,66,179,142,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ccd3636d-c0d8-49cf-8899-16272e80dadf"));
		}

		#endregion

	}

	#endregion

}

