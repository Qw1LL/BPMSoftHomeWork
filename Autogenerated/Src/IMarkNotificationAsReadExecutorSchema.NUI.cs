namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMarkNotificationAsReadExecutorSchema

	/// <exclude/>
	public class IMarkNotificationAsReadExecutorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMarkNotificationAsReadExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMarkNotificationAsReadExecutorSchema(IMarkNotificationAsReadExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5756ae2a-e1ed-46c5-b16e-e91d802e9c2d");
			Name = "IMarkNotificationAsReadExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,143,77,10,194,48,16,133,215,45,244,14,3,221,40,72,15,80,87,254,33,93,84,138,245,2,49,153,214,65,155,148,252,136,69,188,187,177,65,233,206,205,48,239,13,223,123,140,100,29,154,158,113,132,117,85,214,170,177,217,70,201,134,90,167,153,37,37,179,131,178,212,16,31,133,73,226,103,18,71,206,144,108,161,30,140,197,110,153,196,222,73,53,182,254,14,133,180,168,27,31,150,67,81,50,125,157,194,43,115,68,38,118,15,228,206,42,61,98,189,59,223,136,3,125,169,255,80,228,251,253,252,21,150,104,47,74,152,28,170,49,42,28,239,138,4,4,6,103,123,231,133,156,68,158,134,30,11,177,128,45,179,120,162,14,65,99,71,82,124,214,121,248,38,74,81,138,80,224,213,43,124,56,177,146,216,123,111,93,224,93,111,56,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5756ae2a-e1ed-46c5-b16e-e91d802e9c2d"));
		}

		#endregion

	}

	#endregion

}

