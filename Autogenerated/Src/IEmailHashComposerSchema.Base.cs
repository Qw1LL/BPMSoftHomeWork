namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IEmailHashComposerSchema

	/// <exclude/>
	public class IEmailHashComposerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEmailHashComposerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEmailHashComposerSchema(IEmailHashComposerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c4ee924f-2761-4cad-9702-50f6fc4e2bb2");
			Name = "IEmailHashComposer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5e01e2a5-733f-47cc-a4c2-452cdff090f0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,221,147,77,110,194,48,16,133,215,69,226,14,163,176,105,165,42,217,67,200,162,128,40,11,84,84,218,3,24,103,18,44,57,118,228,159,74,168,234,221,59,137,33,52,192,162,234,178,155,72,30,191,25,127,239,217,81,172,66,91,51,142,240,180,89,111,117,225,226,153,86,133,40,189,97,78,104,53,28,124,14,7,119,222,10,85,194,246,96,29,86,147,139,53,233,165,68,222,136,109,188,68,133,70,240,179,230,60,212,32,85,169,62,50,88,146,22,86,202,161,41,232,224,49,172,22,21,19,242,153,217,253,76,87,181,182,104,90,101,146,36,144,90,95,85,204,28,178,227,122,99,244,135,200,209,2,171,5,20,218,0,54,173,64,30,44,43,17,246,52,131,54,57,147,220,51,217,48,197,167,65,201,143,73,181,223,73,193,65,156,16,110,18,220,145,115,250,118,192,107,116,123,157,219,49,108,218,238,176,121,201,216,22,224,21,157,55,202,118,56,93,66,129,76,50,135,57,236,14,71,248,154,25,186,4,66,177,13,236,53,109,168,180,42,80,164,156,70,158,0,233,154,84,24,26,101,169,69,4,110,176,152,70,239,253,173,36,35,151,214,49,197,49,78,147,118,198,237,145,45,74,148,45,46,137,174,154,76,240,118,84,94,57,164,134,147,162,105,89,45,148,175,208,176,157,196,212,58,67,79,34,131,37,186,38,105,180,247,125,88,232,219,122,132,238,82,230,111,47,33,171,135,201,111,98,207,177,96,94,186,22,238,95,38,30,247,67,14,193,54,185,206,131,243,38,179,191,135,59,66,149,135,55,223,174,191,194,111,219,43,82,237,27,128,102,240,74,57,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c4ee924f-2761-4cad-9702-50f6fc4e2bb2"));
		}

		#endregion

	}

	#endregion

}

