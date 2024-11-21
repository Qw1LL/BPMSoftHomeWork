namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IDuplicatesRuleRepositorySchema

	/// <exclude/>
	public class IDuplicatesRuleRepositorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDuplicatesRuleRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDuplicatesRuleRepositorySchema(IDuplicatesRuleRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("724d927b-4ab0-492e-878f-0d68376bae8a");
			Name = "IDuplicatesRuleRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,84,77,79,194,64,16,61,99,194,127,152,192,5,19,211,222,17,123,80,12,33,145,104,64,126,192,182,157,226,38,237,110,221,15,147,198,240,223,157,221,149,143,22,68,47,94,154,206,219,153,55,111,222,108,43,88,133,186,102,25,194,253,203,98,37,11,19,61,72,81,240,141,85,204,112,41,162,41,230,182,46,121,230,163,254,213,103,255,170,103,53,23,27,88,53,218,96,117,219,137,169,186,44,49,115,201,58,154,161,64,197,179,67,206,161,133,194,243,104,180,50,225,140,78,135,10,55,196,3,115,97,80,21,36,113,12,243,233,183,24,212,75,172,165,230,148,221,248,228,56,142,97,162,109,85,49,213,36,223,241,33,25,148,45,17,80,24,110,26,80,251,74,224,59,234,104,71,17,31,113,212,54,165,250,67,82,171,61,17,30,75,232,145,51,244,220,139,94,160,121,147,185,30,195,139,39,9,135,93,145,30,88,162,177,74,104,40,185,54,32,11,200,219,170,181,147,118,170,45,32,53,83,172,2,65,59,188,27,88,141,138,118,39,130,251,131,100,77,49,100,123,0,10,169,104,244,119,139,218,68,147,216,87,158,39,202,88,246,134,126,15,131,100,25,10,192,99,160,29,120,90,172,194,4,201,83,103,2,215,213,143,0,185,145,84,182,203,115,133,243,71,97,43,84,44,45,113,210,118,117,250,250,156,192,12,77,27,213,163,117,107,62,104,143,123,227,56,137,245,97,175,61,72,246,175,215,183,127,176,223,93,69,186,35,29,247,33,109,192,242,252,31,118,112,113,5,60,39,235,93,123,106,253,163,221,157,235,221,49,120,218,53,213,121,250,139,137,48,163,89,169,231,69,195,86,236,131,58,254,209,16,90,252,32,249,113,130,182,226,84,202,18,214,117,78,154,71,167,234,137,105,39,107,136,34,15,159,153,143,183,225,111,209,2,183,95,31,240,57,24,216,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("724d927b-4ab0-492e-878f-0d68376bae8a"));
		}

		#endregion

	}

	#endregion

}

