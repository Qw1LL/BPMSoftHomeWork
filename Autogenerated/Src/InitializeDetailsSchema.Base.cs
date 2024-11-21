namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Store;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: InitializeDetails

	[DesignModeProperty(Name = "SysModuleId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "338c91dd8878440ab0cb78711b91d9bb", CaptionResourceItem = "Parameters.SysModuleId.Caption", DescriptionResourceItem = "Parameters.SysModuleId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DetailTabPanel", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "338c91dd8878440ab0cb78711b91d9bb", CaptionResourceItem = "Parameters.DetailTabPanel.Caption", DescriptionResourceItem = "Parameters.DetailTabPanel.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SysModuleEditId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "338c91dd8878440ab0cb78711b91d9bb", CaptionResourceItem = "Parameters.SysModuleEditId.Caption", DescriptionResourceItem = "Parameters.SysModuleEditId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "InModuleEdit", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "338c91dd8878440ab0cb78711b91d9bb", CaptionResourceItem = "Parameters.InModuleEdit.Caption", DescriptionResourceItem = "Parameters.InModuleEdit.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ParentSysEntitySchemaId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "338c91dd8878440ab0cb78711b91d9bb", CaptionResourceItem = "Parameters.ParentSysEntitySchemaId.Caption", DescriptionResourceItem = "Parameters.ParentSysEntitySchemaId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "UseModuleDetails", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "338c91dd8878440ab0cb78711b91d9bb", CaptionResourceItem = "Parameters.UseModuleDetails.Caption", DescriptionResourceItem = "Parameters.UseModuleDetails.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DefaultCollapsed", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "338c91dd8878440ab0cb78711b91d9bb", CaptionResourceItem = "Parameters.DefaultCollapsed.Caption", DescriptionResourceItem = "Parameters.DefaultCollapsed.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DetailFilter", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "338c91dd8878440ab0cb78711b91d9bb", CaptionResourceItem = "Parameters.DetailFilter.Caption", DescriptionResourceItem = "Parameters.DetailFilter.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ActiveTabIndex", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "338c91dd8878440ab0cb78711b91d9bb", CaptionResourceItem = "Parameters.ActiveTabIndex.Caption", DescriptionResourceItem = "Parameters.ActiveTabIndex.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class InitializeDetails : ProcessUserTask
	{

		#region Constructors: Public

		public InitializeDetails(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("338c91dd-8878-440a-b0cb-78711b91d9bb");
		}

		#endregion

		#region Properties: Public

		public virtual Guid SysModuleId {
			get;
			set;
		}

		public virtual Object DetailTabPanel {
			get;
			set;
		}

		public virtual Guid SysModuleEditId {
			get;
			set;
		}

		public virtual bool InModuleEdit {
			get;
			set;
		}

		public virtual Guid ParentSysEntitySchemaId {
			get;
			set;
		}

		public virtual bool UseModuleDetails {
			get;
			set;
		}

		public virtual bool DefaultCollapsed {
			get;
			set;
		}

		public virtual Object DetailFilter {
			get;
			set;
		}

		public virtual int ActiveTabIndex {
			get;
			set;
		}

		private LocalizableString _allViewMenuItemCaption;
		public LocalizableString AllViewMenuItemCaption {
			get {
				return _allViewMenuItemCaption ?? (_allViewMenuItemCaption = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.AllViewMenuItemCaption.Value"));
			}
		}

		private LocalizableString _notesDetailCaption;
		public LocalizableString NotesDetailCaption {
			get {
				return _notesDetailCaption ?? (_notesDetailCaption = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.NotesDetailCaption.Value"));
			}
		}

		private LocalizableString _rightsDetailCaption;
		public LocalizableString RightsDetailCaption {
			get {
				return _rightsDetailCaption ?? (_rightsDetailCaption = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.RightsDetailCaption.Value"));
			}
		}

		private LocalizableString _logDetailCaption;
		public LocalizableString LogDetailCaption {
			get {
				return _logDetailCaption ?? (_logDetailCaption = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.LogDetailCaption.Value"));
			}
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var detailsTabPanel = DetailTabPanel as	TabPanel;
			if (detailsTabPanel == null) {
				return true;
			}
			var page = detailsTabPanel.Page as BPMSoft.UI.WebControls.Page;
			string tempDataKey = "tempData";
			string activeTabFieldValue = string.Empty;
			string collapsedFieldValue = string.Empty;
			if (BPMSoft.UI.WebControls.Ext.IsAjaxRequest && page.CustomData.ContainsKey(tempDataKey)) {	
				JObject tempData = page.CustomData[tempDataKey] as JObject;	
				collapsedFieldValue = page.Request.Form[detailsTabPanel.ClientID + "_Collapsed"];
				if (string.IsNullOrEmpty(collapsedFieldValue)) {
					collapsedFieldValue = (tempData[detailsTabPanel.ClientID + "_Collapsed"] != null &&	page.UseProfile) ?
						tempData[detailsTabPanel.ClientID + "_Collapsed"].Value<string>() : string.Empty;		
				}
				activeTabFieldValue = page.Request.Form[detailsTabPanel.ClientID + "_ActiveTab"];	
				if (string.IsNullOrEmpty(activeTabFieldValue)) {
					activeTabFieldValue = (tempData[detailsTabPanel.ClientID + "_ActiveTab"] != null && page.UseProfile) ? tempData[detailsTabPanel.ClientID + "_ActiveTab"].Value<string>() : "0";
				}
			}
			
			bool detailsTabPanelCollapsed = false;
			if (string.IsNullOrEmpty(collapsedFieldValue)) {
				detailsTabPanelCollapsed = DefaultCollapsed;
			} else {
				detailsTabPanelCollapsed = bool.Parse(collapsedFieldValue);
			}
			int detailsTabPanelActiveTabIndex = 0;
			bool parsedActiveTabIndex = int.TryParse(activeTabFieldValue, out detailsTabPanelActiveTabIndex);
			if (!parsedActiveTabIndex) {
				detailsTabPanelActiveTabIndex = 0;
			}
			bool applyProfile = false;
			if (page.UseProfile && !BPMSoft.UI.WebControls.Ext.IsAjaxRequest) {
				var profileData = page.ProfileData;
				var profileItem = profileData[detailsTabPanel.ClientID];
				if (profileItem != null) {
					if (profileItem.Values.ContainsKey("collapsed") && !detailsTabPanel.IgnoreProfileProperties.Contains("collapsed")) {
						detailsTabPanelCollapsed = bool.Parse(profileItem.Values["collapsed"].ToString());
					}		
					if (profileItem.Values.ContainsKey("activetabindex") && !detailsTabPanel.IgnoreProfileProperties.Contains("activetabindex")) {
						detailsTabPanelActiveTabIndex = int.Parse(profileItem.Values["activetabindex"].ToString());
					}
				}
			}
			var detailsList = GetDetails();
			if (detailsList.Count > 0 && (detailsTabPanelActiveTabIndex < 0 || detailsTabPanelActiveTabIndex >= detailsList.Count)) {
				detailsTabPanelActiveTabIndex = 0;
			}
			ActiveTabIndex = detailsTabPanelActiveTabIndex;
			foreach(var item in detailsList) {
				var tab = CreateDetailTab(item.Item1, item.Item2, item.Item4, detailsTabPanelCollapsed, detailsTabPanelActiveTabIndex);
				FillGridView(item.Item5, tab, GetModulesGridView(item.Item5));
				if (tab.Items.Count == 0) {
					continue;
				}
				var pageContainer = tab.Items[0] as PageContainer;
				pageContainer.PageInstance.Process.SetPropertyValue("UseModuleDetails", UseModuleDetails || !InModuleEdit);
				pageContainer.PageInstance.Process.SetPropertyValue("SysEntitySchemaId", ParentSysEntitySchemaId);
				pageContainer.PageInstance.Process.SetPropertyValue("IsDetailGrid", true);
				pageContainer.PageInstance.Process.SetPropertyValue("AddToMenuItemMoveTo", true);
				pageContainer.PageInstance.Process.SetPropertyValue("LocatedInEditPage", InModuleEdit);
				pageContainer.PageInstance.Process.SetPropertyValue("ListenerPageProcessUId", 
					(detailsTabPanel.NamingContainer as PageContainer).PageInstance.Process.InstanceUId);
				var detailDataSource = pageContainer.FindPageControlByName("DataSource") as BPMSoft.UI.WebControls.Controls.EntityDataSource;	
				if (detailDataSource != null) {
					if(detailDataSource.SchemaUId.Equals(Guid.Empty) || detailDataSource.SchemaUId.Equals(new Guid("a22b1e79-7fc1-4fe5-aba0-538e9df96f17")))  {
						detailDataSource.SchemaUId = item.Item3;
					} else {
						if (detailDataSource.SchemaUId != item.Item3) {
							detailDataSource.SchemaUId = item.Item3;
							BPMSoft.UI.WebControls.Utilities.EntityDataSourceUtilities.SynchronizeStructure(detailDataSource);
							foreach (var column in detailDataSource.CurrentStructure.Columns) {
								if (!column.IsVisible) {
									column.IsAlwaysSelect = true;
								}
							}
						}
					}
					var association = GetDetailParentAssociation(item.Item1, InModuleEdit, "Filter", item.Item3);
					pageContainer.PageInstance.Process.SetPropertyValue("FilterLeftExpression", association.Value);
					pageContainer.PageInstance.Process.SetPropertyValue("SysModuleDetailId", item.Item1);
					pageContainer.PageInstance.Process.SetPropertyValue("ParentColumnMetaPath", association.Key);
				}
				if (!string.IsNullOrEmpty(item.Item6)) {
					BPMSoft.Configuration.VideoHelpUtilities.SetWebControlHelpProperties(pageContainer, item.Item6, UserConnection);
				}
				if (item.Item2 == new Guid("08a28020-620d-441e-bc3e-a9b9c8d9e6e6")) {
					pageContainer.PageInstance.Process.SetPropertyValue("ModuleEntitySchemaUId", item.Item3);
				}
			}
			if (applyProfile) {
				detailsTabPanel.AllowCallbackScriptMonitoring = false;
				detailsTabPanel.ActiveTabIndex = detailsTabPanelActiveTabIndex;
				detailsTabPanel.Collapsed = detailsTabPanelCollapsed;
				detailsTabPanel.AllowCallbackScriptMonitoring = true;
			}
			if (!detailsTabPanel.Page.IsPostBack) {
				detailsTabPanel.AjaxEvents.TabChange.ShowOpaqueMask = true;
				detailsTabPanel.TabChangeDelay = 300;
			}
			DetailTabPanel = null;
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual List<Tuple<Guid, Guid, Guid, string, Guid, string>> GetDetails() {
			if (InModuleEdit) {
				return GetModuleEditDetails();
			} else {
				return GetModuleDetails();
			}
		}

		public virtual List<Tuple<Guid, Guid, Guid, string, Guid, string>> GetModuleDetails() {
			var result = GetAutoDetail();
			var appCache = UserConnection.ApplicationCache.WithLocalCaching(TSConfiguration.CacheUtilities.WorkspaceCacheGroup);
			string detailsCacheName = TSConfiguration.CacheUtilities.DetailsCache + "_" + UserConnection.CurrentUser.SysCultureName;
			var detailsCollection = BPMSoft.Configuration.CommonUtilities.GetSelectData(UserConnection, BPMSoft.Configuration.CommonUtilities.GetModuleDetailsSelect, appCache, detailsCacheName);
			string captionColumnName = BPMSoft.Configuration.CommonUtilities.GetLczColumnName(UserConnection, "SysModuleDetail", "Caption");
			foreach (var detail in detailsCollection) {
				Guid detailModuleId = new Guid(detail["sysModuleId"].ToString());
				if (detailModuleId == SysModuleId) {
					Guid detailId = detail["detailId"] == DBNull.Value ? Guid.Empty : new Guid(detail["detailId"].ToString());
					Guid pageSchemaId = detail["sysPageSchemaId"] == DBNull.Value ? Guid.Empty : new Guid(detail["sysPageSchemaId"].ToString());
					Guid sysModuleGridId = detail["sysModuleGridId"] == DBNull.Value ? Guid.Empty : new Guid(detail["sysModuleGridId"].ToString());
					Guid entitySchemaId = detail["sysEntitySchemaId"] == DBNull.Value ? Guid.Empty : new Guid(detail["sysEntitySchemaId"].ToString());
					string caption = detail[captionColumnName].ToString();
					string helpContextId = detail["helpContextId"].ToString();
					result.Add(new Tuple<Guid, Guid, Guid, string, Guid, string>(detailId, pageSchemaId, entitySchemaId, caption, sysModuleGridId, helpContextId));
				}
			}
			result.Sort(delegate(Tuple<Guid, Guid, Guid, string, Guid, string> item1, Tuple<Guid, Guid, Guid, string, Guid, string> item2) {
				return item1.Item4.CompareTo(item2.Item4);});
			return result;
		}

		public virtual List<Tuple<Guid, Guid, Guid, string, Guid, string>> GetModuleEditDetails() {
			var result = new List<Tuple<Guid, Guid, Guid, string, Guid, string>>();
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			if (UseModuleDetails) {
				result.AddRange(GetModuleDetails());
			} else {
				result = GetAutoDetail();
				var appCache = UserConnection.ApplicationCache.WithLocalCaching(TSConfiguration.CacheUtilities.WorkspaceCacheGroup);
			        string editDetailsCacheName = TSConfiguration.CacheUtilities.EditDetailsCache + "_" + UserConnection.CurrentUser.SysCultureName;
				var detailsCollection = BPMSoft.Configuration.CommonUtilities.GetSelectData(UserConnection, BPMSoft.Configuration.CommonUtilities.GetModuleEditDetailsSelect, appCache, editDetailsCacheName);
				string captionColumnName = BPMSoft.Configuration.CommonUtilities.GetLczColumnName(UserConnection, "SysModuleEditDetail", "Caption");
				foreach (var detail in detailsCollection) {
					Guid detailModuleId = new Guid(detail["sysModuleEditId"].ToString());
					if (detailModuleId == SysModuleEditId) {
						Guid detailId = detail["detailId"] == DBNull.Value ? Guid.Empty : new Guid(detail["detailId"].ToString());
						Guid pageSchemaId = detail["sysPageSchemaId"] == DBNull.Value ? Guid.Empty : new Guid(detail["sysPageSchemaId"].ToString());
						Guid sysModuleGridId = detail["sysModuleGridId"] == DBNull.Value ? Guid.Empty : new Guid(detail["sysModuleGridId"].ToString());
						Guid entitySchemaId = detail["sysEntitySchemaId"] == DBNull.Value ? Guid.Empty : new Guid(detail["sysEntitySchemaId"].ToString());
						string caption = detail[captionColumnName].ToString();
						string helpContextId = detail["helpContextId"].ToString();
						result.Add(new Tuple<Guid, Guid, Guid, string, Guid, string>(detailId, pageSchemaId, entitySchemaId, caption, sysModuleGridId, helpContextId));
					}
				}
			}
			result.Sort(delegate(Tuple<Guid, Guid, Guid, string, Guid, string> item1, Tuple<Guid, Guid, Guid, string, Guid, string> item2) {
				return item1.Item4.CompareTo(item2.Item4);
			});
			return result;
		}

		public virtual Tab CreateDetailTab(Guid detailId, Guid pageSchemaId, string detailCaption, bool detailsTabPanelCollapsed, int detailsTabPanelActiveTabIndex) {
			var newTab = new BPMSoft.UI.WebControls.Controls.Tab();
			newTab.UId = Guid.NewGuid();
			newTab.Name = "DetailTab" + detailId.ToString().Replace("-", "").ToLower();
			newTab.Caption = detailCaption;
			var detailsTabPanel = DetailTabPanel as TabPanel;
			detailsTabPanel.Add(newTab);
			string tabPanelClientId = detailsTabPanel.ClientID;
			var formPostData = detailsTabPanel.Page.Request.Form;
			bool needCreatePageContainer = false;
			bool needLoadViewState = formPostData[newTab.ClientID + "_TabActivated"] == "true";
			if (formPostData.AllKeys.Length > 3) {
				string []ajaxRequestParam = formPostData[3].ToString().Split('|');
				if (ajaxRequestParam[0] == tabPanelClientId && ajaxRequestParam[2].Equals("TabChange")) {
					string activeTabIndex = formPostData[tabPanelClientId + "_ActiveTab"];
					string previouseTabIndex = formPostData[tabPanelClientId + "_PreviouseActiveTab"];
					if (!activeTabIndex.Equals(string.Empty)) {
						int index = int.Parse(activeTabIndex);
						if (index == detailsTabPanel.Tabs.Count-1) {
							needCreatePageContainer = true;
						}
					}
				}
			}	
			if (!detailsTabPanelCollapsed && detailsTabPanelActiveTabIndex == detailsTabPanel.Tabs.Count - 1) {
				needCreatePageContainer = true;
			}
			if (needCreatePageContainer || needLoadViewState) {
				BPMSoft.UI.WebControls.Controls.PageContainer newContainer = null;
				newContainer = new BPMSoft.UI.WebControls.Controls.PageContainer();
				newContainer.UId = Guid.NewGuid();
				newContainer.CreatedByAjax = !needLoadViewState;
			    newContainer.InitialyCreatedByAjax = true;
				newContainer.Name = "DetailGridContainer" + detailId.ToString().Replace("-", "").ToLower();
				newContainer.PageSchemaUId = pageSchemaId;
				newContainer.Height = System.Web.UI.WebControls.Unit.Percentage(100);
				newContainer.Width = System.Web.UI.WebControls.Unit.Percentage(100);
				newTab.InsertItem(0, newContainer);
				foreach (System.Web.UI.Control control in newContainer.Controls) {
				  BPMSoft.UI.WebControls.Utilities.ControlUtilities.ControlsTreeRecursiveLoop(control, delegate(object sender, EventArgs e) {
				    var webControl = sender as BPMSoft.UI.WebControls.WebControl;
				    if (webControl != null) {
				      webControl.InitialyCreatedByAjax = true;
				    }
				  });
				}
			}
			return newTab;
		}

		public virtual void FillGridView(Guid moduleGridId, Tab gridTab, List<Tuple<Guid, string, string, bool>> entities) {
			bool hasAllItemsView = entities.Count > 0 ? entities[0].Item4 : false;
			gridTab.ShowMenuItemCaption = entities.Count > 0;
			var checkFirst = false;
			for (int i = 0; i < entities.Count; i++) {
				var menuItem = CreateViewMenuItem(entities[i].Item2, entities[i].Item3,
					entities[i].Item1);
				menuItem.Checked = !hasAllItemsView && (i == (entities.Count - 1));
				gridTab.Menu.Insert(0, menuItem);
			}
			if (hasAllItemsView && entities.Count > 0) {
				var menuItem = CreateViewMenuItem("AllViews", AllViewMenuItemCaption, moduleGridId);
				menuItem.Checked = true;
				gridTab.Menu.Insert(0, menuItem);
				gridTab.Menu.Insert(1, CreateMenuSeparator(string.Empty, Guid.NewGuid()));
			}
		}

		public virtual CheckMenuItem CreateViewMenuItem(string viewCode, string viewCaption, Guid viewId) {
			var item = new CheckMenuItem();
			item.Checked = false;
			item.Group = "ViewFilter";
			item.UId =  viewId;
			item.Tag = viewCode;
			item.Name = "viewMenuItem_" + viewId.ToString("N") + item.Tag;
			item.Caption = viewCaption;
			item.AjaxEvents.CheckChange.Event += delegate(object sender, BPMSoft.UI.WebControls.Controls.AjaxEventArgs e){
				var menuItem = sender as BPMSoft.UI.WebControls.Controls.CheckMenuItem;
				if (!menuItem.Checked) {
					return;
				}
				var tabItem = menuItem.Parent as Tab; 
				if (tabItem.Items.Count == 0) {
					return;
				}
				var filterCode = (sender as BPMSoft.UI.WebControls.Controls.CheckMenuItem).Tag;
				((TabPanel)tabItem.Parent).SetActiveTab(tabItem);
				var container = tabItem.Items[0] as PageContainer;
				if (container != null && container.PageInstance != null) {
					var dataSource = container.FindControl("DataSource")
										as DataSource;
					if (dataSource == null) {
						container.PageInstance.ThrowEvent("GridPageRefreshRow");
						return;
					}
					BPMSoft.UI.WebControls.Controls.DataSourceFilterCollection filters = null;
					var viewFilters = dataSource.FindFiltersGroupByName("ViewFilters");
					if (viewFilters != null) {
						foreach (var filterItem in viewFilters) {
							filterItem.IsEnabled = filterItem.Name == filterCode;
						}
						container.PageInstance.ThrowEvent("ClearData");
						dataSource.LoadRows();
					}
				}
			};
			return item;
		}

		public virtual KeyValuePair<string, string[]> GetDetailParentAssociation(Guid detailId, bool isModuleEditDetail, string asscTypeCode, Guid entitySchemaId) {
			string detailParentAsscSchemaName = "SysModuleDetailParentAssc";
			string detailParentAsscFilterColumnName = "SysModuleDetail";
			string parentColumnEntitySchemaPath = "SysModuleDetail.[SysModuleDetail:Id].SysModule.SysModuleEntity.SysEntitySchemaUId";
			if (isModuleEditDetail && !UseModuleDetails) {
				detailParentAsscFilterColumnName = "SysModuleEditDetail";
				detailParentAsscSchemaName = "SysModuleEditDetailParentAssc";
				parentColumnEntitySchemaPath = "SysModuleEditDetail.[SysModuleEditDetail:Id].SysModuleEdit.SysModuleEntity.SysEntitySchemaUId";
			}
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var asscEntitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, detailParentAsscSchemaName);
			asscEntitySchemaQuery.Cache = UserConnection.SessionCache.WithLocalCaching(string.Format(TSConfiguration.CacheUtilities.DetailsCache, SysModuleId));
			var asscColumnMetaPathColumnName = asscEntitySchemaQuery.AddColumn("ColumnMetaPath").Name;
			var asscParentColumnMetaPathColumnName = asscEntitySchemaQuery.AddColumn("ParentColumnMetaPath").Name;
			var parentColumnEntitySchemaColumnName = asscEntitySchemaQuery.AddColumn(parentColumnEntitySchemaPath).Name;
			asscEntitySchemaQuery.Filters.Add(asscEntitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "SysParentAssociationType.Code",
				asscTypeCode));
			asscEntitySchemaQuery.Filters.Add(asscEntitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, detailParentAsscFilterColumnName,
				detailId));
			asscEntitySchemaQuery.CacheItemName = "ParentAsscDetails_" + asscTypeCode + "_" + detailId;
			var associationCollection = asscEntitySchemaQuery.GetEntityCollection(UserConnection);
			string[] associations = new string[associationCollection.Count];	
			string parentColumnMetaPath = String.Empty;
			for(int i = 0; i < associationCollection.Count; i++) {
				var parentSchemaId = associationCollection[i].GetTypedColumnValue<Guid>(parentColumnEntitySchemaColumnName);
				var schemaInstance = entitySchemaManager.GetInstanceByUId(entitySchemaId);
				var associationPath = associationCollection[i].GetColumnValue("ColumnMetaPath").ToString();
				if (!string.IsNullOrEmpty(associationPath)) {
					if (schemaInstance.FindSchemaColumnByPath(associationPath) == null) {
						associationPath = schemaInstance.GetSchemaColumnPathByMetaPath(associationCollection[i].GetColumnValue("ColumnMetaPath").ToString());
					}
				}
				associations[i] = associationPath;
				schemaInstance = entitySchemaManager.GetInstanceByUId(parentSchemaId);
				if (associationCollection[i].GetColumnValue(asscColumnMetaPathColumnName) != null) {
					var associationParentPath = associationCollection[i].GetColumnValue(asscParentColumnMetaPathColumnName).ToString();
					if (!string.IsNullOrEmpty(associationParentPath)) {
						if (schemaInstance.FindSchemaColumnByPath(associationParentPath) == null) {
							associationParentPath = schemaInstance.GetSchemaColumnPathByMetaPath(associationParentPath);
						}
					}
					parentColumnMetaPath = associationParentPath;
				}
			}
			var result = new KeyValuePair<string, string[]>(parentColumnMetaPath, associations);
			return result;
		}

		public virtual BPMSoft.UI.WebControls.Controls.MenuSeparator CreateMenuSeparator(string menuSeparatorCaption, Guid separatorId) {
			var menuSeparator = new BPMSoft.UI.WebControls.Controls.MenuSeparator();
				menuSeparator.UId = separatorId;
				if (!string.IsNullOrEmpty(menuSeparatorCaption)) {
					menuSeparator.Caption= menuSeparatorCaption;
				}
				menuSeparator.CaptionColor = Color.FromArgb(0,2,77,156);
				menuSeparator.Hidden = false;
			return menuSeparator;
		}

		public virtual new List<Tuple<Guid, Guid, Guid, string, Guid, string>> GetAutoDetail() {
			var result = new List<Tuple<Guid, Guid, Guid, string, Guid, string>>();
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, "SysModule");
			entitySchemaQuery.Cache = UserConnection.SessionCache.WithLocalCaching(string.Format(TSConfiguration.CacheUtilities.DetailsCache, SysModuleId));
			var sysEntitySchemaIdColumnName = entitySchemaQuery.AddColumn("SysModuleEntity.SysEntitySchemaUId").Name;
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				entitySchemaQuery.RootSchema.GetPrimaryColumnName(), SysModuleId));
			entitySchemaQuery.CacheItemName = "AutoModuleDetail_" + SysModuleId.ToString("N");
			var collection = entitySchemaQuery.GetEntityCollection(UserConnection);
			if (collection.Count == 1) {
				var schemaUId = collection[0].GetTypedColumnValue<Guid>(sysEntitySchemaIdColumnName);
				var entitySchema = entitySchemaManager.GetInstanceByUId(schemaUId);
				if (InModuleEdit) {
					var notesColumn = entitySchema.Columns.FindByName("Notes");
					if (notesColumn != null && notesColumn.DataValueType is MaxSizeTextDataValueType) {
						var notesPageSchemaId = new Guid("E80EFAE6-82F0-48D1-BC73-38C9F4981AA4");
						result.Add(new Tuple<Guid, Guid, Guid, string, Guid, string>
							(notesPageSchemaId, notesPageSchemaId,	schemaUId,	NotesDetailCaption, Guid.Empty, string.Empty));
					}
				}
				if (entitySchema.AdministratedByRecords) {
					var rightsPageSchemaId = new Guid("08a28020-620d-441e-bc3e-a9b9c8d9e6e6");
					result.Add(new Tuple<Guid, Guid, Guid, string, Guid, string>
							(rightsPageSchemaId, rightsPageSchemaId, schemaUId,	RightsDetailCaption, rightsPageSchemaId, string.Empty));
				}
				if (entitySchema.IsTrackChangesInDB) {
					var logPageSchemaId = new Guid("038F55AD-DC39-4DEA-B9D4-B777F708FE41");
					result.Add(new Tuple<Guid, Guid, Guid, string, Guid, string>
							(logPageSchemaId, logPageSchemaId, Guid.Empty, LogDetailCaption, Guid.Empty, string.Empty));
				}
			}
			return result;
		}

		public virtual List<Tuple<Guid, string, string, bool>> GetModulesGridView(Guid sysModuleGridId) {
			var appCache = UserConnection.SessionCache.WithLocalCaching(TSConfiguration.CacheUtilities.WorkspaceCacheGroup);
			var gridViewsCollection = TSConfiguration.CommonUtilities.GetSelectData(
				UserConnection, TSConfiguration.CommonUtilities.GetModuleGridViewsSelect, appCache, TSConfiguration.CacheUtilities.GridViewCache);
			string captionColumnName = TSConfiguration.CommonUtilities.GetLczColumnName(UserConnection, "SysModuleGridView", "Caption");
			List<Tuple<Guid, string, string, bool>> result = new List<Tuple<Guid, string, string, bool>>();
			foreach (var gridView in gridViewsCollection) {
					Guid currentSysModuleGridId = new Guid(gridView["sysModuleGridId"].ToString());
					if (sysModuleGridId == currentSysModuleGridId) {
						Guid sysModuleGridViewId = new Guid(gridView["sysModuleGridViewId"].ToString());
						string caption = gridView[captionColumnName].ToString();
						bool hasAllItemsView = UserConnection.DBTypeConverter.DBValueToBool(gridView["hasAllItemsView"]);
						string code = gridView["code"].ToString();
						result.Add(new Tuple<Guid, string, string, bool>(sysModuleGridViewId, code, caption, hasAllItemsView));
					}
			}
			return result;
		}

		public virtual void UpdateFiltersRightExprMetaDataByParameterValue(Process process, DataSourceFilterCollection filters) {
			foreach (var filter in filters) {
							var dataSourcefilter = (DataSourceFilter)filter;
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
			if (!HasMapping("SysModuleId")) {
				writer.WriteValue("SysModuleId", SysModuleId, Guid.Empty);
			}
			if (DetailTabPanel != null) {
				if (DetailTabPanel.GetType().IsSerializable || DetailTabPanel.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("DetailTabPanel", DetailTabPanel, null);
				}
			}
			if (!HasMapping("SysModuleEditId")) {
				writer.WriteValue("SysModuleEditId", SysModuleEditId, Guid.Empty);
			}
			if (!HasMapping("InModuleEdit")) {
				writer.WriteValue("InModuleEdit", InModuleEdit, false);
			}
			if (!HasMapping("ParentSysEntitySchemaId")) {
				writer.WriteValue("ParentSysEntitySchemaId", ParentSysEntitySchemaId, Guid.Empty);
			}
			if (!HasMapping("UseModuleDetails")) {
				writer.WriteValue("UseModuleDetails", UseModuleDetails, false);
			}
			if (!HasMapping("DefaultCollapsed")) {
				writer.WriteValue("DefaultCollapsed", DefaultCollapsed, false);
			}
			if (DetailFilter != null) {
				if (DetailFilter.GetType().IsSerializable || DetailFilter.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("DetailFilter", DetailFilter, null);
				}
			}
			if (!HasMapping("ActiveTabIndex")) {
				writer.WriteValue("ActiveTabIndex", ActiveTabIndex, 0);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "SysModuleId":
					SysModuleId = reader.GetGuidValue();
				break;
				case "DetailTabPanel":
					DetailTabPanel = reader.GetSerializableObjectValue();
				break;
				case "SysModuleEditId":
					SysModuleEditId = reader.GetGuidValue();
				break;
				case "InModuleEdit":
					InModuleEdit = reader.GetBoolValue();
				break;
				case "ParentSysEntitySchemaId":
					ParentSysEntitySchemaId = reader.GetGuidValue();
				break;
				case "UseModuleDetails":
					UseModuleDetails = reader.GetBoolValue();
				break;
				case "DefaultCollapsed":
					DefaultCollapsed = reader.GetBoolValue();
				break;
				case "DetailFilter":
					DetailFilter = reader.GetSerializableObjectValue();
				break;
				case "ActiveTabIndex":
					ActiveTabIndex = reader.GetIntValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

