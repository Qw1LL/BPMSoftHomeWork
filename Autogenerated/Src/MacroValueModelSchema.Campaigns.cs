namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MacroValueModelSchema

	/// <exclude/>
	public class MacroValueModelSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MacroValueModelSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MacroValueModelSchema(MacroValueModelSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e05ca81a-184e-4e98-bb5a-a27cf686c759");
			Name = "MacroValueModel";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,145,203,106,195,48,16,69,215,53,248,31,134,100,111,239,219,180,208,122,109,48,4,186,151,149,145,81,145,53,70,35,21,66,200,191,87,143,36,244,105,10,66,160,25,221,115,239,72,86,204,200,139,144,8,47,67,191,39,229,155,142,172,210,83,112,194,107,178,77,39,230,69,232,201,114,93,157,234,170,174,238,182,14,167,216,128,206,8,230,123,232,133,116,244,42,76,192,158,14,104,226,133,184,218,182,133,29,135,121,22,238,248,116,57,71,172,23,218,50,104,171,8,196,72,193,195,156,196,240,158,212,160,200,1,90,175,253,17,36,153,48,219,230,10,106,63,145,150,48,26,45,65,38,243,95,188,75,196,91,198,193,209,130,206,107,140,65,135,172,44,253,239,249,114,225,217,104,193,64,170,164,74,238,63,237,175,254,236,157,182,211,69,114,130,9,253,3,112,218,206,43,6,125,226,114,25,119,29,79,227,27,74,15,121,180,127,227,247,37,147,195,197,33,199,151,204,255,7,113,237,24,17,164,67,245,184,201,196,77,123,211,172,13,87,120,127,102,216,162,61,148,103,206,231,82,253,90,60,127,0,178,55,138,173,93,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e05ca81a-184e-4e98-bb5a-a27cf686c759"));
		}

		#endregion

	}

	#endregion

}

