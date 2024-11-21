namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IColumnProcessorSchema

	/// <exclude/>
	public class IColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IColumnProcessorSchema(IColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("30c9471b-7e5a-4dc5-b5d7-b25c0e8ae3a9");
			Name = "IColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bdeb1980-c322-4103-af7f-58bfe7162080");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,142,193,10,194,48,16,68,207,13,228,31,22,122,149,126,128,199,22,132,28,148,64,191,32,198,77,9,164,187,101,147,156,138,255,110,84,60,72,143,51,243,102,24,114,43,230,205,121,132,209,94,103,14,101,152,152,66,92,170,184,18,153,134,75,76,104,214,141,165,104,181,107,213,245,130,75,243,193,80,65,9,173,119,6,51,113,170,43,89,97,143,57,179,104,213,184,173,222,83,244,16,127,216,129,130,86,188,49,89,148,28,115,65,42,127,249,9,204,232,50,30,150,187,29,158,159,253,30,233,241,189,242,150,205,123,1,31,248,207,180,201,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("30c9471b-7e5a-4dc5-b5d7-b25c0e8ae3a9"));
		}

		#endregion

	}

	#endregion

}

