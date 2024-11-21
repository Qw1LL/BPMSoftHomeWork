namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DateColumnProcessorSchema

	/// <exclude/>
	public class DateColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DateColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DateColumnProcessorSchema(DateColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f8c37261-6156-4687-9016-d3e9e21442ee");
			Name = "DateColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1a247561-b87d-48fb-9e13-b6a8baa960d3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,147,193,78,227,48,16,134,207,32,241,14,163,238,165,149,80,114,103,105,37,90,4,234,97,87,149,160,123,65,28,92,103,82,70,74,236,48,182,145,42,196,187,239,56,110,129,164,217,149,224,146,216,147,127,254,241,124,158,24,85,163,107,148,70,152,175,126,221,217,210,103,11,107,74,218,6,86,158,172,201,110,168,194,101,221,88,246,103,167,175,103,167,39,193,145,217,194,221,206,121,172,127,190,239,63,114,25,135,163,217,141,210,222,50,161,147,239,162,248,193,184,21,127,88,84,202,185,11,184,86,30,23,182,10,181,89,177,213,232,156,229,86,150,231,57,92,146,121,66,38,95,88,13,154,177,156,142,162,250,158,234,126,198,40,159,29,82,92,168,107,197,187,195,254,202,0,25,231,149,145,62,109,9,254,137,28,232,88,25,100,193,2,192,26,71,155,10,161,180,12,77,242,139,29,196,66,160,219,42,240,162,170,128,46,59,84,200,63,149,120,184,198,82,133,202,207,201,20,146,54,246,187,6,109,57,94,246,206,55,57,135,223,130,27,166,96,228,37,130,129,174,39,147,71,49,108,194,166,34,189,63,226,128,10,18,177,1,6,146,44,215,36,207,15,194,210,155,231,16,233,11,232,85,235,156,20,223,128,123,68,183,13,44,24,37,201,117,25,11,3,81,34,126,178,61,182,140,56,143,121,166,72,163,88,213,45,170,233,40,56,100,105,196,160,142,83,57,154,173,101,47,23,115,8,100,151,121,171,110,147,247,240,6,10,142,215,29,27,232,186,78,132,234,70,57,28,247,195,113,238,79,222,246,84,209,20,9,108,151,178,212,104,144,189,204,183,48,102,235,37,23,139,255,97,158,75,165,47,32,150,110,84,26,193,68,54,24,122,150,53,21,104,60,149,132,252,15,146,50,204,233,44,96,95,144,89,244,112,27,168,104,253,254,68,187,123,113,91,47,11,152,206,186,177,44,242,235,171,210,191,219,135,144,208,116,131,111,127,1,32,136,117,197,89,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f8c37261-6156-4687-9016-d3e9e21442ee"));
		}

		#endregion

	}

	#endregion

}

