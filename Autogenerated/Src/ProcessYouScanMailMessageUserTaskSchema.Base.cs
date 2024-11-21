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
	using System.Globalization;

	#region Class: ProcessYouScanMailMessageUserTask

	[DesignModeProperty(Name = "Topic", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "de19169edbb14ccba5e6e4c9bced6d71", CaptionResourceItem = "Parameters.Topic.Caption", DescriptionResourceItem = "Parameters.Topic.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SmmManagerName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "de19169edbb14ccba5e6e4c9bced6d71", CaptionResourceItem = "Parameters.SmmManagerName.Caption", DescriptionResourceItem = "Parameters.SmmManagerName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SmmManagerEmail", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "de19169edbb14ccba5e6e4c9bced6d71", CaptionResourceItem = "Parameters.SmmManagerEmail.Caption", DescriptionResourceItem = "Parameters.SmmManagerEmail.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SmmManagerNotes", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "de19169edbb14ccba5e6e4c9bced6d71", CaptionResourceItem = "Parameters.SmmManagerNotes.Caption", DescriptionResourceItem = "Parameters.SmmManagerNotes.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "PublicationDate", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "de19169edbb14ccba5e6e4c9bced6d71", CaptionResourceItem = "Parameters.PublicationDate.Caption", DescriptionResourceItem = "Parameters.PublicationDate.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SourceSiteURL", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "de19169edbb14ccba5e6e4c9bced6d71", CaptionResourceItem = "Parameters.SourceSiteURL.Caption", DescriptionResourceItem = "Parameters.SourceSiteURL.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MessageURL", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "de19169edbb14ccba5e6e4c9bced6d71", CaptionResourceItem = "Parameters.MessageURL.Caption", DescriptionResourceItem = "Parameters.MessageURL.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MessageTitle", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "de19169edbb14ccba5e6e4c9bced6d71", CaptionResourceItem = "Parameters.MessageTitle.Caption", DescriptionResourceItem = "Parameters.MessageTitle.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MessageBody", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "de19169edbb14ccba5e6e4c9bced6d71", CaptionResourceItem = "Parameters.MessageBody.Caption", DescriptionResourceItem = "Parameters.MessageBody.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MessageAuthor", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "de19169edbb14ccba5e6e4c9bced6d71", CaptionResourceItem = "Parameters.MessageAuthor.Caption", DescriptionResourceItem = "Parameters.MessageAuthor.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "InputYouScanMessage", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "de19169edbb14ccba5e6e4c9bced6d71", CaptionResourceItem = "Parameters.InputYouScanMessage.Caption", DescriptionResourceItem = "Parameters.InputYouScanMessage.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class ProcessYouScanMailMessageUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public ProcessYouScanMailMessageUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("de19169e-dbb1-4ccb-a5e6-e4c9bced6d71");
		}

		#endregion

		#region Properties: Public

		public virtual string Topic {
			get;
			set;
		}

		public virtual string SmmManagerName {
			get;
			set;
		}

		public virtual string SmmManagerEmail {
			get;
			set;
		}

		public virtual string SmmManagerNotes {
			get;
			set;
		}

		public virtual DateTime PublicationDate {
			get;
			set;
		}

		public virtual string SourceSiteURL {
			get;
			set;
		}

		public virtual string MessageURL {
			get;
			set;
		}

		public virtual string MessageTitle {
			get;
			set;
		}

		public virtual string MessageBody {
			get;
			set;
		}

		public virtual string MessageAuthor {
			get;
			set;
		}

		public virtual string InputYouScanMessage {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
						InputYouScanMessage = InputYouScanMessage ?? string.Empty;
						string[] parts = InputYouScanMessage.Split('|');
						Func<int, string> getPart = (i) => {
							if (i < 0 || i >= parts.Length) {
								return string.Empty;
							}
							return parts[i];
						};
						Topic = getPart(0);
						SmmManagerName = string.Concat(getPart(1), " ", getPart(2)).Trim();
						SmmManagerEmail = getPart(3);
						SmmManagerNotes = getPart(4);
						try {
							DateTime date = Convert.ToDateTime(getPart(5), System.Globalization.DateTimeFormatInfo.InvariantInfo);
							string[] time = getPart(6).Split(':');
							int hour = time.Length == 2 ? int.Parse(time[0]) : 0;
							int minute = time.Length == 2 ? int.Parse(time[1]) : 0;
							PublicationDate = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
						} catch
						{
							PublicationDate = DateTime.MinValue;
						}
						SourceSiteURL = getPart(7);
						MessageURL = getPart(8);
						MessageTitle = getPart(9);
						MessageBody = getPart(10);
						MessageAuthor = getPart(11);
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

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("Topic")) {
				writer.WriteValue("Topic", Topic, null);
			}
			if (!HasMapping("SmmManagerName")) {
				writer.WriteValue("SmmManagerName", SmmManagerName, null);
			}
			if (!HasMapping("SmmManagerEmail")) {
				writer.WriteValue("SmmManagerEmail", SmmManagerEmail, null);
			}
			if (!HasMapping("SmmManagerNotes")) {
				writer.WriteValue("SmmManagerNotes", SmmManagerNotes, null);
			}
			if (!HasMapping("PublicationDate")) {
				writer.WriteValue("PublicationDate", PublicationDate, DateTime.ParseExact("01.01.0001 0:00", "dd.MM.yyyy H:mm", CultureInfo.InvariantCulture));
			}
			if (!HasMapping("SourceSiteURL")) {
				writer.WriteValue("SourceSiteURL", SourceSiteURL, null);
			}
			if (!HasMapping("MessageURL")) {
				writer.WriteValue("MessageURL", MessageURL, null);
			}
			if (!HasMapping("MessageTitle")) {
				writer.WriteValue("MessageTitle", MessageTitle, null);
			}
			if (!HasMapping("MessageBody")) {
				writer.WriteValue("MessageBody", MessageBody, null);
			}
			if (!HasMapping("MessageAuthor")) {
				writer.WriteValue("MessageAuthor", MessageAuthor, null);
			}
			if (!HasMapping("InputYouScanMessage")) {
				writer.WriteValue("InputYouScanMessage", InputYouScanMessage, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "Topic":
					Topic = reader.GetStringValue();
				break;
				case "SmmManagerName":
					SmmManagerName = reader.GetStringValue();
				break;
				case "SmmManagerEmail":
					SmmManagerEmail = reader.GetStringValue();
				break;
				case "SmmManagerNotes":
					SmmManagerNotes = reader.GetStringValue();
				break;
				case "PublicationDate":
					PublicationDate = reader.GetDateTimeValue();
				break;
				case "SourceSiteURL":
					SourceSiteURL = reader.GetStringValue();
				break;
				case "MessageURL":
					MessageURL = reader.GetStringValue();
				break;
				case "MessageTitle":
					MessageTitle = reader.GetStringValue();
				break;
				case "MessageBody":
					MessageBody = reader.GetStringValue();
				break;
				case "MessageAuthor":
					MessageAuthor = reader.GetStringValue();
				break;
				case "InputYouScanMessage":
					InputYouScanMessage = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

