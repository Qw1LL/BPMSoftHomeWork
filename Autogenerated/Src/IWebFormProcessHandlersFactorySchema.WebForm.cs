namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IWebFormProcessHandlersFactorySchema

	/// <exclude/>
	public class IWebFormProcessHandlersFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IWebFormProcessHandlersFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IWebFormProcessHandlersFactorySchema(IWebFormProcessHandlersFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("30248ea6-6ed0-4ae8-b005-c4b54f120925");
			Name = "IWebFormProcessHandlersFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9d05c8ee-17e3-41aa-adfe-7e36f0a4c27c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,221,83,177,106,195,48,16,157,19,200,63,28,201,210,66,177,247,36,245,208,210,164,30,2,129,180,116,86,172,179,35,176,36,115,146,40,166,244,223,43,201,137,211,212,133,22,186,117,243,61,221,189,123,239,73,86,76,162,105,88,129,112,183,221,236,116,105,147,123,173,74,81,57,98,86,104,53,25,191,77,198,35,103,132,170,96,215,26,139,114,241,165,246,253,117,141,69,104,54,201,26,21,146,40,206,61,103,82,66,143,122,124,70,88,249,94,200,149,69,42,253,226,57,228,47,184,95,105,146,91,210,5,26,243,200,20,175,145,204,138,21,86,83,27,167,210,52,133,165,113,82,50,106,179,99,125,60,135,82,19,84,104,109,216,215,116,20,112,56,114,0,199,6,21,15,71,126,103,237,209,216,197,42,4,84,86,216,54,57,145,167,159,216,27,183,175,69,1,226,36,241,71,133,163,144,82,111,109,131,246,160,185,153,195,54,242,68,3,3,7,17,88,163,53,96,15,232,117,227,64,123,144,54,212,214,33,13,35,38,65,249,203,187,157,58,131,228,47,77,117,151,48,205,158,60,95,192,160,232,193,100,153,198,137,239,9,94,59,115,57,239,102,125,25,50,149,32,120,200,168,20,72,195,121,66,235,72,153,108,153,158,190,194,81,254,160,156,68,98,251,26,151,121,124,12,204,34,239,195,195,203,252,178,224,127,128,154,171,231,11,67,209,203,185,188,9,123,70,107,39,56,244,186,175,23,191,202,88,27,251,255,67,214,198,71,58,76,121,0,255,33,230,153,255,163,186,167,30,235,247,238,191,190,0,61,246,1,42,174,113,82,90,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("30248ea6-6ed0-4ae8-b005-c4b54f120925"));
		}

		#endregion

	}

	#endregion

}

