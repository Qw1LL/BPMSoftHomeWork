namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IntegrationToolsSchema

	/// <exclude/>
	public class IntegrationToolsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IntegrationToolsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IntegrationToolsSchema(IntegrationToolsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("519fed56-3e17-4fb7-a535-2ce6cf3931cb");
			Name = "IntegrationTools";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,91,75,195,48,20,126,206,96,255,33,250,32,21,164,251,1,94,64,231,21,17,196,77,95,37,237,78,103,32,75,106,206,137,90,100,255,221,52,137,157,235,138,47,165,57,249,174,73,28,74,189,228,179,6,9,86,249,28,190,232,120,60,114,97,118,241,248,48,51,21,229,83,99,161,27,38,224,212,40,5,37,73,163,49,191,1,13,86,150,131,188,252,74,147,36,9,232,119,199,163,218,21,74,150,188,84,2,145,223,105,130,165,21,173,198,220,24,133,252,123,60,98,181,149,31,130,128,91,16,11,163,85,195,159,17,236,212,104,29,205,248,171,219,90,123,85,54,153,236,144,60,160,146,75,247,87,252,181,220,153,181,228,214,50,134,234,25,245,150,109,54,182,4,138,63,204,2,57,59,152,134,173,253,103,189,165,220,47,154,245,180,183,69,14,163,69,79,154,159,242,1,175,201,100,160,150,135,106,248,28,56,131,172,167,121,120,188,19,21,201,182,55,120,3,116,75,84,63,193,187,3,164,71,97,197,10,8,44,206,194,118,118,41,3,95,216,230,36,18,142,18,241,140,191,13,209,82,165,15,97,253,21,161,83,228,35,70,66,126,181,170,169,9,93,100,197,179,65,54,223,243,133,156,82,73,37,200,96,145,90,198,68,23,78,170,5,216,44,52,98,172,240,109,185,196,107,105,177,181,34,235,32,110,84,254,69,138,242,141,103,173,70,253,235,192,165,254,55,55,11,217,146,94,55,99,27,131,74,40,76,14,108,205,193,47,58,16,22,249,121,93,131,94,100,251,7,251,41,94,56,243,173,189,46,74,126,15,205,47,234,15,245,180,163,14,113,94,132,114,144,0,81,122,115,202,69,62,55,233,214,34,34,0,210,243,141,176,205,43,88,255,0,90,187,32,176,12,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("519fed56-3e17-4fb7-a535-2ce6cf3931cb"));
		}

		#endregion

	}

	#endregion

}

