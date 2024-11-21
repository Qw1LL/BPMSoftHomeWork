namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LocalizableStringHelperSchema

	/// <exclude/>
	public class LocalizableStringHelperSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LocalizableStringHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LocalizableStringHelperSchema(LocalizableStringHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("372a558a-906c-4891-8361-c65204ffc892");
			Name = "LocalizableStringHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,77,111,194,48,12,61,23,137,255,144,149,11,104,168,189,111,192,97,104,218,38,13,134,198,62,206,161,24,168,150,38,85,156,48,177,137,255,62,55,109,89,11,101,203,33,138,159,237,151,103,59,145,60,1,76,121,4,236,102,54,153,171,149,9,198,74,174,226,181,213,220,196,74,182,91,223,237,150,103,49,150,235,74,64,146,40,121,221,128,107,32,148,240,142,134,53,37,179,177,224,136,87,236,81,69,92,196,95,124,33,96,110,52,165,220,131,72,65,187,208,48,12,217,0,109,146,112,189,27,21,118,167,190,114,155,246,194,193,202,67,61,128,86,80,18,134,21,198,212,46,68,28,49,52,84,80,196,162,76,210,121,69,30,149,75,251,161,130,9,152,141,90,82,13,51,199,146,59,143,53,215,68,159,30,170,86,166,240,84,98,142,164,92,243,132,73,26,200,208,183,8,154,6,33,33,202,166,224,143,154,170,205,214,32,116,89,205,36,24,109,32,225,83,58,59,130,60,177,95,201,111,148,248,39,165,56,110,220,17,251,127,92,26,140,213,18,15,245,156,201,42,195,178,188,250,252,208,221,202,238,192,188,113,97,161,251,90,107,20,171,247,173,95,134,255,118,226,0,53,86,210,99,217,115,247,188,45,215,76,3,90,97,216,176,72,8,110,147,212,236,178,87,239,121,241,138,117,47,10,248,1,167,86,136,39,237,220,221,102,214,146,214,43,239,198,45,241,250,39,175,16,3,159,93,54,43,35,220,15,92,201,126,174,193,105,20,72,60,18,62,79,31,116,183,222,137,224,93,233,15,247,207,131,103,64,101,117,68,113,74,243,117,214,144,74,115,72,89,175,224,63,212,47,48,120,81,5,107,225,220,187,61,159,82,209,40,231,32,220,253,30,144,203,252,3,57,59,71,235,224,254,7,2,129,239,158,121,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("372a558a-906c-4891-8361-c65204ffc892"));
		}

		#endregion

	}

	#endregion

}

