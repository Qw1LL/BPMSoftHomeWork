namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using Core;
	using Core.Factories;
	using Newtonsoft.Json.Linq;

	#region Class: DashboardItemDataAttribute

	[AttributeUsage(AttributeTargets.Class)]
	public class DashboardItemDataAttribute : System.Attribute
	{

		#region Constructors: Public

		public DashboardItemDataAttribute(string widgetType) {
			this.widgetType = widgetType;
		}

		#endregion

		#region Properties: Public

		private string widgetType;
		public string WidgetType
		{
			get
			{
				return widgetType;
			}
		}

		#endregion

	}

	#endregion

	#region Class: DashboardItemDataFactory

	/// <summary>
	/// Provides factory to create dashboard item data instances.
	/// </summary>
	public class DashboardItemDataFactory
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Properties: Private

		private static Dictionary<string, Type> _widgetTypes = null;
		private Dictionary<string, Type> WidgetTypes
		{
			get {
				if (_widgetTypes == null) {
					_widgetTypes = GetWidgetTypes();
				}
				return _widgetTypes;
			}
		}
		#endregion

		#region Construstors: Public

		public DashboardItemDataFactory(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Dictionary<string, Type> GetWidgetTypes() {
			var types = new Dictionary<string, Type>();
			Assembly assembly = _userConnection.AppConnection.Workspace.WorkspaceAssembly;
			foreach (Type type in assembly.GetTypes()) {
				object[] attributes = type.GetCustomAttributes(typeof(DashboardItemDataAttribute), true);
				if (attributes.Length > 0 && type.GetInterfaces().Contains(typeof(IDashboardItemData))) {
					string widgetType = ((DashboardItemDataAttribute)attributes[0]).WidgetType;
					types.Add(widgetType, type);
				}
			}
			return types;
		}

		private Type GetClassType(string widgetType) {
			Type type;
			if (WidgetTypes.TryGetValue(widgetType, out type)) {
				return type;
			}
			return null;

		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates instance of dashboard item data.
		/// </summary>
		/// <param name="widgetType">Widget type name. Value must be set in attribute "DashboardItemDataAttribute" of specified class</param>
		/// <param name="dashboardName">Name of dashboard.</param>
		/// <param name="config">Configuration  of dashboard.</param>
		/// <param name="timeZoneOffset">Offset in hours.</param>
		/// <returns>Instanceof dashboard item data.</returns>
		public IDashboardItemData CreateInstance(string widgetType, string dashboardName, JObject config, int timeZoneOffset) {
			Type classType = GetClassType(widgetType);
			object instance = null;
			if (classType != null) {
				instance = CreateConcreteInstance(classType, dashboardName, config, timeZoneOffset);
			}
			return (IDashboardItemData)instance;
		}

		/// <summary>
		/// Creates instance of dashboard item data for section.
		/// </summary>
		/// <param name="widgetType">Widget type name. Value must be set in attribute "DashboardItemDataAttribute" of specified class</param>
		/// <param name="dashboardName">Name of dashboard.</param>
		/// <param name="config">Configuration  of dashboard.</param>
		/// <param name="bindingColumnValue">Value for section binding filter.</param>
		/// <param name="timeZoneOffset">Offset in hours.</param>
		/// <returns>Instanceof dashboard item data.</returns>
		public IDashboardItemData CreateInstance(string widgetType, string dashboardName, JObject config, string bindingColumnValue, int timeZoneOffset) {
			Type classType = GetClassType(widgetType);
			if (classType == null) {
				return null;
			} else {
				return (IDashboardItemData)ClassFactory.ForceGet<IDashboardItemData>(classType.AssemblyQualifiedName,
					new ConstructorArgument("dashboardName", dashboardName),
					new ConstructorArgument("config", config),
					new ConstructorArgument("bindingColumnValue", bindingColumnValue),
					new ConstructorArgument("userConnection", _userConnection),
					new ConstructorArgument("timeZoneOffset", timeZoneOffset));
			}
		}

		/// <summary>
		/// Creates instance of dashboard item data.
		/// </summary>
		/// <param name="widgetType">Widget type name. Value must be set in attribute "DashboardItemDataAttribute" of specified class</param>
		/// <param name="dashboardName">Name of dashboard.</param>
		/// <param name="config">Configuration  of dashboard.</param>
		/// <param name="timeZoneOffset">Offset in hours.</param>
		/// <returns>Instanceof dashboard item data.</returns>
		public IDashboardItemData CreateConcreteInstance(Type classType, string dashboardName, JObject config, int timeZoneOffset) {
			string assemblyQualifiedName = classType.AssemblyQualifiedName;
			return ClassFactory.ForceGet<IDashboardItemData>(assemblyQualifiedName,
				new ConstructorArgument("dashboardName", dashboardName),
				new ConstructorArgument("config", config),
				new ConstructorArgument("userConnection", _userConnection),
				new ConstructorArgument("timeZoneOffset", timeZoneOffset));
		}

		#endregion
	}

	#endregion

}
