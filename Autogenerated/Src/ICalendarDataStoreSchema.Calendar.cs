namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ICalendarDataStoreSchema

	/// <exclude/>
	public class ICalendarDataStoreSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICalendarDataStoreSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICalendarDataStoreSchema(ICalendarDataStoreSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a242fa2e-8226-41ca-826d-a20b92e1d9d5");
			Name = "ICalendarDataStore";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("761f835c-6644-4753-9a3e-2c2ccab7b4d0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,145,177,110,131,48,16,134,103,144,120,135,83,166,116,129,189,165,12,77,151,74,173,84,149,188,192,5,14,98,9,219,232,108,82,161,40,239,94,99,112,66,212,78,93,44,249,238,255,124,159,109,133,146,76,143,21,193,203,231,71,169,27,155,238,180,106,68,59,48,90,161,85,186,195,142,84,141,108,146,248,156,196,209,96,132,106,161,28,141,37,249,148,196,174,146,101,25,228,102,144,18,121,44,150,253,23,245,76,134,148,53,128,80,45,39,64,141,22,193,88,205,148,6,46,91,129,253,112,232,68,5,66,89,226,102,18,122,11,179,95,29,88,78,92,190,47,224,251,72,76,176,135,199,91,63,95,37,253,81,231,40,114,235,47,53,95,120,215,88,155,155,148,80,141,102,57,223,245,202,172,181,230,74,143,140,18,148,123,172,231,77,96,55,69,24,11,181,203,143,105,158,249,152,167,78,90,212,126,214,150,169,113,186,1,122,152,95,237,111,183,18,79,4,213,17,85,75,6,116,115,133,254,111,118,231,228,243,76,118,96,101,138,114,168,42,50,126,140,238,105,249,237,60,11,237,41,127,208,186,243,78,219,123,255,232,146,196,151,31,44,205,5,56,57,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a242fa2e-8226-41ca-826d-a20b92e1d9d5"));
		}

		#endregion

	}

	#endregion

}

