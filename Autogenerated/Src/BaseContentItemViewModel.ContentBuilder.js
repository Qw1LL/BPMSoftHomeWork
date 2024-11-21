/**
 * Base view model for all view models which adds on ContentBuilder sheet.
 */
define("BaseContentItemViewModel", ["BaseContentSerializableViewModelMixin"], function() {
	Ext.define("BPMSoft.configuration.BaseContentItemViewModel", {
		extend: "BPMSoft.BaseViewModel",
		alternateClassName: "BPMSoft.BaseContentItemViewModel",

		mixins: {
			SerializableMixin: "BPMSoft.BaseContentSerializableViewModelMixin"
		},

		/**
		 * Creates config clone and defines additional or empty properties.
		 * @protected
		 * @virtual
		 * @param {Object} config Config object from constructor.
		 */
		getPreparedConfigBeforeCreate: function(config) {
			var changedConfig = BPMSoft.deepClone(config);
			changedConfig.Styles = config.Styles || {};
			return changedConfig;
		},

		/**
		 * Extends childItemTypes collection from BPMSoft.BaseContentSerializableViewModelMixin.
		 * Function calls first of all in constructor for defines new or replace existing items in collection.
		 * @protected
		 */
		extendChildrenItemTypes: BPMSoft.emptyFn,

		/**
		 * Extends serializableSlicePropertiesCollection from BPMSoft.BaseContentSerializableViewModelMixin.
		 * Function calls first of all in constructor for defines new or replace existing items in collection.
		 * @protected
		 */
		extendSerializableSlicePropertiesCollection: BPMSoft.emptyFn,

		/**
		 * Sandbox instance.
		 * @type {Object}
		 */
		sandbox: null,

		/**
		 * Constructor which prepared values for create instance.
		 * If class contains children elements - constructor creates child elements.
		 * @public
		 * @param {Object} config Contains values property for create view model instance with defined values properties.
		 * @param {Boolean} isOldElement Flag indicates how view model creates.
		 * If true - view model creates by BPMSoft.ContentBuilderHelper, in otherwise - without helper.
		 */
		constructor: function(config, isOldElement) {
			this.extendChildrenItemTypes();
			this.extendSerializableSlicePropertiesCollection();
			var copiedConfig = Ext.apply({}, config);
			this.sandbox = config && config.sandbox;
			if (isOldElement !== true && config && config.values) {
				var preparedConfig = this.getPreparedConfigBeforeCreate(config.values);
				var values = this.prepareValues(preparedConfig);
				if (preparedConfig.Items) {
					values.Items = new BPMSoft.BaseViewModelCollection();
					BPMSoft.each(preparedConfig.Items, function (item) {
						var vm = this.createItemViewModel(item);
						values.Items.add(vm.$Id, vm);
					}, this);
				}
				copiedConfig.values = values;
				arguments[0] = copiedConfig;
			}
			this.callParent(arguments);
		}
	});
	return BPMSoft.BaseContentItemViewModel;
});
