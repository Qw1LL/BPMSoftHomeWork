namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ObjectFilesCopySettingsSchema

	/// <exclude/>
	public class ObjectFilesCopySettingsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ObjectFilesCopySettingsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ObjectFilesCopySettingsSchema(ObjectFilesCopySettingsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8c876db7-b521-4b78-af16-6a8f941e5884");
			Name = "ObjectFilesCopySettings";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("8b1c57bf-1ff6-4af0-890b-4cc1ace5ccaa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,146,65,110,194,48,16,69,215,32,113,135,145,216,147,61,84,93,52,162,168,139,170,208,180,7,48,206,36,113,149,216,169,199,86,21,161,222,189,99,7,40,180,80,81,54,145,231,219,223,243,252,39,90,52,72,173,144,8,119,203,199,204,20,110,146,26,93,168,210,91,225,148,209,163,225,102,52,28,120,82,186,132,172,35,135,205,108,95,127,27,44,78,230,218,41,167,144,120,155,15,140,45,150,236,134,180,22,68,83,120,90,191,161,116,247,170,70,74,77,219,101,232,28,95,64,241,104,146,36,112,67,190,105,132,237,110,183,245,51,182,22,9,181,35,48,209,10,69,240,130,100,51,208,214,61,217,153,147,3,119,235,215,181,146,32,67,223,243,109,7,252,40,254,238,49,151,214,180,104,3,254,20,150,241,134,126,255,39,91,20,22,24,176,108,224,32,152,103,43,112,134,215,117,160,252,168,148,172,34,107,16,3,109,128,252,77,185,195,140,161,117,153,172,176,17,43,143,182,59,161,108,160,68,55,11,221,102,240,121,41,150,215,234,221,35,168,156,51,84,133,66,11,166,128,28,137,223,31,199,10,65,119,156,101,108,244,55,228,194,171,28,94,132,101,140,67,186,215,135,252,58,182,99,40,87,33,7,165,53,199,135,249,118,218,23,240,164,59,75,63,227,107,89,78,230,116,10,137,133,218,55,250,255,100,105,244,157,9,107,140,58,239,127,193,88,247,234,177,200,218,23,198,102,45,253,163,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8c876db7-b521-4b78-af16-6a8f941e5884"));
		}

		#endregion

	}

	#endregion

}

