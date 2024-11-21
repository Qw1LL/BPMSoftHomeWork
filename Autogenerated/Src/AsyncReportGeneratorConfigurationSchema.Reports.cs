namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AsyncReportGeneratorConfigurationSchema

	/// <exclude/>
	public class AsyncReportGeneratorConfigurationSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AsyncReportGeneratorConfigurationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AsyncReportGeneratorConfigurationSchema(AsyncReportGeneratorConfigurationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("320cda9d-04b0-419a-991e-dff36d9fb757");
			Name = "AsyncReportGeneratorConfiguration";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f8ef1a6f-6619-48e3-9227-afa9b7782f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,144,77,110,2,49,12,133,215,32,113,7,139,238,153,61,180,72,237,44,216,180,210,8,196,1,66,234,12,81,51,246,200,201,72,69,136,187,227,249,171,90,90,209,77,34,59,126,241,251,30,153,10,99,109,44,194,75,241,182,99,151,22,57,147,243,101,35,38,121,166,217,244,60,155,78,30,4,75,45,32,15,38,198,37,60,199,19,217,45,214,44,105,131,132,58,201,114,163,82,81,150,101,240,24,155,170,50,114,90,15,181,138,4,35,82,138,96,0,63,19,82,108,255,101,7,233,136,58,141,8,86,208,61,205,239,253,62,207,214,224,88,192,180,54,142,194,196,77,4,233,4,80,246,10,157,90,140,22,178,111,30,234,230,16,188,5,219,114,252,143,1,75,184,79,57,209,112,244,252,202,167,16,174,81,146,71,13,169,232,86,245,239,183,81,116,141,13,106,10,138,17,219,219,128,53,33,28,140,253,128,253,246,181,195,35,78,222,121,219,59,209,132,44,87,117,192,177,250,147,247,55,240,72,28,147,120,42,33,31,150,236,37,192,89,197,105,213,174,95,193,101,224,64,122,239,81,186,186,239,254,108,94,174,125,87,149,202,49,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("320cda9d-04b0-419a-991e-dff36d9fb757"));
		}

		#endregion

	}

	#endregion

}

