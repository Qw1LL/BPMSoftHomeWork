namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IRemindingTextFormerSchema

	/// <exclude/>
	public class IRemindingTextFormerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IRemindingTextFormerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IRemindingTextFormerSchema(IRemindingTextFormerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("734bc083-96cd-481d-a4cd-ea2b71a900a5");
			Name = "IRemindingTextFormer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1a637eec-ed5e-4e5a-93be-edcf08166986");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,146,77,79,195,48,12,134,207,173,180,255,96,141,11,72,168,189,67,233,97,124,76,61,32,85,108,127,160,31,238,8,106,146,202,73,129,10,237,191,227,164,172,173,4,7,56,113,180,253,250,121,237,56,170,144,104,186,162,66,216,228,143,59,221,216,232,86,171,70,28,122,42,172,208,10,86,225,199,42,12,122,35,212,1,118,131,177,40,89,208,182,88,185,170,137,182,168,144,68,117,61,105,102,10,97,116,175,172,176,2,13,151,89,112,70,120,112,200,76,89,164,134,45,175,32,123,66,41,84,205,141,123,124,183,15,154,36,146,215,198,113,12,137,233,165,44,104,72,191,226,156,244,171,168,209,128,56,1,160,209,4,116,66,128,101,134,75,49,196,68,39,72,188,160,116,125,217,138,106,209,255,179,127,224,86,254,54,130,79,108,209,46,12,75,93,15,222,53,130,169,99,233,55,102,186,130,10,9,138,31,250,102,237,166,203,93,140,60,130,89,167,119,194,63,36,235,225,77,216,103,63,189,35,119,147,38,74,98,31,120,158,177,228,170,60,197,134,173,207,179,185,61,25,75,151,160,203,23,62,78,234,73,179,211,133,187,80,240,203,181,248,104,45,254,211,94,123,231,253,215,197,142,227,255,66,85,143,95,108,21,30,63,1,98,28,12,184,216,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("734bc083-96cd-481d-a4cd-ea2b71a900a5"));
		}

		#endregion

	}

	#endregion

}

