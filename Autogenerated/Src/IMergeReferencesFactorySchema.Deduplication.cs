namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMergeReferencesFactorySchema

	/// <exclude/>
	public class IMergeReferencesFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMergeReferencesFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMergeReferencesFactorySchema(IMergeReferencesFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3658508f-d4ef-48d0-af35-afb96664f468");
			Name = "IMergeReferencesFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,145,193,106,195,48,12,134,207,9,228,29,4,187,108,151,248,190,149,30,214,178,209,67,71,233,158,192,179,229,212,16,219,65,182,7,97,244,221,103,59,203,150,17,122,17,232,71,250,249,126,201,114,131,126,224,2,225,249,116,124,119,42,180,59,103,149,238,34,241,160,157,109,247,40,227,208,107,81,186,166,254,106,234,166,174,238,8,187,212,194,193,6,36,149,150,31,225,112,68,234,240,140,10,9,173,64,255,194,69,112,52,150,113,198,24,108,124,52,134,211,184,253,233,79,228,62,181,68,15,6,195,197,73,15,202,17,160,13,58,140,64,191,46,32,35,105,219,165,161,100,14,3,185,164,249,118,182,100,11,207,33,126,36,74,208,51,209,109,160,42,101,168,86,76,69,56,99,136,100,61,8,215,247,40,114,98,112,106,137,147,33,87,44,107,152,73,161,201,109,187,187,225,214,110,216,60,146,119,254,243,46,150,94,49,252,197,184,247,161,92,196,139,11,26,254,150,190,247,240,84,142,124,133,84,242,111,208,202,233,61,89,190,126,3,182,125,153,165,224,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3658508f-d4ef-48d0-af35-afb96664f468"));
		}

		#endregion

	}

	#endregion

}

