namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ImapErrorMessagesSchema

	/// <exclude/>
	public class ImapErrorMessagesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImapErrorMessagesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImapErrorMessagesSchema(ImapErrorMessagesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a97a27d8-986d-4adc-b58a-66f3167f55a1");
			Name = "ImapErrorMessages";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,144,193,10,194,48,12,134,207,27,236,29,10,222,125,128,121,115,40,8,155,14,122,240,92,187,88,10,91,82,210,78,17,217,187,59,90,81,132,121,76,254,47,127,254,4,213,0,222,41,13,98,219,54,146,174,97,221,40,219,23,249,179,200,139,60,91,49,24,75,40,100,224,81,135,82,28,6,229,118,204,196,13,120,175,12,248,72,185,241,210,91,45,124,132,150,152,44,185,125,236,246,22,250,206,151,162,141,131,73,251,154,88,52,162,38,93,41,60,82,168,8,17,116,216,44,34,18,248,6,60,83,114,116,142,56,72,223,191,249,121,203,242,72,77,198,226,137,219,123,119,102,66,243,199,247,129,58,158,48,203,49,55,96,151,162,199,122,74,191,249,105,78,47,28,26,212,66,73,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a97a27d8-986d-4adc-b58a-66f3167f55a1"));
		}

		#endregion

	}

	#endregion

}

