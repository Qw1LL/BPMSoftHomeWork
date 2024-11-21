namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MessageInfoSchema

	/// <exclude/>
	public class MessageInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MessageInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MessageInfoSchema(MessageInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9feca6c1-1d38-4545-9bd8-624db176b74f");
			Name = "MessageInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4a46c73e-2533-4fb4-8b08-c16580add3d1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,201,110,194,48,16,61,7,137,127,24,137,107,149,220,1,33,149,80,1,82,105,81,161,31,96,236,73,176,148,216,145,199,57,68,85,255,189,182,179,20,46,45,112,243,44,111,153,177,93,147,84,57,28,26,178,88,206,198,163,250,34,140,83,93,20,200,173,212,138,226,53,42,52,146,15,45,203,253,238,160,51,235,122,12,198,47,202,74,43,145,92,117,60,82,172,68,170,24,199,139,30,149,201,188,54,204,83,141,71,95,190,43,154,24,204,93,8,105,193,136,166,176,67,34,150,227,86,101,58,148,171,250,84,72,14,220,87,175,139,81,139,31,8,246,70,87,104,188,252,20,246,1,213,214,59,6,178,198,251,237,40,192,129,163,40,34,180,179,112,200,187,195,247,21,102,93,75,1,169,65,102,81,44,155,173,184,13,181,114,237,71,89,98,143,124,87,119,168,237,180,144,153,124,72,174,135,222,170,247,11,108,119,178,145,100,181,105,30,113,253,166,173,151,54,31,200,181,17,183,58,63,105,93,192,134,209,179,181,140,159,75,84,246,31,92,146,36,48,167,186,44,153,105,22,125,98,37,195,211,116,41,32,126,198,146,125,110,5,1,83,2,76,231,134,64,103,80,184,233,252,219,165,120,96,74,46,169,250,165,12,108,115,63,217,83,152,111,1,175,61,218,45,141,221,177,152,67,239,232,145,201,194,119,114,83,89,119,31,127,187,110,59,211,51,83,57,30,155,10,187,196,193,35,59,229,94,112,176,208,41,79,80,137,246,7,133,184,205,94,39,67,238,7,41,98,112,5,33,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9feca6c1-1d38-4545-9bd8-624db176b74f"));
		}

		#endregion

	}

	#endregion

}

