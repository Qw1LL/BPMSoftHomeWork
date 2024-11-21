namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SocialMessageNotifierSchema

	/// <exclude/>
	public class SocialMessageNotifierSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SocialMessageNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SocialMessageNotifierSchema(SocialMessageNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f5268ed0-9504-4b95-a582-f1d27a5fc37c");
			Name = "SocialMessageNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("54cf5269-6f00-4e87-a6e6-8261561e21be");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,221,106,194,48,20,199,175,43,248,14,193,221,40,72,31,192,125,192,172,195,9,115,202,234,118,159,165,167,53,208,38,146,164,140,34,125,247,157,38,177,237,54,17,119,211,146,147,223,249,159,175,156,82,115,145,145,184,210,6,138,219,225,160,236,29,195,72,230,57,48,195,165,208,225,18,4,40,206,90,100,190,93,199,50,53,200,40,8,159,132,225,134,131,198,219,225,64,208,2,244,129,50,232,49,34,229,89,169,104,35,53,28,28,27,42,184,81,144,225,145,68,57,213,122,70,98,201,56,205,215,160,53,205,224,85,26,158,114,80,22,60,148,159,57,103,132,53,220,121,140,204,200,156,106,248,227,28,184,72,93,40,44,196,168,146,25,169,102,100,107,101,29,224,67,156,21,31,219,226,42,2,246,55,33,168,25,4,129,135,86,34,149,228,158,8,248,34,125,139,99,78,16,2,206,25,155,104,118,213,1,18,108,108,89,136,15,154,151,112,135,25,97,63,31,198,35,79,143,38,83,231,29,41,160,6,146,121,181,74,46,43,44,75,158,160,127,143,255,173,177,17,151,21,22,8,237,120,1,157,202,70,180,26,107,153,52,141,184,62,145,190,195,31,149,127,164,210,185,180,42,207,84,63,26,67,217,190,64,9,20,194,105,130,191,58,205,235,13,152,84,73,63,213,173,226,5,85,85,47,138,119,137,217,30,10,250,222,103,157,41,68,155,103,94,56,174,2,62,125,141,137,81,63,234,5,183,75,129,154,182,228,41,177,133,159,166,30,28,175,232,145,123,84,109,2,88,224,213,78,13,77,106,23,171,246,89,122,57,131,205,235,106,137,246,84,100,208,136,89,168,198,237,196,175,95,9,16,137,219,10,123,118,214,159,198,250,27,91,149,134,26,27,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f5268ed0-9504-4b95-a582-f1d27a5fc37c"));
		}

		#endregion

	}

	#endregion

}

