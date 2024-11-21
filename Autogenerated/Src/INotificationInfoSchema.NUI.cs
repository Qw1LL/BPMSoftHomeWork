namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: INotificationInfoSchema

	/// <exclude/>
	public class INotificationInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public INotificationInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public INotificationInfoSchema(INotificationInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("aee85563-7cba-4466-bec1-e9df72ba319c");
			Name = "INotificationInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,148,241,106,194,48,16,198,255,86,240,29,238,9,244,1,28,131,185,13,41,76,25,234,30,32,54,215,122,195,36,146,92,255,40,178,119,223,37,42,115,104,55,35,164,161,73,243,125,191,126,199,181,86,25,12,59,85,34,76,222,103,75,87,241,240,217,217,138,234,198,43,38,103,7,253,253,160,223,107,2,217,26,150,109,96,52,99,89,203,24,141,70,240,16,26,99,148,111,31,143,235,194,50,250,42,122,85,206,3,89,153,77,114,1,87,1,111,16,172,99,170,168,76,123,195,147,201,232,204,101,215,172,183,84,138,244,100,84,204,207,36,133,56,202,161,248,70,23,252,180,177,34,222,98,23,236,146,214,11,236,99,176,131,108,15,53,242,24,66,156,190,226,211,78,204,196,233,54,159,146,84,183,67,10,141,246,199,250,132,35,163,106,236,224,76,27,210,80,196,3,133,206,0,45,176,116,94,3,29,121,232,193,173,63,177,228,140,132,137,252,42,114,110,179,208,203,114,131,70,129,149,30,204,175,231,129,119,176,152,71,135,252,218,74,214,91,211,205,48,132,171,149,237,132,188,40,70,80,86,3,83,86,188,168,91,69,201,2,13,89,157,110,111,101,158,127,45,176,117,74,199,132,82,155,191,43,249,150,14,222,89,195,223,253,169,49,48,217,127,171,41,191,146,39,45,233,62,44,113,6,115,234,93,179,187,179,93,146,246,106,70,185,100,124,3,121,47,67,9,9,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("aee85563-7cba-4466-bec1-e9df72ba319c"));
		}

		#endregion

	}

	#endregion

}

