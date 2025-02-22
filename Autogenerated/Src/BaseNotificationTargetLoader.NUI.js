﻿define("BaseNotificationTargetLoader", ["NetworkUtilities", "BaseModule"],
		function(NetworkUtilities) {
			Ext.define("BPMSoft.configuration.BaseNotificationTargetLoader", {
				extend: "BPMSoft.BaseModule",
				alternateClassName: "BPMSoft.BaseNotificationTargetLoader",
				Ext: null,
				sandbox: null,
				BPMSoft: null,

				/**
				 * Loads target page.
				 * @param {BPMSoft.BaseViewModel} config Object to generate configuration.
				 */
				loadFromViewModel: function(config) {
					var hash = NetworkUtilities.getEntityUrl(config.get("SchemaName"), config.get("SubjectId"));
					this.sandbox.publish("PushHistoryState", {hash: hash});
				},

				/**
				 * Loads target page.
				 * @param {Object} config Object to generate configuration.
				 */
				loadFromPopup: function(config) {
					var parts = config.id.split("_");
					var entitySchemaName = parts[0];
					var id = parts[1];
					var hash = NetworkUtilities.getEntityUrl(entitySchemaName, id);
					this.sandbox.publish("PushHistoryState", {hash: hash});
				},

				/**
				 * Initialize module.
				 */
				init: function() {
					var config = this.sandbox.publish("GetNotificationInfo", {}, [this.sandbox.id]);
					if (Ext.isEmpty(config)) {
						return;
					}
					if (!Ext.isEmpty(config.get)) {
						this.loadFromViewModel(config);
					} else {
						this.loadFromPopup(config);
					}
				}
			});

			return BPMSoft.BaseNotificationTargetLoader;
		});
