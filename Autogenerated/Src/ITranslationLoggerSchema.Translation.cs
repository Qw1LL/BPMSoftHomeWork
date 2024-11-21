namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ITranslationLoggerSchema

	/// <exclude/>
	public class ITranslationLoggerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITranslationLoggerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITranslationLoggerSchema(ITranslationLoggerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fee74088-6ba4-462a-9370-fec3c8e1fb8d");
			Name = "ITranslationLogger";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5bb0d1bd-fb48-4884-8a1c-84058bcf48c3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,80,65,10,194,48,16,60,183,208,63,44,120,209,75,31,96,79,42,30,10,22,196,250,129,152,110,99,164,205,150,77,42,138,248,119,99,138,218,130,151,108,102,103,102,119,18,35,90,180,157,144,8,235,125,81,82,237,210,13,153,90,171,158,133,211,100,210,35,11,99,155,112,79,226,71,18,71,189,213,70,65,121,183,14,219,236,139,127,102,198,177,39,75,98,175,153,49,42,15,32,55,14,185,246,203,150,144,143,68,59,82,10,57,40,187,254,212,104,9,250,35,252,171,139,124,14,127,126,199,22,232,206,84,217,37,236,131,123,32,175,164,43,216,50,19,207,183,55,137,221,123,0,224,194,7,154,112,249,74,190,153,3,218,190,113,192,161,140,68,185,169,105,78,167,11,74,7,254,163,172,80,97,68,216,142,166,26,2,4,252,28,94,58,105,250,222,11,134,150,54,110,96,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fee74088-6ba4-462a-9370-fec3c8e1fb8d"));
		}

		#endregion

	}

	#endregion

}

