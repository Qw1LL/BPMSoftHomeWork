define("DuplicatesWidgetModule", ["DuplicatesWidget", "DuplicatesWidgetViewModel"], function() {
	Ext.define("BPMSoft.configuration.DuplicatesWidgetModule", {
		extend: "BPMSoft.configuration.BaseModule",
		alternateClassName: "BPMSoft.DuplicatesWidgetModule",
		Ext: null,
		sandbox: null,
		BPMSoft: null,
		view: null,
		model: null,

		messages: {
			/**
			 * @message GetDuplicatesWidgetConfig
			 * Returns duplicates widget config.
			 */
			"GetDuplicatesWidgetConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message RefreshDuplicatesWidget
			 * Refresh duplicates widget data.
			 */
			"RefreshDuplicatesWidget": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message PushHistoryState
			 * Notification that history state was modified.
			 */
			"PushHistoryState": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
		},
		
		//region Methods: Private

		/**
		 * Renders duplicates widget.
		 * @param {Object} renderTo Element to rendering.
		 * @private
		 */
		_renderDuplicatesWidget: function(renderTo) {
			this.view = this.Ext.create("BPMSoft.DuplicatesWidget", {
				entitySchemaName: {"bindTo": "EntitySchemaName"},
				entityId: {"bindTo": "EntityId"},
				duplicates: {"bindTo": "Duplicates"},
				parentComponent: renderTo.id,
				widgetClick: {"bindTo": "onWidgetClick"}
			});
			this.view.bind(this.model);
			this.view.render(renderTo);
		},

		/**
		 * @private
		 */
		_updateConfig: function() {
			const config = this.sandbox.publish("GetDuplicatesWidgetConfig", null, [this.sandbox.id]) || {};
			if (!config) {
				return;
			}
			this.model.$EntitySchemaName = config.entitySchemaName;
			this.model.$EntityId = config.entityId;
			this.model.$Duplicates = config.duplicates;
		},
		
		//endregion
		
		//region Methods: Protected

		/**
		 * @inheritDoc BPMSoft.BaseModule#init
		 * @override
		 */
		init: function() {
			this.sandbox.registerMessages(this.messages);
			this.subscribeMessages();
			const config = this.sandbox.publish("GetDuplicatesWidgetConfig", null, [this.sandbox.id]) || {};
			this.model = Ext.create("BPMSoft.DuplicatesWidgetViewModel", {
				sandbox: this.sandbox,
				Ext: this.Ext,
				BPMSoft: this.BPMSoft
			});
			this.model.$EntitySchemaName = config.entitySchemaName;
			this.model.$EntityId = config.entityId;
			this.model.$Duplicates = config.duplicates;
			this.callParent(arguments);
		},

		/**
		 * Subscribes to messages of the module.
		 * @private
		 */
		subscribeMessages: function() {
			this.sandbox.subscribe("RefreshDuplicatesWidget", this.refreshDuplicatesWidget, this, [this.sandbox.id]);
		},

		/**
		 * Refresh duplicates widget data.
		 * @param {Boolean} overdue Data Overdue duplicates data.
		 */
		refreshDuplicatesWidget: function() {
			this._updateConfig();
		},

		/**
		 * @inheritDoc BPMSoft.BaseModule#render
		 * @override
		 */
		render: function(renderTo) {
			this.callParent(arguments);
			if (!renderTo.dom) {
				renderTo = Ext.get(renderTo.id);
			}
			this._renderDuplicatesWidget(renderTo);
		},

		/**
		 * @inheritDoc BPMSoft.BaseModule#destroy
		 * @override
		 */
		destroy: function() {
			if (this.view) {
				this.view.destroy();
			}
			if (this.model) {
				this.model.destroy();
			}
			this.callParent(arguments);
		}
		
		//endregion

	});

	return BPMSoft.DuplicatesWidgetModule;

});
