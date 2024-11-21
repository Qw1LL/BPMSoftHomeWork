namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FastReportAppEventListenerSchema

	/// <exclude/>
	public class FastReportAppEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FastReportAppEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FastReportAppEventListenerSchema(FastReportAppEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1c2eae70-2e46-4408-b770-04ce11ee4b96");
			Name = "FastReportAppEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6b2e55c4-93df-4e50-a678-d373851bda85");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,81,203,110,194,48,16,60,7,137,127,216,210,75,184,248,3,168,122,40,148,84,72,160,162,82,137,99,181,36,155,96,201,216,145,109,210,151,250,239,93,199,60,91,84,245,226,196,187,51,179,59,99,141,27,114,53,230,4,195,249,108,97,74,47,70,70,151,178,218,90,244,210,104,241,68,181,177,94,234,74,100,232,124,188,141,117,37,53,117,59,159,221,78,178,117,220,59,112,47,161,131,160,166,60,168,221,252,139,240,27,181,164,21,171,108,54,167,10,149,50,43,84,131,65,172,139,169,169,120,169,138,251,140,184,182,84,241,56,24,41,116,110,0,71,233,187,186,30,55,164,253,84,58,79,154,108,139,174,183,43,37,115,200,3,248,15,44,12,224,103,105,136,142,99,72,56,7,62,15,83,51,73,170,224,177,115,43,27,244,20,155,117,188,192,132,23,133,23,197,219,178,226,45,240,109,134,26,249,34,30,200,7,19,100,211,222,206,119,175,31,237,36,215,164,139,40,126,62,105,70,126,109,218,81,173,133,221,164,104,199,52,100,173,44,8,26,35,11,120,212,188,251,194,163,245,233,222,4,63,139,167,55,15,121,252,246,33,60,103,146,172,216,147,56,129,239,219,33,249,36,137,209,220,163,199,133,217,218,156,142,111,59,209,210,75,84,242,131,173,28,255,211,29,175,65,11,37,43,133,228,50,169,104,137,110,100,137,3,41,56,132,236,164,209,86,141,21,207,246,61,2,246,10,178,132,244,234,178,196,126,245,196,175,165,19,187,112,197,216,90,195,89,6,138,80,204,129,146,73,240,138,14,180,97,215,145,42,218,140,153,250,21,78,62,46,196,29,171,231,69,174,125,3,57,231,6,10,58,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1c2eae70-2e46-4408-b770-04ce11ee4b96"));
		}

		#endregion

	}

	#endregion

}

