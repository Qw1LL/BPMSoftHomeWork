define("ObjectLinkStructureExplorerViewModel", ["StructureExplorerMainViewModel"],
function() {

	/**
	 * @class BPMSoft.configuration.ObjectLinkStructureExplorerViewModel
	 * Object link structure explorer view model class.
	 */
	Ext.define("BPMSoft.configuration.ObjectLinkStructureExplorerViewModel", {
		extend: "BPMSoft.StructureExplorerMainViewModel",
		alternateClassName: "BPMSoft.ObjectLinkStructureExplorerViewModel",

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.StructureExplorerMainViewModel#init
		 * @overridden
		 */
		init: function(callback, scope) {
			this.$IsBottomPanelVisible = false;
			this.callParent([function() {
				Ext.callback(callback, scope || this);
			}, this]);
		},

		/**
		 * @inheritdoc BPMSoft.StructureExplorerMainViewModel#modifySelectResponse
		 * @overridden
		 */
		modifySelectResponse: function() {
			let response = this.callParent(arguments);
			response.linkColor = this.$LinkColor;
			return response;
		},

		/**
		 * @inheritdoc BPMSoft.StructureExplorerMainViewModel#setSourceItems
		 * @overridden
		 */
		setSourceItems: function(identifier, callback, scope) {
			this.callParent([identifier, function(items) {
				const referenceSchemaName = identifier.referenceSchemaName;
				const referenceSchema = BPMSoft[referenceSchemaName];
				if (referenceSchema) {
					var primaryDisplayColumn = referenceSchema.primaryDisplayColumn;
					if (primaryDisplayColumn) {
						var entitySchemaColumn = {
							columnName: primaryDisplayColumn.name,
							customHtml: primaryDisplayColumn.caption,
							dataValueType: BPMSoft.DataValueType.TEXT,
							displayValue: primaryDisplayColumn.caption,
							isLookup: false,
							markerValue: primaryDisplayColumn.name.concat(" ", primaryDisplayColumn.caption),
							value: primaryDisplayColumn.uId
						};
						this.set("EntitySchemaColumn", entitySchemaColumn);
					}
				}
				Ext.callback(callback, scope, [items]);
			}, this]);
			
			
		}

		//endregion

	});
	return BPMSoft.ObjectLinkStructureExplorerViewModel;
});
