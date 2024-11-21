namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MailingResponseSchema

	/// <exclude/>
	public class MailingResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MailingResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MailingResponseSchema(MailingResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d3aa9b5b-0ffb-4cd9-a76c-7a7c5b382b5e");
			Name = "MailingResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6e206974-7c3f-4704-9c49-6b38b2d992b2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,203,110,194,48,16,69,215,32,241,15,35,177,79,246,128,88,64,43,132,4,85,68,150,85,23,142,51,73,173,218,113,228,71,85,64,253,247,142,243,160,80,40,106,55,81,124,125,231,206,201,76,42,166,208,214,140,35,44,146,109,170,11,23,45,117,85,136,210,27,230,132,174,70,195,227,104,56,26,14,188,21,85,9,233,222,58,84,211,31,103,170,144,18,121,176,219,104,133,21,26,193,175,60,59,95,57,161,48,74,233,150,73,113,104,210,201,69,190,177,193,146,14,176,148,204,218,9,108,153,144,84,184,35,44,10,196,198,18,199,49,204,172,87,138,153,253,28,58,33,49,250,93,228,104,161,54,186,70,227,4,189,234,2,220,43,66,230,229,27,160,162,36,176,88,229,129,195,116,121,81,31,23,247,121,36,60,63,48,199,232,195,157,97,220,189,144,80,251,76,10,14,60,32,93,19,13,218,161,156,200,147,19,192,4,146,166,178,189,191,192,238,5,138,241,210,5,210,14,45,16,93,35,181,76,91,84,25,154,64,212,35,101,90,75,72,61,231,72,100,71,40,209,77,41,136,30,159,119,122,46,206,230,225,152,243,246,127,61,87,94,228,144,54,133,235,252,207,77,87,232,104,33,38,24,45,224,7,199,58,236,252,151,206,93,167,199,222,118,246,118,163,95,231,182,206,132,213,238,80,137,102,146,27,126,72,27,105,169,115,188,83,183,126,172,188,66,195,50,137,179,54,99,14,79,218,137,66,240,230,191,220,112,251,157,115,115,202,99,90,93,187,252,230,220,170,151,34,105,95,27,186,58,60,93,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d3aa9b5b-0ffb-4cd9-a76c-7a7c5b382b5e"));
		}

		#endregion

	}

	#endregion

}

