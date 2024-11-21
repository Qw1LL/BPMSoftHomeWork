namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MergeableColumnSchema

	/// <exclude/>
	public class MergeableColumnSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MergeableColumnSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MergeableColumnSchema(MergeableColumnSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("130e3881-b742-42e2-8cd7-66092d66a439");
			Name = "MergeableColumn";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,78,205,10,194,48,12,62,175,208,119,232,19,248,2,158,116,23,61,76,132,61,65,182,101,165,208,54,163,105,25,67,246,238,182,83,193,131,138,135,132,228,251,201,151,196,198,107,213,46,28,209,237,165,72,219,122,188,54,45,141,113,87,147,115,228,63,192,1,51,40,133,7,135,60,65,143,111,148,31,141,78,1,162,33,47,197,77,138,106,74,157,53,189,234,45,48,171,6,131,70,232,44,214,100,147,203,138,170,72,94,26,142,161,228,60,184,26,166,114,68,109,130,74,99,204,145,121,224,231,176,150,246,205,123,201,143,253,107,236,136,172,58,243,193,206,176,240,201,12,3,254,204,204,181,222,1,88,121,109,118,53,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("130e3881-b742-42e2-8cd7-66092d66a439"));
		}

		#endregion

	}

	#endregion

}

