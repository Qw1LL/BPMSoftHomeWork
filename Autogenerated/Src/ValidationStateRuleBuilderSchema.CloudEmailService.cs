namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ValidationStateRuleBuilderSchema

	/// <exclude/>
	public class ValidationStateRuleBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ValidationStateRuleBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ValidationStateRuleBuilderSchema(ValidationStateRuleBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ba59d1f0-c429-42e9-8b97-e960f4125c65");
			Name = "ValidationStateRuleBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bbfdb6d8-67aa-4e5b-af46-39321e13789f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,193,106,195,48,12,61,183,208,127,16,221,165,189,36,247,46,11,172,99,148,194,10,97,25,187,187,137,146,26,28,187,216,114,74,25,251,247,201,73,202,218,173,131,14,130,137,165,247,158,244,44,105,209,160,219,139,2,97,153,109,114,83,81,244,100,116,37,107,111,5,73,163,39,227,143,201,120,228,157,212,53,228,71,71,216,112,94,41,44,66,210,69,43,212,104,101,113,63,25,51,42,142,99,72,156,111,26,97,143,233,112,207,172,105,101,137,14,26,164,157,41,129,12,212,72,96,189,226,88,101,44,56,18,132,208,10,37,75,65,198,70,39,157,248,76,104,239,183,74,22,80,40,225,28,188,247,80,46,159,7,234,43,43,45,189,84,37,90,88,192,122,35,164,226,94,187,212,55,114,0,176,20,187,225,115,116,103,177,230,56,108,186,174,220,2,178,174,68,159,252,233,163,11,172,144,28,208,14,207,90,111,250,90,151,22,88,53,120,248,109,162,143,88,36,111,181,75,19,135,8,133,197,234,97,186,126,214,190,65,43,182,10,147,63,250,15,38,211,105,156,194,65,210,174,239,32,74,226,147,86,16,31,158,168,149,150,188,80,112,171,102,176,21,126,220,108,14,97,208,163,209,81,162,42,161,151,6,141,7,120,228,81,183,200,75,65,162,32,119,201,159,205,121,242,215,72,249,94,73,122,67,71,161,168,191,153,245,31,112,198,150,110,213,69,93,50,250,69,54,146,174,82,62,135,173,96,92,191,24,221,157,163,252,125,1,37,25,233,83,33,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ba59d1f0-c429-42e9-8b97-e960f4125c65"));
		}

		#endregion

	}

	#endregion

}

