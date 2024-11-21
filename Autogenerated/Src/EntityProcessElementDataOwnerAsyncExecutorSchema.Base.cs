namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EntityProcessElementDataOwnerAsyncExecutorSchema

	/// <exclude/>
	public class EntityProcessElementDataOwnerAsyncExecutorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EntityProcessElementDataOwnerAsyncExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EntityProcessElementDataOwnerAsyncExecutorSchema(EntityProcessElementDataOwnerAsyncExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("232b7840-ec6e-489d-a023-bb9b694170a3");
			Name = "EntityProcessElementDataOwnerAsyncExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,84,75,107,219,64,16,62,59,144,255,48,36,23,9,130,116,79,28,67,234,138,224,67,98,67,218,222,55,171,145,188,84,218,21,251,176,43,130,255,123,71,187,146,109,165,86,161,208,139,97,118,230,123,232,155,93,75,86,163,105,24,71,248,178,121,121,83,133,77,150,74,22,162,116,154,89,161,228,245,213,199,245,213,204,25,33,75,120,107,141,197,250,225,88,159,0,117,173,228,165,115,141,151,79,147,76,90,97,5,154,228,201,180,146,175,27,12,106,230,31,199,147,149,180,168,11,114,223,33,9,123,171,177,164,6,44,43,102,204,61,120,92,187,209,138,6,76,86,97,141,210,126,101,150,5,154,189,68,237,81,105,154,194,220,184,186,102,186,93,244,181,103,128,189,224,91,192,95,200,157,69,3,106,16,134,66,105,224,91,38,203,206,170,234,136,64,21,128,94,14,154,160,7,24,4,13,228,36,153,192,32,148,158,41,53,238,189,18,28,184,23,155,114,235,141,122,203,153,119,66,218,247,176,10,211,217,142,134,198,169,16,45,237,140,126,143,105,188,160,221,170,156,242,216,120,185,208,252,252,209,253,1,34,112,141,197,227,205,180,64,18,108,224,77,122,194,105,36,158,159,102,145,253,153,213,123,123,138,234,98,52,33,192,100,158,14,36,71,214,243,168,134,172,118,74,228,208,203,68,223,13,106,186,175,18,185,151,114,163,242,14,38,63,225,73,151,6,152,46,157,119,17,67,119,201,103,179,29,163,53,142,70,30,33,10,28,126,7,19,68,241,145,232,225,68,211,205,247,171,92,201,66,17,147,196,125,247,132,38,246,235,135,130,141,89,144,92,229,4,26,217,73,134,198,93,152,123,197,125,192,78,77,46,85,229,106,249,131,85,142,222,206,51,218,111,109,131,185,47,231,207,78,228,139,104,12,90,119,100,1,243,74,127,11,113,47,179,174,114,223,185,32,67,173,255,168,116,8,249,253,61,168,104,188,228,56,89,118,151,11,163,207,137,199,158,236,208,191,4,148,121,120,12,190,14,167,227,195,195,111,204,227,193,230,10,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("232b7840-ec6e-489d-a023-bb9b694170a3"));
		}

		#endregion

	}

	#endregion

}

