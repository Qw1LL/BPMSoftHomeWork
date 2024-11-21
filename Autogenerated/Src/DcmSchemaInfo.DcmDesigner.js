define("DcmSchemaInfo", ["ext-base", "BPMSoft"],
	function(Ext, BPMSoft) {

		/**
		 * Dcm schema info class.
		 */
		Ext.define("BPMSoft.Designers.DcmSchemaInfo", {
			alternateClassName: "BPMSoft.DcmSchemaInfo",

			//region Properties: Public

			/**
			 * Unique identifier of the schema.
			 * @type {String}
			 */
			uId: null,

			/**
			 * Name of the schema.
			 * @type {String}
			 */
			name: null,

			/**
			 * Caption of the schema.
			 * @type {String}
			 */
			caption: null,

			/**
			 * Stages.
			 * @type {BPMSoft.Collection}
			 */
			stages: null,

			/**
			 * Stage connections.
			 * @type {BPMSoft.DcmSchemaStageConnections}
			 */
			stageConnections: null,

			/**
			 * Entity schema unique identifier.
			 * @type {String}
			 */
			entitySchemaUId: null,

			/**
			 * Stage column unique identifier.
			 * @type {String}
			 */
			stageColumnUId: null,

			//endregion

			//region Constructors: Public

			/**
			 * Constructor for DcmSchemaInfo class.
			 */
			constructor: function(config) {
				this.uId = config.uId;
				this.name = config.name;
				this.caption = config.caption;
				this.entitySchemaUId = config.entitySchemaUId;
				this.stageColumnUId = config.stageColumnUId;
				this._initStages(config.stages || []);
				this._initStageConnections(config.stageConnections || []);
			},

			//endregion

			//region Methods: Private

			/**
			 * @private
			 */
			_initStages: function(stages) {
				const stageItems = Ext.create("BPMSoft.Collection");
				BPMSoft.each(stages, function(stage) {
					stageItems.add(stage.uId, stage);
				}, this);
				this.stages = stageItems;
			},

			/**
			 * @private
			 */
			_initStageConnections: function(stageConnections) {
				const stageConnectionItems = [];
				BPMSoft.each(stageConnections, function(stageConnection) {
					const stageConnectionItem = Ext.create("BPMSoft.DcmSchemaStageConnection");
					stageConnectionItem.source = stageConnection.source;
					stageConnectionItem.target = stageConnection.target;
					stageConnectionItems.push(stageConnectionItem);
				}, this);
				this.stageConnections = Ext.create("BPMSoft.DcmSchemaStageConnections", {
					connections: stageConnectionItems
				});
			}

			//endregion

		});

		return BPMSoft.Designers.DcmSchemaInfo;
	}
);
 