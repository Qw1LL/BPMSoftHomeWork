namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MaxSizeTextColumnProcessorSchema

	/// <exclude/>
	public class MaxSizeTextColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MaxSizeTextColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MaxSizeTextColumnProcessorSchema(MaxSizeTextColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cf2e8673-fb8d-4ba0-9c62-446b24f54ef1");
			Name = "MaxSizeTextColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("560ff4eb-7ab5-4d8f-8733-4031e1e3144b");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,65,79,235,48,12,199,207,67,226,59,88,227,178,73,79,237,29,216,164,183,33,158,118,0,77,26,227,130,56,100,169,59,44,181,73,159,147,32,6,226,187,227,54,27,91,199,122,224,210,54,238,223,127,219,191,36,70,149,232,42,165,17,38,243,187,133,205,125,50,181,38,167,117,96,229,201,154,228,150,10,156,149,149,101,127,126,246,113,126,214,11,142,204,26,22,27,231,177,188,250,94,239,115,25,79,71,147,91,165,189,101,66,39,255,69,113,193,184,22,127,152,22,202,185,75,184,83,111,11,122,199,7,124,243,83,91,132,210,204,217,106,116,206,114,163,78,211,20,174,201,188,32,147,207,172,6,205,152,143,250,39,212,253,116,188,147,187,80,150,138,55,187,245,95,3,100,156,87,70,70,181,57,248,23,114,160,235,226,32,31,44,12,172,113,180,42,16,114,203,80,69,191,122,136,131,206,64,55,197,224,85,21,1,93,178,43,148,30,84,122,186,193,92,133,194,79,200,100,146,61,240,155,10,109,62,152,29,181,57,252,3,247,2,30,70,96,228,37,130,238,249,135,195,103,241,173,194,170,32,189,109,184,91,12,151,112,18,97,79,182,78,158,123,234,50,172,231,80,239,136,192,159,55,230,81,241,75,210,63,80,55,129,41,163,242,232,218,192,133,132,40,17,183,150,221,67,136,115,205,246,39,220,24,169,20,171,178,225,54,234,7,135,44,179,24,212,245,97,237,143,151,178,150,93,218,5,146,235,180,81,55,201,91,132,221,117,7,203,150,27,180,205,135,194,118,165,28,14,142,195,245,173,232,125,110,249,162,201,34,226,54,111,169,81,33,123,57,253,66,155,173,151,92,204,106,65,55,242,137,212,250,5,242,27,229,85,60,152,145,116,48,244,95,190,41,67,227,41,39,228,14,164,114,210,99,55,96,95,145,89,244,240,47,80,214,248,61,214,118,15,226,182,156,101,48,26,183,99,201,1,200,99,113,188,226,199,52,34,163,118,240,243,11,85,46,1,1,128,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cf2e8673-fb8d-4ba0-9c62-446b24f54ef1"));
		}

		#endregion

	}

	#endregion

}

