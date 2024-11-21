namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ReportGeneratorConfigurationSchema

	/// <exclude/>
	public class ReportGeneratorConfigurationSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ReportGeneratorConfigurationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ReportGeneratorConfigurationSchema(ReportGeneratorConfigurationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bd36e74f-9114-4b76-b9c4-17f67f21a2f8");
			Name = "ReportGeneratorConfiguration";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,145,207,106,2,65,12,198,207,10,190,67,192,107,241,1,106,233,65,45,210,67,97,113,219,7,24,103,227,54,101,118,102,72,178,135,69,250,238,205,254,65,168,45,122,9,228,155,31,95,146,111,162,107,80,178,243,8,155,226,173,76,39,93,109,83,60,81,221,178,83,74,113,49,63,47,230,179,86,40,214,80,118,162,216,172,175,122,227,67,64,223,195,178,218,99,68,38,111,140,81,75,198,218,84,216,6,39,242,8,7,204,137,117,32,156,38,190,26,99,124,110,143,129,60,248,30,191,67,207,108,43,171,151,17,5,167,140,172,132,54,167,24,108,198,247,201,114,223,82,53,57,190,99,147,131,83,124,173,224,12,53,234,26,164,47,223,127,249,151,168,164,93,233,63,177,113,31,247,241,3,250,196,213,77,110,71,67,76,142,187,39,81,182,8,31,32,29,191,44,187,231,105,185,194,177,125,135,34,203,127,46,75,140,213,120,239,208,143,234,111,209,180,31,107,58,163,143,209,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bd36e74f-9114-4b76-b9c4-17f67f21a2f8"));
		}

		#endregion

	}

	#endregion

}

