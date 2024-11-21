define("ChangeLogUtilities", ["ext-base", "BPMSoft", "RightUtilities"], function(Ext, BPMSoft, rightUtilities) {

	/**
	 * Auxiliary class to work with the change log.
	 */
	Ext.define("BPMSoft.configuration.ChangeLogUtilities", {
		alternateClassName: "BPMSoft.ChangeLogUtilities",

		/**
		 * Returns change log base Url.
		 * @return {String} Change log base url.
		 */
		getChangeLogBaseUrl: function() {
			return [
				BPMSoft.workspaceBaseUrl,
				"ClientApp",
				"#",
				"ChangeLog"
			].join("/");
		},

		/**
		 * Checks if can show change log for entity schema.
		 * @param {*} entitySchema Entity schema.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Execution context.
		 */
		canShowEntitySchemaChangeLog: function(entitySchema, callback, scope) {
			if (!entitySchema || !entitySchema.isTrackChangesInDB || BPMSoft.Features.getIsDisabled("NewChangeLogUI")) {
				Ext.callback(callback, scope, [false]);
				return;
			}
			rightUtilities.checkCanExecuteOperation({
				operation: "CanViewChangeLog"
			}, function(result) {
				Ext.callback(callback, scope, [result]);
			}, this);
		},

		/**
		 * Checks if can show object change log settings.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Execution context.
		 */
		canShowObjectChangeLogSettings: function(callback, scope) {
			if (BPMSoft.Features.getIsDisabled("NewChangeLogUI")) {
				Ext.callback(callback, scope, [false]);
				return;
			}
			rightUtilities.checkCanExecuteOperation({
				operation: "CanManageChangeLog"
			}, function(result) {
				Ext.callback(callback, scope, [result]);
			}, this);
		},

		/**
		 * Opens record change log.
		 * @param {String} entitySchemaUid Entity schema unique identifier.
		 * @param {String} primaryColumnValue Entity schema primary column value.
		 */
		openRecordChangeLog: function(entitySchemaUid, primaryColumnValue) {
			var url = [
				this.getChangeLogBaseUrl(),
				entitySchemaUid,
				primaryColumnValue
			].join("/");
			window.open(url, "_blank");
		},

		/**
		 * Opens object change log settings.
		 * @param {String} entitySchemaUid Entity schema unique identifier.
		 */
		openObjectChangeLogSettings: function(entitySchemaUid) {
			var url = [
				this.getChangeLogBaseUrl(),
				entitySchemaUid
			].join("/");
			window.open(url, "_blank");
		},

		/**
		 * Opens change log settings.
		 */
		openChangeLogSettings: function() {
			window.open(this.getChangeLogBaseUrl(), "_blank");
		}
	});

	return Ext.create("BPMSoft.ChangeLogUtilities");
});
