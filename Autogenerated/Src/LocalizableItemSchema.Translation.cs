namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LocalizableItemSchema

	/// <exclude/>
	public class LocalizableItemSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LocalizableItemSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LocalizableItemSchema(LocalizableItemSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("19dfea59-9b33-4952-b46b-b44061ba40b3");
			Name = "LocalizableItem";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6d72ca66-8680-4c3f-b4a0-15ba7a19db7c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,93,107,131,48,20,125,182,176,255,112,97,47,27,72,125,239,62,96,107,97,200,86,86,104,217,123,170,87,9,211,68,242,81,112,163,255,125,215,196,170,117,32,133,190,72,114,239,201,57,55,39,71,193,74,212,21,75,16,94,55,235,173,204,204,124,41,69,198,115,171,152,225,82,204,119,138,9,93,184,245,205,236,247,102,22,88,205,69,14,219,90,27,44,31,186,125,127,88,225,240,12,33,8,115,171,48,167,13,44,11,166,245,2,62,100,194,10,254,195,246,5,198,196,226,32,149,221,23,60,129,164,65,140,1,176,128,248,223,153,128,134,161,111,207,45,133,54,202,38,70,42,146,216,56,58,143,104,169,71,12,119,132,110,38,255,198,58,132,118,125,96,133,197,16,222,44,79,33,177,133,177,10,227,52,132,21,51,184,227,37,66,41,83,158,113,76,63,69,8,123,41,11,224,250,197,26,153,163,64,178,11,211,123,104,28,10,130,119,172,225,169,97,110,12,10,130,175,134,150,10,142,222,151,150,39,118,42,119,74,190,181,238,68,168,215,43,250,102,124,46,72,136,209,8,14,118,108,173,65,145,122,119,206,173,218,40,89,161,50,28,71,70,69,81,4,143,218,150,37,83,245,243,169,64,119,153,119,205,104,216,109,125,109,189,107,238,236,111,159,163,241,195,86,138,31,104,38,208,109,225,56,33,227,60,186,72,200,187,121,133,84,235,61,240,20,133,105,220,85,211,186,46,14,253,131,93,161,236,159,54,113,127,6,164,116,106,90,120,117,202,221,32,18,87,168,175,208,160,42,185,64,13,60,243,97,164,244,0,27,198,103,122,32,151,249,113,4,47,155,104,148,69,95,61,47,30,255,0,195,50,195,67,140,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("19dfea59-9b33-4952-b46b-b44061ba40b3"));
		}

		#endregion

	}

	#endregion

}

