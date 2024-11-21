namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MailingStateValidatorSchema

	/// <exclude/>
	public class MailingStateValidatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MailingStateValidatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MailingStateValidatorSchema(MailingStateValidatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3c9024bb-355f-4ec3-8193-b5436b64da82");
			Name = "MailingStateValidator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bbfdb6d8-67aa-4e5b-af46-39321e13789f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,147,223,107,194,48,16,199,159,43,248,63,28,62,233,75,251,7,172,246,65,25,67,152,48,236,216,235,136,237,85,3,105,218,229,135,67,134,255,251,46,73,235,234,212,177,135,64,114,201,125,142,239,247,46,146,213,168,91,86,32,44,94,214,121,83,153,120,217,200,138,239,172,98,134,55,114,60,250,26,143,34,171,185,220,65,126,212,6,107,186,23,2,11,119,169,227,39,148,168,120,241,240,251,205,51,151,31,20,164,112,146,36,144,106,91,215,76,29,179,238,188,193,86,161,70,105,52,152,61,194,129,9,94,50,211,40,168,104,213,140,11,71,210,134,25,212,192,138,162,81,165,11,152,198,191,86,86,160,142,123,114,50,64,183,118,43,120,1,133,96,90,195,58,96,114,71,121,235,11,208,35,39,39,106,21,63,80,28,20,178,178,145,226,8,171,71,105,107,84,108,43,48,93,221,72,37,177,27,170,155,193,187,47,31,164,93,105,243,129,37,65,9,205,37,9,144,26,225,147,155,61,232,22,11,94,113,44,97,107,185,40,81,57,1,215,10,66,164,101,138,213,32,169,49,243,137,43,183,8,41,147,236,149,228,95,216,227,205,32,164,39,166,137,79,244,156,206,138,155,38,76,239,8,236,202,120,102,183,159,129,183,43,10,170,97,62,188,163,222,27,231,137,158,206,92,251,163,211,31,158,116,69,8,225,58,120,175,179,63,38,169,190,199,255,177,200,227,38,153,87,227,39,168,155,39,146,116,225,137,79,84,104,172,146,58,75,147,126,55,176,235,192,149,177,76,92,76,195,96,0,232,159,208,204,211,16,244,114,166,67,35,131,172,222,177,64,239,198,37,206,209,253,152,169,59,192,60,243,242,226,51,36,228,157,77,116,235,244,13,142,197,48,16,150,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3c9024bb-355f-4ec3-8193-b5436b64da82"));
		}

		#endregion

	}

	#endregion

}

