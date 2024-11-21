namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SsoAppEventListenerSchema

	/// <exclude/>
	public class SsoAppEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SsoAppEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SsoAppEventListenerSchema(SsoAppEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("aebf3d9a-9819-4190-84a0-91aa0f7bd750");
			Name = "SsoAppEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,82,93,79,235,48,12,125,46,18,255,193,218,125,25,18,106,223,97,76,98,19,32,33,190,164,94,196,115,150,186,35,162,77,42,219,25,160,43,254,251,117,210,13,193,224,197,81,236,156,227,227,227,120,211,35,15,198,34,44,30,110,235,208,74,185,12,190,117,235,72,70,92,240,135,7,255,14,15,138,200,206,175,191,60,32,60,253,145,125,194,149,86,250,62,120,173,105,245,15,225,90,9,96,217,25,230,19,168,57,156,15,195,197,6,189,220,56,22,244,72,249,89,85,85,48,227,216,247,134,222,231,219,123,134,192,64,97,227,26,100,80,8,189,195,16,156,23,104,3,65,93,223,131,177,73,29,131,54,136,140,4,140,204,169,27,139,33,41,119,188,213,23,226,33,174,58,103,193,102,238,95,212,192,9,236,167,22,134,81,145,234,128,198,207,129,110,81,158,67,163,35,61,100,198,177,184,63,70,78,212,73,12,67,28,26,35,8,204,1,108,240,162,210,65,12,191,36,149,63,101,142,153,193,144,233,193,235,110,206,38,9,131,111,50,153,207,24,17,44,97,123,54,217,41,93,110,107,213,28,156,215,217,189,197,114,86,101,116,38,219,14,29,54,72,164,94,194,38,184,6,238,125,61,186,149,245,77,247,184,178,70,61,143,32,109,190,40,92,11,211,171,46,172,76,167,15,107,20,209,165,115,121,137,70,34,161,250,120,237,228,201,169,35,81,106,251,140,77,236,144,118,208,34,253,148,242,175,206,202,57,150,185,225,29,190,38,192,163,174,77,91,122,204,155,156,61,102,147,148,47,201,80,139,22,198,190,172,41,68,223,36,228,49,172,66,232,230,83,161,136,71,233,239,21,197,71,138,26,242,106,208,55,227,118,242,125,204,126,79,126,252,7,121,231,165,166,233,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("aebf3d9a-9819-4190-84a0-91aa0f7bd750"));
		}

		#endregion

	}

	#endregion

}

