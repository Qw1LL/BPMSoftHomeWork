namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ChatContactSchema

	/// <exclude/>
	public class ChatContactSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ChatContactSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ChatContactSchema(ChatContactSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9dfeee86-228f-4670-b6f8-b56e2b8c7992");
			Name = "ChatContact";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,145,219,78,195,48,12,134,175,153,212,119,136,118,5,55,233,3,112,144,160,32,132,68,97,162,18,55,136,11,47,245,58,139,28,170,28,144,6,218,187,227,180,76,99,168,187,74,236,255,255,236,216,177,96,48,244,160,80,220,44,234,198,173,162,172,156,93,81,151,60,68,114,86,62,27,75,106,13,214,162,150,53,134,0,29,217,174,152,125,23,179,147,20,248,42,154,77,136,104,206,255,197,242,37,217,72,6,101,131,158,64,211,215,80,109,239,218,55,243,131,231,147,20,214,174,69,205,221,163,7,21,217,202,230,178,44,197,69,72,198,128,223,92,253,198,149,134,16,132,98,31,144,69,47,86,206,11,126,97,28,83,42,138,22,34,200,29,92,254,161,223,110,89,217,53,120,231,68,159,150,154,148,80,67,197,138,107,100,145,53,150,242,128,35,80,163,89,162,63,125,226,69,137,75,49,167,118,126,150,217,29,124,159,168,21,15,109,30,109,210,111,249,60,36,66,244,121,5,217,112,148,234,215,46,186,73,108,145,149,163,28,26,32,61,201,221,101,229,40,7,74,57,254,177,67,242,209,185,143,212,191,130,78,40,174,71,67,46,176,45,102,219,31,128,79,48,132,55,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9dfeee86-228f-4670-b6f8-b56e2b8c7992"));
		}

		#endregion

	}

	#endregion

}

