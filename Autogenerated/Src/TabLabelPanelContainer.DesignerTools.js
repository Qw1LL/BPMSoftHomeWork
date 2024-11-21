define("TabLabelPanelContainer", ["ext-base", "BPMSoft", "TabLabelPanelItem"],
	function(Ext, BPMSoft) {

		/**
		 * @class BPMSoft.TabLabelPanelContainer
		 * Tabs container class.
		 */
		Ext.define("BPMSoft.TabLabelPanelContainer", {
			extend: "BPMSoft.Container",

			mixins: {
				reorderable: "BPMSoft.Reorderable",
				droppable: "BPMSoft.Droppable"
			},

			/**
			 * @inheritDoc BPMSoft.Reorderable#reorderableElCls
			 * @protected
			 */
			reorderableElCls: "tab-label-panel-reorderable-position",

			/**
			 * @inheritDoc BPMSoft.Reorderable#zeroElClassName
			 * @protected
			 */
			zeroElClassName: "tab-label-panel-reorderable-zero-element",

			/**
			 * @inheritdoc BPMSoft.component#onAfterRender
			 * @overridden
			 */
			onAfterRender: function() {
				this.callParent(arguments);
				this.mixins.droppable.onAfterRender.apply(this, arguments);
				this.mixins.reorderable.onAfterRender.apply(this, arguments);
			},

			/**
			 * @inheritdoc BPMSoft.component#onAfterReRender
			 * @overridden
			 */
			onAfterReRender: function() {
				this.callParent(arguments);
				this.mixins.droppable.onAfterReRender.apply(this, arguments);
				this.mixins.reorderable.onAfterReRender.apply(this, arguments);
			},

			/**
			 * @inheritdoc BPMSoft.component#onDestroy
			 * @overridden
			 */
			onDestroy: function() {
				this.mixins.droppable.onDestroy.apply(this, arguments);
				this.mixins.reorderable.onDestroy.apply(this, arguments);
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc BPMSoft.Bindable#getBindConfig
			 * @protected
			 */
			getBindConfig: function() {
				var reorderableBindConfig = this.mixins.reorderable.getBindConfig.apply(this, arguments);
				var parentBindConfig = Ext.apply(reorderableBindConfig, this.callParent(arguments));
				return Ext.apply(parentBindConfig, {});
			},

			/**
			 * @inheritDoc BPMSoft.Reorderable#getItemConfig
			 * @protected
			 */
			getItemConfig: function(viewModelItem) {
				var self = this;
				return {
					className: "BPMSoft.TabLabelPanelItem",
					caption: {
						bindTo: "Caption"
					},
					id: viewModelItem.get("Id"),
					ondragenter: {
						bindTo: "onDragEnter"
					},
					ondragdrop: {
						bindTo: "onDragDrop"
					},
					ondragout: {
						bindTo: "onDragOut"
					},
					getGroupName: function() {
						return [self.getGroupName()];
					},
					click: {
						bindTo: "onTabClick"
					},
					afterrerender: {
						bindTo: "onItemReRender"
					}
				};
			},

			/**
			 * @inheritDoc BPMSoft.Reorderable#subscribeForCollectionEvents
			 * @protected
			 */
			subscribeForCollectionEvents: function() {
				this.callParent(arguments);
				this.mixins.reorderable.subscribeForCollectionEvents.apply(this, arguments);
			},

			/**
			 * @inheritDoc BPMSoft.Reorderable#unSubscribeForCollectionEvents
			 * @protected
			 */
			unSubscribeForCollectionEvents: function() {
				this.callParent(arguments);
				this.mixins.reorderable.unSubscribeForCollectionEvents.apply(this, arguments);
			},

			/**
			 * @inheritDoc BPMSoft.Reorderable#createZeroElement
			 * @protected
			 */
			createZeroElement: function() {
				var zeroElementId = this.getZeroElementId();
				var zeroElementControl = Ext.get(zeroElementId);
				if (zeroElementControl) {
					zeroElementControl.destroy();
				}
				var zeroElementHtml = Ext.String.format(this.zeroElTpl, this.getZeroElementId(), this.zeroElClassName);
				this.wrapEl.insertHtml("beforebegin", zeroElementHtml);
				var zeroElement = Ext.get(zeroElementId);
				var zeroDDElement = zeroElement.initDD(zeroElementId, {isTarget: true, instance: this, tag: zeroElementId}, {});
				if (Ext.isFunction(this.getGroupName)) {
					var groups = this.getGroupName();
					if (Ext.isArray(groups)) {
						BPMSoft.each(groups, function(group) {
							zeroDDElement.addToGroup(group);
						}, this);
					} else {
						zeroDDElement.addToGroup(groups);
					}
				}
			}
		});
	});
