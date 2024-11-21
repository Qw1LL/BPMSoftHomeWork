namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IWebFormResultInfoSchema

	/// <exclude/>
	public class IWebFormResultInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IWebFormResultInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IWebFormResultInfoSchema(IWebFormResultInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("30bc9300-f8d4-4de5-89f5-8558b24e931e");
			Name = "IWebFormResultInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,145,79,107,2,49,16,197,207,10,126,135,1,175,197,189,171,120,104,105,139,7,97,169,133,158,179,217,201,26,216,77,100,38,113,41,210,239,222,252,169,186,181,165,245,20,222,203,155,95,94,18,35,58,228,189,144,8,247,229,102,107,149,155,61,88,163,116,227,73,56,109,205,100,124,156,140,39,227,209,148,176,9,18,214,198,33,169,16,159,195,250,13,171,39,75,221,11,178,111,221,218,40,155,146,69,81,192,146,125,215,9,122,95,125,233,146,236,65,215,200,160,79,227,160,44,65,143,85,92,59,160,132,8,187,81,165,115,103,39,82,49,64,237,125,213,106,57,128,252,86,97,148,11,159,27,111,208,237,108,205,115,40,211,116,222,188,46,153,140,103,116,12,2,14,162,245,24,14,169,181,12,85,76,3,253,46,32,144,206,45,25,216,75,137,204,177,228,207,150,217,73,148,179,4,88,202,149,35,143,203,66,174,64,171,19,97,1,54,162,123,205,120,23,35,74,180,156,50,3,244,133,84,89,219,194,54,79,194,17,26,116,11,248,248,239,66,129,15,72,20,158,59,124,52,139,6,111,111,253,250,199,232,37,201,142,226,43,61,198,224,38,231,174,202,77,209,212,249,55,146,206,238,119,51,120,159,57,77,47,86,138,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("30bc9300-f8d4-4de5-89f5-8558b24e931e"));
		}

		#endregion

	}

	#endregion

}

