namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ITermIntervalSchema

	/// <exclude/>
	public class ITermIntervalSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITermIntervalSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITermIntervalSchema(ITermIntervalSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a8612d32-9e85-4a58-a2a0-2c095913c7e1");
			Name = "ITermInterval";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f69a32ba-7e77-47bd-be6b-d095bbdc629a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,82,77,111,194,48,12,61,131,196,127,176,224,2,151,246,206,24,135,49,13,245,80,132,70,183,203,180,67,104,221,18,173,77,81,146,34,177,137,255,62,39,253,160,43,31,187,197,206,243,123,246,179,5,203,80,237,89,136,240,180,246,55,121,172,157,69,46,98,158,20,146,105,158,139,65,255,103,208,239,21,138,139,4,54,71,165,49,123,232,196,206,107,33,52,207,208,217,160,228,44,229,223,182,238,140,90,176,20,69,196,100,64,152,55,193,53,60,94,87,114,106,160,114,106,40,145,16,205,72,98,66,255,176,72,153,82,83,48,159,1,202,204,254,185,174,11,51,85,100,25,147,199,121,21,91,28,132,185,208,140,11,148,16,231,18,244,14,193,52,9,92,104,148,7,150,214,181,110,171,248,163,153,96,155,226,167,73,60,51,205,168,73,45,89,168,77,98,95,108,83,30,66,104,21,206,141,244,140,71,77,159,47,28,211,136,26,93,91,176,109,179,100,242,49,219,162,28,175,200,113,50,97,168,143,123,28,78,12,109,205,123,97,85,64,16,176,228,189,4,141,29,244,80,213,227,116,155,153,230,43,58,212,52,55,188,155,244,93,186,86,193,178,224,81,211,144,23,253,211,69,85,84,91,2,43,90,233,1,155,240,126,241,136,52,74,239,40,42,115,237,84,235,4,60,179,189,152,142,117,10,158,33,246,154,109,222,184,5,175,46,128,60,6,122,102,205,1,148,75,116,174,221,193,217,178,170,246,143,214,44,48,24,59,81,87,209,38,124,212,187,60,162,139,99,26,36,234,66,10,85,42,199,41,75,172,224,165,98,153,169,208,115,107,89,137,158,185,117,210,160,2,88,162,246,153,250,26,79,140,127,100,85,199,168,211,47,218,164,178,67,206,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a8612d32-9e85-4a58-a2a0-2c095913c7e1"));
		}

		#endregion

	}

	#endregion

}

