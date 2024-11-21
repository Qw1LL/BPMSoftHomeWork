namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LookupValuesEntitySchemaColumnSchema

	/// <exclude/>
	public class LookupValuesEntitySchemaColumnSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LookupValuesEntitySchemaColumnSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LookupValuesEntitySchemaColumnSchema(LookupValuesEntitySchemaColumnSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("76ad8774-b047-419f-b521-b9a051bdfc9f");
			Name = "LookupValuesEntitySchemaColumn";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,79,75,3,49,16,197,207,45,244,59,12,244,162,32,187,119,171,130,46,86,10,85,10,69,239,49,155,109,131,201,100,205,159,67,41,126,119,39,217,172,174,45,84,61,230,101,230,205,251,77,130,76,11,215,50,46,224,110,245,184,54,141,47,42,131,141,220,4,203,188,52,88,204,165,18,11,221,26,235,39,227,253,100,60,10,78,226,6,214,59,231,133,158,77,198,164,76,173,216,80,37,64,165,152,115,151,176,52,230,45,180,47,76,5,225,238,209,75,191,91,243,173,208,172,50,42,104,76,45,101,89,194,149,11,90,51,187,187,201,231,91,4,137,206,51,164,40,166,1,191,149,14,120,116,4,110,208,51,186,3,164,172,192,176,6,145,108,193,37,95,8,40,223,131,0,89,71,185,145,194,198,126,149,82,244,149,60,205,46,250,209,229,96,118,27,94,149,228,121,212,111,217,71,113,5,223,196,115,41,84,77,200,171,228,145,208,142,216,146,176,252,145,230,40,112,12,118,156,172,143,246,16,100,13,195,52,207,139,122,246,231,97,29,122,218,221,233,49,206,219,248,180,79,84,152,221,167,2,235,14,53,159,109,199,77,63,132,138,3,247,198,30,192,103,171,211,107,60,59,135,61,124,252,167,33,109,160,227,249,218,192,69,31,56,146,145,99,116,27,29,108,9,174,15,187,136,140,202,34,35,221,197,206,36,228,48,67,222,172,13,37,82,62,1,129,91,203,105,46,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("76ad8774-b047-419f-b521-b9a051bdfc9f"));
		}

		#endregion

	}

	#endregion

}

