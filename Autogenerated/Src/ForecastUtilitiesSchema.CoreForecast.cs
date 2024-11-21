namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ForecastUtilitiesSchema

	/// <exclude/>
	public class ForecastUtilitiesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ForecastUtilitiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ForecastUtilitiesSchema(ForecastUtilitiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("91be19b7-738e-4443-9fd0-37cbba5954a8");
			Name = "ForecastUtilities";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,145,77,107,195,48,12,134,207,41,244,63,136,156,186,75,12,59,110,105,160,11,116,167,65,89,183,221,61,87,246,12,137,29,252,145,81,70,255,251,228,166,161,237,218,67,119,176,192,146,30,189,250,48,188,69,223,113,129,240,180,122,89,91,25,138,218,26,169,85,116,60,104,107,138,165,117,40,184,15,31,247,211,201,207,116,146,69,175,141,58,201,109,91,107,30,167,19,138,48,198,160,244,177,109,185,219,86,135,255,202,217,94,111,208,131,60,148,129,24,116,163,131,70,95,140,8,59,97,186,248,217,104,1,62,144,184,0,209,112,239,97,236,224,125,36,41,143,58,33,123,33,185,119,188,98,136,206,120,42,226,180,8,192,149,114,168,246,195,64,216,118,152,116,47,133,7,79,199,29,111,193,208,74,230,185,140,70,212,118,131,121,149,44,88,121,81,169,100,251,252,35,238,6,229,106,125,93,25,122,222,68,44,61,34,8,135,114,158,47,142,9,111,20,31,176,156,85,37,27,43,165,210,231,59,185,202,192,51,134,154,55,98,73,61,167,200,44,205,78,103,26,103,184,131,116,186,44,243,223,58,136,47,152,253,245,103,180,95,132,156,246,145,63,12,142,108,232,224,186,92,177,142,45,221,252,8,10,27,77,184,13,173,83,234,25,204,123,117,27,186,232,213,1,220,160,228,177,9,255,235,117,151,108,50,244,118,191,188,230,42,12,247,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("91be19b7-738e-4443-9fd0-37cbba5954a8"));
		}

		#endregion

	}

	#endregion

}

