define("BaseCommunicationDetail", ["CTIBaseCommunicationViewModel"],
	function() {
		return {
			messages: {
				"CallCustomer": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"DoNotUseCommunication": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {

				/**
				 * ############## ######.
				 * @inheritdoc BPMSoft.BaseCommunicationDetail#init
				 * @overridden
				 */
				init: function() {
					this.set("BaseCommunicationViewModelClassName", "BPMSoft.CTIBaseCommunicationViewModel");
					this.callParent(arguments);
				}
			}
		};
	});
