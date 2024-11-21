namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ICalendarOperationProviderSchema

	/// <exclude/>
	public class ICalendarOperationProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICalendarOperationProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICalendarOperationProviderSchema(ICalendarOperationProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("612d2abe-2c2a-4f21-8270-8e0f51100801");
			Name = "ICalendarOperationProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("761f835c-6644-4753-9a3e-2c2ccab7b4d0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,213,84,77,107,219,64,16,61,199,224,255,48,248,148,64,144,126,64,29,65,234,148,98,72,154,208,164,205,161,244,176,146,70,206,146,253,16,251,225,34,66,254,123,102,37,173,228,218,9,54,129,28,114,18,187,154,121,243,222,211,27,41,38,209,214,172,64,248,122,115,117,171,43,151,44,180,170,248,202,27,230,184,86,201,130,9,84,37,51,118,58,121,154,78,142,188,229,106,5,183,141,117,40,191,108,157,169,83,8,44,66,155,77,190,163,66,195,139,177,230,85,248,241,117,156,115,199,37,254,82,220,193,217,62,66,73,44,37,16,130,73,211,20,230,214,75,201,76,147,245,231,159,88,27,180,168,156,5,6,69,223,8,186,198,14,11,106,163,215,188,68,147,196,254,116,3,160,246,185,224,5,112,229,208,84,193,160,101,28,125,29,1,110,250,126,170,14,230,236,112,104,47,206,203,146,166,175,153,240,8,186,2,71,172,193,19,109,11,78,67,201,28,6,29,144,55,35,65,174,42,109,100,39,119,128,221,164,214,221,212,204,48,9,138,62,224,217,44,226,204,178,72,178,29,148,204,211,182,234,245,166,150,211,44,251,29,30,187,149,6,157,55,202,238,0,198,251,80,120,17,233,147,200,227,225,16,201,156,6,243,58,229,39,221,71,250,108,14,185,62,98,179,236,46,146,250,104,75,255,92,231,86,11,116,248,247,16,131,119,214,38,50,62,212,251,118,79,9,110,244,182,100,141,253,207,236,127,136,143,64,251,93,11,170,123,151,221,133,23,253,194,241,181,222,227,96,152,102,23,218,43,50,253,135,151,57,210,194,86,45,135,54,14,171,158,239,1,230,6,33,91,230,94,114,235,230,195,30,95,176,38,27,12,184,15,19,222,202,240,72,106,143,153,33,179,15,184,17,225,67,253,162,95,10,215,165,165,160,81,123,127,120,91,227,144,70,11,69,96,181,37,51,80,38,46,49,20,246,120,249,77,121,73,50,115,129,243,40,113,25,126,108,20,144,44,142,11,210,142,158,167,147,231,23,211,233,16,211,20,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("612d2abe-2c2a-4f21-8270-8e0f51100801"));
		}

		#endregion

	}

	#endregion

}

