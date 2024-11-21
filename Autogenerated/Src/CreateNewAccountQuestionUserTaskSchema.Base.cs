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

	#region Class: CreateNewAccountQuestionUserTask

	[DesignModeProperty(Name = "CreateNewSocialAccountEvent", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "829b799ec3d44a82a4c560f17413f5e2", CaptionResourceItem = "Parameters.CreateNewSocialAccountEvent.Caption", DescriptionResourceItem = "Parameters.CreateNewSocialAccountEvent.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ControlClientID", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "829b799ec3d44a82a4c560f17413f5e2", CaptionResourceItem = "Parameters.ControlClientID.Caption", DescriptionResourceItem = "Parameters.ControlClientID.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SocialNetwork", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "829b799ec3d44a82a4c560f17413f5e2", CaptionResourceItem = "Parameters.SocialNetwork.Caption", DescriptionResourceItem = "Parameters.SocialNetwork.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DiscardCreationEvent", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "829b799ec3d44a82a4c560f17413f5e2", CaptionResourceItem = "Parameters.DiscardCreationEvent.Caption", DescriptionResourceItem = "Parameters.DiscardCreationEvent.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class CreateNewAccountQuestionUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public CreateNewAccountQuestionUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("829b799e-c3d4-4a82-a4c5-60f17413f5e2");
		}

		#endregion

		#region Properties: Public

		public virtual string CreateNewSocialAccountEvent {
			get;
			set;
		}

		public virtual string ControlClientID {
			get;
			set;
		}

		public virtual string SocialNetwork {
			get;
			set;
		}

		public virtual string DiscardCreationEvent {
			get;
			set;
		}

		private LocalizableString _windowCaption;
		public LocalizableString WindowCaption {
			get {
				return _windowCaption ?? (_windowCaption = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.WindowCaption.Value"));
			}
		}

		private LocalizableString _message;
		public LocalizableString Message {
			get {
				return _message ?? (_message = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.Message.Value"));
			}
		}

		private LocalizableString _createSocialAccount;
		public LocalizableString CreateSocialAccount {
			get {
				return _createSocialAccount ?? (_createSocialAccount = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.CreateSocialAccount.Value"));
			}
		}

		private LocalizableString _doNotCreateAccount;
		public LocalizableString DoNotCreateAccount {
			get {
				return _doNotCreateAccount ?? (_doNotCreateAccount = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.DoNotCreateAccount.Value"));
			}
		}

		private LocalizableString _doNotShowMessage;
		public LocalizableString DoNotShowMessage {
			get {
				return _doNotShowMessage ?? (_doNotShowMessage = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.DoNotShowMessage.Value"));
			}
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var script = @"
			BPMSoft.CustomMessage = function() {
				var windowCaption = '" + WindowCaption + @"';
				var msg = '" + Message + @"';
				var radio1Caption = '" + string.Format(CreateSocialAccount, SocialNetwork.ToString()) + @"';
				var radio2Caption = '" + DoNotCreateAccount + @"';
				var checkboxCaption = '" + DoNotShowMessage + @"';
			
				var controlClientID = '" + ControlClientID + @"';
				var createNewSocialAccountEventName = '" + CreateNewSocialAccountEvent + @"';
				var discardCreationEventName = '" + DiscardCreationEvent + @"';
			
				var showMessageAgain = true;
				var createNewAccount = true;
			
				var popupWindow = new BPMSoft.Window({
					name: 'rrc',
					caption: windowCaption, 
					resizable: false,
					width: 480,
					frame: true,
					height: 250,
					modal: true,
					frameStyle: 'padding: 0 0 0 0',
					closeAction: 'hide',
					//fitHeightByContent: true
				});
			
				function create () {
					var mainLayout = new BPMSoft.ControlLayout({
						id: 'mainLayout',
						direction: 'vertical',
						displayStyle: 'controls',
						width: '100%',
						layoutConfig: {
							padding: '5 5 5 5'
						},
						fitHeightByContent: true
					});
					popupWindow.add(mainLayout);
					addMessage(mainLayout);
					addRadioButtons(mainLayout);
					addCheckBox(mainLayout);
					var l = addButton(popupWindow);
				}
			
				function addMessage(mainLayout){
					var layout = insertLayout(mainLayout);
					layout.add(new BPMSoft.Label( { caption:msg } ));
				}
			
				function addRadioButtons(mainLayout) {
					var radioLayout = insertLayout(mainLayout);
					var radio = new BPMSoft.Radio({
						caption: radio1Caption,
						name: 'radio',
						checked: true
					});
					radio.on('check', function(o,value){
						createNewAccount = value; 
					}, this);
					radioLayout.add(radio);
			
					radio = new BPMSoft.Radio({
						caption: radio2Caption,
						name: 'radio'
					});
					radioLayout.add(radio);
				}
			
				function addCheckBox(mainLayout) {
					var checkBoxLayout = insertLayout(mainLayout);
					var checkbox = new BPMSoft.CheckBox({
						caption: checkboxCaption,
						name: 'checkbox'
					});
					checkbox.on('check', function(o,value){
						showMessageAgain = value; 
					}, this, null);
					checkBoxLayout.add(checkbox);
				}
			
				function addButton(mainLayout) {
					var layout = insertLayout(mainLayout);
					var btn = new BPMSoft.Button({ caption: 'OK' });
				//	btn.handler = this.onOkButtonClick.createDelegate(this);
					btn.on('click', onOkButtonClick);
					layout.setAlign('center')
					layout.add(btn);
				//	layout.displayStyle = 'footer';
					layout.edges = '1 0 0 0';
					return layout;
				}
			
				function onOkButtonClick(){
					var component = window[controlClientID];
					var signalName;
					if (createNewAccount){
						signalName = createNewSocialAccountEventName;
					} else {
						signalName = discardCreationEventName;
					}
					component.callPageMethod(
						'ThrowEvent',
							{
								formProxyArg: 'htmlForm',
								viewStateMode: 'include',
								signalName: signalName,
								showMessageAgain: showMessageAgain,
								createNewAccount: createNewAccount
							},	
						null
					);
					popupWindow.close();
				}
			
				function insertLayout(mainLayout) {
					var layout = new BPMSoft.ControlLayout({
						direction: 'vertical',
						displayStyle: 'controls',
						width: '100%',
						layoutConfig: {
							//padding: '15 15 15 15'
							padding: '5 5 5 5'
						},
						fitHeightByContent: true
					});
					mainLayout.add(layout);
					return layout;
				}
			
				return {
					show: function() {
						create();
						var mainLayout = popupWindow.items.items[0];
						var l = popupWindow.items.items[1];
						popupWindow.show();
						var height = mainLayout.getHeight() + popupWindow.header.getHeight() + l.getHeight();
						popupWindow.suspendEvents();
						popupWindow.setHeight(height);
						popupWindow.resumeEvents();
						popupWindow.doLayout(true);
					}
				}
			}();
			
			Ext.onReady(function() {
				 BPMSoft.CustomMessage.show();
			});
			";
			ScriptManager scriptManager = ((BPMSoft.UI.WebControls.Page)System.Web.HttpContext.Current.CurrentHandler).FindControl("ScriptManager") as ScriptManager;
			scriptManager.AddScript(script);
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public virtual void UpdateFiltersRightExprMetaDataByParameterValue(Process process, DataSourceFilterCollection filters) {
			foreach (var filter in filters) {
				if (filter is DataSourceFilterCollection) {
					UpdateFiltersRightExprMetaDataByParameterValue(process, (DataSourceFilterCollection)filter);
					continue;
				}	
				var dataSourcefilter = (DataSourceFilter)filter;
				if (dataSourcefilter.RightExpression == null) {
					continue;
				}
				if (dataSourcefilter.RightExpression.Type == DataSourceFilterExpressionType.Custom) {
					dataSourcefilter.RightExpression.Type = DataSourceFilterExpressionType.Parameter;
					if (dataSourcefilter.RightExpression.Parameters.Count == 2) {
						var parameters = dataSourcefilter.RightExpression.Parameters;
						var metaPath = parameters[1].Value;
						parameters[1].Value = process.GetParameterValueByMetaPath((string)metaPath);
						parameters.RemoveAt(0);
					}
					if (dataSourcefilter.SubFilters != null && dataSourcefilter.SubFilters.Count > 0) {
						UpdateFiltersRightExprMetaDataByParameterValue(process, dataSourcefilter.SubFilters);
					}
				}
			}
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("CreateNewSocialAccountEvent")) {
				writer.WriteValue("CreateNewSocialAccountEvent", CreateNewSocialAccountEvent, null);
			}
			if (!HasMapping("ControlClientID")) {
				writer.WriteValue("ControlClientID", ControlClientID, null);
			}
			if (!HasMapping("SocialNetwork")) {
				writer.WriteValue("SocialNetwork", SocialNetwork, null);
			}
			if (!HasMapping("DiscardCreationEvent")) {
				writer.WriteValue("DiscardCreationEvent", DiscardCreationEvent, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "CreateNewSocialAccountEvent":
					CreateNewSocialAccountEvent = reader.GetStringValue();
				break;
				case "ControlClientID":
					ControlClientID = reader.GetStringValue();
				break;
				case "SocialNetwork":
					SocialNetwork = reader.GetStringValue();
				break;
				case "DiscardCreationEvent":
					DiscardCreationEvent = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

