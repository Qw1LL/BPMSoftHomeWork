namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Interfaces;
	using BPMSoft.Core.Campaign.StartSignal;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;

	#region Class: CampaignStartSignalElement

	/// <summary>
	/// Element that appends participants to campaign audience by signal.
	/// </summary>
	[DesignModeProperty(Name = "EntitySchemaUId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = EntitySchemaUIdPropertyName)]
	[DesignModeProperty(Name = "SignalEntityId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = SignalEntityIdPropertyName)]
	[DesignModeProperty(Name = "WaitingRandomSignal",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = WaitingRandomSignalPropertyName)]
	[DesignModeProperty(Name = "EntityFilters",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = EntityFiltersPropertyName)]
	[DesignModeProperty(Name = "NewEntityChangedColumns",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = NewEntityChangedPropertyName)]
	[DesignModeProperty(Name = "HasEntityFilters",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = HasEntityFiltersPropertyName)]
	[DesignModeProperty(Name = "WaitingEntitySignal",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = WaitingEntitySignalPropertyName)]
	[DesignModeProperty(Name = "EntitySignal",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = EntitySignalPropertyName)]
	[DesignModeProperty(Name = "HasEntityColumnChange",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = HasEntityColumnChangePropertyName)]
	[DesignModeProperty(Name = "IsRecurring",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = IsRecurringPropertyName)]
	public class CampaignStartSignalElement : CampaignSchemaElement, IProcessSchemaSignalEvent,
		IFragmentSynchronizable, ICampaignSignalEntityHandlerFactory
	{

		#region Constants: Private

		private const string EntitySchemaUIdPropertyName = "EntitySchemaUId";
		private const string SignalEntityIdPropertyName = "SignalEntityId";
		private const string WaitingRandomSignalPropertyName = "WaitingRandomSignal";
		private const string EntityFiltersPropertyName = "EntityFilters";
		private const string EntityChangedPropertyName = "EntityChangedColumns";
		private const string NewEntityChangedPropertyName = "NewEntityChangedColumns";
		private const string HasEntityFiltersPropertyName = "HasEntityFilters";
		private const string WaitingEntitySignalPropertyName = "WaitingEntitySignal";
		private const string EntitySignalPropertyName = "EntitySignal";
		private const string HasEntityColumnChangePropertyName = "HasEntityColumnChange";
		private const string IsRecurringPropertyName = "IsRecurring";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="CampaignStartSignalElement"/>.
		/// </summary>
		public CampaignStartSignalElement() {
			ElementType = CampaignSchemaElementType.StartSignal | CampaignSchemaElementType.Sessioned;
			WaitingRandomSignal = false;
			WaitingEntitySignal = true;
			HasEntityColumnChange = false;
		}

		/// <summary>
		/// Constructor for <see cref="CampaignStartSignalElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignStartSignalElement"/>.</param>
		public CampaignStartSignalElement(CampaignStartSignalElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignStartSignalElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignStartSignalElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignStartSignalElement(CampaignStartSignalElement source,
				Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema)
					: base(source, dictToRebind, parentSchema) {
			EntitySchemaUId = source.EntitySchemaUId;
			SignalEntityId = source.SignalEntityId;
			Signal = source.Signal;
			WaitingRandomSignal = source.WaitingRandomSignal;
			WaitingEntitySignal = source.WaitingEntitySignal;
			EntitySignal = source.EntitySignal;
			HasEntityColumnChange = source.HasEntityColumnChange;
			HasEntityFilters = source.HasEntityFilters;
			LocalizableEntityFilters = new LocalizableString(source.LocalizableEntityFilters);
			EntityFilters = source.EntityFilters;
			EntityChangedColumns = source.EntityChangedColumns;
			IsRecurring = source.IsRecurring;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action => CampaignConsts.CampaignLogTypeStartSignal;

		#endregion

		#region Properties: Public

		public override bool UseBackgroundMode => false;

		[MetaTypeProperty("{F8D0C56D-9E31-402A-A3CB-0ACDD64775AE}")]
		public bool WaitingRandomSignal { get; set; }

		[MetaTypeProperty("{D685589D-A715-4566-8C72-3D42F077B233}")]
		public bool WaitingEntitySignal { get; set; }

		[MetaTypeProperty("{8DE6065C-AF3D-4068-88AE-D6E42D1A545D}")]
		public EntityChangeType EntitySignal { get; set; }

		[MetaTypeProperty("{289F8A5A-8A80-482B-B10F-2065FD84103B}")]
		public string Entity { get; set; }

		[MetaTypeProperty("{3E5B2704-3A07-406C-9CF6-7FEFD0DF4FEF}")]
		public string Signal { get; set; }

		private ProcessSchemaParameterCollection _parameters;
		[MetaTypeProperty("{6175B47D-3E11-4DBA-8C16-D4461658B0AC}")]
		public ProcessSchemaParameterCollection Parameters => _parameters ?? (_parameters = new ProcessSchemaParameterCollection());

		private Guid _entitySchemaUId;
		[MetaTypeProperty("{ACE8356A-D76C-4DC9-97C1-384A98E7F92D}")]
		public Guid EntitySchemaUId {
			get => _entitySchemaUId;
			set => _entitySchemaUId = value;
		}

		private Guid _signalEntityId;
		[MetaTypeProperty("{A7657A71-56A1-4356-BE20-BDE9AA0D1C5C}")]
		public Guid SignalEntityId {
			get => _signalEntityId;
			set => _signalEntityId = value;
		}

		[MetaTypeProperty("{5ADCAE7A-1C06-43AB-8E79-576858BCA80F}")]
		public bool HasEntityColumnChange { get; set; }

		private Collection<string> _entityChangedColumns;
		[MetaTypeProperty("{5172EC29-A278-4527-AE96-93C426B89958}")]
		public Collection<string> EntityChangedColumns {
			get => _entityChangedColumns ?? (_entityChangedColumns = new Collection<string>());
			set => _entityChangedColumns = value;
		}

		[MetaTypeProperty("{4172EC29-A278-4527-AE96-93C426B89958}")]
		public Collection<string> NewEntityChangedColumns { get; set; }

		[MetaTypeProperty("{C240A12D-7038-429F-BDFF-5DB0F65859F8}")]
		public bool HasEntityFilters { get; set; }

		private string _entityFilters;
		[MetaTypeProperty("{6B3076E2-2ED3-4873-8EB2-FCF4049C1696}")]
		public string EntityFilters {
			get => _entityFilters ?? LocalizableEntityFilters.Value;
			set => _entityFilters = value;
		}

		private LocalizableString _localizableEntityFilters;
		public LocalizableString LocalizableEntityFilters {
			get => _localizableEntityFilters ?? (_localizableEntityFilters = new LocalizableString());
			set => _localizableEntityFilters = LocalizableString.Merge(_localizableEntityFilters, value);
		}

		/// <summary>
		/// Flag to indicate state of recurring campaign participation rule for current signal.
		/// </summary>
		[MetaTypeProperty("{890F5A49-F56A-4E27-8B8C-F8427C215CDF}")]
		public bool IsRecurring { get; set; }

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Reads MetaData values to properties.
		/// </summary>
		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case EntitySchemaUIdPropertyName:
					EntitySchemaUId = reader.GetGuidValue();
					break;
				case SignalEntityIdPropertyName:
					SignalEntityId = reader.GetGuidValue();
					break;
				case WaitingRandomSignalPropertyName:
					WaitingRandomSignal = reader.GetBoolValue();
					break;
				case WaitingEntitySignalPropertyName:
					WaitingEntitySignal = reader.GetBoolValue();
					break;
				case EntitySignalPropertyName:
					EntitySignal = (EntityChangeType)reader.GetIntValue();
					break;
				case HasEntityFiltersPropertyName:
					HasEntityFilters = reader.GetBoolValue();
					break;
				case EntityChangedPropertyName:
					var changedColumns = reader.GetSerializableObjectValue<Dictionary<string, string>>();
					EntityChangedColumns.AddRange(changedColumns.Keys);
					break;
				case NewEntityChangedPropertyName:
					EntityChangedColumns = reader.GetSerializableObjectValue<Collection<string>>();
					break;
				case HasEntityColumnChangePropertyName:
					HasEntityColumnChange = reader.GetBoolValue();
					break;
				case EntityFiltersPropertyName:
					EntityFilters = reader.GetStringValue();
					break;
				case IsRecurringPropertyName:
					IsRecurring = reader.GetBoolValue();
					break;
			}
		}

		/// <summary>
		/// Produces concrete entity handler for signal element.
		/// </summary>
		/// <returns>Instance of <see cref="CampaignSignalEntityHandler"/>.</returns>
		protected virtual ICampaignSignalEntityHandler GetElementEntityHandler(UserConnection userConnection) =>
			new CampaignSignalEntityHandler(userConnection);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Writes meta data values.
		/// </summary>
		/// <param name="writer">Instance of the <see cref="DataWriter"/> type.</param>
		public override void WriteMetaData(DataWriter writer) {
			base.WriteMetaData(writer);
			writer.WriteValue(EntitySchemaUIdPropertyName, EntitySchemaUId, Guid.Empty);
			writer.WriteValue(SignalEntityIdPropertyName, SignalEntityId, Guid.Empty);
			writer.WriteValue(WaitingRandomSignalPropertyName, WaitingRandomSignal, false);
			writer.WriteValue(WaitingEntitySignalPropertyName, WaitingEntitySignal, true);
			writer.WriteValue(EntitySignalPropertyName, EntitySignal, EntityChangeType.None);
			writer.WriteValue(HasEntityColumnChangePropertyName, HasEntityColumnChange, false);
			writer.WriteValue(HasEntityFiltersPropertyName, HasEntityFilters, false);
			writer.WriteSerializableObjectValue(NewEntityChangedPropertyName, EntityChangedColumns, null);
			writer.WriteValue(EntityFiltersPropertyName, EntityFilters, string.Empty);
			writer.WriteValue(IsRecurringPropertyName, IsRecurring, false);
		}

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the AddCampaignParticipantElement.</returns>
		public override object Clone() {
			return new CampaignStartSignalElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the AddCampaignParticipantElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new CampaignStartSignalElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignStartSignalFlowElement {
				UserConnection = userConnection
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		/// <summary>
		/// Forcibly obtains process parameters.
		/// Implements interface <see cref="IProcessParametersMetaInfo"/>.
		/// </summary>
		/// <returns>Returns collection of parameters.
		/// Instance of <see cref="ProcessSchemaParameterCollection"/></returns>
		public ProcessSchemaParameterCollection ForceGetParameters() {
			return Parameters;
		}

		/// <summary>
		/// Returns instance of specific for campaign signal element sync manager
		/// that contains logic to synchronize campaign participants.
		/// </summary>
		/// <returns>Instance of <see cref="ICampaignFragmentSyncManager"/>.</returns>
		public ICampaignFragmentSyncManager GetSyncManager() {
			return new CampaignSignalFragmentSyncManager(ParentSchema.EntityId, UId) {
				IsRecurring = IsRecurring
			};
		}

		/// <summary>
		/// Produces concrete entity handler for signal element that implements this interface.
		/// </summary>
		/// <returns>Instance of <see cref="ICampaignSignalEntityHandler"/>.</returns>
		public ICampaignSignalEntityHandler GetEntityHandler(UserConnection userConnection) =>
			GetElementEntityHandler(userConnection);

		#endregion

	}

	#endregion

}

