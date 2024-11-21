namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DateTimeIntervalSchema

	/// <exclude/>
	public class DateTimeIntervalSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DateTimeIntervalSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DateTimeIntervalSchema(DateTimeIntervalSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("be7d9f97-3f60-46fc-bf01-100533e7371c");
			Name = "DateTimeInterval";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ccf14817-0a4a-4532-9be8-ee78c30bd143");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,144,203,10,131,48,16,69,215,17,252,135,1,247,186,111,75,23,125,44,186,40,20,236,15,164,58,74,192,76,36,153,20,164,248,239,53,62,160,32,45,116,17,152,201,156,156,155,132,164,70,215,202,2,225,112,187,230,166,226,244,104,168,82,181,183,146,149,161,56,122,197,145,240,78,81,13,121,231,24,245,118,232,19,139,245,48,132,156,173,47,24,54,112,146,140,119,165,241,66,140,246,41,155,56,26,168,44,203,96,231,188,214,210,118,251,185,15,160,131,194,16,75,69,104,211,5,203,62,184,214,63,26,85,128,155,228,107,181,8,87,90,217,199,141,156,165,101,224,1,15,230,181,122,113,47,210,249,192,40,20,53,114,120,156,16,110,46,250,175,57,103,42,255,73,9,248,143,140,176,18,164,114,250,213,56,234,223,26,4,53,63,149,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("be7d9f97-3f60-46fc-bf01-100533e7371c"));
		}

		#endregion

	}

	#endregion

}

