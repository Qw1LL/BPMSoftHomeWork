namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AsyncAcceptChatNotifierExecutorSchema

	/// <exclude/>
	public class AsyncAcceptChatNotifierExecutorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AsyncAcceptChatNotifierExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AsyncAcceptChatNotifierExecutorSchema(AsyncAcceptChatNotifierExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("de6fad3b-1ad3-c490-fb1b-04c758b887d2");
			Name = "AsyncAcceptChatNotifierExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("08afff10-3d0c-4f3d-b6a0-28a42952a988");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,83,77,111,219,48,12,61,187,64,255,3,225,29,230,0,129,115,223,18,3,89,22,20,25,150,38,88,145,222,21,153,73,52,216,146,161,143,180,198,208,255,62,74,254,138,187,238,98,72,20,249,222,35,249,44,89,137,166,98,28,225,219,126,251,164,78,54,93,41,121,18,103,167,153,21,74,166,187,82,10,126,97,82,98,145,110,209,24,118,22,242,124,127,247,231,254,46,114,134,142,240,84,27,139,229,215,119,119,66,41,10,228,30,194,164,15,40,81,11,62,228,12,84,101,169,228,71,113,141,20,165,248,39,141,103,194,128,85,193,140,129,47,176,52,181,228,75,206,177,178,171,11,179,143,202,138,147,64,29,114,103,179,25,204,141,43,75,166,235,172,189,255,194,74,163,65,105,13,48,9,204,87,95,180,146,202,25,160,174,44,200,22,32,237,234,103,55,0,149,59,22,130,3,15,220,255,97,94,191,34,119,86,105,210,182,249,161,142,221,149,170,105,68,244,237,59,216,162,189,168,220,247,176,15,176,205,235,123,205,33,208,98,27,80,21,210,26,148,38,241,71,229,108,144,76,194,149,147,118,212,75,81,123,253,255,54,208,68,42,166,89,9,146,22,189,136,157,65,77,11,150,205,106,226,236,64,119,2,236,2,233,124,22,178,63,46,14,103,180,168,77,156,237,251,243,168,166,29,217,85,104,235,88,1,87,37,114,104,102,130,201,97,196,13,99,41,83,216,124,23,225,68,218,231,198,106,242,195,20,212,241,55,61,103,48,48,79,192,91,47,138,196,9,146,33,10,139,5,72,87,20,221,107,100,105,50,47,32,241,5,150,250,236,74,50,192,35,61,239,244,186,172,108,189,126,245,91,36,170,228,166,37,224,76,126,182,112,196,0,20,79,188,43,163,232,45,124,127,10,99,231,15,78,228,217,205,74,22,55,170,200,226,246,153,21,14,147,184,79,136,167,129,127,168,77,38,45,232,149,233,222,120,4,227,179,188,165,118,109,101,103,173,100,60,161,182,248,68,255,6,227,23,72,60,74,71,182,201,65,200,65,91,63,134,222,222,7,73,85,185,103,49,43,111,159,192,81,39,67,253,109,191,244,9,206,69,153,55,230,13,247,38,58,14,190,253,5,234,76,181,148,63,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("de6fad3b-1ad3-c490-fb1b-04c758b887d2"));
		}

		#endregion

	}

	#endregion

}

