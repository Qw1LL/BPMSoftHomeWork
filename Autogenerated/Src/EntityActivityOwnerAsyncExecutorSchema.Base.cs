namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EntityActivityOwnerAsyncExecutorSchema

	/// <exclude/>
	public class EntityActivityOwnerAsyncExecutorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EntityActivityOwnerAsyncExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EntityActivityOwnerAsyncExecutorSchema(EntityActivityOwnerAsyncExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ac041bc6-71d1-475e-a18c-3ab49a0d8e36");
			Name = "EntityActivityOwnerAsyncExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,84,75,111,219,48,12,62,167,64,255,3,209,93,108,160,176,239,109,26,32,11,130,34,135,54,5,178,237,174,202,180,45,204,150,2,61,146,25,67,254,251,100,202,78,162,174,62,12,216,37,129,72,126,15,146,146,37,107,209,236,25,71,248,250,246,178,83,165,205,86,74,150,162,114,154,89,161,228,237,205,239,219,155,153,51,66,86,176,235,140,197,246,241,124,190,0,218,86,201,207,226,26,63,143,102,107,105,133,21,104,178,165,233,36,223,238,49,168,153,127,44,207,54,210,162,46,189,251,30,233,177,95,52,86,62,1,171,134,25,243,0,132,235,150,220,138,67,255,79,224,163,68,77,181,121,158,195,220,184,182,101,186,91,12,103,194,193,81,240,26,240,23,114,103,209,128,26,229,160,84,26,120,205,100,213,27,84,61,17,168,18,144,68,128,5,149,222,37,140,236,249,21,253,222,189,55,130,3,39,133,216,24,121,34,119,107,18,245,50,15,176,9,53,235,131,231,143,219,246,100,126,41,254,247,220,238,11,218,90,21,190,225,55,18,9,201,143,253,13,1,68,224,26,203,167,187,105,129,44,216,192,187,252,130,211,232,121,126,154,197,250,239,177,188,119,96,53,147,166,68,221,15,230,50,136,171,233,132,105,89,5,182,70,144,120,140,226,217,60,31,233,207,122,215,163,27,103,119,80,162,128,193,64,242,221,160,246,87,85,34,39,19,46,58,222,195,100,115,75,93,25,96,186,114,173,79,153,20,250,251,61,155,29,152,223,101,84,242,4,73,224,160,237,76,16,165,103,162,199,11,13,213,19,116,35,75,229,137,250,126,163,141,251,217,16,43,229,131,129,217,128,40,124,125,100,36,27,19,247,161,238,21,143,1,59,85,185,82,141,107,229,15,214,56,127,21,159,209,126,235,246,88,208,113,254,236,68,177,72,98,16,145,5,204,171,255,22,164,131,204,182,41,166,100,182,77,241,63,149,2,215,142,215,254,10,244,241,137,182,46,5,4,59,133,129,79,142,54,137,47,68,154,173,250,135,139,201,135,237,164,68,115,26,158,19,202,34,188,40,58,135,104,28,60,253,1,49,90,165,248,48,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ac041bc6-71d1-475e-a18c-3ab49a0d8e36"));
		}

		#endregion

	}

	#endregion

}

