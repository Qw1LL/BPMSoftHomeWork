namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TranslationLoggerSchema

	/// <exclude/>
	public class TranslationLoggerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TranslationLoggerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TranslationLoggerSchema(TranslationLoggerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5a3f11c0-05c4-491f-b69b-c36875a97219");
			Name = "TranslationLogger";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5bb0d1bd-fb48-4884-8a1c-84058bcf48c3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,83,219,106,194,64,16,125,142,224,63,12,246,69,161,228,3,34,34,173,72,9,52,32,181,125,46,107,28,211,148,100,55,204,110,164,82,252,247,78,118,19,53,151,150,190,36,115,57,115,102,230,76,34,69,142,186,16,49,194,227,38,218,170,131,241,87,74,30,210,164,36,97,82,37,253,87,18,82,103,214,30,143,190,199,35,175,212,169,76,96,123,210,6,243,249,197,79,50,181,19,89,16,172,84,158,115,213,179,74,18,14,95,243,87,114,194,225,232,109,39,70,48,230,142,48,97,7,86,153,208,58,128,155,124,69,143,100,65,69,185,203,210,24,226,10,211,135,64,0,225,64,157,199,139,240,243,218,65,73,109,168,140,141,34,110,180,177,148,14,81,211,247,56,166,111,26,137,203,36,198,85,16,202,150,59,131,74,41,207,235,128,22,29,88,37,132,119,174,71,65,185,119,211,180,71,219,144,42,144,76,138,213,96,148,30,133,193,122,50,231,64,167,71,199,117,115,36,104,108,47,79,215,198,185,205,17,242,82,240,158,217,205,230,189,68,45,229,133,170,182,60,66,83,146,108,234,96,185,132,105,99,47,170,162,72,72,193,142,255,132,166,22,109,210,211,113,50,155,185,201,206,255,208,34,66,243,161,246,195,23,58,170,116,15,107,34,69,211,245,87,140,133,221,30,155,67,184,102,190,203,243,169,249,227,243,215,121,97,78,247,140,105,41,210,99,11,31,172,146,47,168,203,204,0,217,215,32,173,75,249,17,106,205,107,255,202,26,202,131,154,170,221,39,31,8,248,215,179,216,54,157,69,52,169,63,190,17,23,109,7,57,246,3,36,3,210,241,210,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5a3f11c0-05c4-491f-b69b-c36875a97219"));
		}

		#endregion

	}

	#endregion

}

