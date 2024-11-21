namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IDefaultValueManagerSchema

	/// <exclude/>
	public class IDefaultValueManagerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IDefaultValueManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IDefaultValueManagerSchema(IDefaultValueManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("823db1cb-37ea-4cab-bf5f-dc43956066ce");
			Name = "IDefaultValueManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("30ff16fc-9eaa-40ad-9611-33924da6f041");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,145,207,106,195,48,12,198,207,11,228,29,68,79,27,148,228,1,150,245,176,150,149,28,10,99,97,219,217,73,228,224,145,200,193,127,50,202,216,187,79,142,187,118,93,11,6,91,146,245,211,231,207,36,6,180,163,104,16,30,159,119,149,150,46,91,107,146,170,243,70,56,165,41,219,34,33,31,177,125,199,250,73,155,161,66,51,169,6,211,228,43,77,110,188,85,212,65,181,183,14,135,251,127,49,115,250,30,155,0,177,145,162,154,211,157,211,48,131,33,203,43,207,115,40,172,31,6,97,246,171,67,252,130,206,27,178,208,162,20,190,119,48,137,222,163,5,169,13,116,106,66,130,94,80,27,120,188,1,146,83,110,159,253,162,242,63,172,209,215,189,106,64,145,67,35,195,99,203,77,36,190,5,224,78,144,232,208,240,189,240,168,11,33,115,162,66,119,77,5,30,103,94,14,141,153,81,24,49,0,177,205,15,11,111,209,176,189,20,109,89,172,74,178,78,16,203,209,18,66,13,154,99,49,43,242,185,243,58,232,51,126,70,217,50,163,13,26,164,226,110,166,28,252,56,235,222,168,153,200,170,10,235,12,87,151,160,235,15,30,179,130,45,70,7,236,237,214,171,22,142,216,37,188,158,73,157,213,157,194,187,240,101,223,105,194,235,7,57,207,227,245,64,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("823db1cb-37ea-4cab-bf5f-dc43956066ce"));
		}

		#endregion

	}

	#endregion

}

