namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IPrimaryImportEntitiesSetterSchema

	/// <exclude/>
	public class IPrimaryImportEntitiesSetterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IPrimaryImportEntitiesSetterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IPrimaryImportEntitiesSetterSchema(IPrimaryImportEntitiesSetterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8f3be9bf-a5b6-4e6a-a262-4785da28353f");
			Name = "IPrimaryImportEntitiesSetter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,145,219,106,132,48,16,134,175,87,240,29,6,175,90,40,241,1,106,189,104,177,69,150,130,224,19,100,237,184,12,107,18,201,97,169,148,125,247,38,166,106,119,41,189,51,147,239,63,100,148,92,160,25,121,135,240,220,188,183,170,183,236,69,201,158,142,78,115,75,74,178,87,26,176,22,163,210,54,77,190,210,100,231,12,201,35,180,147,177,40,60,58,12,216,5,206,176,55,148,168,169,123,92,153,205,79,35,171,164,37,75,104,252,181,7,70,119,24,168,3,146,22,117,31,178,235,70,147,224,122,138,73,11,220,162,245,128,231,67,240,46,207,115,40,140,19,129,43,151,129,71,12,224,39,25,27,34,241,71,8,86,1,205,86,235,136,173,22,249,173,71,49,114,205,5,72,191,137,167,108,254,70,31,107,178,50,182,129,109,196,138,124,62,252,45,93,162,178,178,186,45,244,191,240,132,147,223,164,19,210,75,247,56,65,23,15,87,162,179,162,143,240,218,187,88,170,89,59,253,170,247,0,117,37,157,64,205,15,3,22,243,22,167,114,237,112,125,27,109,98,108,9,91,131,251,240,3,47,105,114,249,6,163,99,80,6,25,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8f3be9bf-a5b6-4e6a-a262-4785da28353f"));
		}

		#endregion

	}

	#endregion

}

