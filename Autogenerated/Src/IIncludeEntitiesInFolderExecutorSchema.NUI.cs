namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IIncludeEntitiesInFolderExecutorSchema

	/// <exclude/>
	public class IIncludeEntitiesInFolderExecutorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IIncludeEntitiesInFolderExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IIncludeEntitiesInFolderExecutorSchema(IIncludeEntitiesInFolderExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fc490832-b2c8-4995-9b6d-4c38bf371f49");
			Name = "IIncludeEntitiesInFolderExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,144,65,75,3,49,16,133,207,22,250,31,134,122,209,75,115,215,90,168,82,97,15,5,65,111,226,33,38,147,37,144,157,44,147,9,84,196,255,110,54,217,162,80,193,227,188,188,247,242,241,72,15,152,70,109,16,238,159,14,207,209,201,250,33,146,243,125,102,45,62,18,124,46,23,203,197,197,37,99,63,93,158,4,217,21,247,13,116,29,153,144,45,238,73,188,120,76,29,61,198,96,145,247,71,52,89,34,215,156,82,10,54,41,15,131,230,143,237,124,119,167,142,210,86,27,0,231,10,144,8,174,150,164,245,41,172,126,165,199,252,30,188,249,129,248,151,97,166,63,195,168,194,206,90,72,24,208,8,218,63,16,38,130,115,132,166,140,154,245,0,84,166,187,91,57,31,10,78,106,171,173,182,27,85,31,171,183,128,66,67,193,171,36,236,169,127,125,3,70,19,217,166,151,88,254,191,190,45,182,175,182,48,146,109,35,79,103,209,190,1,184,54,250,238,153,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fc490832-b2c8-4995-9b6d-4c38bf371f49"));
		}

		#endregion

	}

	#endregion

}

