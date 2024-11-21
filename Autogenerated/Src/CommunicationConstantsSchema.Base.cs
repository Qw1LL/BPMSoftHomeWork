namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CommunicationConstantsSchema

	/// <exclude/>
	public class CommunicationConstantsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CommunicationConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CommunicationConstantsSchema(CommunicationConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e9a5adfa-2804-4de4-87ad-c536b6ee39e7");
			Name = "CommunicationConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("45b7d114-643d-4217-a8b2-b9950d3eddb7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,143,207,74,196,48,16,135,207,45,244,29,194,158,244,16,119,178,221,180,93,196,67,255,46,30,22,22,170,15,16,147,180,6,218,164,108,90,164,136,239,110,90,189,172,136,8,115,154,249,230,247,205,76,86,233,22,213,179,29,101,127,31,248,129,175,89,47,237,192,184,68,217,249,84,155,102,188,203,141,110,84,59,93,216,168,140,14,252,247,192,247,134,233,165,83,28,217,209,245,56,226,29,179,22,229,166,239,39,173,248,138,185,29,59,90,71,46,180,183,221,94,13,209,56,15,18,97,116,52,166,237,228,2,92,231,93,36,19,70,119,51,58,78,74,124,83,79,110,229,249,81,160,7,164,229,219,58,184,217,200,70,82,17,179,29,166,77,152,96,73,8,193,9,37,18,3,16,74,5,236,57,16,177,185,93,191,250,91,113,126,53,122,53,252,16,148,16,198,213,142,166,184,136,179,28,23,149,19,100,0,213,34,40,34,40,15,97,146,71,255,18,212,167,250,151,248,20,14,148,144,108,143,73,88,1,46,193,197,167,73,148,125,221,95,192,62,119,154,53,222,251,8,124,87,159,85,52,2,95,172,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e9a5adfa-2804-4de4-87ad-c536b6ee39e7"));
		}

		#endregion

	}

	#endregion

}

