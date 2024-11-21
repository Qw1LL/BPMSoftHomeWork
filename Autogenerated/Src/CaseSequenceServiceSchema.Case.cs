namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CaseSequenceServiceSchema

	/// <exclude/>
	public class CaseSequenceServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CaseSequenceServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CaseSequenceServiceSchema(CaseSequenceServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9cde13d8-2e84-4425-a1cc-ccd4661bb767");
			Name = "CaseSequenceService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,203,75,204,77,45,46,72,76,78,85,112,10,240,13,206,79,43,209,115,206,207,75,203,76,47,45,74,44,201,204,207,211,115,78,44,78,13,78,45,44,77,205,75,6,210,69,101,153,201,169,188,92,213,188,92,181,0,145,140,156,218,57,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9cde13d8-2e84-4425-a1cc-ccd4661bb767"));
		}

		#endregion

	}

	#endregion

}

