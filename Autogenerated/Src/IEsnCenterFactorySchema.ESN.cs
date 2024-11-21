namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IEsnCenterFactorySchema

	/// <exclude/>
	public class IEsnCenterFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEsnCenterFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEsnCenterFactorySchema(IEsnCenterFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5db535e2-9bbb-4b57-8890-3bdffc4020de");
			Name = "IEsnCenterFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b66b5ae8-46e0-4931-ad78-c2c1ba5fd6ea");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,146,193,78,132,48,16,134,207,144,240,14,19,188,232,133,222,149,229,176,100,77,56,104,54,110,124,128,10,3,54,217,182,100,90,76,54,198,119,119,202,178,2,89,47,122,34,51,76,190,255,235,100,140,212,232,122,89,35,108,247,79,7,219,250,172,180,166,85,221,64,210,43,107,178,221,225,57,137,63,147,56,26,156,50,29,148,150,240,33,137,185,190,33,236,120,0,160,50,30,169,101,194,61,84,59,103,74,12,245,163,172,189,165,211,56,41,132,128,220,13,90,75,58,21,83,189,39,251,161,26,116,160,209,191,219,198,65,107,9,106,66,14,229,20,101,156,151,134,157,108,11,74,247,71,212,12,101,6,98,152,105,55,233,28,148,130,40,178,75,136,88,164,244,195,219,81,213,140,154,236,126,147,139,194,195,174,252,198,70,25,92,240,63,38,215,42,209,216,233,37,73,13,134,247,189,73,7,135,196,123,54,88,135,37,167,69,181,136,89,192,95,215,99,33,32,23,35,103,198,18,250,129,140,43,94,198,239,159,133,115,113,1,4,226,252,115,90,192,79,125,187,118,129,245,11,238,248,38,162,175,243,93,160,105,206,167,145,196,220,249,6,171,236,28,136,96,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5db535e2-9bbb-4b57-8890-3bdffc4020de"));
		}

		#endregion

	}

	#endregion

}

