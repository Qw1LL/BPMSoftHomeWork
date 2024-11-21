namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ICalendarSchema

	/// <exclude/>
	public class ICalendarSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICalendarSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICalendarSchema(ICalendarSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("77b2d1ec-9baf-4fa5-be75-9d8f0bdfecfb");
			Name = "ICalendar";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("761f835c-6644-4753-9a3e-2c2ccab7b4d0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,146,203,106,195,48,16,69,215,14,228,31,6,127,64,188,111,157,44,154,130,49,180,180,52,134,66,119,138,61,74,68,101,201,72,114,131,91,242,239,29,57,126,64,94,144,210,133,23,163,185,215,115,174,70,138,149,104,43,150,35,60,188,62,175,52,119,179,165,86,92,108,106,195,156,208,106,182,100,18,85,193,140,157,78,126,166,147,160,182,66,109,96,213,88,135,229,253,81,77,78,41,49,247,54,59,75,80,161,17,57,105,72,21,69,17,196,182,46,75,102,154,69,87,191,97,101,208,162,114,22,242,110,6,8,197,181,41,15,131,123,91,116,228,139,93,83,97,197,12,43,65,17,251,60,204,194,69,218,83,62,178,38,142,6,193,96,177,136,76,90,13,185,65,62,15,59,218,116,41,181,66,182,150,24,66,228,165,85,189,150,34,39,8,135,134,251,27,25,126,27,103,11,184,131,209,0,164,14,118,91,52,8,89,219,24,199,83,199,223,211,73,228,246,32,65,74,235,182,8,162,160,224,130,11,52,62,231,105,208,195,201,23,147,53,14,101,118,201,55,202,146,90,20,144,22,208,18,4,27,116,126,69,193,190,221,193,21,34,109,192,246,100,78,148,8,223,148,243,54,176,115,182,81,149,81,247,131,154,41,237,23,250,226,136,50,176,127,193,45,88,3,154,115,123,27,109,113,234,26,69,233,147,176,206,111,156,182,249,66,162,127,225,220,33,126,2,189,186,74,50,119,227,213,94,178,158,33,126,39,105,214,41,175,96,251,111,255,11,92,42,7,200,249,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("77b2d1ec-9baf-4fa5-be75-9d8f0bdfecfb"));
		}

		#endregion

	}

	#endregion

}

