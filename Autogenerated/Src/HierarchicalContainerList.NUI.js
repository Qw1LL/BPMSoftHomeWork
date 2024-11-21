define("HierarchicalContainerList", ["ContainerList"], function() {

	/**
	 * Implements view of the collection of items by container config with hierarchical feature.
	 */
	Ext.define("BPMSoft.controls.HierarchicalContainerList", {
		extend: "BPMSoft.ContainerList",
		alternateClassName: "BPMSoft.HierarchicalContainerList",

		// region Properties: Public

		/**
		 * Name of hierarchical property.
		 */
		nestedItemsAttributeName: null,

		/**
		 * Id of nested items container.
		 */
		nestedItemsContainerId: null,

		/**
		 * Determines an attribute name to use when generating a nested container id. Defaults to item sandbox id.
		 */
		nestedContainerIdAttributeName: null,

		/**
		 * Determines whether to handle item addition or not.
		 */
		handleAddItems: false,

		// endregion

		// region Methods: Private

		/**
		 * Has parameter nested parameters.
		 * @private
		 */
		_hasNested: function(item) {
			return this.handleAddItems || (!Ext.isEmpty(this.nestedItemsAttributeName) &&
				item.get(this.nestedItemsAttributeName) && item.get(this.nestedItemsAttributeName).getCount() > 0);
		},

		/**
		 * @private
		 */
		_getContainerId: function(item) {
			return this.nestedContainerIdAttributeName
				? item.get(this.nestedContainerIdAttributeName)
				: item.sandbox.id;
		},

		/**
		 * Creates nested items control config.
		 * @private
		 */
		_generateNestedContainerListConfig: function(item) {
			const containerId = this._getContainerId(item);
			const wrapEl = this.initialConfig.selectors && this.initialConfig.selectors.wrapEl;
			const containerListConfig = Ext.merge(Ext.clone(this.initialConfig), {
				id: this.initialConfig.id + containerId,
				collection: {
					bindTo: this.nestedItemsAttributeName
				}
			});
			if (wrapEl) {
				containerListConfig.selectors = {
					wrapEl: wrapEl + containerId
				};
			}
			return {
				items: [containerListConfig]
			};
		},

		/**
		 * Adds nested hierarchical container list to current container.
		 * @private
		 */
		_addNestedToContainer: function(container, item) {
			if (container && container.items) {
				const viewConfig = this._generateNestedContainerListConfig(item);
				const id = this._getContainerId(item) + "NestedItemsContainer";
				const itemView = Ext.create("BPMSoft.Container", Ext.merge(viewConfig, {
					id: id
				}));
				container.items.push(itemView);
			}
		},

		/**
		 * Searches for element in view configuration by id.
		 * @param {Object[]} viewConfig Configuration of the view.
		 * @param {String} itemId Item id.
		 * @return {Object} Searched item.
		 */
		_findViewConfigItem: function(viewConfig, itemId) {
			let result = null;
			if (viewConfig && Ext.isArray(viewConfig.items)) {
				BPMSoft.each(viewConfig.items, function(item) {
					if ((item && item.id) === itemId) {
						result = item;
						return false;
					} else {
						result = this._findViewConfigItem(item, itemId);
						if (result) {
							return false;
						}
					}
				}, this);
			}
			return result;
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritDoc BPMSoft.BPMSoft.ContainerList#getItemView
		 */
		getItemView: function(item) {
			const prefix = this.itemPrefix || item.sandbox.id;
			const id = item.get(this.idProperty);
			const itemConfig = this.getItemViewConfig(item);
			itemConfig.classes.wrapClassName.push("hierarchical-container-list-item");
			const targetForNested = this._findViewConfigItem(itemConfig, this.nestedItemsContainerId);
			this.decorateView([itemConfig], id, prefix);
			const className = itemConfig && itemConfig.className ? itemConfig.className : "BPMSoft.Container";
			if (this._hasNested(item)) {
				this._addNestedToContainer(targetForNested, item);
			}
			return Ext.create(className, itemConfig);
		}

		// endregion

	});

});
