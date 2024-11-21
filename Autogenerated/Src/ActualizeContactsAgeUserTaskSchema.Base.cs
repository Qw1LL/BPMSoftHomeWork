namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ActualizeContactsAgeUserTask

	[DesignModeProperty(Name = "DateFrom", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b807605b93a34b3ab75e805e388c09bb", CaptionResourceItem = "Parameters.DateFrom.Caption", DescriptionResourceItem = "Parameters.DateFrom.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DateTo", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b807605b93a34b3ab75e805e388c09bb", CaptionResourceItem = "Parameters.DateTo.Caption", DescriptionResourceItem = "Parameters.DateTo.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsActualizeAllRecord", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b807605b93a34b3ab75e805e388c09bb", CaptionResourceItem = "Parameters.IsActualizeAllRecord.Caption", DescriptionResourceItem = "Parameters.IsActualizeAllRecord.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ChunkSize", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b807605b93a34b3ab75e805e388c09bb", CaptionResourceItem = "Parameters.ChunkSize.Caption", DescriptionResourceItem = "Parameters.ChunkSize.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MaxDegreeOfParallelism", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b807605b93a34b3ab75e805e388c09bb", CaptionResourceItem = "Parameters.MaxDegreeOfParallelism.Caption", DescriptionResourceItem = "Parameters.MaxDegreeOfParallelism.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ChunkProcessingDelay", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "b807605b93a34b3ab75e805e388c09bb", CaptionResourceItem = "Parameters.ChunkProcessingDelay.Caption", DescriptionResourceItem = "Parameters.ChunkProcessingDelay.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class ActualizeContactsAgeUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public ActualizeContactsAgeUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("b807605b-93a3-4b3a-b75e-805e388c09bb");
		}

		#endregion

		#region Properties: Public

		public virtual DateTime DateFrom {
			get;
			set;
		}

		public virtual DateTime DateTo {
			get;
			set;
		}

		public virtual bool IsActualizeAllRecord {
			get;
			set;
		}

		public virtual int ChunkSize {
			get;
			set;
		}

		public virtual int MaxDegreeOfParallelism {
			get;
			set;
		}

		public virtual int ChunkProcessingDelay {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			ContactActualizerAge contactActualizerAge = new ContactActualizerAge(UserConnection, ChunkSize, MaxDegreeOfParallelism, ChunkProcessingDelay);
			if (IsActualizeAllRecord) {
				contactActualizerAge.RunActualize();
			} else {
				contactActualizerAge.RunActualizeByPeriod(DateFrom, DateTo);
			}
			BPMSoft.Core.Configuration.SysSettings.SetDefValue(UserConnection, "LastAgeActualizationDate", DateTime.Now.Date);
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public override ProcessElementNotification GetNotificationData() {
			return base.GetNotificationData();
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("DateFrom")) {
				writer.WriteValue("DateFrom", DateFrom, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("DateTo")) {
				writer.WriteValue("DateTo", DateTo, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("IsActualizeAllRecord")) {
				writer.WriteValue("IsActualizeAllRecord", IsActualizeAllRecord, false);
			}
			if (!HasMapping("ChunkSize")) {
				writer.WriteValue("ChunkSize", ChunkSize, 0);
			}
			if (!HasMapping("MaxDegreeOfParallelism")) {
				writer.WriteValue("MaxDegreeOfParallelism", MaxDegreeOfParallelism, 0);
			}
			if (!HasMapping("ChunkProcessingDelay")) {
				writer.WriteValue("ChunkProcessingDelay", ChunkProcessingDelay, 0);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "DateFrom":
					DateFrom = reader.GetDateTimeValue();
				break;
				case "DateTo":
					DateTo = reader.GetDateTimeValue();
				break;
				case "IsActualizeAllRecord":
					IsActualizeAllRecord = reader.GetBoolValue();
				break;
				case "ChunkSize":
					ChunkSize = reader.GetIntValue();
				break;
				case "MaxDegreeOfParallelism":
					MaxDegreeOfParallelism = reader.GetIntValue();
				break;
				case "ChunkProcessingDelay":
					ChunkProcessingDelay = reader.GetIntValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

