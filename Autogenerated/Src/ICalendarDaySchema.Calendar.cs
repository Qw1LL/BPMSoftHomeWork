namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ICalendarDaySchema

	/// <exclude/>
	public class ICalendarDaySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICalendarDaySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICalendarDaySchema(ICalendarDaySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("19a08bf9-19ad-47db-8c56-e2bfbacbcbb5");
			Name = "ICalendarDay";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("761f835c-6644-4753-9a3e-2c2ccab7b4d0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,203,106,195,48,16,60,59,144,127,208,177,189,216,247,54,228,208,20,130,161,47,72,66,206,138,181,54,34,178,228,74,171,6,83,242,239,221,117,236,16,66,125,241,77,218,157,217,25,143,214,86,214,16,26,89,128,120,249,122,223,184,18,211,149,179,165,174,162,151,168,157,77,87,210,128,85,210,135,249,236,119,62,75,98,208,182,18,155,54,32,212,207,119,119,98,26,3,5,211,66,186,6,11,94,23,132,33,84,19,15,70,23,66,91,4,95,178,86,62,140,125,149,173,120,162,171,113,22,228,193,0,129,89,38,201,178,76,44,66,172,107,233,219,229,80,96,176,43,197,9,224,152,94,65,217,45,138,16,159,229,158,250,140,237,79,221,188,164,2,100,191,73,18,250,195,185,115,246,191,208,224,78,40,137,176,213,53,140,202,93,218,87,194,181,48,65,244,195,89,113,114,254,200,129,42,250,210,198,187,6,60,182,35,218,7,231,140,200,3,177,246,61,105,130,230,64,69,246,220,61,207,143,52,97,68,241,77,7,92,244,140,188,199,46,197,93,33,76,177,177,179,250,59,146,1,5,22,117,169,193,243,51,115,6,216,54,99,217,175,163,86,252,202,91,130,236,114,53,69,118,13,216,169,12,169,115,10,35,106,93,197,3,70,111,195,146,247,240,150,179,200,134,14,67,149,163,109,7,30,222,71,195,11,241,240,120,249,19,200,206,249,15,78,48,89,140,115,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("19a08bf9-19ad-47db-8c56-e2bfbacbcbb5"));
		}

		#endregion

	}

	#endregion

}

