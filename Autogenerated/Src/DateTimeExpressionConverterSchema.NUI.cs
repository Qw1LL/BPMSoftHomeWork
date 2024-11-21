namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DateTimeExpressionConverterSchema

	/// <exclude/>
	public class DateTimeExpressionConverterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DateTimeExpressionConverterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DateTimeExpressionConverterSchema(DateTimeExpressionConverterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3950f08c-8bf5-45b1-a16f-7b3f28203807");
			Name = "DateTimeExpressionConverter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e35bf724-6dee-44c8-b23b-34796602023a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,201,78,195,48,16,61,167,82,255,97,8,151,68,66,201,157,165,18,75,145,56,20,42,181,55,196,193,77,166,33,40,182,35,47,136,8,241,239,140,237,44,5,42,162,200,146,223,155,247,102,241,8,198,81,183,172,64,184,89,175,54,114,111,178,91,41,246,117,101,21,51,181,20,243,217,231,124,22,89,93,139,10,54,157,54,200,47,198,251,36,224,92,10,135,211,127,170,176,34,29,220,54,76,235,115,184,99,6,183,53,199,229,71,171,80,107,98,200,254,29,149,65,53,159,81,120,158,231,112,169,45,231,76,117,139,254,238,52,96,72,4,56,170,160,24,100,80,56,231,108,208,230,7,226,231,35,89,174,141,81,245,206,26,76,98,231,27,167,47,20,216,218,93,83,23,193,233,191,18,225,28,30,142,193,100,65,99,161,115,108,119,133,230,85,150,212,240,218,91,7,242,119,115,30,232,93,52,148,99,155,239,172,177,232,58,250,219,82,64,90,166,24,7,65,79,117,21,251,224,120,113,247,75,125,153,251,160,227,26,166,42,203,81,24,29,47,224,186,44,107,247,178,172,129,17,254,171,86,104,172,18,122,49,244,92,30,148,171,105,162,162,34,205,16,228,84,253,72,3,7,75,87,20,9,18,185,123,195,194,132,26,207,6,118,204,11,87,16,199,41,184,21,139,162,158,116,121,238,165,226,204,56,182,44,179,213,42,235,232,139,221,130,69,81,189,135,228,100,42,252,65,63,218,166,121,82,75,222,154,46,73,7,175,232,135,203,24,30,44,190,252,57,60,187,79,56,121,15,112,182,85,221,154,41,141,73,18,10,75,251,30,164,53,94,50,229,10,99,240,96,182,149,27,31,157,76,5,164,135,89,251,216,126,132,190,106,79,19,235,215,9,69,25,54,202,223,3,250,19,252,250,6,222,90,25,116,178,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3950f08c-8bf5-45b1-a16f-7b3f28203807"));
		}

		#endregion

	}

	#endregion

}

