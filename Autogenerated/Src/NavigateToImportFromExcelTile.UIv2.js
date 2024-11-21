define("NavigateToImportFromExcelTile", ["NavigateToImportFromExcelTileResources", "RightUtilities"],
	function(resources, RightUtilities) {

		/**
		 * @class BPMSoft.configuration.NavigateToImportFromExcelTileViewModel
		 * ##### ###### ############# ######.
		 */
		Ext.define("BPMSoft.configuration.NavigateToImportFromExcelTileViewModel", {
			extend: "BPMSoft.SystemDesignerTileViewModel",
			alternateClassName: "BPMSoft.NavigateToImportFromExcelTileViewModel",
			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * ###### #### #######.
			 * {String}
			 */
			windowHeight: "300",

			/**
			 * ###### #### #######.
			 * {String}
			 */
			windowWidth: "600",

			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.SystemDesignerTileViewModel#onClick
			 * @overridden
			 */
			onClick: function() {
				if (this.get("CanImportFromExcel") != null) {
					this.navigateToImportFromExcel();
				} else {
					RightUtilities.checkCanExecuteOperation({
						operation: "CanImportFromExcel"
					}, function(result) {
						this.set("CanImportFromExcel", result);
						this.navigateToImportFromExcel();
					}, this);
				}
			},

			/**
			 * ######### #### ####### ###### ## Excel.
			 * @private
			 */
			navigateToImportFromExcel: function() {
				if (this.get("CanImportFromExcel") === true) {
					var url = BPMSoft.workspaceBaseUrl + "/ViewPage.aspx?Id=c2af7f54-07df-4670-9c2b-af2497d3231f";
					window.open(url, "_blank", "height=" + this.windowHeight + ",width=" + this.windowWidth);
				} else {
					var message = this.get("Resources.Strings.RightsErrorMessage");
					this.BPMSoft.utils.showInformation(message);
				}
			}
		});
	});
