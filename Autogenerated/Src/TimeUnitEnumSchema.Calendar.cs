namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TimeUnitEnumSchema

	/// <exclude/>
	public class TimeUnitEnumSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TimeUnitEnumSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TimeUnitEnumSchema(TimeUnitEnumSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2edcc60c-6562-466a-beae-9495a7f738b1");
			Name = "TimeUnitEnum";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("761f835c-6644-4753-9a3e-2c2ccab7b4d0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,81,77,75,3,49,16,61,239,194,254,135,1,47,10,178,235,93,43,104,21,234,161,42,84,233,65,122,200,198,105,13,230,99,201,36,66,177,253,239,78,178,237,182,130,66,66,230,189,188,153,188,201,88,97,144,58,33,17,110,159,167,51,183,12,245,216,217,165,90,69,47,130,114,182,30,11,141,246,93,120,170,202,239,170,44,34,41,187,130,217,154,2,154,203,170,100,230,196,227,138,133,112,111,163,161,204,52,77,3,87,20,141,17,126,125,189,195,55,95,66,105,209,106,132,160,12,66,180,42,16,44,157,135,128,222,16,72,161,101,212,253,139,251,10,205,81,137,46,182,90,73,64,126,3,94,184,192,43,231,51,157,28,21,143,206,34,140,224,226,60,129,169,178,49,96,14,39,46,250,28,220,137,117,62,231,206,127,178,251,35,201,142,25,148,243,30,115,2,163,45,111,94,111,79,45,57,141,1,23,7,31,20,216,170,4,169,5,209,224,103,130,186,67,191,119,245,91,217,58,167,225,129,246,159,153,228,167,225,67,29,146,243,183,164,224,12,114,122,225,49,68,111,7,26,70,163,65,91,179,63,216,108,254,190,75,189,252,123,217,183,206,115,43,114,119,188,211,0,217,82,63,195,4,183,63,233,234,160,110,17,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2edcc60c-6562-466a-beae-9495a7f738b1"));
		}

		#endregion

	}

	#endregion

}

