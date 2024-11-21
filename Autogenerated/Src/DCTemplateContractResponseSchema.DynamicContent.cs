namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DCTemplateContractResponseSchema

	/// <exclude/>
	public class DCTemplateContractResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DCTemplateContractResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DCTemplateContractResponseSchema(DCTemplateContractResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3fd21c44-491c-46a0-85b5-eea55b81914b");
			Name = "DCTemplateContractResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ad993b20-8db8-48d6-9762-5a83fb4975c6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,81,203,78,195,48,16,60,83,169,255,176,42,7,110,201,189,133,30,104,175,149,170,150,27,226,224,186,155,196,40,182,35,123,13,10,85,255,157,117,94,74,137,64,92,172,120,60,59,59,51,49,66,163,175,132,68,120,222,239,142,54,163,100,99,77,166,242,224,4,41,107,146,109,109,132,86,146,65,66,67,243,217,101,62,187,11,94,153,28,142,181,39,212,201,33,24,82,26,147,35,58,37,74,245,213,140,173,6,214,127,84,147,173,32,17,191,157,144,196,163,60,124,239,48,103,34,108,74,225,253,18,182,155,23,212,85,41,8,123,218,129,93,91,227,177,97,167,105,10,143,62,104,45,92,189,238,238,61,1,100,148,128,207,66,201,2,36,79,11,101,60,179,145,95,28,102,79,139,169,246,34,93,67,167,34,204,25,178,96,100,116,205,233,168,6,155,1,21,56,22,184,137,198,53,124,40,137,253,118,150,74,6,67,20,28,175,166,110,219,131,7,101,50,235,116,91,73,31,35,29,229,120,29,23,243,198,64,21,78,165,146,93,164,223,75,129,37,252,101,138,133,248,55,242,57,212,188,119,182,66,71,10,185,235,125,179,163,125,255,89,108,3,244,91,155,54,227,90,176,167,119,148,20,35,76,51,180,33,118,168,79,232,98,132,62,195,212,253,32,60,0,23,200,145,86,224,227,113,237,28,163,57,183,166,155,123,139,222,130,215,111,130,110,205,41,212,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3fd21c44-491c-46a0-85b5-eea55b81914b"));
		}

		#endregion

	}

	#endregion

}

