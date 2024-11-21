namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISearchDuplicatesActionExecutorSchema

	/// <exclude/>
	public class ISearchDuplicatesActionExecutorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISearchDuplicatesActionExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISearchDuplicatesActionExecutorSchema(ISearchDuplicatesActionExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3b0287fd-e228-4668-ae2a-c035310e2343");
			Name = "ISearchDuplicatesActionExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,144,77,10,194,48,16,133,215,21,188,195,128,27,221,180,123,21,65,173,136,11,65,232,9,98,58,173,129,102,82,242,3,138,120,119,99,162,214,138,224,38,48,51,223,188,247,50,196,36,154,150,113,132,213,97,95,168,202,166,107,69,149,168,157,102,86,40,74,115,44,93,219,8,30,170,225,224,58,28,36,206,8,170,161,184,24,139,114,246,85,251,237,166,65,254,128,77,186,69,66,45,120,199,116,22,82,42,242,125,63,25,105,172,61,13,59,178,168,43,31,100,10,187,2,153,230,167,252,105,140,102,25,4,55,103,228,206,42,29,214,178,44,131,185,113,82,50,125,89,60,235,94,86,144,140,88,141,58,125,193,217,7,221,186,163,231,64,188,60,255,91,38,254,231,254,125,199,221,163,61,169,210,76,225,16,164,226,112,235,68,9,113,7,59,169,40,61,254,237,208,187,54,152,255,204,228,113,206,36,68,65,42,99,154,224,126,139,231,236,53,111,119,244,90,37,216,223,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3b0287fd-e228-4668-ae2a-c035310e2343"));
		}

		#endregion

	}

	#endregion

}

