﻿define("EmailMiningEnums", [],
	function() {
		Ext.ns("BPMSoft.EmailMiningEnums");

		/**
		 * @enum
		 * EnrichStatus property of Websocket response message.
		 */
		BPMSoft.EmailMiningEnums.EmailEnrichStatus = {
			/**
			 * Email not processed yet.
			 */
			INACTIVE: "",
			/**
			 * Enrichment process successfully completed.
			 */
			DONE: "Done",
			/**
			 * Enrichment service return error for email.
			 */
			ERROR: "Error"
		};

		/**
		 * @enum
		 * Values enum for Status column of EnrichEmailData.
		 */
		BPMSoft.EmailMiningEnums.EnrichEmailDataStatus = {
			/**
			 * Email data mined, but not processed by user yet.
			 */
			MINED: "Mined",
			/**
			 * Email data processed.
			 */
			ENRICHED: "Enriched"
		};

		/**
		 * @enum
		 * Values enum for websocket message body type.
		 */
		BPMSoft.EmailMiningEnums.EnrichMessageBodyType = {
			/**
			 * Email signtures enriched message type.
			 */
			ENRICHED: "EmailEnriched",
			/**
			 * Enrich data saved message type.
			 */
			SAVED: "EnrichedDataSaved"
		};

		/**
		 * @enum
		 * Statuses of the extracted entity duplication. Indicates if the extracted data found in existing business entity.
		 */
		BPMSoft.EmailMiningEnums.EnrchDuplicateStatus = {
			/**
			 * Not exists in the business entity (new data).
			 */
			NOT_DUPLICATED: "",
			/**
			 * Exists in the business entity.
			 */
			EXISTS_IN_ENTITY: "ExistsInEntity"
		};
	}
);
