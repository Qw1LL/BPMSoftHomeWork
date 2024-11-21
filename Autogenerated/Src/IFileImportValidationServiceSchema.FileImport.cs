namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileImportValidationServiceSchema

	/// <exclude/>
	public class IFileImportValidationServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileImportValidationServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileImportValidationServiceSchema(IFileImportValidationServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cb43cabf-2447-44e4-b1b4-3716ee0c72e1");
			Name = "IFileImportValidationService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,81,193,106,2,49,16,61,71,240,31,6,189,40,72,62,192,210,139,5,97,11,91,197,45,245,32,61,196,205,184,13,221,77,210,36,43,72,241,223,59,187,217,213,30,218,61,133,121,121,111,222,155,25,45,42,244,86,228,8,171,109,154,153,83,224,79,70,159,84,81,59,17,148,209,124,173,74,76,42,107,92,24,143,190,199,35,86,123,165,11,200,46,62,96,197,51,116,103,149,99,106,36,150,15,67,159,124,143,71,34,16,101,234,176,160,190,144,232,128,238,68,190,75,72,238,30,111,162,84,178,53,238,212,173,230,208,21,148,44,56,145,135,217,11,133,134,71,152,12,8,39,243,119,82,218,250,88,170,28,84,111,54,232,5,36,104,70,188,101,76,49,124,24,233,151,176,109,219,180,89,216,97,99,49,238,166,143,211,24,177,3,77,152,232,179,249,196,89,148,53,249,182,155,236,117,178,128,29,126,213,232,195,218,184,74,4,194,137,154,162,247,162,192,8,241,103,111,244,2,86,70,94,178,112,41,155,209,238,148,27,202,247,78,88,139,114,209,216,49,182,163,179,25,237,187,22,255,117,109,183,192,254,26,186,215,67,7,225,236,206,234,22,210,229,6,23,223,121,188,32,155,162,150,113,67,84,93,227,85,127,65,215,31,122,150,93,40,83,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cb43cabf-2447-44e4-b1b4-3716ee0c72e1"));
		}

		#endregion

	}

	#endregion

}

