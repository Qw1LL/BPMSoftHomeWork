namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IForecastEntitySnapshotServiceSchema

	/// <exclude/>
	public class IForecastEntitySnapshotServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IForecastEntitySnapshotServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IForecastEntitySnapshotServiceSchema(IForecastEntitySnapshotServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3c7ea9e9-65c5-7705-1050-9886d7a946fc");
			Name = "IForecastEntitySnapshotService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,81,75,107,195,48,12,62,39,144,255,32,210,203,6,35,134,30,187,46,135,61,10,61,12,6,129,222,53,71,238,12,181,29,108,39,80,198,254,251,28,187,222,186,117,176,147,145,252,189,36,105,84,228,6,228,4,247,47,207,157,17,190,121,48,90,200,253,104,209,75,163,155,141,177,196,209,249,221,178,42,223,171,178,42,139,133,165,125,248,129,173,246,100,69,96,174,96,155,81,79,218,75,127,236,52,14,238,205,248,142,236,36,57,69,22,99,12,214,110,84,10,237,177,61,213,29,78,4,238,4,6,151,208,32,140,5,138,58,77,230,177,51,226,48,190,30,36,7,153,221,255,53,47,66,236,226,194,255,43,128,251,78,208,163,199,95,246,151,254,169,51,160,69,5,58,44,239,174,206,252,186,205,222,160,200,227,172,214,172,89,68,254,77,20,242,16,134,168,219,77,124,129,255,88,252,57,115,50,178,143,97,179,193,85,158,57,55,30,231,232,57,200,13,36,197,116,73,72,54,215,183,65,233,35,93,144,116,159,142,56,151,161,247,9,87,63,41,131,5,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3c7ea9e9-65c5-7705-1050-9886d7a946fc"));
		}

		#endregion

	}

	#endregion

}

