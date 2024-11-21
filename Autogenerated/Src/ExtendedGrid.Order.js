define("ExtendedGrid", ["css!ExtendedGrid"], function() {
	Ext.define("BPMSoft.controls.ExtendedGrid", {

		extend: "BPMSoft.Grid",

		alternateClassName: "BPMSoft.ExtendedGrid",

		/**
		 * ######## ######## # #### ##### ViewGenerator
		 * @type{Object}
		 */
		viewGenerator: null,

		/**
		 * ######## ######## # #### ##### ViewModel ##########
		 * @type{Object}
		 */
		viewModelClass: null,

		/**
		 * Css ##### ############## ### ####### ############# ###### #######
		 * @protected
		 */
		activeRowRemoveCss: "active-row-removed",

		/**
		 * @inheritDoc BPMSoft.Grid#init
		 * @overridden
		 */
		init: function() {
			this.callParent(arguments);
			this.addEvents(
				/**
				 * @event
				 * #####-#### "####### ########" # ######## ####### ####### ##### ##########
				 */
				"beforeChangedRow"
			);
		},

		/**
		 * ########## config ######## ###### # #######
		 * @protected
		 * @param id ############# ###### ######
		 * @return {object}
		 */
		getActiveRowViewConfig: function(id) {
			var col = 0;
			var gridLayoutItems = [];
			var columnsConfig = this.columnsConfig;
			var collection = this.collection;
			var viewModel = collection.get(id);
			BPMSoft.each(columnsConfig, function(item) {
				var colSpan = item.cols;
				var columnName = item.key[0].name.bindTo;
				var column = viewModel.columns[columnName];
				this.viewGenerator.viewModelClass = this.viewModelClass;
				var controlConfig = {
					bindTo: columnName,
					name: columnName,
					enabled: true,
					dataValueType: column.dataValueType
				};
				var control = this.viewGenerator.generateEditControl(controlConfig);
				gridLayoutItems.push({
					row: 0,
					column: col,
					colSpan: colSpan,
					item: control
				});
				col += colSpan;
			}, this);
			return {
				className: "BPMSoft.GridLayout",
				items: gridLayoutItems
			};
		},

		/**
		 * ##### ######## ######## ###### #######
		 * @protected
		 * @param newId ############# ###### ######
		 */
		setActiveRow: function(newId) {
			var oldId = this.activeRow;
			if (!oldId && !newId) {
				return;
			}
			if (newId !== oldId) {
				if (oldId) {
					var item = this.collection.get(oldId);
					if (item) {
						this.onUpdateItem(item, true);
					}
				}
				this.fireEvent("beforeChangedRow", oldId);
				this.deactivateRow(oldId);
				this.activateRow(newId);
				this.activeRow = newId;
				this.fireEvent("selectRow", this.activeRow);
			}
		},

		/**
		 * ##### ####### ############# ###### # ##########
		 * @protected
		 * @param id ############# ###### ######
		 */
		createActionsRow: function(id) {
			var renderTo = this.callParent(arguments);
			var viewConfig = this.getActiveRowViewConfig(id);
			var view = Ext.create("BPMSoft.GridLayout", viewConfig);
			var collection = this.collection;
			var viewModel = collection.get(id);
			view.bind(viewModel);
			view.render(renderTo);
			this.renderRowActions(renderTo, id);
		},

		/**
		 * ## ############# ######### ### ########## ##### # "##########" ### ######## ############# ###### #######
		 * @protected
		 * @param id ############# ###### ######
		 */
		addRowActions: function(id) {
			var actionsRow = Ext.get(this.id + this.actionsRowPrefix + id);
			if (!actionsRow) {
				var renderTo = this.createActionsRow(id);
				if (renderTo) {
					this.renderRowActions(renderTo, id);
				}
			} else {
				actionsRow.removeCls(this.hiddenCss);
			}
		},

		/**
		 * @protected
		 * @param id ############# ###### ######
		 */
		activateRow: function(id) {
			if (!this.rendered || !id) {
				return;
			}
			var row = this.getDomRow(id);
			row.addCls(this.activeRowCss);
			row.addCls(this.activeRowRemoveCss);
			this.addRowActions(id);
		},

		/**
		 * @protected
		 * @param id ############# ###### ######
		 */
		deactivateRow: function(id) {
			if (!this.rendered || !id) {
				return;
			}
			var row = this.getDomRow(id);
			row.removeCls(this.activeRowCss);
			row.removeCls(this.activeRowRemoveCss);
			this.removeRowActions(id);
		},

		/**
		 * ##### ####### #######. ######### ### DOM ######## ### # ###### ########### # #######, ## ## # #########.
		 * @overridden
		 */
		clear: function() {
			this.callParent(arguments);
			this.activeRow = null;
		},

		/**
		 * ########## ####### ########## ######
		 * @overridden
		 * @param item BPMSoft.BaseViewModel
		 */
		onUpdateItem: function(item, callParent) {
			if (callParent === true) {
				this.callParent(arguments);
			}
		}
	});
	return BPMSoft.ExtendedGrid;
});
