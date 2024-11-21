namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CheckedEmailResponseSchema

	/// <exclude/>
	public class CheckedEmailResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CheckedEmailResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CheckedEmailResponseSchema(CheckedEmailResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d3507f4f-1914-4114-8a7c-cc67545f380a");
			Name = "CheckedEmailResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,145,77,79,2,49,16,134,207,144,240,31,38,120,209,203,238,93,144,131,43,33,30,48,132,61,26,15,165,12,75,99,63,54,51,237,1,137,255,221,233,46,248,129,122,105,211,119,222,119,230,105,235,149,67,110,149,70,184,95,45,235,176,139,69,21,252,206,52,137,84,52,193,23,213,188,94,139,33,120,70,30,13,143,163,225,32,177,241,13,212,7,142,232,196,108,45,234,236,228,98,129,30,201,232,201,165,103,157,124,52,14,139,90,170,202,154,183,174,241,151,235,223,185,203,176,69,203,98,20,235,21,97,35,50,84,86,49,223,66,181,71,253,138,219,185,83,198,158,241,58,95,89,150,48,229,228,156,162,195,236,116,94,99,75,200,232,35,67,220,35,232,62,11,152,195,64,167,52,236,40,56,144,169,197,185,75,249,173,205,243,131,138,74,0,35,41,29,95,68,104,211,198,26,13,58,227,192,223,52,3,121,44,89,63,209,87,20,90,164,104,80,248,87,93,188,175,95,34,119,194,2,133,54,16,112,222,51,181,112,38,27,51,220,111,186,30,111,137,110,131,116,253,36,31,10,119,48,238,3,227,155,76,123,198,125,156,251,228,144,212,198,226,244,59,244,76,222,40,187,225,8,13,198,73,158,58,129,247,19,62,250,109,127,131,238,220,171,63,69,209,62,0,49,235,21,82,71,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d3507f4f-1914-4114-8a7c-cc67545f380a"));
		}

		#endregion

	}

	#endregion

}

