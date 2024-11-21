namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BaseMessageNotifierSchema

	/// <exclude/>
	public class BaseMessageNotifierSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseMessageNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseMessageNotifierSchema(BaseMessageNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dc1877d9-eed2-4af1-98c3-84cf7a260a2d");
			Name = "BaseMessageNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4a46c73e-2533-4fb4-8b08-c16580add3d1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,77,111,194,48,12,61,23,137,255,96,105,151,114,233,15,128,109,210,64,218,132,52,38,52,196,121,74,19,183,68,42,73,21,167,157,208,196,127,95,66,63,40,172,108,140,155,237,188,188,103,191,56,5,73,149,194,106,71,22,183,209,76,103,25,114,43,181,162,232,5,21,26,201,39,195,193,112,160,216,22,41,103,28,97,186,92,172,116,98,29,82,37,50,45,12,243,224,225,224,203,163,130,59,131,169,75,97,150,49,162,49,76,25,225,2,137,136,165,248,166,173,76,36,154,3,46,47,226,76,114,96,49,89,195,184,5,238,241,45,188,131,134,49,204,207,74,238,122,37,214,170,61,75,204,132,147,91,26,89,50,139,213,97,94,37,96,144,9,173,178,29,188,74,178,247,13,153,79,252,120,143,240,145,213,33,77,106,86,84,162,34,62,85,89,26,157,163,177,18,189,210,161,255,90,168,154,165,38,158,171,68,159,196,174,215,32,8,8,237,228,16,164,117,176,255,93,204,185,235,172,41,184,213,198,207,165,173,123,20,20,205,100,117,218,103,88,56,170,21,143,115,193,3,40,252,188,48,127,56,186,166,157,5,218,141,22,253,131,151,90,10,88,21,49,113,35,99,12,207,21,160,233,227,103,99,209,147,16,97,123,220,237,163,75,189,86,116,19,249,59,110,117,137,127,243,31,156,219,181,190,37,218,109,12,223,64,88,178,35,61,72,213,89,148,6,26,52,149,104,157,11,183,107,161,221,72,170,116,188,208,37,87,171,234,89,177,113,122,174,44,154,196,125,180,190,197,63,254,28,217,192,46,124,143,32,184,109,31,175,126,204,250,179,252,227,133,186,55,26,207,189,116,159,29,251,111,223,122,104,208,149,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dc1877d9-eed2-4af1-98c3-84cf7a260a2d"));
		}

		#endregion

	}

	#endregion

}

