namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DCRepositoryReadOptionsSchema

	/// <exclude/>
	public class DCRepositoryReadOptionsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DCRepositoryReadOptionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DCRepositoryReadOptionsSchema(DCRepositoryReadOptionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e1294a92-73db-463a-b908-32d204d88db2");
			Name = "DCRepositoryReadOptions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ad993b20-8db8-48d6-9762-5a83fb4975c6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,77,110,194,48,16,133,215,32,113,135,81,216,86,137,96,89,66,22,133,45,45,162,185,192,52,76,82,75,142,109,217,78,171,8,113,247,78,254,64,208,32,177,177,228,153,247,60,207,159,173,176,36,103,48,35,120,219,239,62,117,238,195,141,86,185,40,42,139,94,104,21,110,107,133,165,200,184,232,73,249,217,244,52,155,78,42,39,84,241,148,62,220,233,35,73,183,154,77,217,54,183,84,176,4,54,18,157,123,133,237,230,64,70,59,225,181,173,15,132,199,15,211,28,224,90,105,20,69,16,187,170,44,209,214,73,191,191,170,65,119,82,200,181,5,203,86,7,158,74,35,209,83,56,152,163,59,119,236,107,67,6,45,150,192,1,105,29,164,139,32,73,123,23,100,77,164,48,142,46,162,199,182,101,144,112,18,41,50,28,119,153,234,139,155,93,239,209,29,227,116,241,2,233,50,129,223,111,178,4,233,162,161,49,132,105,145,13,157,101,207,169,153,215,54,120,2,63,1,175,23,156,123,171,13,89,47,136,153,238,219,225,93,255,158,225,164,41,244,1,32,151,88,140,242,131,45,229,88,73,15,63,40,43,2,225,248,12,98,64,150,242,117,112,13,121,189,76,248,174,21,5,209,101,194,13,249,129,198,152,17,254,151,28,156,160,32,191,2,215,44,103,88,143,26,219,137,221,151,154,204,73,29,59,14,237,254,220,125,180,155,226,249,15,191,221,112,165,227,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e1294a92-73db-463a-b908-32d204d88db2"));
		}

		#endregion

	}

	#endregion

}

