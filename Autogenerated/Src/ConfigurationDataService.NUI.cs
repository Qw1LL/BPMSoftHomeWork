namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using System.Linq;

	#region Class: PageStructureDto

	[DataContract]
	public class PageStructureDto
	{

		#region Constructors: Public

		public PageStructureDto() { }

		public PageStructureDto(PageStructure pageStructure) {
			CaptionLcz = pageStructure.CaptionLcz;
			Caption = pageStructure.Caption;
			TypeId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(pageStructure.UId);
			ModuleEditId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(pageStructure.ModuleEditId);
			CardSchemaName = pageStructure.CardSchema;
			HasAddMiniPage = false;
			MiniPageSchemaName = ConfigurationDataDtoUtils.GetTypedValue<string>(pageStructure.MiniPageSchema);
			MiniPageModes = ConfigurationDataDtoUtils.GetTypedValue<string>(pageStructure.MiniPageModes);
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "caption")]
		public string Caption {
			get;
			set;
		}

		[DataMember(Name = "captionLcz", EmitDefaultValue = false)]
		public string CaptionLcz {
			get;
			set;
		}

		[DataMember(Name = "cardSchemaName")]
		public string CardSchemaName {
			get;
			set;
		}

		[DataMember(Name = "hasAddMiniPage", EmitDefaultValue = false)]
		public bool HasAddMiniPage {
			get;
			set;
		}

		[DataMember(Name = "miniPageSchemaName", EmitDefaultValue = false)]
		public string MiniPageSchemaName {
			get;
			set;
		}

		[DataMember(Name = "miniPageModes", EmitDefaultValue = false)]
		public string MiniPageModes {
			get;
			set;
		}

		[DataMember(Name = "moduleEditId")]
		public Guid ModuleEditId {
			get;
			set;
		}

		[DataMember(Name = "typeId", EmitDefaultValue = false)]
		public Guid TypeId {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: ModuleStructureDto

	[DataContract]
	public class ModuleStructureDto
	{

		#region Constructors: Public

		public ModuleStructureDto() { }

		public ModuleStructureDto(ModuleStructure moduleStructure) {
			TypeColumnName = ConfigurationDataDtoUtils.GetTypedValue<string>(moduleStructure.Attribute);
			CardModule = moduleStructure.CardModule;
			CardSchema = moduleStructure.CardSchema;
			EntitySchemaName = moduleStructure.Module;
			EntitySchemaUId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(moduleStructure.EntitySchemaUId);
			Hide = ConfigurationDataDtoUtils.GetTypedValue<bool>(moduleStructure.Hide);
			ImageId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(moduleStructure.ImageId);
			LogoId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(moduleStructure.LogoId);
			MiniPageSchema = moduleStructure.MiniPageSchema;
			ModuleHeader = moduleStructure.ModuleHeader;
			ModuleId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(moduleStructure.ModuleId);
			PagesStructure = moduleStructure.PagesStructure?
				.Select(ps => new PageStructureDto(ps))
				.ToList();
			Position = null;
			SectionModule = moduleStructure.SectionModule;
			SectionSchema = moduleStructure.SectionSchema;
			VisaSchemaUId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(moduleStructure.VisaSchemaUId);
			VisaSchemaName = moduleStructure.VisaSchemaName;
			Workplace = ConfigurationDataDtoUtils.GetTypedValue<Guid>(moduleStructure.Workplace);
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "cardModule")]
		public string CardModule {
			get;
			set;
		}

		[DataMember(Name = "cardSchema")]
		public string CardSchema {
			get;
			set;
		}

		[DataMember(Name = "entitySchemaName")]
		public string EntitySchemaName {
			get;
			set;
		}

		[DataMember(Name = "entitySchemaUId")]
		public Guid EntitySchemaUId {
			get;
			set;
		}

		[DataMember(Name = "hide")]
		public bool Hide {
			get;
			set;
		}

		[DataMember(Name = "imageId")]
		public Guid ImageId {
			get;
			set;
		}

		[DataMember(Name = "logoId")]
		public Guid LogoId {
			get;
			set;
		}

		[DataMember(Name = "miniPageSchema")]
		public string MiniPageSchema {
			get;
			set;
		}

		[DataMember(Name = "moduleCaption")]
		public string ModuleCaption {
			get;
			set;
		}

		[DataMember(Name = "moduleHeader")]
		public string ModuleHeader {
			get;
			set;
		}

		[DataMember(Name = "moduleId")]
		public Guid ModuleId {
			get;
			set;
		}

		[DataMember(Name = "pages", EmitDefaultValue = false)]
		public List<PageStructureDto> PagesStructure {
			get;
			set;
		}

		[DataMember(Name = "position", EmitDefaultValue = false)]
		public int? Position {
			get;
			set;
		}

		[DataMember(Name = "sectionModule")]
		public string SectionModule {
			get;
			set;
		}

		[DataMember(Name = "sectionSchema")]
		public string SectionSchema {
			get;
			set;
		}

		[DataMember(Name = "typeColumnName", EmitDefaultValue = false)]
		public string TypeColumnName {
			get;
			set;
		}

		[DataMember(Name = "visaSchemaUId", EmitDefaultValue = false)]
		public Guid VisaSchemaUId {
			get;
			set;
		}

		[DataMember(Name = "visaSchemaName", EmitDefaultValue = false)]
		public string VisaSchemaName {
			get;
			set;
		}

		[DataMember(Name = "workplace", EmitDefaultValue = false)]
		public Guid Workplace {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: EntityStructureDto

	[DataContract]
	public class EntityStructureDto
	{

		#region Constructors: Public

		public EntityStructureDto() {
			PagesStructure = new List<PageStructureDto>();
		}

		public EntityStructureDto(EntityStructure entityStructure) {
			EntitySchemaName = entityStructure.EntityName;
			EntitySchemaUId = ConfigurationDataDtoUtils.GetTypedValue<Guid>(entityStructure.EntitySchemaUId);
			SearchRowSchema = entityStructure.SearchRowSchema;
			TypeColumnName = entityStructure.Attribute;
			PagesStructure = entityStructure.PagesStructure?
				.Select(ps => new PageStructureDto(ps))
				.ToList();
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "entitySchemaName")]
		public string EntitySchemaName {
			get;
			set;
		}

		[DataMember(Name = "entitySchemaUId")]
		public Guid EntitySchemaUId {
			get;
			set;
		}

		[DataMember(Name = "pages")]
		public List<PageStructureDto> PagesStructure {
			get;
			set;
		}

		[DataMember(Name = "searchRowSchema", EmitDefaultValue = false)]
		public string SearchRowSchema {
			get;
			set;
		}

		[DataMember(Name = "typeColumnName", EmitDefaultValue = false)]
		public string TypeColumnName {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: ConfigurationDataDto

	[DataContract]
	public class ConfigurationDataDto
	{
		#region Constructors: Public

		public ConfigurationDataDto() { }

		public ConfigurationDataDto(ConfigurationData configurationData) {
			ModulesStructure = configurationData.ModulesStructure?
				.Select(ms => new ModuleStructureDto(ms.Value))
				.ToList();
			EntitiesStructure = configurationData.EntitiesStructure?
				.Select(es => new EntityStructureDto(es.Value))
				.ToList();
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "modulesStructure")]
		public List<ModuleStructureDto> ModulesStructure {
			get;
			set;
		}


		[DataMember(Name = "entitiesStructure")]
		public List<EntityStructureDto> EntitiesStructure {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: ConfigurationDataDtoUtils

	public class ConfigurationDataDtoUtils
	{

		#region Methods: Protected

		protected static bool GetBooleanValue(object value) {
			if (value == null) {
				return false;
			}
			if (value is string && (value as string).IsNullOrEmpty()) {
				return false;
			}
			return Convert.ToBoolean(value);
		}

		protected static Guid GetGuidValue(object value) {
			if (value == null) {
				return Guid.Empty;
			}
			if (value is string) {
				return (value as string).IsNullOrEmpty() ? Guid.Empty : new Guid((string)value);
			}
			if (value is Guid) {
				return (Guid)value;
			}
			throw new Exception();
		}

		protected static string GetStringValue(object value) {
			if (value == null) {
				return null;
			}
			if (value is string) {
				return (value as string).IsNullOrEmpty() ? null : (string)value;
			}
			return Convert.ToString(value);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Prepares and returns value by type.
		/// </summary>
		/// <typeparam name="T">Type of return value.</typeparam>
		/// <param name="value">Value.</param>
		/// <returns>Typed value.</returns>
		public static T GetTypedValue<T>(object value) {
			if (typeof(T) == typeof(string)) {
				return (T)(object)GetStringValue(value);
			}
			if (typeof(T) == typeof(Guid)) {
				return (T)(object)GetGuidValue(value);
			}
			if (typeof(T) == typeof(bool)) {
				return (T)(object)GetBooleanValue(value);
			}
			throw new Exception();
		}

		#endregion

	}

	#endregion

	#region Class: ConfigurationDataResponse

	[DataContract]
	public class ConfigurationDataResponse : ConfigurationServiceResponse
	{

		#region Constructors: Public

		public ConfigurationDataResponse() : base() { }

		public ConfigurationDataResponse(Exception e) : base(e) { }

		public ConfigurationDataResponse(ConfigurationDataDto data) : base() {
			Data = data;
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "data")]
		public ConfigurationDataDto Data {
			get; set;
		}

		#endregion

	}

	#endregion

	#region Class: ConfigurationDataService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ConfigurationDataService : BaseService
	{

		#region Fields: Private

		private ConfigurationSectionHelper _configurationSectionHelper;

		#endregion

		#region Constructors: Public

		public ConfigurationDataService() : base() { }

		public ConfigurationDataService(UserConnection userConnection)
			: base(userConnection) {
		}

		#endregion

		#region Properties: Private

		private ConfigurationSectionHelper ConfigurationSectionHelper =>
				_configurationSectionHelper ?? (_configurationSectionHelper = ClassFactory.Get<ConfigurationSectionHelper>(
					new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationDataResponse GetData() {
			try {
				var data = ConfigurationSectionHelper.GetConfigurationData(UserConnection);
				return new ConfigurationDataResponse(new ConfigurationDataDto(data));
			}
			catch (Exception e) {
				return new ConfigurationDataResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationDataResponse GetEntityData(IEnumerable<string> entityNames) {
			try {
				var data = ConfigurationSectionHelper.GetConfigurationData(UserConnection, entityNames);
				return new ConfigurationDataResponse(new ConfigurationDataDto(data));
			}
			catch (Exception e) {
				return new ConfigurationDataResponse(e);
			}
		}

		#endregion

	}

	#endregion

}

