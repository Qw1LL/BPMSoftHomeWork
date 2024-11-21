namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IColumnsAggregatorFactorySchema

	/// <exclude/>
	public class IColumnsAggregatorFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IColumnsAggregatorFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IColumnsAggregatorFactorySchema(IColumnsAggregatorFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c9f4596c-5acf-4767-9176-f091a98db598");
			Name = "IColumnsAggregatorFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,81,75,106,195,48,16,93,199,224,59,12,94,181,155,232,0,117,12,169,33,197,139,150,208,210,3,168,202,216,21,88,35,49,35,45,66,201,221,43,39,77,27,99,232,70,160,209,251,205,19,105,135,18,180,65,120,220,63,191,249,62,174,91,79,189,29,18,235,104,61,173,119,118,196,206,5,207,177,44,190,202,98,149,196,210,112,131,101,124,40,139,60,87,74,65,45,201,57,205,199,230,231,254,138,129,81,144,162,128,195,248,233,15,208,123,6,195,168,35,130,241,99,114,36,160,135,129,113,208,209,243,85,69,221,200,132,244,49,90,3,150,34,114,63,165,236,218,11,111,251,75,219,105,147,207,99,6,79,249,22,65,86,211,160,253,199,243,12,152,153,94,38,65,179,118,64,185,159,77,149,4,57,247,66,104,166,82,170,166,86,231,215,63,48,99,76,76,210,212,130,217,134,177,223,84,221,139,167,61,178,88,137,185,130,69,236,74,101,149,43,109,210,89,110,182,61,232,144,247,134,39,92,210,239,222,103,145,96,158,240,62,127,202,234,84,22,167,111,170,187,194,218,223,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c9f4596c-5acf-4767-9176-f091a98db598"));
		}

		#endregion

	}

	#endregion

}

