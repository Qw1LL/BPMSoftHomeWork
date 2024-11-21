namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Messaging.Common;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PostUserMessageUserTask

	[DesignModeProperty(Name = "SendForAll", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4b1606b826b2466b91351167317fea23", CaptionResourceItem = "Parameters.SendForAll.Caption", DescriptionResourceItem = "Parameters.SendForAll.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TargetUserIdsKey", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4b1606b826b2466b91351167317fea23", CaptionResourceItem = "Parameters.TargetUserIdsKey.Caption", DescriptionResourceItem = "Parameters.TargetUserIdsKey.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SenderName", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4b1606b826b2466b91351167317fea23", CaptionResourceItem = "Parameters.SenderName.Caption", DescriptionResourceItem = "Parameters.SenderName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "MessageText", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4b1606b826b2466b91351167317fea23", CaptionResourceItem = "Parameters.MessageText.Caption", DescriptionResourceItem = "Parameters.MessageText.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class PostUserMessageUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public PostUserMessageUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("4b1606b8-26b2-466b-9135-1167317fea23");
		}

		#endregion

		#region Properties: Public

		public virtual bool SendForAll {
			get;
			set;
		}

		public virtual string TargetUserIdsKey {
			get;
			set;
		}

		public virtual string SenderName {
			get;
			set;
		}

		public virtual string MessageText {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			MsgChannelManager channelManager = MsgChannelManager.Instance;
			if (!SendForAll) {
				List<Guid> targetIds = UserConnection.SessionData[TargetUserIdsKey] as List<Guid>;
				if (targetIds != null) {
					foreach(Guid id in targetIds) {	
						IMsgChannel userChannel = channelManager.FindItemByUId(id);
						PostMsgText(userChannel);
					}
				}
			} else {
				foreach(IMsgChannel userChannel in channelManager.Channels.Values) {
					PostMsgText(userChannel);
				}
			}
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

		public virtual void PostMsgText(IMsgChannel userChannel) {
			IMsg msg = new SimpleMessage() {
				Id = Guid.NewGuid(),
				Body = MessageText
			};
			msg.Header.Sender = SenderName;
			userChannel.PostMessage(msg);
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("SendForAll")) {
				writer.WriteValue("SendForAll", SendForAll, false);
			}
			if (!HasMapping("TargetUserIdsKey")) {
				writer.WriteValue("TargetUserIdsKey", TargetUserIdsKey, null);
			}
			if (!HasMapping("SenderName")) {
				writer.WriteValue("SenderName", SenderName, null);
			}
			if (!HasMapping("MessageText")) {
				writer.WriteValue("MessageText", MessageText, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "SendForAll":
					SendForAll = reader.GetBoolValue();
				break;
				case "TargetUserIdsKey":
					TargetUserIdsKey = reader.GetStringValue();
				break;
				case "SenderName":
					SenderName = reader.GetStringValue();
				break;
				case "MessageText":
					MessageText = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

