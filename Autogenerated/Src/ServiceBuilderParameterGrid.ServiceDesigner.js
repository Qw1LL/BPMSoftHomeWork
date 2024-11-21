 define("ServiceBuilderParameterGrid", ["ServiceBuilderParameterGridResources"], function() {
	return {
		messages: {

			/**
			 * @message GetSelectedParameters
			 * Subscribes on GetSelectedParameters.
			 * @return {Array} Returns selected parameters uids.
			 */
			GetSelectedParameters: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message UpdateGridParameters
			 * Publishes on UpdateGridParameters.
			 */
			GetParametersConfig: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}

		},
		attributes: {

			/**
			 * Parameters initial config
			 */
			ParametersConfig: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				value: null,
				onChange: "_onParameterConfigChanged"
			},

			/**
			 * Multiselect flag.
			 */
			MultiSelect: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			}

		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_onParameterConfigChanged: function() {
				this.initParameters(function() {
					this.updateGridViewModel();
					this.$SelectedRows = this.$GridData.getKeys();
					this.$ExpandHierarchyLevels = this.getHierarchicalNodesUIds(this.$GridData);
				}, this);
			},

			/**
			 * @private
			 */
			_onGetSelectedParameters: function () {
				return this.$SelectedRows;
			},

			/**
			 * @private
			 */
			_selectParent: function(id, selectedRows) {
				var selectedRow = this.$GridData.get(id);
				var parentId = selectedRow.$ParentId;
				if (parentId) {
					Ext.Array.include(selectedRows, parentId);
					this._selectParent(parentId, selectedRows);
				}
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseServiceParameterGrid#onSelectedRowsChange
			 * @override
			 */
			onSelectedRowsChange: function (previous, current) {
				this.callParent(arguments);
				var info = this.getSelectionInfo(previous, current);
				if (info.selected) {
					BPMSoft.each(info.ids, function(i) {
						this._selectParent(i, current);
					}, this);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseServiceParameterGrid#initParameters
			 * @override
			 */
			initParameters: function(callback, scope) {
				this.callParent([function() {
					this.$Parameters.clear();
					var parsedConfig = JSON.parse(this.$ParametersConfig);
					var parametersConfig = parsedConfig && parsedConfig.items;
					BPMSoft.each(parametersConfig, function(config, uid) {
						this.$Parameters.add(uid, this.Ext.create("BPMSoft.ServiceParameter", config));
					}, this);
					Ext.callback(callback, scope);
				}, this]);
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseObject#constructor
			 * @override
			 */
			constructor: function () {
				this.callParent(arguments);
				this.sandbox.subscribe("GetSelectedParameters", this._onGetSelectedParameters, this, [this.sandbox.id]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
			 * @override
			 */
			onRender: function () {
				this.callParent(arguments);
				this.$ParametersConfig = this.sandbox.publish("GetParametersConfig", null, [this.sandbox.id]);
			}

			//endregion

		},
		diff: [
			{
				operation: "remove",
				name: "EnableMultiSelect"
			},
			{
				operation: "remove",
				name: "DisableMultiSelect"
			},
			{
				operation: "insert",
				name: "label",
				parentName: "ToolbarContainer",
				propertyName: "items",
				index: 0,
				values: {
					itemType: BPMSoft.ViewItemType.LABEL,
					caption: "$Resources.Strings.ToolbarCaption",
					classes: { "labelClass": ["service-method-builder-caption-16"] }
				}
			}
		]
	};
});
