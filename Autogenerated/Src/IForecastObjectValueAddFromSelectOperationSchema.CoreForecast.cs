namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IForecastObjectValueAddFromSelectOperationSchema

	/// <exclude/>
	public class IForecastObjectValueAddFromSelectOperationSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IForecastObjectValueAddFromSelectOperationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IForecastObjectValueAddFromSelectOperationSchema(IForecastObjectValueAddFromSelectOperationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("215656b7-d84b-1549-3dd0-2a8672dc7856");
			Name = "IForecastObjectValueAddFromSelectOperation";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,145,77,75,195,64,16,134,207,13,228,63,12,57,41,148,4,188,90,3,70,45,244,32,21,3,189,111,179,147,118,117,63,226,126,84,139,244,191,187,31,77,109,17,47,129,153,201,251,204,51,137,36,2,205,64,58,132,230,229,185,85,189,45,31,148,236,217,198,105,98,153,146,229,92,105,236,136,177,171,155,60,251,206,179,137,51,76,110,160,221,27,139,226,246,84,255,102,53,150,143,141,31,248,81,85,85,48,51,78,8,162,247,245,177,94,72,139,186,15,235,122,165,129,80,26,210,253,113,7,168,245,27,118,22,118,132,59,4,223,83,154,154,114,36,85,103,168,193,173,57,235,128,157,104,139,209,115,25,17,171,64,184,167,116,174,149,104,145,251,206,114,192,116,145,79,251,59,252,243,143,223,36,52,224,233,11,59,103,49,184,141,10,96,21,156,241,35,252,53,142,130,92,140,93,216,165,206,64,52,17,32,253,247,189,43,204,22,209,22,245,8,129,88,151,179,42,190,243,79,36,106,23,117,210,159,194,39,179,91,32,156,123,169,15,199,52,82,232,20,119,66,154,11,204,78,49,10,141,227,239,254,248,164,104,174,218,176,44,173,156,66,194,65,162,95,135,63,120,200,179,195,15,38,203,203,36,6,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("215656b7-d84b-1549-3dd0-2a8672dc7856"));
		}

		#endregion

	}

	#endregion

}

