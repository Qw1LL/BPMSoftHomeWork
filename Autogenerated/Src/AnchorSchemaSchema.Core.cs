namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AnchorSchemaSchema

	/// <exclude/>
	public class AnchorSchemaSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AnchorSchemaSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AnchorSchemaSchema(AnchorSchemaSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d6e901b7-c83c-496b-bfca-a90070dabbd4");
			Name = "AnchorSchema";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9dcf4d22-4488-4059-8715-c0b6327feea5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,211,215,82,112,86,6,2,5,16,1,165,193,108,29,136,8,156,143,80,130,204,66,230,194,40,231,252,162,84,5,45,125,0,120,94,16,74,90,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d6e901b7-c83c-496b-bfca-a90070dabbd4"));
		}

		#endregion

	}

	#endregion

}

