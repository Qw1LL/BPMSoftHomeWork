namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BaseQueueMessageSchema

	/// <exclude/>
	public class BaseQueueMessageSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseQueueMessageSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseQueueMessageSchema(BaseQueueMessageSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("04c48118-f957-49c4-a4ac-39fa34b1c523");
			Name = "BaseQueueMessage";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("097cd95f-c972-4e9b-ab53-9b1cae85bae7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,146,193,78,2,65,12,134,207,144,240,14,77,184,232,133,189,139,122,0,77,212,4,131,162,94,140,135,178,116,215,137,187,51,235,180,19,36,196,119,183,179,187,34,8,225,50,73,219,191,237,247,119,215,98,73,92,97,74,48,154,78,102,46,147,193,216,217,204,228,193,163,24,103,123,221,117,175,219,9,108,108,14,179,21,11,149,195,77,124,79,75,113,150,99,207,29,59,171,5,45,245,61,229,218,7,227,2,153,207,96,132,76,15,129,2,77,136,25,115,170,53,73,146,192,57,135,178,68,191,186,108,227,40,132,178,17,65,230,60,124,198,174,193,175,58,217,146,87,97,94,152,20,112,206,226,49,21,72,227,170,189,77,208,44,127,66,254,216,5,232,168,35,125,55,164,83,239,42,242,98,72,113,167,245,232,166,254,159,178,78,92,179,152,18,133,22,64,86,76,108,130,212,5,43,17,116,159,180,243,26,15,115,155,91,231,233,45,198,45,186,177,242,55,233,209,45,121,28,103,192,26,114,146,33,112,124,190,143,64,60,51,121,157,161,87,210,1,209,130,203,64,222,9,210,224,189,98,65,208,250,49,160,214,241,234,228,138,50,12,133,188,96,17,232,6,237,162,136,159,245,2,14,165,7,141,139,211,109,27,122,255,216,16,113,244,167,17,250,58,104,161,79,118,209,156,186,142,155,236,110,82,115,63,33,15,104,133,136,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("04c48118-f957-49c4-a4ac-39fa34b1c523"));
		}

		#endregion

	}

	#endregion

}

