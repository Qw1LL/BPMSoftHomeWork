namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IOperationAgentSchema

	/// <exclude/>
	public class IOperationAgentSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IOperationAgentSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IOperationAgentSchema(IOperationAgentSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("125ee0b8-83aa-4709-82ef-794af080f041");
			Name = "IOperationAgent";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,148,207,106,194,64,16,198,207,10,125,135,33,189,88,40,230,94,109,192,138,72,14,182,162,248,0,107,118,18,23,146,221,116,255,136,82,250,238,157,77,76,208,180,90,79,73,102,191,111,230,55,59,67,36,43,208,148,44,65,120,91,46,214,42,181,195,169,146,169,200,156,102,86,40,9,15,253,175,135,126,207,25,33,51,88,31,141,197,98,212,249,38,67,158,99,226,213,102,56,71,137,90,36,164,33,213,163,198,204,231,136,165,69,157,82,141,23,136,63,74,172,51,79,50,148,182,146,133,97,8,99,227,138,130,233,99,116,250,110,45,160,82,176,59,122,52,62,96,222,56,108,124,225,153,177,116,219,92,36,32,90,111,167,26,80,43,36,107,185,150,218,103,181,2,205,11,44,107,111,45,232,18,85,129,21,90,167,165,1,171,29,130,72,161,80,26,129,237,153,200,217,54,71,15,244,155,168,183,85,42,135,5,41,39,123,150,11,47,132,47,200,208,142,224,219,31,87,52,40,121,13,116,73,183,64,187,83,188,69,187,131,76,226,193,66,210,78,163,185,58,39,197,167,71,230,116,5,34,21,168,205,21,216,42,162,235,100,209,244,158,60,227,176,145,123,127,60,147,174,160,11,167,46,199,115,39,120,4,115,180,239,4,21,211,154,152,193,211,232,70,15,155,146,51,139,134,134,151,42,93,176,243,186,26,19,165,249,45,230,146,105,86,128,164,85,126,13,106,117,204,131,104,211,229,37,220,74,249,183,17,15,9,150,190,110,16,205,154,215,11,199,94,9,126,226,92,213,69,136,117,224,27,61,33,198,252,25,90,43,180,249,110,246,189,70,107,254,159,89,194,172,210,180,122,170,58,164,19,119,109,225,174,222,135,9,238,29,105,167,227,153,172,234,13,126,79,183,77,237,59,252,115,153,105,201,253,127,224,34,88,197,126,0,90,149,149,39,119,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("125ee0b8-83aa-4709-82ef-794af080f041"));
		}

		#endregion

	}

	#endregion

}

