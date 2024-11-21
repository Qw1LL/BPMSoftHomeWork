namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DuplicatesScheduledSearchParameterCronFactorySchema

	/// <exclude/>
	public class DuplicatesScheduledSearchParameterCronFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DuplicatesScheduledSearchParameterCronFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DuplicatesScheduledSearchParameterCronFactorySchema(DuplicatesScheduledSearchParameterCronFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bafd10b7-77ee-4318-8348-d2d3788c8c67");
			Name = "DuplicatesScheduledSearchParameterCronFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,219,78,219,64,16,134,175,141,196,59,76,13,66,107,20,173,144,122,87,10,149,154,112,80,69,104,36,67,185,94,214,19,123,85,103,215,221,3,106,132,242,238,29,175,157,56,73,85,81,46,231,244,205,252,255,174,22,11,116,141,144,8,95,103,211,220,204,61,31,27,61,87,101,176,194,43,163,249,4,139,208,212,74,198,232,240,224,245,240,32,9,78,233,18,242,165,243,184,56,223,139,249,157,210,191,40,73,233,35,139,37,205,192,184,22,206,125,130,73,143,65,151,203,138,160,53,22,57,10,43,171,153,176,116,131,71,59,182,70,95,11,233,141,93,70,64,19,158,105,2,156,167,221,18,100,139,121,47,37,105,239,29,46,49,154,96,218,211,53,51,171,94,136,18,247,36,77,23,128,108,235,160,180,135,137,88,126,159,63,33,254,204,43,99,253,61,145,239,80,151,190,130,11,248,216,169,75,142,80,23,29,183,143,251,37,83,244,149,41,218,21,241,252,126,195,142,20,231,109,235,216,13,250,246,216,171,223,141,69,231,104,150,181,173,73,226,43,245,63,66,161,120,179,37,131,168,63,121,17,22,92,44,145,48,71,34,222,30,229,249,166,255,124,143,241,160,22,248,30,70,219,63,48,10,34,118,222,18,227,74,135,5,39,31,126,136,58,160,99,126,217,160,153,179,205,234,174,47,203,58,95,248,88,56,255,121,175,120,201,214,213,167,10,45,50,194,175,233,151,91,154,249,173,112,215,181,40,135,122,6,39,39,48,116,127,184,128,61,50,191,55,26,215,240,28,107,148,126,151,190,9,248,131,201,227,147,178,244,38,205,120,30,158,187,23,102,103,163,127,254,164,140,134,30,155,6,45,203,178,206,28,139,62,88,13,199,233,25,188,14,70,243,169,210,129,60,94,237,36,111,77,176,148,250,2,167,148,142,187,248,55,163,52,75,71,233,104,203,225,108,5,167,105,164,175,254,254,180,125,110,59,181,250,3,189,22,240,10,14,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bafd10b7-77ee-4318-8348-d2d3788c8c67"));
		}

		#endregion

	}

	#endregion

}

