define("ViewModelSchemaDesignerTabContainer", ["ext-base", "BPMSoft", "ViewModelSchemaDesignerTabItem"],
	function(Ext, BPMSoft) {
		/**
		 * Class for reorderable tab container.
		 * @class BPMSoft.ViewModelSchemaDesignerTabContainer
		 * @extends {@link BPMSoft.Container}
		 */
		Ext.define("BPMSoft.ViewModelSchemaDesignerTabContainer", {
			extend: "BPMSoft.Container",

			mixins: {
				reorderable: "BPMSoft.Reorderable",
				droppable: "BPMSoft.Droppable"
			},

			/**
			 * @inheritdoc BPMSoft.Reorderable#zeroElClassName
			 * @overridden
			 */
			zeroElClassName: "tab-item-content-reorderable-zero-element",

			/**
			 * @inheritdoc BPMSoft.Component#onAfterRender
			 * @overridden
			 */
			onAfterRender: function() {
				this.callParent(arguments);
				this.mixins.droppable.onAfterRender.apply(this, arguments);
				this.mixins.reorderable.onAfterRender.apply(this, arguments);
			},

			/**
			 * @inheritdoc BPMSoft.Component#onAfterReRender
			 * @overridden
			 */
			onAfterReRender: function() {
				this.callParent(arguments);
				this.mixins.droppable.onAfterReRender.apply(this, arguments);
				this.mixins.reorderable.onAfterReRender.apply(this, arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @overridden
			 */
			onDestroy: function() {
				this.mixins.droppable.onDestroy.apply(this, arguments);
				this.mixins.reorderable.onDestroy.apply(this, arguments);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.Bindable#getBindConfig
			 * @overridden
			 */
			getBindConfig: function() {
				var reorderableBindConfig = this.mixins.reorderable.getBindConfig.apply(this, arguments);
				var droppableBindConfig = this.mixins.droppable.getBindConfig.apply(this, arguments);
				var parentBindConfig = this.callParent(arguments);
				return Ext.apply(droppableBindConfig, reorderableBindConfig, parentBindConfig);
			},

			/**
			 * @inheritdoc BPMSoft.Bindable#subscribeForCollectionEvents
			 * @overridden
			 */
			subscribeForCollectionEvents: function() {
				this.callParent(arguments);
				this.mixins.reorderable.subscribeForCollectionEvents.apply(this, arguments);
			},

			/**
			 * @inheritdoc BPMSoft.Bindable#unSubscribeForCollectionEvents
			 * @overridden
			 */
			unSubscribeForCollectionEvents: function() {
				this.callParent(arguments);
				this.mixins.reorderable.unSubscribeForCollectionEvents.apply(this, arguments);
			}
		});

		return BPMSoft.ViewModelSchemaDesignerTabContainer;
	});
