define("DcmSchemaStage", ["DcmSchemaStageResources", "DcmConstants"], function(resources) {
	/**
	 * @class BPMSoft.Designers.DcmSchemaStage
	 * Dcm stage schema class.
	 */
	Ext.define("BPMSoft.Designers.DcmSchemaStage", {
		extend: "BPMSoft.configuration.BaseProcessSchemaElement",
		alternateClassName: "BPMSoft.DcmSchemaStage",

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.configuration.BaseProcessSchemaElement#typeName
		 * @overridden
		 */
		typeName: "BPMSoft.Core.DcmProcess.DcmSchemaStage",

		/**
		 * Flag of permissions usage.
		 * @type {Boolean}
		 */
		usePermissions: false,

		/**
		 * Role identifiers that defining the state changes of this stage.
		 * @type {String}
		 */
		permissions: null,

		/**
		 * Default stage header color.
		 * @protected
		 * @type {String}
		 */
		defaultColor: "#F9763D",

		//endregion

		//region Properties: Public

		/**
		 * Stage record identifier.
		 * @type {String}
		 */
		stageRecordId: null,

		/**
		 * Elements.
		 * @type {BPMSoft.Collection}
		 */
		elements: null,

		/**
		 * Parent alternative stage identifier.
		 * @type {String}
		 */
		parentStageUId: null,

		/**
		 * Stage header color.
		 * @type {String}
		 */
		color: "#F9763D",

		/**
		 * @inheritdoc BPMSoft.configuration.BaseProcessSchemaElement#editPageSchemaName
		 * @overridden
		 */
		editPageSchemaName: "DcmSchemaStagePropertiesPage",

		/**
		 * @inheritdoc BPMSoft.manager.BaseProcessElementSchema#name
		 */
		name: "Stage",

		/**
		 * @inheritdoc BPMSoft.manager.BaseProcessElementSchema#caption
		 */
		caption: resources.localizableStrings.Caption,

		/**
		 * @inheritdoc BPMSoft.manager.BaseProcessElementSchema#typeCaption
		 */
		typeCaption: resources.localizableStrings.TypeCaption,

		/**
		 * Indicates if stage is successful.
		 * @type {Boolean}
		 */
		isSuccessful: true,

		/**
		 * Next stage transition type.
		 * @type {BPMSoft.DcmConstants.ElementRequiredType}
		 */
		transitionType: BPMSoft.DcmConstants.StageTransitionType.NONE.value,

		//endregion

		//region Constructors: Public

		/**
		 * @inheritdoc BPMSoft.BaseProcessSchemaElement#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.color = this.color || this.defaultColor;
			this.initCollection("elements", "BPMSoft.DcmSchemaElement", this.parentSchema);
		},

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#loadLocalizableValues
		 * @overridden
		 */
		loadLocalizableValues: function(localizableValues) {
			this.callParent(arguments);
			var elementsLocalizableValues = localizableValues.Elements || {};
			this.elements.each(function(element) {
				element.loadLocalizableValues(elementsLocalizableValues[element.name] || {});
			});
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#loadLocalizableValuesByUIds
		 * @overridden
		 */
		loadLocalizableValuesByUIds: function(localizableValues) {
			this.callParent(arguments);
			this.elements.each(function(element) {
				element.loadLocalizableValuesByUIds(localizableValues);
			});
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableObject
		 * @overridden
		 */
		getSerializableObject: function(serializableObject) {
			this.callParent(arguments);
			this.setSerializableCollectionProperty(serializableObject, "elements");
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
		 * @overridden
		 */
		getSerializableProperties: function() {
			let properties = this.callParent(arguments);
			properties = Ext.Array.push(properties, [
				"parentStageUId",
				"color",
				"stageRecordId",
				"isSuccessful",
				"transitionType"
			]);
			if (BPMSoft.Features.getIsEnabled("DcmStagesPermissions")) {
				properties = Ext.Array.push(properties, [
					"permissions",
					"usePermissions"
				]);
			}
			return properties;
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseProcessSchemaElement#getLocalizableValues
		 * @overridden
		 */
		getLocalizableValues: function(localizableValues) {
			this.callParent(arguments);
			this.elements.each(function(element) {
				element.getLocalizableValues(localizableValues);
			});
		},

		/**
		 * Returns header image config of the property page.
		 * @throws {BPMSoft.NotImplementedException}
		 * @protected
		 * @virtual
		 * @return {Object} Image config.
		 */
		getTitleImage: function() {
			return resources.localizableImages.TitleImage;
		},

		//endregion

		//region Methods: Public

		/**
		 * Returns stage items collection.
		 * @return {BPMSoft.core.collections.Collection} stage items.
		 */
		getItems: function() {
			return this.elements;
		},

		/**
		 * Adds dcm element to stage.
		 * @throws BPMSoft.NullOrEmptyException if parentSchema is null.
		 * @param {BPMSoft.configuration.DcmSchemaElement} item Dcm schema item.
		 */
		add: function(item) {
			this.checkParentSchema();
			item.containerUId = this.uId;
			this.parentSchema.addElement(item);
		},

		/**
		 * Removes dcm element from stage.
		 * @throws BPMSoft.NullOrEmptyException if parentSchema is null.
		 * @param {String} itemName Dcm schema item name.
		 */
		remove: function(itemName) {
			this.checkParentSchema();
			this.parentSchema.remove(itemName);
		},

		/**
		 * Returns True if stage is alternative.
		 * @return {Boolean} True if stage is alternative.
		 */
		getIsAlternative: function() {
			var parentStageUId = this.getParentStageUId();
			return parentStageUId != null;
		},

		/**
		 * Returns parent stage uId. If stage doesn't have parent stage, returns null.
		 * @throws BPMSoft.NullOrEmptyException if parentSchema is null.
		 * @return {String|null} Parent stage uId.
		 */
		getParentStageUId: function() {
			this.checkParentSchema();
			if (this.parentStageUId != null) {
				return this.parentStageUId;
			}
			var alternateStages = this.parentSchema.stages.filter("parentStageUId", this.uId);
			return alternateStages.isEmpty() ? null : this.uId;
		},

		/**
		 * Returns parent stage. If stage is not alternative stage, returns null.
		 * @return {BPMSoft.Designers.DcmSchemaStage|null} Parent stage.
		 */
		getParentStage: function() {
			var parentStageUId = this.getParentStageUId();
			if (parentStageUId == null) {
				return null;
			}
			return this.parentSchema.stages.get(parentStageUId);
		},

		/**
		 * Returns flag that indicates whether that stage instance is parent of alternative stages group.
		 * @return {Boolean} True if stage is parent of group, else False.
		 */
		getIsParent: function() {
			var parentStageUId = this.getParentStageUId();
			return parentStageUId === this.uId;
		},

		/**
		 * Returns alternative stages for parent stage. If stage is not parent of group, returns empty collection.
		 * @return {BPMSoft.core.collections.Collection}
		 */
		getChildren: function() {
			this.checkParentSchema();
			return this.parentSchema.stages.filter("parentStageUId", this.uId);
		},

		/**
		 * Returns flag that indicates whether the stage is last stage in group.
		 * If stage is not alternative to another stage, returns false.
		 * @return {Boolean}
		 */
		getIsLastStageInGroup: function() {
			var parentStage = this.getParentStage();
			if (parentStage == null) {
				return false;
			}
			var alternativeStages = parentStage.getChildren();
			var stageIndexInGroup = alternativeStages.indexOf(this);
			var groupLength = alternativeStages.getCount();
			return stageIndexInGroup === groupLength - 1;
		},

		/**
		 * Returns True if stage is last in collection.
		 * @return {Boolean}
		 */
		getIsLastStage: function() {
			var stageIndex = this.parentSchema.stages.indexOf(this);
			var stagesLength = this.parentSchema.stages.getCount();
			return stageIndex === stagesLength - 1;
		}

		//endregion

	});
	return BPMSoft.Designers.DcmSchemaStage;
});
