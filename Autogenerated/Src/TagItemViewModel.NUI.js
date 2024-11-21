define("TagItemViewModel", ["TagItemViewModelResources", "TagConstantsV2", "css!TagModuleSchemaStyles"],
	function(resources, TagConstants) {
		/**
		 * @class BPMSoft.configuration.TagItemViewModel
		 */
		Ext.define("BPMSoft.configuration.TagItemViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.TagItemViewModel",

			Ext: null,
			BPMSoft: null,
			sandbox: null,

			/**
			 * ############# ####### ######## ####.
			 * @protected
			 */
			init: function() {
				this.addEvents(
					/**
					 * @event
					 * ####### ######## ####.
					 * @param {Object} viewModel ###### ############# ####.
					 */
					"entityInTagDeleted"
				);
			},

			/**
			 * ######### ###### ## ######## #### # ###### #######.
			 * @private
			 * @returns {BPMSoft.DeleteQuery} ###### ## ######## ######
			 */
			getDeleteQuery: function() {
				var deleteQuery = this.Ext.create("BPMSoft.DeleteQuery", {
					rootSchemaName: this.get("InTagSchemaName")
				});
				deleteQuery.filters.add(this.BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Id", this.get("Id")
				));
				return deleteQuery;
			},

			/**
			 * ########## ##### ## ###### "####### ###" # ###### ####.
			 * ####### ### ## ####### ######## ######.
			 * @protected
			 */
			onRemoveTagFromEntityImageClick: function() {
				if (this.BPMSoft.CurrentUser.userType !== this.BPMSoft.UserType.SSP) {
					this.deleteTag();
				} else if (this.BPMSoft.CurrentUser.userType === this.BPMSoft.UserType.SSP &&
					this.get("TagTypeId") === TagConstants.TagType.Public) {
					this.showInformationDialog(resources.localizableStrings.CannotDeleteTagMessage);
				} else {
					this.deleteTag();
				}
			},

			/**
			 * ####### ### ## ######, # ########### ###### ## ######## ######## ####.
			 * @private
			 */
			deleteTag: function() {
				var deleteQuery = this.getDeleteQuery();
				deleteQuery.execute(function(response) {
					if (response.success) {
						this.fireEvent("entityInTagDeleted", this);
					}
				}, this);
			},

			/**
			 * ########## ##### ## ####.
			 * ######### ######### # ############# ###### ## ####, # #######.
			 */
			onTagItemButtonClick: function() {

			}
		});
		return BPMSoft.TagItemViewModel;
	});
