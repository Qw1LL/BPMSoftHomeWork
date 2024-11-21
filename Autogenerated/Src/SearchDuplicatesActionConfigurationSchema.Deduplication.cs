namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SearchDuplicatesActionConfigurationSchema

	/// <exclude/>
	public class SearchDuplicatesActionConfigurationSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SearchDuplicatesActionConfigurationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SearchDuplicatesActionConfigurationSchema(SearchDuplicatesActionConfigurationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c9a4d829-6614-4e72-91b0-9433556c337c");
			Name = "SearchDuplicatesActionConfiguration";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,205,106,195,48,12,62,183,208,119,16,244,158,220,215,82,216,218,81,10,27,132,229,9,60,71,73,13,177,19,44,123,16,74,223,125,178,147,172,75,87,182,238,98,144,244,233,251,17,54,66,35,181,66,34,60,101,175,121,83,186,100,219,152,82,85,222,10,167,26,147,236,176,240,109,173,100,172,22,243,211,98,62,243,164,76,5,121,71,14,245,234,170,230,237,186,70,25,192,148,236,209,160,85,242,130,185,72,104,221,152,91,125,139,73,102,27,137,68,60,229,249,210,98,197,92,176,173,5,209,3,228,40,172,60,238,6,71,72,143,81,105,226,56,174,165,105,10,107,242,90,11,219,109,134,154,121,63,84,129,4,20,73,96,204,197,29,17,105,64,78,146,143,52,233,55,158,214,191,243,14,200,224,230,62,51,51,190,24,191,95,65,216,69,139,214,41,228,52,89,100,235,231,215,142,99,227,217,56,229,58,56,20,193,204,79,55,163,157,189,87,197,128,61,20,112,130,10,221,138,83,242,115,254,155,156,228,17,181,0,195,255,224,110,149,60,238,252,67,235,69,145,131,166,4,235,107,164,223,101,2,116,29,180,54,240,22,208,113,245,134,206,18,77,209,223,52,214,125,119,218,60,127,2,237,208,2,96,221,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c9a4d829-6614-4e72-91b0-9433556c337c"));
		}

		#endregion

	}

	#endregion

}

