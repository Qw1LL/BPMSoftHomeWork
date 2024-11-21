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

	#region Class: InitializePrimaryGrids

	[DesignModeProperty(Name = "PrimaryGridTabPanel", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "bc29c02b046c4813bcc5346bd851ba4e", CaptionResourceItem = "Parameters.PrimaryGridTabPanel.Caption", DescriptionResourceItem = "Parameters.PrimaryGridTabPanel.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SysModuleId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "bc29c02b046c4813bcc5346bd851ba4e", CaptionResourceItem = "Parameters.SysModuleId.Caption", DescriptionResourceItem = "Parameters.SysModuleId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class InitializePrimaryGrids : ProcessUserTask
	{

		#region Constructors: Public

		public InitializePrimaryGrids(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("bc29c02b-046c-4813-bcc5-346bd851ba4e");
		}

		#endregion

		#region Properties: Public

		public virtual Object PrimaryGridTabPanel {
			get;
			set;
		}

		public virtual Guid SysModuleId {
			get;
			set;
		}

		private LocalizableString _allViewMenuItemCaption;
		public LocalizableString AllViewMenuItemCaption {
			get {
				return _allViewMenuItemCaption ?? (_allViewMenuItemCaption = new LocalizableString(Storage, Schema.GetResourceManagerName(), "LocalizableStrings.AllViewMenuItemCaption.Value"));
			}
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var primaryGrids = GetPrimaryGrids(SysModuleId);
			foreach (var item in primaryGrids) {
				var gridTab = CreatePrimaryGridTab(item.Item1, item.Item3, item.Item4);
				FillGridView(item.Item2, gridTab, GetModulesGridView(item.Item2));
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual List<Tuple<Guid, Guid, Guid, string, bool>> GetPrimaryGrids(Guid moduleId) {
			var result = new List<Tuple<Guid, Guid, Guid, string, bool>>();
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, "SysModulePrimaryGrid");
			entitySchemaQuery.Cache = UserConnection.SessionCache.WithLocalCaching(string.Format(TSConfiguration.CacheUtilities.DetailsCache, moduleId));
			var idColumnName = entitySchemaQuery.AddColumn("Id").Name;
			var captionColumnName = entitySchemaQuery.AddColumn("Caption").Name;
			var gridIdColumnName = entitySchemaQuery.AddColumn("SysModuleGrid.Id").Name;
			var hasAllItemsViewName = entitySchemaQuery.AddColumn("SysModuleGrid.HasAllItemsView").Name;
			var gridPageSchemaIdColumnName = entitySchemaQuery.AddColumn("SysModuleGrid.SysPageSchemaUId").Name;
			var positionColumnName = entitySchemaQuery.AddColumn("Position").OrderByAsc();
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "SysModule", moduleId));
			entitySchemaQuery.CacheItemName = string.Format("SysModulePrimaryGrids_{0}", moduleId);
			var entities = entitySchemaQuery.GetEntityCollection(UserConnection);
			foreach (var item in entities) {
				result.Add(new Tuple<Guid, Guid, Guid, string, bool>(item.GetTypedColumnValue<Guid>(idColumnName), item.GetTypedColumnValue<Guid>(gridIdColumnName),
				item.GetTypedColumnValue<Guid>(gridPageSchemaIdColumnName),	item.GetTypedColumnValue<string>(captionColumnName),
				item.GetTypedColumnValue<bool>(hasAllItemsViewName)));
			}
			return result;
		}

		public virtual Tab CreatePrimaryGridTab(Guid primaryGridId, Guid primaryGridPageSchemaId, string primaryGridCaption) {
			var newTab = new BPMSoft.UI.WebControls.Controls.Tab();
			newTab.UId = Guid.NewGuid();
			newTab.Name = "DetailTab" + primaryGridId.ToString().Replace("-", "").ToLower();
			newTab.Caption = primaryGridCaption;
			var primaryGridTabPanel = PrimaryGridTabPanel as TabPanel;
			primaryGridTabPanel.Add(newTab);
			BPMSoft.UI.WebControls.Controls.PageContainer newContainer = null;
			newContainer = new BPMSoft.UI.WebControls.Controls.PageContainer();
			newContainer.UId = Guid.NewGuid();
			newContainer.Name = "PrimaryGridContainer" + primaryGridId.ToString().Replace("-", "").ToLower();
			newContainer.PageSchemaUId = primaryGridPageSchemaId;
			newContainer.Height = System.Web.UI.WebControls.Unit.Percentage(100);
			newContainer.Width = System.Web.UI.WebControls.Unit.Percentage(100);
			newTab.InsertItem(0, newContainer);
			newContainer.PageInstance.Process.SetPropertyValue("ListenerPageProcessUId", 
				(primaryGridTabPanel.NamingContainer as PageContainer).PageInstance.Process.InstanceUId);
			newContainer.PageInstance.Process.SetPropertyValue("SysModuleId", SysModuleId);
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
					var dataSource = container.FindPageControlByName("DataSource")
										as DataSource;
					if (dataSource == null) {
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

		public virtual List<Tuple<Guid, string, string, bool>> GetModulesGridView(Guid sysModuleGridId) {
			var appCache = UserConnection.ApplicationCache.WithLocalCaching(TSConfiguration.CacheUtilities.WorkspaceCacheGroup);
			var gridViewsCollection = TSConfiguration.CommonUtilities.GetSelectData(
				UserConnection, TSConfiguration.CommonUtilities.GetModuleGridViewsSelect, appCache, TSConfiguration.CacheUtilities.GridViewCache);
			string captionColumnName = BPMSoft.Configuration.CommonUtilities.GetLczColumnName(UserConnection, "SysModuleGridView", "Caption");
			List<Tuple<Guid, string, string, bool>> result = new List<Tuple<Guid, string, string, bool>>();
			foreach (var gridView in gridViewsCollection) {
					Guid currentSysModuleGridId = new Guid(gridView["sysModuleGridId"].ToString());
					if (sysModuleGridId == currentSysModuleGridId) {
						Guid sysModuleGridViewId = new Guid(gridView["sysModuleGridViewId"].ToString());
						string caption = gridView[captionColumnName].ToString();
						bool hasAllItemsView = Convert.ToBoolean(gridView["hasAllItemsView"].ToString());
						string code = gridView["code"].ToString();
						result.Add(new Tuple<Guid, string, string, bool>(sysModuleGridViewId, code, caption, hasAllItemsView));
					}
			}
			return result;
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (PrimaryGridTabPanel != null) {
				if (PrimaryGridTabPanel.GetType().IsSerializable || PrimaryGridTabPanel.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("PrimaryGridTabPanel", PrimaryGridTabPanel, null);
				}
			}
			if (!HasMapping("SysModuleId")) {
				writer.WriteValue("SysModuleId", SysModuleId, Guid.Empty);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "PrimaryGridTabPanel":
					PrimaryGridTabPanel = reader.GetSerializableObjectValue();
				break;
				case "SysModuleId":
					SysModuleId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

