namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AutoSubmittedHandlerSchema

	/// <exclude/>
	public class AutoSubmittedHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AutoSubmittedHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AutoSubmittedHandlerSchema(AutoSubmittedHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4504d36d-abab-4979-82a1-10f52e7b8f0e");
			Name = "AutoSubmittedHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,146,75,79,195,48,12,128,207,157,180,255,96,149,203,38,65,123,231,49,105,76,32,56,12,16,67,220,211,214,91,3,121,20,59,1,77,136,255,142,251,24,143,33,46,173,226,196,159,243,197,118,202,34,55,170,68,56,191,91,174,252,58,100,11,239,214,122,19,73,5,237,221,120,244,62,30,37,145,181,219,192,106,203,1,237,201,120,36,145,60,207,225,148,163,181,138,182,179,97,61,135,210,40,102,8,181,10,64,216,16,50,186,192,160,160,86,174,50,72,224,215,144,206,99,240,71,171,88,88,29,2,86,41,52,228,27,164,176,5,237,0,173,210,6,106,84,21,82,182,171,146,255,40,211,196,194,232,114,168,211,146,190,64,87,67,137,99,184,190,234,242,239,6,238,176,33,201,98,34,223,228,128,112,35,102,255,156,131,37,218,2,137,251,179,251,154,93,96,137,161,246,21,148,53,150,207,173,45,194,171,50,17,91,187,254,234,223,78,251,182,173,212,95,171,62,210,40,82,22,156,244,227,44,237,128,233,236,113,199,253,243,106,123,133,178,211,188,75,255,166,17,134,72,142,103,247,253,31,30,72,72,122,61,92,85,51,164,55,62,5,113,134,75,101,88,138,136,7,189,105,70,65,237,114,91,216,240,226,133,247,6,22,173,241,196,23,79,88,134,30,52,133,118,60,146,164,207,0,14,36,131,146,93,188,68,97,78,186,19,217,131,95,117,209,201,244,16,22,138,81,198,139,3,103,115,99,252,27,86,191,122,184,107,69,167,125,216,129,147,62,121,225,173,248,105,246,46,187,165,74,59,101,174,55,206,19,182,192,169,76,100,146,124,12,205,69,87,245,253,149,149,196,146,241,232,227,19,251,38,223,223,227,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4504d36d-abab-4979-82a1-10f52e7b8f0e"));
		}

		#endregion

	}

	#endregion

}

