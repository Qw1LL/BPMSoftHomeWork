namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MarketingAppEventListenerSchema

	/// <exclude/>
	public class MarketingAppEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MarketingAppEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MarketingAppEventListenerSchema(MarketingAppEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ab8c1b0d-1351-4fe6-8ded-74eb63abcdfb");
			Name = "MarketingAppEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,82,193,106,194,64,16,61,71,240,31,134,244,98,161,36,119,171,129,42,45,8,149,138,22,60,175,201,36,46,186,187,233,238,68,106,75,255,189,147,77,82,162,210,203,194,190,247,230,205,155,217,213,66,161,43,69,138,48,91,45,55,38,167,104,110,116,46,139,202,10,146,70,15,7,223,195,65,80,57,169,139,158,192,98,244,34,82,50,86,162,123,188,225,183,184,99,141,82,70,51,199,236,157,197,130,173,96,126,20,206,141,97,41,236,1,137,11,158,202,242,249,132,154,94,165,35,212,104,189,56,142,99,152,184,74,41,97,207,73,123,95,99,105,209,177,210,129,66,218,155,204,1,25,144,90,146,20,71,249,133,192,249,15,162,192,168,171,143,123,6,101,181,59,202,20,210,186,249,255,189,97,12,215,208,76,56,228,122,158,159,207,191,33,150,77,128,49,172,188,111,67,94,135,246,192,76,106,14,218,70,115,204,35,66,106,49,159,134,126,17,205,2,207,97,156,128,36,84,174,14,127,155,190,65,74,97,133,2,205,79,53,13,83,163,9,63,41,76,22,218,145,208,252,112,38,239,155,119,99,240,51,122,93,156,68,147,216,27,120,191,118,29,230,132,214,202,12,225,100,100,6,111,154,171,54,36,44,141,174,202,161,109,119,15,245,63,8,130,29,47,37,234,201,59,186,254,5,65,208,31,44,170,231,159,44,106,31,6,220,187,217,156,117,186,198,143,10,29,61,64,7,111,37,237,231,28,232,112,41,72,70,141,227,79,187,124,212,89,179,127,127,111,208,75,144,177,95,176,188,11,89,203,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ab8c1b0d-1351-4fe6-8ded-74eb63abcdfb"));
		}

		#endregion

	}

	#endregion

}

