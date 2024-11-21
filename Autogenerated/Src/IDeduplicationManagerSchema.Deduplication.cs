namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IDeduplicationManagerSchema

	/// <exclude/>
	public class IDeduplicationManagerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDeduplicationManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDeduplicationManagerSchema(IDeduplicationManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f3e391f5-bea4-4635-974c-b28b77b1e29d");
			Name = "IDeduplicationManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,83,193,110,131,48,12,61,83,105,255,96,117,151,77,154,224,222,50,14,91,215,169,135,74,85,249,130,20,12,139,68,2,115,146,73,213,212,127,159,9,208,142,110,213,122,216,5,176,253,158,253,252,72,180,80,104,26,145,33,60,109,214,105,93,216,240,185,214,133,44,29,9,43,107,29,46,48,119,77,37,51,31,221,76,62,111,38,129,51,82,151,144,238,141,69,53,63,139,153,93,85,152,181,96,19,190,162,70,146,25,99,24,117,75,88,114,22,86,218,34,21,60,112,6,171,81,243,181,208,162,68,242,224,40,138,32,54,78,41,65,251,164,143,71,96,80,29,58,28,192,209,55,116,227,118,140,3,57,76,186,52,40,224,109,248,121,148,182,70,251,86,231,102,6,27,223,160,43,158,75,241,137,165,212,185,129,161,39,26,96,182,17,31,216,202,249,169,167,203,52,130,132,2,205,126,63,78,11,230,47,142,236,45,190,59,52,118,154,244,31,97,28,121,240,137,75,104,29,105,147,156,56,144,29,141,102,248,80,111,9,171,23,237,20,146,216,85,24,47,164,71,176,142,216,88,226,223,244,0,221,59,73,252,14,167,126,119,227,176,87,2,191,10,189,159,255,105,141,145,74,86,130,128,48,171,137,227,130,106,197,163,107,194,28,80,91,105,247,215,90,69,87,155,147,246,51,125,127,249,95,22,245,93,183,221,34,75,222,35,245,107,120,195,46,21,7,251,122,241,173,97,65,224,143,26,234,188,59,109,222,194,67,119,53,70,201,195,23,118,174,34,237,147,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f3e391f5-bea4-4635-974c-b28b77b1e29d"));
		}

		#endregion

	}

	#endregion

}

