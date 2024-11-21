namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ConfigurationServiceResponseSchema

	/// <exclude/>
	public class ConfigurationServiceResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ConfigurationServiceResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ConfigurationServiceResponseSchema(ConfigurationServiceResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bbd217b6-97c9-4dc1-83e9-27fef9bede8a");
			Name = "ConfigurationServiceResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bbd880ce-b4f0-465b-921f-c6a2e08aa5ce");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,83,77,111,194,48,12,61,7,137,255,16,137,11,147,166,254,0,38,46,48,52,237,80,132,40,183,105,135,44,184,93,180,146,84,137,195,198,38,254,251,92,210,210,143,49,180,211,46,85,28,63,63,191,103,167,90,236,192,21,66,2,159,173,226,196,164,24,205,141,78,85,230,173,64,101,244,112,240,53,28,48,239,148,206,120,114,112,8,187,187,94,28,173,189,70,181,131,40,1,171,68,174,62,79,117,13,170,166,93,122,85,66,246,74,66,108,182,144,71,247,2,5,245,66,43,36,54,240,133,181,198,62,234,212,240,105,75,145,133,78,109,93,22,157,209,68,64,20,79,109,206,103,186,40,252,75,174,36,151,185,112,142,119,140,85,116,107,50,111,180,3,62,225,51,225,206,33,149,146,111,250,178,145,133,140,224,101,177,67,235,37,26,235,38,124,117,226,13,136,170,199,53,246,241,13,47,199,200,88,226,165,4,146,50,229,196,5,165,107,118,252,59,203,226,67,66,81,38,56,212,132,205,213,148,119,248,70,160,183,65,122,215,199,202,154,2,44,42,184,236,162,225,107,78,161,147,3,172,78,45,23,169,200,93,104,203,88,45,51,65,129,190,76,38,128,221,187,241,94,228,30,110,42,124,123,211,4,61,135,29,212,241,23,75,140,181,77,197,128,175,102,75,142,130,139,58,93,121,218,43,139,94,228,188,39,240,167,188,11,243,181,128,222,106,174,225,189,95,94,205,226,36,123,78,143,178,92,64,244,0,184,57,20,180,239,104,73,255,213,109,128,196,52,43,145,5,64,117,174,50,9,10,249,182,161,199,26,146,77,24,188,215,251,188,232,166,25,95,103,120,215,61,52,69,255,46,191,247,32,79,59,61,126,3,172,78,67,20,126,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bbd217b6-97c9-4dc1-83e9-27fef9bede8a"));
		}

		#endregion

	}

	#endregion

}

