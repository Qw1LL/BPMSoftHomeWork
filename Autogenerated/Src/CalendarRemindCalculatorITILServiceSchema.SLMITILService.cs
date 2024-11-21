namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CalendarRemindCalculatorITILServiceSchema

	/// <exclude/>
	public class CalendarRemindCalculatorITILServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CalendarRemindCalculatorITILServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CalendarRemindCalculatorITILServiceSchema(CalendarRemindCalculatorITILServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("67ff7e01-713e-4dfe-9885-71eb157ffd86");
			Name = "CalendarRemindCalculatorITILService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,107,194,64,16,61,71,240,63,12,122,81,8,254,0,197,75,131,148,64,5,169,237,169,244,176,110,198,116,33,217,132,253,80,68,243,223,59,187,217,214,164,31,144,227,155,153,55,239,189,217,181,90,200,28,246,23,109,176,92,141,71,214,195,135,221,118,95,29,205,34,169,20,82,113,60,146,172,68,93,51,142,157,150,60,138,220,42,102,68,37,199,163,171,155,138,166,10,115,130,144,20,76,235,37,36,172,64,153,49,245,140,165,144,25,33,110,11,102,42,149,190,164,79,123,84,39,193,209,211,106,123,40,4,7,238,88,67,72,240,255,106,218,70,86,162,187,147,74,106,163,44,167,22,25,218,41,113,98,166,21,141,234,22,12,17,156,189,106,84,180,74,34,119,113,193,246,224,220,109,139,150,112,96,26,103,63,90,224,221,52,173,226,148,116,90,95,1,7,147,91,52,31,85,230,252,249,67,4,123,237,81,180,161,11,243,65,87,73,20,82,158,148,2,51,201,113,176,253,24,30,173,200,128,147,251,52,11,134,163,19,83,190,178,145,70,152,11,172,33,71,147,124,227,31,41,227,64,142,65,226,249,237,29,174,48,9,202,41,253,170,52,155,196,48,161,211,87,138,168,45,10,237,29,227,134,10,208,204,87,94,85,28,103,93,209,53,72,91,20,112,187,117,172,44,122,84,55,227,220,47,54,101,77,140,254,228,93,178,63,246,149,49,82,104,172,146,94,164,213,167,119,234,148,241,60,232,111,252,122,113,98,105,164,147,117,162,52,126,255,31,223,32,212,186,165,230,19,235,192,209,15,147,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("67ff7e01-713e-4dfe-9885-71eb157ffd86"));
		}

		#endregion

	}

	#endregion

}

