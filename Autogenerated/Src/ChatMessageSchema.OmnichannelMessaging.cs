namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ChatMessageSchema

	/// <exclude/>
	public class ChatMessageSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ChatMessageSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ChatMessageSchema(ChatMessageSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("21c9a1d7-90b7-429c-ad25-dd578ea023a7");
			Name = "ChatMessage";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,146,205,110,194,48,16,132,207,69,226,29,86,156,218,139,243,0,165,72,252,84,8,169,105,81,225,86,245,96,156,5,44,197,54,242,58,85,105,197,187,119,157,16,74,40,205,37,114,50,251,141,39,99,91,105,144,118,82,33,140,230,233,194,173,131,24,59,187,214,155,194,203,160,157,21,47,198,106,181,149,214,98,46,82,36,146,27,109,55,221,206,119,183,115,83,16,47,225,108,96,238,221,135,206,208,147,152,56,35,181,21,143,54,232,160,145,238,79,211,139,61,5,52,151,239,188,103,158,163,138,27,146,152,162,69,175,213,159,153,215,130,221,12,138,5,171,50,215,95,101,62,158,226,185,36,73,160,79,133,49,210,239,7,199,247,113,46,137,64,57,27,56,9,122,88,59,15,156,51,128,41,255,2,73,212,96,114,70,190,77,100,144,220,64,240,82,133,119,254,176,43,86,185,86,160,74,183,49,243,85,9,200,82,236,160,2,82,52,43,244,183,207,220,37,60,64,79,103,189,187,200,214,240,180,208,25,204,178,42,235,85,66,22,97,235,124,147,138,155,197,36,28,4,134,165,222,98,16,155,105,226,20,124,44,111,201,66,27,135,159,225,58,199,66,11,151,105,95,157,87,19,78,171,114,38,181,10,167,85,91,134,253,238,34,251,209,102,201,2,196,71,91,115,129,11,218,26,180,129,154,30,79,154,66,255,104,52,60,13,13,224,119,29,175,229,191,71,72,35,87,31,117,211,119,229,92,14,179,51,57,94,212,67,183,115,248,1,208,199,22,186,74,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("21c9a1d7-90b7-429c-ad25-dd578ea023a7"));
		}

		#endregion

	}

	#endregion

}

