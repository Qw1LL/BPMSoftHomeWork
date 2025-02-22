﻿define("CommunicationSynchronizerMixin", [], function() {
	/**
	 * @class BPMSoft.configuration.mixins.CommunicationSynchronizerMixin
	 * Communication synchronizer mixin.
	 */
	Ext.define("BPMSoft.configuration.mixins.CommunicationSynchronizerMixin", {

		alternateClassName: "BPMSoft.CommunicationSynchronizerMixin",

		/**
		 * Removes changedValues columns wich would be synchronized by detail from entity.
		 * @protected
		 */
		clearChangedValuesSynchronizedByDetail: function() {
			var detailName = this.get("CommunicationDetailName");
			var communicationDetailId = this.getDetailId(detailName);
			if (communicationDetailId) {
				var communicationsSavedByDetail =
					this.sandbox.publish("GetCommunicationsSynchronizedByDetail", null, [communicationDetailId]);
				this.BPMSoft.each(communicationsSavedByDetail, function(item) {
					var modelColumn = this.getColumnByName(item);
					if (modelColumn && !modelColumn.isRequired) {
						delete this.changedValues[item];
					}
				}, this);
			}
		},

		/**
		 * Synchronizes entity column with communication detail.
		 * @protected
		 * @param {Mixed} arg Dependency argument.
		 * @param {String} columnName Sync column name.
		 */
		syncEntityWithCommunicationDetail: function(arg, columnName) {
			var communicationDetailName = this.get("CommunicationDetailName");
			if (this.Ext.isEmpty(communicationDetailName)) {
				return;
			}
			var syncColumnValue = this.get(columnName);
			this.set(columnName, syncColumnValue);
			var syncOldColumnValue = this.getPrevious(columnName);
			var communicationDetailId = this.getDetailId(communicationDetailName);
			this.sandbox.publish("SyncCommunication", {
				syncColumnName: columnName,
				syncColumnValue: syncColumnValue,
				syncOldColumnValue: syncOldColumnValue
			}, [communicationDetailId]);
		}
	});
	return BPMSoft.CommunicationSynchronizerMixin;
});
