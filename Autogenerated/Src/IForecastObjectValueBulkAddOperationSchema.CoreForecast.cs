namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IForecastObjectValueBulkAddOperationSchema

	/// <exclude/>
	public class IForecastObjectValueBulkAddOperationSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IForecastObjectValueBulkAddOperationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IForecastObjectValueBulkAddOperationSchema(IForecastObjectValueBulkAddOperationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("949d29b4-32dc-fbc9-0241-7774107a898a");
			Name = "IForecastObjectValueBulkAddOperation";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,146,203,106,132,64,16,69,215,10,254,67,97,54,9,4,133,44,19,35,100,242,194,69,152,16,97,246,173,93,58,157,104,183,244,99,96,8,249,247,148,79,132,201,98,200,70,236,235,173,83,183,203,146,172,69,211,177,18,97,243,254,150,171,202,70,143,74,86,162,118,154,89,161,100,244,162,52,150,204,216,221,77,224,127,7,190,231,140,144,53,228,71,99,177,37,107,211,96,217,251,76,244,138,18,181,40,239,2,159,92,23,26,107,82,33,147,22,117,69,244,91,200,102,210,182,248,164,154,29,107,28,110,92,243,245,192,249,182,195,177,219,80,27,199,49,36,198,181,45,211,199,116,58,47,28,168,148,6,198,121,31,130,112,74,115,3,86,245,234,192,134,189,48,86,233,35,168,161,9,28,250,46,147,49,154,217,241,10,222,185,162,17,37,136,133,127,94,76,143,70,65,207,147,172,131,64,214,255,100,243,78,194,141,74,199,52,107,65,210,127,186,15,141,100,157,217,43,27,166,115,76,152,165,36,30,140,127,215,77,113,194,244,99,124,89,155,15,74,240,62,243,244,233,114,38,231,19,248,137,89,182,116,185,134,236,89,186,150,6,81,52,152,172,102,52,86,167,243,197,175,104,15,188,159,113,23,80,242,113,29,250,35,105,191,114,134,80,255,115,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("949d29b4-32dc-fbc9-0241-7774107a898a"));
		}

		#endregion

	}

	#endregion

}

