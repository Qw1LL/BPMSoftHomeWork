namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IForecastObjectValueGetOperationSchema

	/// <exclude/>
	public class IForecastObjectValueGetOperationSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IForecastObjectValueGetOperationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IForecastObjectValueGetOperationSchema(IForecastObjectValueGetOperationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8085a14a-5f12-d391-672c-77b5acc1b8d6");
			Name = "IForecastObjectValueGetOperation";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,146,79,107,131,64,16,197,207,10,249,14,131,189,180,80,20,122,108,173,135,150,38,8,45,41,21,114,223,152,89,187,69,119,101,255,20,66,233,119,239,236,110,20,33,133,92,212,121,190,121,254,102,29,201,6,52,35,107,17,158,222,223,26,197,109,254,172,36,23,157,211,204,10,37,243,181,210,216,50,99,119,119,171,244,103,149,38,206,8,217,65,115,52,22,7,178,246,61,182,222,103,242,13,74,212,162,125,88,165,228,186,210,216,145,10,181,180,168,57,165,223,67,61,37,109,247,95,212,179,99,189,195,13,218,237,136,241,75,161,175,40,10,40,141,27,6,166,143,213,169,158,51,128,43,13,29,90,235,9,248,41,13,84,136,131,111,159,7,164,41,125,48,249,20,85,44,178,70,183,239,69,11,98,142,187,76,148,208,196,116,61,195,10,2,89,47,83,156,99,36,65,25,153,102,3,72,58,252,199,204,124,34,218,172,106,252,173,44,194,155,255,141,92,244,196,30,255,79,86,173,67,5,109,40,207,250,52,90,167,165,169,94,5,209,161,116,3,13,181,239,17,20,159,240,202,98,242,248,166,250,101,246,148,139,243,248,8,222,202,15,27,31,205,117,224,132,0,125,11,17,34,34,193,146,239,134,22,33,249,141,203,128,242,16,247,193,151,164,253,1,220,254,35,216,116,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8085a14a-5f12-d391-672c-77b5acc1b8d6"));
		}

		#endregion

	}

	#endregion

}

