namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OmnichannelChatCloserSchema

	/// <exclude/>
	public class OmnichannelChatCloserSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OmnichannelChatCloserSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OmnichannelChatCloserSchema(OmnichannelChatCloserSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("495695b8-7d6f-4949-94fd-1777698ef8a2");
			Name = "OmnichannelChatCloser";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,83,77,107,194,64,16,61,71,240,63,12,122,81,144,228,222,250,1,77,173,88,144,74,75,207,101,141,163,174,36,187,97,103,227,7,197,255,222,205,174,166,73,20,241,54,51,153,247,230,205,188,141,96,9,82,202,34,132,151,249,236,75,174,180,31,74,177,226,235,76,49,205,165,240,63,18,193,163,13,19,2,99,127,134,68,108,205,197,186,217,248,109,54,188,140,76,8,161,84,248,92,100,95,71,210,152,24,142,56,198,40,39,32,127,130,2,21,143,76,143,233,106,43,92,155,42,132,49,35,130,39,40,209,135,27,166,195,88,18,42,219,25,4,1,244,41,75,18,166,142,195,115,254,137,169,66,66,161,9,88,29,10,14,11,91,185,240,47,240,160,132,79,179,69,204,35,136,236,224,155,99,141,156,233,187,92,140,15,24,101,90,26,21,94,190,101,33,249,141,99,188,204,53,207,21,223,49,141,86,165,151,186,4,114,26,35,79,18,55,208,35,252,168,34,118,139,123,109,20,75,199,116,206,207,180,51,212,27,249,48,239,4,117,181,210,249,54,202,141,101,194,157,27,178,74,218,5,187,130,167,80,103,74,148,85,193,104,4,157,114,62,0,129,251,218,184,78,141,173,155,27,237,157,30,94,200,158,220,125,173,219,105,11,246,238,87,70,238,55,40,128,107,224,4,154,39,152,187,121,109,167,171,164,76,177,4,132,121,195,131,86,85,107,107,152,31,6,162,162,224,247,3,219,125,27,108,99,212,168,168,53,156,23,177,95,198,156,31,208,142,43,157,177,24,118,146,47,193,189,21,188,111,66,15,166,175,220,70,70,123,159,180,50,63,74,15,228,98,107,62,15,225,127,242,197,172,29,51,186,171,182,15,110,24,95,243,198,90,227,85,113,190,61,240,248,144,114,133,203,28,78,157,123,22,186,106,181,120,250,3,97,207,238,43,33,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("495695b8-7d6f-4949-94fd-1777698ef8a2"));
		}

		#endregion

	}

	#endregion

}

