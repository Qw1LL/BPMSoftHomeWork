namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DCTemplateGroupModelSchema

	/// <exclude/>
	public class DCTemplateGroupModelSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DCTemplateGroupModelSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DCTemplateGroupModelSchema(DCTemplateGroupModelSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a31f9786-6cb9-4933-9916-2eea05b45be7");
			Name = "DCTemplateGroupModel";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("748ec229-6875-456a-9dfd-63087e63e63a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,84,193,110,219,48,12,61,167,64,255,129,75,47,45,48,216,247,166,206,128,37,64,145,67,182,0,221,62,64,149,232,88,131,45,105,18,189,212,40,246,239,163,228,56,73,211,100,203,114,176,162,103,145,239,145,124,178,17,13,6,39,36,194,231,213,242,201,150,148,205,172,41,245,186,245,130,180,53,217,188,51,162,209,146,65,66,67,217,210,42,172,195,245,213,235,245,213,168,13,218,172,225,169,11,132,205,100,183,191,40,205,92,144,136,255,189,144,196,161,28,124,227,113,205,7,97,86,139,16,238,97,62,251,134,141,171,5,225,163,183,173,75,180,233,92,158,231,240,16,218,166,17,190,155,110,247,41,6,200,130,71,231,49,48,1,40,38,128,38,70,65,105,61,71,32,130,244,88,22,227,163,204,227,124,10,28,160,169,203,134,236,249,65,122,215,62,215,90,130,76,12,167,69,141,184,23,252,220,85,176,242,214,161,39,141,92,198,42,133,247,239,143,149,39,224,187,209,63,91,4,173,162,134,82,163,143,42,222,203,24,116,60,182,90,193,66,193,43,172,145,38,16,226,227,55,20,9,207,190,224,38,174,183,119,147,255,33,4,91,2,109,203,58,232,196,63,52,236,91,113,172,230,2,110,163,240,5,54,154,42,109,128,42,220,209,255,157,87,243,88,23,41,244,4,223,13,26,213,247,255,237,48,150,72,149,85,151,76,226,235,47,244,158,219,18,0,95,28,31,213,4,210,26,6,41,186,154,205,117,222,67,131,147,163,151,168,115,251,58,102,125,130,0,166,173,235,152,35,174,103,170,76,136,19,94,52,192,87,5,139,113,114,239,120,58,48,109,221,108,159,127,160,36,216,84,90,86,131,64,84,217,67,158,66,15,251,21,136,175,158,220,87,19,93,41,136,47,195,25,245,183,167,236,221,179,222,65,145,50,143,122,13,31,138,84,72,66,70,159,192,224,230,92,78,136,223,137,248,99,151,20,125,174,108,161,62,14,96,154,230,14,143,187,254,13,15,53,46,247,137,102,235,230,163,9,247,115,127,11,50,246,7,36,106,156,50,207,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a31f9786-6cb9-4933-9916-2eea05b45be7"));
		}

		#endregion

	}

	#endregion

}

