namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Globalization;

	#region Class: ChangeDuplicateStatus

	[DesignModeProperty(Name = "SchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f26d139184454cb380880be2264b24f9", CaptionResourceItem = "Parameters.SchemaId.Caption", DescriptionResourceItem = "Parameters.SchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DuplicateId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f26d139184454cb380880be2264b24f9", CaptionResourceItem = "Parameters.DuplicateId.Caption", DescriptionResourceItem = "Parameters.DuplicateId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "CurrentStatusId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "f26d139184454cb380880be2264b24f9", CaptionResourceItem = "Parameters.CurrentStatusId.Caption", DescriptionResourceItem = "Parameters.CurrentStatusId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class ChangeDuplicateStatus : ProcessUserTask
	{

		#region Constructors: Public

		public ChangeDuplicateStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("f26d1391-8445-4cb3-8088-0be2264b24f9");
		}

		#endregion

		#region Properties: Public

		public virtual Guid SchemaId {
			get;
			set;
		}

		public virtual Guid DuplicateId {
			get;
			set;
		}

		public virtual Guid CurrentStatusId {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var contactSchemaId = new Guid("16BE3651-8FE2-4159-8DD0-A803D4683DD3");
			string duplicateSchemaName;
			
			Guid oppositeStatusId = Guid.Empty;
			if (SchemaId == contactSchemaId) {
				duplicateSchemaName = "ContactDuplicate";
			} else {
				duplicateSchemaName = "AccountDuplicate";
			}
			if (CurrentStatusId == Guid.Empty) {
				var statusOfDuplicateSelect = new Select(UserConnection)
													.Column(duplicateSchemaName, "StatusOfDuplicateId")
													.From(duplicateSchemaName)
													.Where("Id").IsEqual(Column.Parameter(DuplicateId)) as Select;
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
					using (IDataReader dr = statusOfDuplicateSelect.ExecuteReader(dbExecutor)) {
						while (dr.Read()) {
							CurrentStatusId = UserConnection.DBTypeConverter.DBValueToGuid(dr.GetValue(0));		
						}
					}
				}
			}
			var oppositeStatusOfDuplicateSelect = new Select(UserConnection)
													.Column("DuplicateStatus", "Id")
													.From("DuplicateStatus")
													.Where("Id").IsNotEqual(Column.Parameter(CurrentStatusId)) as Select;
			
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = oppositeStatusOfDuplicateSelect.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						oppositeStatusId = UserConnection.DBTypeConverter.DBValueToGuid(dr.GetValue(0));		
					}
				}
			}
			var update = new Update(UserConnection, duplicateSchemaName)
								.Set("StatusOfDuplicateId", Column.Parameter(oppositeStatusId))						
								.Where("Id").IsEqual(Column.Parameter(DuplicateId)) as Update;
			update.Execute();
			CurrentStatusId = Guid.Empty;
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("SchemaId")) {
				writer.WriteValue("SchemaId", SchemaId, Guid.Empty);
			}
			if (!HasMapping("DuplicateId")) {
				writer.WriteValue("DuplicateId", DuplicateId, Guid.Empty);
			}
			if (!HasMapping("CurrentStatusId")) {
				writer.WriteValue("CurrentStatusId", CurrentStatusId, Guid.Empty);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "SchemaId":
					SchemaId = reader.GetGuidValue();
				break;
				case "DuplicateId":
					DuplicateId = reader.GetGuidValue();
				break;
				case "CurrentStatusId":
					CurrentStatusId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

