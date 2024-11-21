namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IDeduplicationSearchQueryBuilderSchema

	/// <exclude/>
	public class IDeduplicationSearchQueryBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDeduplicationSearchQueryBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDeduplicationSearchQueryBuilderSchema(IDeduplicationSearchQueryBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d41dcdd7-e798-4db1-b723-80024a0e025a");
			Name = "IDeduplicationSearchQueryBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,65,78,195,48,16,60,39,82,254,176,106,47,32,161,228,94,74,14,165,128,122,168,40,148,15,184,201,166,181,20,59,97,215,62,84,168,127,199,177,27,100,104,15,92,162,236,120,102,118,118,109,45,20,114,47,42,132,197,102,189,237,26,147,63,118,186,145,123,75,194,200,78,231,75,172,109,223,202,202,87,89,250,149,165,137,101,169,247,176,61,178,65,229,216,109,139,213,112,200,249,11,106,36,89,221,103,169,99,77,9,247,14,133,149,54,72,141,107,48,131,213,47,179,45,10,170,14,111,22,233,184,176,178,173,145,188,174,40,10,152,179,85,74,208,177,60,215,129,10,159,3,23,118,129,12,77,71,80,199,134,64,232,24,108,242,209,165,136,108,122,187,115,60,144,99,154,127,132,73,220,176,238,251,51,201,26,205,161,171,121,6,27,239,21,14,255,198,245,128,183,96,224,56,118,67,157,130,177,35,50,144,109,145,135,168,151,89,3,210,11,18,10,180,187,159,135,137,39,79,202,229,40,63,171,231,133,39,93,215,52,82,215,63,2,126,15,187,153,148,231,159,75,45,161,177,164,185,140,151,237,88,35,60,240,162,45,133,25,35,224,102,245,164,173,66,18,187,22,231,81,95,23,116,249,241,90,134,196,119,131,75,146,60,95,139,6,87,3,223,134,215,148,76,81,215,225,30,92,117,10,47,44,130,178,244,244,13,194,23,26,78,202,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d41dcdd7-e798-4db1-b723-80024a0e025a"));
		}

		#endregion

	}

	#endregion

}

