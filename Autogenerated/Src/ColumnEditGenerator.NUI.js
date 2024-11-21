define("ColumnEditGenerator", ["ext-base", "ViewGeneratorV2"],
	function(Ext) {

		Ext.define("BPMSoft.configuration.ColumnEditGenerator", {
			extend: "BPMSoft.ViewGenerator",
			alternateClassName: "BPMSoft.ColumnEditGenerator",

			/**
			 * ### ###### ###### ### ###### ###### ###### #######.
			 * @private
			 * @type {String}
			 */
			loadColumnMethodName: "loadColumn",

			/**
			 * ### ###### ###### ### ########## ########### ######.
			 * @private
			 * @type {String}
			 */
			prepareListMethodName: "loadColumnsData",

			/**
			 * @inheritDoc BPMSoft.configuration.ViewGenerator#generateLookupEdit
			 * @overridden
			 */
			generateLookupEdit: function() {
				var lookupEdit = this.callParent(arguments);
				Ext.apply(lookupEdit, {
					loadVocabulary: { bindTo: this.loadColumnMethodName },
					prepareList: { bindTo: this.prepareListMethodName }
				});
				return lookupEdit;
			}
		});

		return Ext.create("BPMSoft.ColumnEditGenerator");

	});
