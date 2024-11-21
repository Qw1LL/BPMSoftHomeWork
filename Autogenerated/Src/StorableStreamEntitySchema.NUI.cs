namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: StorableStreamEntitySchema

	/// <exclude/>
	public class StorableStreamEntitySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public StorableStreamEntitySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public StorableStreamEntitySchema(StorableStreamEntitySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a0a87ec1-0968-41f6-a659-4da5f3e39a17");
			Name = "StorableStreamEntity";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,80,203,106,195,48,16,60,59,144,127,216,38,151,246,34,167,133,82,72,74,33,175,67,15,77,74,157,146,67,8,101,29,175,141,64,182,140,180,46,184,33,255,94,201,74,160,164,151,149,102,180,179,51,171,10,75,178,53,30,8,102,239,111,137,206,89,204,117,149,203,162,49,200,82,87,253,222,177,223,139,26,43,171,2,146,214,50,149,147,43,44,94,215,142,114,228,208,80,225,20,48,87,104,237,24,18,214,6,83,69,9,27,194,178,235,136,227,24,158,109,83,150,104,218,151,51,222,26,172,107,50,144,107,3,182,107,5,214,144,146,3,218,80,38,46,178,248,143,110,151,144,145,168,228,143,159,191,119,68,221,164,74,30,224,224,157,175,140,151,21,75,110,97,12,51,180,142,10,79,129,116,66,191,92,52,148,57,220,172,150,155,100,51,93,45,166,31,139,135,175,81,23,55,218,173,83,171,21,49,221,14,182,82,41,159,202,80,169,191,41,3,204,217,133,126,18,247,143,98,36,224,211,18,44,144,17,106,163,221,50,220,138,193,157,207,117,9,22,162,92,142,35,20,196,19,176,190,156,130,211,144,170,76,230,225,126,214,164,45,211,110,31,198,254,87,132,234,101,225,215,61,60,253,2,212,165,45,113,204,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a0a87ec1-0968-41f6-a659-4da5f3e39a17"));
		}

		#endregion

	}

	#endregion

}

