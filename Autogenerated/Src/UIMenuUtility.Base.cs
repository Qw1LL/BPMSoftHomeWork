namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Reflection;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.UI.WebControls;
	using BPMSoft.UI.WebControls.Controls;

	#region Class: DynamicMenuConstructor

	public class DynamicMenuConstructor
	{

		#region Methods: Private 

		private static BPMSoft.UI.WebControls.Controls.MenuItem GetMenuItem(BPMSoft.UI.WebControls.PageSchemaUserControl page, string menuOwnerClientID,
				string name, string caption, ControlImage controlImage, string clickCode) {
			var menuItem = new BPMSoft.UI.WebControls.Controls.MenuItem();
			menuItem.CreatedByAjax = true;
			menuItem.EnableViewState = false;
			menuItem.Name = name;
			menuItem.UId = Guid.NewGuid();
			menuItem.Tag = clickCode;
			menuItem.Caption = caption;
			menuItem.Image = controlImage;

			return menuItem;
		}
		#endregion

		#region Methods: Public

		public static void ClientRemoveMenuItemByName(BPMSoft.UI.WebControls.PageSchemaUserControl page, string menuOwnerClientID, string name) {
			var script = string.Empty;
			script += string.Format("var targetIndex = {0}.getMenu().items.indexOfKey('{1}'); \n", menuOwnerClientID, name);
			script += "if (targetIndex != -1 ) { \n";
			script += string.Format(" {0}.menu.removeByIndex(targetIndex); }}\n", menuOwnerClientID);
			var scriptManager = ScriptManager.GetCurrent(page.AspPage);
			scriptManager.AddScript(script);
		}

		public static void SetComponentMenuItemClickSignal(BPMSoft.UI.WebControls.PageSchemaUserControl page, string CmpClientId, string signalName) {
			var script =
				"{0}.getMenu().on('itemClick', function(item, event, itemId, itemIndex) {{ \n" +
				"	var tag = item.tag; \n" +
				"	var pars = new Object(); pars.tag = tag; \n" +
				"	var parStr =  Ext.util.JSON.encodeObject(pars, 3); \n" +
				"	window.BPMSoft.AjaxMethods.ThrowClientEventWithParameters('{1}', '{2}', parStr); \n" +
				"}}, {0}.getMenu()); \n";
			script = string.Format(script, CmpClientId, page.Process.InstanceUId, signalName);
			var scriptManager = ScriptManager.GetCurrent(page.AspPage);
			scriptManager.AddScript(script);
		}

		// with specified Signal on click
		public static MenuItem ClientInsertAfterMenuItem(BPMSoft.UI.WebControls.PageSchemaUserControl page, string menuOwnerClientID, string TargetMIClientID,
				string name, string caption, ControlImage controlImage, string clickCode, string signalName) {
			var script = string.Empty;
			script += string.Format("var targetIndex = 1 + {0}.getMenu().items.indexOfKey('{1}'); \n", menuOwnerClientID, TargetMIClientID);
			script += string.Format("if ({0}.getMenu().items.get(targetIndex) && {0}.menu.items.get(targetIndex).id == '{1}' ) {{\n", menuOwnerClientID, name);
			script += string.Format(" {0}.menu.removeByIndex(targetIndex); }}\n", menuOwnerClientID);
			var menuItem = GetMenuItem(page, menuOwnerClientID, name, caption, controlImage, clickCode);
			if (!string.IsNullOrEmpty(signalName)) {
				menuItem.AjaxEvents.Click.SignalName = signalName;
				menuItem.AjaxEvents.Click.AjaxEventTargetControlID = menuOwnerClientID;
			}
			script += string.Format("window.{0} = {1};\n", menuItem.ClientID, menuItem.GenerateControlScript(true, null));
			script += string.Format("{0}.getMenu().insert(targetIndex, window.{1});\n", menuOwnerClientID, menuItem.ClientID);
			var scriptManager = ScriptManager.GetCurrent(page.AspPage);
			scriptManager.AddScript(script);
			return menuItem;
		}

		// with specified Signal on click
		public static MenuItem ClientInsertMenuItem(BPMSoft.UI.WebControls.PageSchemaUserControl page, string menuOwnerClientID, int index,
				string name, string caption, ControlImage controlImage, string clickCode, string signalName) {
			var script = string.Empty;
			script += string.Format("if ({0}.getMenu().items.get({1}) &&  {0}.menu.items.get({1}).id == '{2}' ) {{\n", menuOwnerClientID, index, name);
			script += string.Format(" {0}.menu.removeByIndex({1}); }}\n", menuOwnerClientID, index);
			var menuItem = GetMenuItem(page, menuOwnerClientID, name, caption, controlImage, clickCode);
			if (!string.IsNullOrEmpty(signalName)) {
				menuItem.AjaxEvents.Click.SignalName = signalName;
				menuItem.AjaxEvents.Click.AjaxEventTargetControlID = menuOwnerClientID;
			}
			script += string.Format("window.{0} = {1};\n", menuItem.ClientID, menuItem.GenerateControlScript(true, null));
			script += string.Format("{0}.getMenu().insert({2}, window.{1});\n", menuOwnerClientID, menuItem.ClientID, index);
			var scriptManager = ScriptManager.GetCurrent(page.AspPage);
			scriptManager.AddScript(script);
			return menuItem;
		}

		// with specified Signal on click
		public static MenuItem ClientAppendMenuItem(BPMSoft.UI.WebControls.PageSchemaUserControl page, string menuOwnerClientID,
				string name, string caption, ControlImage controlImage, string clickCode, string signalName) {
			var script = string.Empty;
			script += string.Format("if ({0}.getMenu().items.indexOfKey('{1}') != -1) {{\n", menuOwnerClientID, name);
			script += string.Format(" {0}.menu.removeByIndex({0}.getMenu().items.indexOfKey('{1}')); }}\n", menuOwnerClientID, name);
			var menuItem = GetMenuItem(page, menuOwnerClientID, name, caption, controlImage, clickCode);
			if (!string.IsNullOrEmpty(signalName)) {
				menuItem.AjaxEvents.Click.SignalName = signalName;
				menuItem.AjaxEvents.Click.AjaxEventTargetControlID = menuOwnerClientID;
			}
			script += string.Format("window.{0} = {1};\n", menuItem.ClientID, menuItem.GenerateControlScript(true, null));
			script += string.Format("{0}.getMenu().addItem(window.{1});\n", menuOwnerClientID, menuItem.ClientID);
			var scriptManager = ScriptManager.GetCurrent(page.AspPage);
			scriptManager.AddScript(script);
			return menuItem;
		}

		// with delegate Ajax on click
		public static MenuItem ClientInsertMenuItem(BPMSoft.UI.WebControls.PageSchemaUserControl page, string menuOwnerClientID, int index,
				string name, string caption, ControlImage controlImage, string clickCode, Action<string> onClickHandler) {
			var script = string.Empty;
			script += string.Format("if ({0}.getMenu().items.get({1}) &&  {0}.menu.items.get({1}).id == '{2}' ) {{\n", menuOwnerClientID, index, name);
			script += string.Format(" {0}.menu.removeByIndex({1}); }}\n", menuOwnerClientID, index);
			var menuItem = GetMenuItem(page, menuOwnerClientID, name, caption, controlImage, clickCode);
			menuItem.AjaxEvents.Click.Event += delegate (object sender, BPMSoft.UI.WebControls.Controls.AjaxEventArgs e) {
				var clickedMenuItemCode = e.ExtraParameters[0].Value;
				onClickHandler(clickedMenuItemCode);
			};
			/*menuItem.AjaxEvents.MenuItemClick.Event += delegate(object sender, BPMSoft.UI.WebControls.Controls.AjaxEventArgs e) {		
													var clickedMenuItemCode = e.ExtraParameters[2].Value;											
													onClickHandler(clickedMenuItemCode);
													};
			*/
			script += string.Format("window.{0} = {1};\n", menuItem.ClientID, menuItem.GenerateControlScript(true, null));
			script += string.Format("{0}.getMenu().insert({2}, window.{1});\n", menuOwnerClientID, menuItem.ClientID, index);
			var scriptManager = ScriptManager.GetCurrent(page.AspPage);
			scriptManager.AddScript(script);
			return menuItem;
		}

		// with delegate Ajax on click
		public static MenuItem ClientAppendMenuItem(BPMSoft.UI.WebControls.PageSchemaUserControl page, string menuOwnerClientID,
				string name, string caption, ControlImage controlImage, string clickCode, Action<string> onClickHandler) {
			var script = string.Empty;
			var menuItem = GetMenuItem(page, menuOwnerClientID, name, caption, controlImage, clickCode);
			menuItem.AjaxEvents.Click.Event += delegate (object sender, BPMSoft.UI.WebControls.Controls.AjaxEventArgs e) {
				var clickedMenuItemCode = e.ExtraParameters[0].Value;
				onClickHandler(clickedMenuItemCode);
			};
			script += string.Format("window.{0} = {1};\n", menuItem.ClientID, menuItem.GenerateControlScript(true, null));
			script += string.Format("{0}.getMenu().addItem(window.{1});\n", menuOwnerClientID, menuItem.ClientID);
			var scriptManager = ScriptManager.GetCurrent(page.AspPage);
			scriptManager.AddScript(script);
			return menuItem;
		}

		public static void SetMenuItemVisibility(BPMSoft.UI.WebControls.PageSchemaUserControl page, string menuItemClientID, bool value) {
			var script = string.Empty;
			script += string.Format("window.{0}.visible = {1};\n", menuItemClientID, value.ToString().ToLower());
			script += string.Format("window.{0}.actualizeIsVisible();\n", menuItemClientID);
			var scriptManager = ScriptManager.GetCurrent(page.AspPage);
			scriptManager.AddScript(script);
		}

		#endregion

	}

	#endregion

	#region Class: UIMenuUtility

	public class UIMenuUtility : IMetaDataSerializable
	{

		#region Consts: Public


		#endregion

		#region Constructor: Public

		public UIMenuUtility(UserConnection userConnection) {
			UserConnection = userConnection;
			if (string.IsNullOrEmpty(UserContextKey)) {
				UserContextKey = "UIMenuUtility";
			}
		}

		#endregion

		#region Properties: Public

		public string LoginMenuItemCaption {
			get; set;
		}

		public string LogoutMenuItemCaption {
			get; set;
		}

		public string NotAuthorizedCaption {
			get; set;
		}

		public string UserContextKey {
			get;
			set;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection {
			get; set;
		}

		protected BPMSoft.UI.WebControls.PageSchemaUserControl _page {
			get; set;
		}

		#endregion

		#region Methods: Protected

		protected virtual object ReadSerialazebleObjectValue(DataReader reader) {
			object value = null;
			reader.ReadInto();
			string typeFullName = string.Empty;
			if (string.Equals(reader.CurrentName, DataWriter.SerializableObjectTypeFullNamePropertyName)) {
				typeFullName = reader.GetStringValue();
			}
			reader.Read();
			if (string.Equals(reader.CurrentName, DataWriter.SerializableObjectValuePropertyName)) {
				value = reader.GetSerialazebleObjectValue(System.Type.GetType(typeFullName));
			}
			reader.ReadOut();
			return value;
		}

		protected void ApplyPropertiesDataValues(DataReader reader) {
			//base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "":
					//SaveCallOnCallInfoEvent = reader.GetValue<System.Boolean>();
					break;
			}
		}

		#endregion

		#region Methods: Public

		public virtual void Prepare(BPMSoft.UI.WebControls.PageSchemaUserControl page) {
			_page = page;
		}

		public virtual void RefreshReferences(BPMSoft.UI.WebControls.PageSchemaUserControl page) {
			_page = page;
			UserConnection = page.UserConnection;
		}

		public virtual void Serialize(string key) {
			var result = string.Empty;
			using (var stringWriter = new StringWriter()) {
				using (var dataWriter = new JsonDataWriter(new JsonDataWriterSettings(), stringWriter)) {
					WriteMetaData(dataWriter);
				}
				result = stringWriter.ToString();
			}
			if (result.Trim() != string.Empty) {
				UserConnection.SessionData[key] = result;
			}
		}

		public virtual void Deserialize(string key) {
			var value = UserConnection.SessionData[key] as string;
			if (value == null) {
				return;
			}
			using (var stringReader = new StringReader(value)) {
				using (var reader = new JsonDataReader(stringReader)) {
					reader.Read();
					ReadMetaData(reader);
				}
			}
		}

		public void WritePropertiesData(DataWriter writer) {
			/*writer.WriteValue("SaveCallOnCallInfoEvent", typeof(System.Boolean), SaveCallOnCallInfoEvent, null);
			if (MsgServer != null) {
				if (MsgServer.GetType().IsSerializable ||
					MsgServer.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerialazebleObjectValue("MsgServer", MsgServer, null);
				}
			}
			writer.WriteValue("TapiMsgSessionUId", typeof(System.String), TapiMsgSessionUId, null);
			*/
		}

		public void ReadMetaData(DataReader reader) {
			while (!string.IsNullOrEmpty(reader.CurrentName)) {
				ApplyPropertiesDataValues(reader);
				reader.Read();
			}
			return;
		}

		public void WriteMetaData(DataWriter writer) {
			WritePropertiesData(writer);
		}

		public static void InitializeMenu<T>(T ownerComponent, Action<string> clickCallBack)
				where T : Button {
			ownerComponent.AjaxEvents.MenuItemClick.Event +=
				delegate (object sender, BPMSoft.UI.WebControls.Controls.AjaxEventArgs e) {
					var clickedMenuItemCode = e.ExtraParameters[2].Value;
					clickCallBack(clickedMenuItemCode);
				};
		}

		public static void AppendMenuItems<T>(T ownerComponent, Dictionary<string, string> itemTagsAndCaptions)
				where T : Button {
			foreach (var itemTagAndCaption in itemTagsAndCaptions) {
				AppendMenuItem<T>(ownerComponent, itemTagAndCaption.Key, itemTagAndCaption.Value, new ControlImage { });
			}
		}

		public static void AppendMenuItem<T>(T ownerComponent, string code, string caption, ControlImage image)
				where T : Button {
			var menuItem = new BPMSoft.UI.WebControls.Controls.MenuItem();
			menuItem.UId = Guid.NewGuid();
			menuItem.Name = ownerComponent + "_" + code;
			menuItem.Caption = caption;
			menuItem.Tag = code;
			menuItem.Image = image;
			ownerComponent.Menu.Add(menuItem);
			if (BPMSoft.UI.WebControls.Ext.IsAjaxRequest) {
				ownerComponent.Menu.AddCaptionItem(menuItem);
			}
		}

		#region Old Methods from 5.1 - need refactoring

		public void CompleteButtonMenuItems(object/*PageSchemaUserControl*/ page, BPMSoft.UI.WebControls.Controls.Button button,
				Dictionary<string, string> itemTagsAndCaptions) {
			//if (BPMSoft.UI.WebControls.Ext.IsAjaxRequest) {
			button.Menu.RemoveAll();
			//}
			foreach (var itemTagAndCaption in itemTagsAndCaptions) {
				if (itemTagAndCaption.Value == "|") {
					if (!BPMSoft.UI.WebControls.Ext.IsAjaxRequest) {
						var menuSeparator = new BPMSoft.UI.WebControls.Controls.MenuSeparator();
						menuSeparator.Name = itemTagAndCaption.Key;
						button.Menu.Add(menuSeparator);
					} else {
						button.Menu.AddSeparator();
					}
					continue;
				}
				var menuItem = new BPMSoft.UI.WebControls.Controls.MenuItem();
				menuItem.UId = Guid.NewGuid();
				menuItem.Name = itemTagAndCaption.Key;
				menuItem.Caption = itemTagAndCaption.Value;
				menuItem.Tag = itemTagAndCaption.Key;
				menuItem.Image = new ControlImage { };
				button.Menu.Add(menuItem);
				if (BPMSoft.UI.WebControls.Ext.IsAjaxRequest) {
					button.Menu.AddCaptionItem(menuItem);
				}
			}
			if (itemTagsAndCaptions.Count > 0) {
				var script = button.ClientID + ".onContentChanged();";
				MethodInfo addScriptMethod = page.GetType().GetMethod("AddScript");
				addScriptMethod.Invoke(page, new object[] { script });
			}
			return;
		}

		public Dictionary<string, string> ConvertGuidStringDictionaryToStringStringDictionary(Dictionary<Guid, string> guidStringDictionary) {
			var stringStringDictionary = new Dictionary<string, string>(guidStringDictionary.Count);
			foreach (var kvp in guidStringDictionary) {
				stringStringDictionary.Add(kvp.Key.ToString("N"), kvp.Value);
			}
			return stringStringDictionary;
		}

		public void SetEventHandler(Action<string, string> action) {

		}

		#endregion

		#endregion

	}

	#endregion

}
