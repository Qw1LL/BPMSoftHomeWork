define("CampaignEnums", ["CampaignEnumsResources"],
	function(resources) {
		return {
			/**
			 * @enum
			 * Campaign diagram element type.
			 */
			StepType: {
				/* Bulk email */
				EMAIL_MAILING: "0270a11d-534c-40ec-8a72-c4902d6afb09",
				/* Event */
				EVENT: "75b0f8d2-a3f4-4715-ad37-a501543af26c",
				/* Campaign audience */
				CAMPAIGN_AUDIENCE: "36503c76-9542-45b6-a934-a61f2b9bce48",
				/* Target */
				TARGET: "30eb28eb-bb1f-4d18-9358-55556d80d833",
				/* Exiting from campaign */
				EXITING_CAMPAIGN: "b748cdc5-b478-4ed1-8b52-51513ee49ed9",
				/* Landing */
				LANDING: "5e9d3401-8047-4833-b9f0-c2c8d3dbbe62",
				/* Create lead */
				CREATE_LEAD: "12c48da4-8305-4aa7-92a9-2c75dc5d458b"
			},

			/**
			 * @enum
			 * Campaign filter types.
			 */
			CampaignFilter: {
				FORM_SUBMITTED: "71eb567e-4342-4442-bd28-70f0f32f7267",
				FORM_NOT_SUBMITTED: "b5bea8f2-04de-4a8f-a6c3-a35c14df6881",
				EMAIL_CLICKED: "7eaff636-eab8-4ebd-817a-5fb82a728f17"
			},

			/**
			 * @enum
			 * Campaign status.
			 */
			CampaignStatus: {
				/* Executed */
				EXECUTED: "49cc0a4f-75df-4b47-953b-0faa4983321d",
				/* Finished */
				FINISHED: "5b792494-d40f-4b2b-8cfd-ab75ac5d33aa",
				/* Planned */
				PLANNED: "24b80784-2172-4903-94ad-ca1fddf368dd",
				/* Stopped */
				STOPPED: "9168c6b6-68e9-469c-9792-769bb39de25f",
				/* Scheduled */
				SCHEDULED: "d55a44bb-fa64-45f5-b83d-c5ef7cd76208"
			},

			/**
			 * Singleton step types.
			 */
			SingletonStepTypes: BPMSoft.Features.getIsEnabled("OutboundCampaign")
					? [
						/* Campaign Audience */
						"36503c76-9542-45b6-a934-a61f2b9bce48"
					]
					: [
						/* Campaign audience*/
						"36503c76-9542-45b6-a934-a61f2b9bce48",
						/* Lending */
						"5e9d3401-8047-4833-b9f0-c2c8d3dbbe62"
					],

			/**
			 * Element sizes.
			 */
			StepTypeSize: {
				/* Default value */
				"Default": {
					"height": 56,
					"width": 56
				},
				/* Value for small elements */
				"Small": {
					"height": 47,
					"width": 49
				}
			},

			/**
			 * CampaignSchemaElementType to indicate type of flow element
			 * @type {Object}
			 */
			CampaignSchemaElementTypes: {
				/* Conditional transition element */
				CONDITIONAL_TRANSITION: "ConditionalTransition",
				/* Simple transition element */
				TRANSITION: "Transition",
				/* Marketing email element */
				MARKETING_EMAIL: "MarketingEmail",
				/* Campaign landing element */
				CAMPAIGN_LANDING: "CampaignLanding",
				/* Campaign event element */
				CAMPAIGN_EVENT: "CampaignEvent",
				/* Add audience element */
				ADD_AUDIENCE: "AddAudience",
				/* Exit audience element */
				EXIT_AUDIENCE: "ExitAudience",
				/* Campaign timer element */
				CAMPAIGN_TIMER: "CampaignTimer",
				/* Campaign add object element */
				ADD_OBJECT_ELEMENT: "CampaignAddObject",
				/* Campaign update object element */
				UPDATE_OBJECT_ELEMENT: "CampaignUpdateObject",
				/* Campaign split gateway element */
				CAMPAIGN_SPLIT_GATEWAY: "CampaignSplitGateway",
				/* Campaign deduplicator element */
				CAMPAIGN_DEDUPLICATOR: "CampaignDeduplicator"
			},

			/**
			 * Campaign diagram node types for campaign elements.
			 * @type {Object}
			 */
			CampaignDiagramNodeTypes: {
				START: "start",
				INTERMEDIATE: "intermediate",
				END: "end"
			},

			/**
			 * Available operations on campaign page.
			 * @type {Object}
			 */
			CampaignPageOperations: {
				UPDATE_SCHEMA: "UpdateSchema",
				UPDATE_VERSION: "UpdateVersion"
			},

			/**
			 * CampaignFlowSchemaValidationRules to validate campaign flow schema
			 * @type {Object}
			 */
			CampaignFlowSchemaValidationRules: {
				/* Async element without incoming sequence flows */
				ASYNC_WITHOUT_INCOMINGS: "AsyncWithoutIncomings",
				/* Add campaign participant element without outgoing sequence flows */
				ADD_AUDIENCE_WITHOUT_OUTGOINGS: "AddAudienceWithoutOutgoings",
				/* Contains the name of rule in case of flow schema loop without delayed transitions */
				LOOP_WITHOUT_DELAYED_TRANSITIONS: "LoopWithoutDelayedTransitions"
			},

			/**
			 * BulkEmail response ids based on response status
			 */
			BulkEmailResponses: {
				DELIVERED: "9c56db88-d16a-438f-b223-148b00c66c80",
				OPEN: "5788b052-74ab-481d-8d0f-efe87a19848f",
				CLICKS: "62a08686-cc06-4b4d-88e2-a6df4d4f6b77",
				REPLIED: "59c7e5e9-3eec-456f-823f-d9b68e8203ce",
				SPAM_COMPLAINED: "dc5fed60-4c3b-46bd-bf12-7f3defc099b2",
				UNSUBSCRIBED: "a670ee81-2166-4c85-9e41-88901ca9ca38",
				HARD_BOUNCE: "cba985b0-32b8-48f7-924e-7f33e8bd45b8",
				DELIVERY_ERROR: "c2248d51-84ed-44b3-8e05-001b570bb517",
				EMAIL_LIMIT_REACHED: "31aaed28-5789-43ff-9801-9ff6b5956b9b",
				SOFT_BOUNCE: "9ba89f3b-6041-4e81-8f1a-b666cfb5bf7b",
				REJECTED: "edd1ced0-abdb-4b5a-89a2-46cfdbe33d7f",
				STOPPED_MANUALLY: "13244973-d412-42be-b4e7-99b040ab793f",
				STOPPED_TIME_EXPIRED: "abc2c0d7-7fbc-49c8-8e9e-ab7358fc7044",
				CANCELED_UNSUB_FROM_ALL: "bbfb3947-54ff-48c0-a1e5-f46f01a54e6d",
				CANCELED_SENDERS_NAME_NOT_VALID: "10a81c66-8181-4580-a264-d425e12e8e2d",
				CANCELED_SENDERS_DOMAIN_NOT_VERIFIED: "47b6cad6-45b8-43cd-a52b-1ee53fae2ef8",
				CANCELED_DUPLICATED_EMAIL: "290f4fdb-d628-4049-bbd4-77572845ba33",
				CANCELED_EMAIL_NOT_PROVIDED: "8ffde5f0-cb75-4d90-a757-7e4748491abf",
				INVALID_EMAIL_ADDRESS: "86d520bb-0eb2-493e-b8c5-55523ac31705",
				CANCELED_INCORRECT_EMAIL: "f83922c2-c8a3-4dd0-a688-d59a41e1ab2b",
				CANCELED_INVALID_EMAIL: "59acda79-1acd-47cc-8655-8e74bd2d00d0",
				CANCELED_TEMPLATE_NOT_FOUND: "16c4a15f-81b2-473a-9b28-7ea2ce95b582",
				CANCELED_UNSUBSCRIBED_BY_EMAIL_TYPE: "d4960b73-6d9e-4f77-bd97-9ec91a9e92ca"
			},

			/**
			 * Campaign item completed condition
			 */
			StepCompletedConditions: {
				COMPLETED: 0,
				NOT_COMPLETED: 1,
				ANY: 2
			},

			CampaignScheduledMode: {
				/* Run manually */
				RUN_MANUALLY: "229d71cf-80c8-4158-ae9d-b0da644ed6a8",
				/* Run at the specified time */
				AT_THE_SPECIFIED_TIME: "5ee38934-d028-4c1e-a1c8-2b039991baea"
			},

			/**
			 * Colors enum for analytics badges in campaign viewer.
			 */
			AnalyticsBadgesColors: {
				COMPLETED: "#BCE941",
				NON_COMPLETED: "#67748E",
				IN_PROGRESS: "#F9763D",
				ERROR: "#F53939",
				SUSPENDED: "#FFC324",
				HISTORY: "#9932CC"
			},

			/**
			 * Returns element parameters.
			 * @param {Object} stepType Element type.
			 * @return {Object}
			 */
			GetStepTypeConfig: function(stepType) {
				var stepTypeConfigs = {
					/* BulkEmail */
					"0270a11d-534c-40ec-8a72-c4902d6afb09": {
						"sysImage": "StepTypeEmailImage",
						"portsSet": BPMSoft.diagram.PortsSet.Basic,
						"constraints": ["Select", "Drag", "Connect", "Shadow", "Delete"]
					},
					/* Event */
					"75b0f8d2-a3f4-4715-ad37-a501543af26c": {
						"sysImage": "StepTypeEventImage",
						"portsSet": BPMSoft.diagram.PortsSet.Basic,
						"constraints": ["Select", "Drag", "Connect", "Shadow", "Delete"]
					},
					/* Campaign audience */
					"36503c76-9542-45b6-a934-a61f2b9bce48": {
						"sysImage": "StepTypeAudienceImage",
						"portsSet": BPMSoft.diagram.PortsSet.Basic,
						"outgoingConnectionsLimit": 1,
						"incomingConnectionsLimit": -1,
						"constraints": ["Select", "Drag", "Connect", "Shadow", "Delete"]
					},
					/* Target */
					"30eb28eb-bb1f-4d18-9358-55556d80d833": {
						"sysImage": "StepTypeTargetImage",
						"portsSet": BPMSoft.diagram.PortsSet.Basic,
						"outgoingConnectionsLimit": -1,
						"constraints": ["Select", "Drag", "Connect", "Shadow"]
					},
					/* Exclude from campaign */
					"b748cdc5-b478-4ed1-8b52-51513ee49ed9": {
						"sysImage": "StepTypeExitingImage",
						"portsSet": BPMSoft.diagram.PortsSet.Basic,
						"outgoingConnectionsLimit": -1,
						"constraints": ["Select", "Drag", "Connect", "Shadow"]
					},
					/* Lending */
					"5e9d3401-8047-4833-b9f0-c2c8d3dbbe62": {
						"sysImage": "StepTypeLandingImage",
						"portsSet": BPMSoft.diagram.PortsSet.Basic,
						"outgoingConnectionsLimit": BPMSoft.Features.getIsEnabled("OutboundCampaign") ? 2 : 1,
						"incomingConnectionsLimit": BPMSoft.Features.getIsEnabled("OutboundCampaign") ? 1 : -1,
						"constraints": ["Select", "Drag", "Connect", "Shadow", "Delete"],
						"positions": {
							"start": {
								isInPosition: function(node) {
									return Ext.isEmpty(node.inEdges);
								},
								"outgoingConnectionsLimit": 1,
								"incomingConnectionsLimit": BPMSoft.Features.getIsEnabled("OutboundCampaign") ? null : -1
							},
							"middle": {
								isInPosition: function(node) {
									return !Ext.isEmpty(node.inEdges);
								},
								"outgoingConnectionsLimit": BPMSoft.Features.getIsEnabled("OutboundCampaign") ? 2 : 1,
								"incomingConnectionsLimit": BPMSoft.Features.getIsEnabled("OutboundCampaign") ? null : -1
							}
						}
					},
					/* Create lead */
					"12c48da4-8305-4aa7-92a9-2c75dc5d458b": {
						"sysImage": "StepTypeCreateLeadImage",
						"portsSet": BPMSoft.diagram.PortsSet.Basic,
						"outgoingConnectionsLimit": 1,
						"constraints": ["Select", "Drag", "Connect", "Shadow", "Delete"],
						"height": this.StepTypeSize.Small.height,
						"width": this.StepTypeSize.Small.width
					}
				};
				return Ext.merge({}, this.StepTypeSize.Default, stepTypeConfigs[stepType]);
			},

			/**
			 * Returns default campaign node config.
			 * @return {Object}
			 */
			GetDefaultCampaign: function() {
				var targetId = BPMSoft.generateGUID();
				var endTaskId = BPMSoft.generateGUID();
				return {
					"nodes": [
						{
							"offsetX": 435,
							"offsetY": 70,
							"labels": [{
								"text": resources.localizableStrings.TargetCaption
							}],
							"stepType": this.StepType.TARGET,
							"name": targetId
						},
						{
							"offsetX": 435,
							"offsetY": 210,
							"labels": [{
								"text": resources.localizableStrings.ExitingCampaignCaption
							}],
							"stepType": this.StepType.EXITING_CAMPAIGN,
							"name": endTaskId
						}
					],
					"connectors": []
				};
			},

			/**
			 * Returns default email node config.
			 * @return {Object}
			 */
			GetDefaultEmailNode: function() {
				var emailId = BPMSoft.generateGUID();
				return {
					"offsetX": 150,
					"offsetY": 150,
					"labels": [
						{
							"text": resources.localizableStrings.BulkEmailCaption
						}
					],
					"stepType": this.StepType.EMAIL_MAILING,
					"name": emailId,
					"isDBObject": true
				};
			},

			/**
			 * Returns default event node config.
			 * @return {Object}
			 */
			GetDefaultEventNode: function() {
				var eventId = BPMSoft.generateGUID();
				return {
					"offsetX": 150,
					"offsetY": 150,
					"labels": [
						{
							"text": resources.localizableStrings.EventCaption
						}
					],
					"stepType": this.StepType.EVENT,
					"name": eventId,
					"isDBObject": true
				};
			},

			/**
			 * Returns default landing node config.
			 * @return {Object}
			 */
			GetDefaultLandingNode: function() {
				var id = BPMSoft.generateGUID();
				return {
					"offsetX": 150,
					"offsetY": 150,
					"labels": [
						{
							"text": resources.localizableStrings.LandingCaption
						}
					],
					"stepType": this.StepType.LANDING,
					"name": id,
					"isDBObject": true
				};
			},

			/**
			 * Returns default audience node config.
			 * @return {Object}
			 */
			GetDefaultAudienceNode: function() {
				var id = BPMSoft.generateGUID();
				return {
					"offsetX": 150,
					"offsetY": 150,
					"labels": [
						{
							"text": resources.localizableStrings.CampaignAudienceCaption
						}
					],
					"stepType": this.StepType.CAMPAIGN_AUDIENCE,
					"name": id,
					"isDBObject": true
				};
			},

			/**
			 * Returns default create lead node config.
			 * @return {Object}
			 */
			GetDefaultCreateLeadNode: function() {
				var id = BPMSoft.generateGUID();
				var result = {
					"offsetX": 150,
					"offsetY": 150,
					"labels": [
						{
							"text": resources.localizableStrings.CreateLeadCaption
						}
					],
					"stepType": this.StepType.CREATE_LEAD,
					"name": id,
					"isDBObject": true
				};
				return Ext.merge(result, this.StepTypeSize.Small);
			},

			/**
			 * Checked if element have to be singleton
			 * @param {Object} stepType Element type.
			 * @return {Boolean}
			 */
			IsSingletonStepType: function(stepType) {
				return Ext.Array.contains(this.SingletonStepTypes, stepType);
			},

			/**
			 * Checks if we can create connection with same type we needed
			 * @param {Object} sourceStepType Element type.
			 * @param {Object} targetStepType Element type.
			 * @return {Boolean}
			 */
			IsStepTypeConnectionAllow: function(sourceStepType, targetStepType) {
				var denyCombinations = [
					[
						this.StepType.LANDING,
						this.StepType.CREATE_LEAD
					],
					[
						this.StepType.LANDING,
						this.StepType.LANDING
					],
					[
						this.StepType.CAMPAIGN_AUDIENCE,
						this.StepType.LANDING
					],
					[
						this.StepType.CREATE_LEAD,
						this.StepType.CREATE_LEAD
					],
					[
						this.StepType.CAMPAIGN_AUDIENCE,
						this.StepType.EXITING_CAMPAIGN
					],
					[
						this.StepType.CAMPAIGN_AUDIENCE,
						this.StepType.TARGET
					]
				];
				if (!BPMSoft.Features.getIsEnabled("OutboundCampaign")) {
					denyCombinations.push([
						this.StepType.LANDING,
						this.StepType.EXITING_CAMPAIGN
					], [
						this.StepType.LANDING,
						this.StepType.TARGET
				]);
				}
				var result = true;
				BPMSoft.each(denyCombinations, function(stepCombination) {
					if ((stepCombination[0] === sourceStepType) && (stepCombination[1] === targetStepType)) {
						result = false;
						return result;
					}
				}, this);
				return result;
			}

		};
	});
