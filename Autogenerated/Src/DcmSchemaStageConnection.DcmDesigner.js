define("DcmSchemaStageConnection", ["ext-base", "BPMSoft"],
	function(Ext, BPMSoft) {
		Ext.define("BPMSoft.Designers.DcmSchemaStageConnection", {
			alternateClassName: "BPMSoft.DcmSchemaStageConnection",

			mixins: {
				serializable: "BPMSoft.Serializable"
			},

			/**
			 * Uid of the stage from which connection is established.
			 * @type {String}
			 */
			source: null,

			/**
			 * Uid of the stage to which connection is established
			 * @type {String}
			 */
			target: null,

			/**
			 * Returns equality of this and given connections.
			 * @param {BPMSoft.DcmSchemaStageConnection} connection Connection to compare.
			 * @returns {boolean} True if connections are equal.
			 */
			getIsEqual: function(connection) {
				return this.source === connection.source && this.target === connection.target;
			},

			/**
			 * @inheritdoc BPMSoft.Serializable#getSerializableObject
			 * @overridden
			 */
			getSerializableObject: function(serializableObject) {
				var sourceData = this.getSerializableProperty(this.source);
				var targetData = this.getSerializableProperty(this.target);
				var config = {
					"typeName": "BPMSoft.Core.DcmProcess.DcmSchemaStageConnection",
					"source": sourceData,
					"target": targetData
				};
				serializableObject.connections.push(config);
			}
		});

		return BPMSoft.Designers.DcmSchemaStageConnection;
	}
);
