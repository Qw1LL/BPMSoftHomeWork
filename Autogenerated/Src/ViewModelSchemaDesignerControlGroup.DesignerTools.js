﻿define("ViewModelSchemaDesignerControlGroup", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	/**
	 * Class for control grouping in design time.
	 * @class BPMSoft.ViewModelSchemaDesignerControlGroup
	 * @extends {@link BPMSoft.ControlGroup}
	 */
	Ext.define("BPMSoft.ViewModelSchemaDesignerControlGroup", {
		extend: "BPMSoft.ControlGroup",

		/**
		 * @inheritdoc BPMSoft.controls.ControlGroup#getTpl
		 * @overridden
		 */
		getTpl: function() {
			return [
				/* jshint ignore:start */
				/* jscs:disable */
				'<div id="{id}-wrap" class="{wrapClass}" style="{wrapStyle}">',
				'<tpl if="isHeaderVisible">',
				'<div id="{id}-caption-wrap" class="ts-controlgroup-caption-wrap draggable-item-move">',
				'<div id="{id}-wrap-marker" class="ts-controlgroup-marker-wrap">',
				'<div id="{id}-marker" class="ts-controlgroup-marker">',
				'</div>',
				'</div>',
				'<span id="{id}-caption">',
				'{caption}',
				'</span>',
				'<div id="{id}-tools" class="ts-controlgroup-tools ts-box-sizing">',
				'<tpl for="tools">',
				'</span>{%this.renderTool(out, values)%}',
				'</tpl>',
				'</div>',
				'</div>',
				'</tpl>',
				'<div id="{id}" class="{wrapContainerClass}">',
				'<tpl for="items">',
				'<@item>',
				'</tpl>',
				'</div>',
				'</div>'
				/* jscs:enable */
				/* jshint ignore:end */
			];
		},

		/**
		 * @inheritdoc BPMSoft.controls.ControlGroup#getSelectors
		 * @overridden
		 */
		getSelectors: function() {
			var selectors = this.callParent(arguments);
			selectors.captionWrapEl = Ext.String.format("#{0}-caption-wrap", this.id);
			return selectors;
		},

		/**
		 * @inheritdoc BPMSoft.controls.ControlGroup#setCollapsed
		 * @overridden
		 */
		setCollapsed: function(collapsed) {
			this.callParent(arguments);
			var rendered = this.allowRerender();
			var items = this.items;
			if (rendered && !collapsed && !Ext.isEmpty(items)) {
				items.each(function(item) {
					if (item.className === "BPMSoft.GridLayoutEdit") {
						item.reRender();
					}
				});
			}
		}
	});

	return BPMSoft.ViewModelSchemaDesignerControlGroup;
});
