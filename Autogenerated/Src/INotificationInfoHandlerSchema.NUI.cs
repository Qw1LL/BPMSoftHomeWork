namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationInfoHandlerSchema

	/// <exclude/>
	public class INotificationInfoHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationInfoHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationInfoHandlerSchema(INotificationInfoHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6fc817aa-1460-4964-9d28-c837ff664b7c");
			Name = "INotificationInfoHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,82,75,75,195,64,16,62,183,208,255,48,228,212,66,73,176,23,15,214,128,138,212,28,212,66,17,15,226,97,147,157,173,3,251,8,187,155,66,17,255,187,147,196,98,219,40,44,11,59,124,243,61,102,214,10,131,161,22,21,194,237,250,113,227,84,76,239,156,85,180,109,188,136,228,236,100,252,57,25,143,154,64,118,11,155,125,136,104,174,206,222,140,215,26,171,22,28,210,21,90,244,84,49,134,81,89,150,193,50,52,198,8,191,207,251,119,97,35,122,213,170,41,231,161,246,174,194,208,113,89,23,73,81,213,105,134,244,208,156,29,117,191,61,151,193,105,140,56,77,94,73,107,40,17,60,26,183,67,9,66,49,43,92,166,23,139,116,49,7,178,108,75,72,104,194,63,153,210,226,233,72,237,65,88,169,209,39,179,119,22,169,155,82,83,197,20,7,155,39,208,194,42,247,3,103,44,15,134,239,65,202,174,176,238,147,97,24,6,27,13,146,245,149,90,120,97,192,242,58,174,19,98,161,144,228,191,147,5,167,32,126,224,25,219,50,235,154,254,230,224,248,190,144,3,22,146,1,148,119,166,221,222,141,52,100,95,44,197,19,166,157,35,9,125,204,54,240,180,184,183,141,65,47,74,141,203,193,56,114,158,21,175,210,244,142,230,112,12,94,53,36,243,118,13,173,143,89,251,111,190,38,99,62,223,221,38,33,207,115,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6fc817aa-1460-4964-9d28-c837ff664b7c"));
		}

		#endregion

	}

	#endregion

}

