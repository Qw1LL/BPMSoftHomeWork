namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CalendarRemindCalculatorCustomerServiceSchema

	/// <exclude/>
	public class CalendarRemindCalculatorCustomerServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CalendarRemindCalculatorCustomerServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CalendarRemindCalculatorCustomerServiceSchema(CalendarRemindCalculatorCustomerServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("edcd46c2-7ae7-4652-8fc1-4857d18db187");
			Name = "CalendarRemindCalculatorCustomerService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("50529f8b-8504-4b8d-9a81-5bda32bd1be4");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,193,106,194,64,16,61,71,240,31,6,189,40,4,63,192,226,165,65,74,14,130,84,122,42,61,172,155,49,93,72,118,195,236,174,34,154,127,239,36,217,214,212,182,144,30,223,204,190,121,239,205,172,183,74,231,176,59,91,135,229,195,120,228,91,248,184,221,236,204,193,45,18,67,200,197,241,72,139,18,109,37,36,246,90,250,160,114,79,194,41,163,199,163,75,243,42,154,18,230,12,33,41,132,181,75,72,68,129,58,19,244,140,165,210,25,35,233,11,225,12,37,222,58,83,34,237,144,142,74,98,75,173,252,190,80,18,100,195,28,74,132,191,37,120,34,91,138,110,142,140,182,142,188,228,22,27,219,146,58,10,215,9,71,85,7,134,138,206,94,44,18,143,211,40,155,232,224,191,193,121,51,49,90,194,94,88,156,221,181,160,117,84,119,170,83,214,234,188,5,28,140,110,208,189,155,172,241,216,46,36,88,236,150,99,29,111,91,14,222,78,66,200,185,82,14,46,180,196,127,197,136,225,201,171,12,36,167,72,179,96,60,58,10,106,43,107,237,148,59,195,10,114,116,201,23,190,75,27,7,114,12,26,79,175,111,112,129,73,80,78,249,167,165,217,36,134,9,159,193,16,83,25,65,61,231,143,198,34,234,48,235,107,172,64,251,162,128,235,181,167,188,184,241,154,7,141,211,197,186,172,220,249,211,104,68,232,60,233,150,218,77,229,165,247,202,120,26,124,236,31,39,100,166,69,206,222,51,89,183,26,191,220,53,212,250,165,250,3,254,95,65,178,112,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("edcd46c2-7ae7-4652-8fc1-4857d18db187"));
		}

		#endregion

	}

	#endregion

}

