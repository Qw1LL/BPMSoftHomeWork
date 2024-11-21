namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileImportServiceSchema

	/// <exclude/>
	public class IFileImportServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileImportServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileImportServiceSchema(IFileImportServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1053b299-f5b8-465b-9060-5fe6f2707c72");
			Name = "IFileImportService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("39b49a3d-3e30-4c01-a6cc-3961eeed3fd5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,229,149,205,110,130,64,16,199,207,107,226,59,108,244,130,137,225,1,52,189,216,196,134,38,84,34,77,60,152,30,86,24,232,182,176,75,119,23,18,211,244,221,59,176,96,53,24,47,61,169,39,178,179,255,249,248,205,0,35,88,14,186,96,17,208,69,224,135,50,49,238,163,20,9,79,75,197,12,151,194,93,242,12,188,188,144,202,12,7,223,195,1,41,53,23,41,13,247,218,64,238,134,160,42,30,129,47,99,200,230,151,46,221,13,236,80,128,146,177,130,20,227,82,234,9,3,42,193,196,51,234,253,37,105,157,26,233,182,61,96,65,70,177,200,56,47,88,43,125,160,163,158,124,52,121,67,125,81,238,50,30,81,222,5,62,27,151,212,16,135,42,124,48,239,50,214,51,26,52,190,77,90,178,93,21,96,233,187,204,117,116,178,69,6,79,84,242,19,28,235,86,151,18,172,194,215,209,148,174,225,171,4,109,150,82,229,204,160,29,165,62,104,205,82,176,38,247,89,75,49,165,11,25,239,67,179,207,224,68,114,176,186,27,197,138,2,226,105,157,142,144,53,14,70,10,13,151,163,54,232,228,100,104,45,108,231,79,67,86,65,221,10,103,50,191,94,194,110,142,90,99,217,158,72,228,1,239,9,76,239,210,233,141,190,5,160,202,62,175,185,21,151,135,221,117,99,181,251,0,252,104,238,185,17,13,251,93,191,13,22,250,198,249,179,50,23,218,71,127,220,62,199,127,133,211,155,128,41,220,31,184,27,244,77,183,163,146,60,174,223,253,127,195,143,65,196,118,77,226,233,199,46,239,35,19,90,126,1,199,115,54,232,60,8,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1053b299-f5b8-465b-9060-5fe6f2707c72"));
		}

		#endregion

	}

	#endregion

}

