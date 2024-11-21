define("CaseSection", [],
	function() {
		return {
			entitySchemaName: "Case",
			messages: {
				/**
				 * @message GetCaseStatus
				 * Send information about case status to section.
				 */
				"SendCaseStatusToSection": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {
				/**
				 * Run escalation action enabled.
				 */
				"RunEscalationEnabled": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * Run reclasification action enabled.
				 */
				"RunReclasificationEnabled": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				}
			},
			diff: /**SCHEMA_DIFF*/[

			]/**SCHEMA_DIFF*/,
			methods: {
				/**
				 * @inheritdoc this.BPMSoft.BaseSection#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initSectionMessages();
				},
				/**
				 * Initializes the initial values of the model.
				 * @protected
				 */
				initSectionMessages: function() {
					var subscriberId = this.sandbox.id + "_CardModuleV2";
					this.sandbox.subscribe("SendCaseStatusToSection", this.onSendCaseStatusToSection, this,
						[subscriberId]);
				},
				/**
				 * On send case status to section handler.
				 * Sets run escalation action enabled.
				 * @protected
				 */
				onSendCaseStatusToSection: function(status) {
					var runEscalationEnabled = this.getRunEscalationEnabled(status);
					this.set("RunEscalationEnabled", runEscalationEnabled);
					this.set("RunReclassificationEnabled", runEscalationEnabled);
				},
				/**
				 * Returns run escalation action enabled.
				 * @protected
				 * @virtual
				 * @return {Boolean} Run escalation action enabled.
				 */
				getRunEscalationEnabled: function(status) {
					return !status.IsFinal && !status.IsResolved;
				}
			}
		};
	});

