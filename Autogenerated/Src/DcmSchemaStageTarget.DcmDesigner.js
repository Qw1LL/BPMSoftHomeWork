define("DcmSchemaStageTarget", ["ext-base", "BPMSoft"],
	function(Ext, BPMSoft) {
		/**
		 * @class BPMSoft.Designers.DcmSchemaStageTarget
		 * Dcm stage target schema class.
		 */
		Ext.define("BPMSoft.Designers.DcmSchemaStageTarget", {
			extend: "BPMSoft.BaseProcessSchemaElement",
			alternateClassName: "BPMSoft.DcmSchemaStageTarget",

			//region Properties: Protected

			/**
			 * List of target stages uId.
			 * @type {Array}
			 */
			targets: null,

			//endregion

			//region Constructors: Public

			/**
			 * @inheritdoc BPMSoft.manager.BaseObject#constructor
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				this.targets = [];
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
			 * @overridden
			 */
			getSerializableProperties: function() {
				var properties = this.callParent(arguments);
				return Ext.Array.push(properties, ["targets"]);
			},

			//endregion

			//region Methods: Public

			/**
			 * Returns source stage UId.
 			 * @return {String}
			 */
			getStageUId: function() {
				return this.uId;
			}

			//endregion

		});

		return BPMSoft.Designers.DcmSchemaStageTarget;
	}
);
