namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IDashboardItemSelectBuilderSchema

	/// <exclude/>
	public class IDashboardItemSelectBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDashboardItemSelectBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDashboardItemSelectBuilderSchema(IDashboardItemSelectBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4e4bbf9b-4e63-40a8-8dcf-802e271ecd52");
			Name = "IDashboardItemSelectBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("eccc4091-3404-497f-94e5-8c10d0f3a0d7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,144,77,106,195,64,12,133,215,9,228,14,90,182,80,236,3,36,100,225,56,148,44,2,1,159,64,182,101,103,202,252,184,210,12,193,132,220,189,178,77,211,110,218,205,44,158,244,222,251,52,30,29,201,128,13,65,113,57,87,161,139,217,33,248,206,244,137,49,154,224,55,235,251,102,189,74,98,124,15,213,40,145,156,206,173,165,102,26,74,246,78,158,216,52,219,231,206,33,48,101,101,161,130,74,67,170,173,105,192,248,72,220,77,21,167,18,229,90,7,228,246,164,73,21,77,57,69,50,182,37,214,117,109,210,119,149,231,57,236,36,57,135,60,238,191,133,210,204,141,42,193,205,196,43,52,193,38,231,5,6,100,61,64,243,37,123,122,243,223,230,31,227,78,34,43,226,27,132,250,67,123,247,112,244,209,196,81,207,153,146,206,56,192,29,122,138,91,120,252,195,49,211,10,200,140,14,159,137,20,168,11,12,45,70,4,27,176,253,3,99,185,117,177,191,188,46,223,51,247,60,190,0,89,205,203,251,129,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4e4bbf9b-4e63-40a8-8dcf-802e271ecd52"));
		}

		#endregion

	}

	#endregion

}

