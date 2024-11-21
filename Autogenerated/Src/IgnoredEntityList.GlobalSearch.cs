namespace BPMSoft.Configuration.GlobalSearch
{
	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using BPMSoft.Configuration.GlobalSearchColumnUtils;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: IgnoredEntityList

	/// <summary>
	/// Controls ignored entities and columns.
	/// </summary>
	public class IgnoredEntityList
	{
		#region Constants: Private

		/// <summary>
		/// Default ignore items patterns.
		/// </summary>
		private static readonly string[] _defaultIgnoredItemsPatterns = {
			"account_owner$",
			"^campaign\\.schemadata$",
			"_templateBody$",
			"_searchNumber$",
			"_addresstype$",
			"_communicationtype$",
			"_socialmediaid$",
			"_externalcommunicationtype$",
			"_nonactualreason$",
			"_gpsn$",
			"_gpse$",
			"_pricelist$",
			"knowledgebase_notes$",
			"knowledgebase_code$",
			"knowledgebase_keywords$",
			"case_notes$",
			"case_priority$",
			"case_origin$",
			"case_closurecode$",
			"case_satisfactionlevel$",
			"case_category$",
			"case_parentcase$",
			"case_processingtimeunit$",
			"case_servicecategory$",
			"case_solvedonsupportlevel$",
			"case_supportlevel$",
			"case_holder$",
			"case_problem$",
			"case_change$",
			"_reactiontimeunit$",
			"_solutiontimeunit$",
			"serviceitem_reactiontime$",
			"serviceitem_solutiontime$",
			"problem_author$",
			"problem_type$",
			"problem_priority$",
			"problem_status$",
			"problem_change$",
			"release_status$",
			"release_type$",
			"release_priority$",
			"servicepact_status$",
			"servicepact_type$",
			"servicepact_serviceprovider$",
			"servicepact_serviceprovidercontact$",
			"servicepact_calendar$",
			"servicepact_supportlevel$",
			"change_author$",
			"change_parentchange$",
			"change_source$",
			"change_purpose$",
			"change_category$",
			"change_priority$",
			"change_status$",
			"change_release$",
			"confitem_status$",
			"confitem_parentconfitem$",
			"confitem_category$",
			"confitem_country$",
			"confitem_region$",
			"confitem_city$",
			"confitem_street$",
			"confitem_address$",
			"entitydefaultvalues$",
			"formfields$",
			"generatedwebform_body$",
			"generatedwebform_state$",
			"generatedwebform_owner$",
			"generatedwebform_type$",
			"call_direction$",
			"call_result$",
			"call_activity$",
			"call_lead$",
			"call_order$",
			"call_opportunity$",
			"call_case$",
			"activity_priority$",
			"activity_author$",
			"activity_timezone$",
			"activity_color$",
			"_emailsendstatus$",
			"_erroronsend$",
			"_durationinmnutesandhours$",
			"activity_allowedresult$",
			"activity_messagetype$",
			"activity_mailhash$",
			"activity_globalactivityid$",
			"activity_activityconnection$",
			"activity_organizer$",
			"activity_calldirection$",
			"_headerproperties$",
			"activity_useremailaddress$",
			"activity_location$",
			"activity_queueitem$",
			"activity_body$",
			"contact_dear$",
			"contact_salutationtype$",
			"contact_gender$",
			"contact_twitterafda$",
			"contact_facebookafda$",
			"contact_linkedinafda$",
			"contact_surname$",
			"contact_givenname$",
			"contact_middlename$",
			"contact_owner$",
			"order_currency$",
			"order_sourceorder$",
			"order_paymenttype$",
			"order_receivername$",
			"order_comment$",
			"order_contactnumber$",
			"invoice_paymentstatus$",
			"invoice_supplierbillinginfo$",
			"invoice_customerbillinginfo$",
			"invoice_currency$",
			"product_owner$",
			"product_unit$",
			"product_currency$",
			"product_tax$",
			"product_type$",
			"opportunity_type$",
			"opportunity_closereason$",
			"opportunity_category$",
			"opportunity_responsibledepartment$",
			"opportunity_weaknesses$",
			"opportunity_strength$",
			"opportunity_winner$",
			"opportunity_description$",
			"opportunity_leadtype$",
			"document_state$",
			"contract_state$",
			"contract_parent$",
			"contract_ourcompany$",
			"contract_currency$",
			"lead_status$",
			"lead_industry$",
			"lead_annualrevenue$",
			"lead_addresstype$",
			"lead_leadtype$",
			"lead_leadtypestatus$",
			"lead_accountcategory$",
			"lead_accountownership$",
			"lead_department$",
			"lead_gender$",
			"lead_dear$",
			"lead_owner$",
			"lead_salesowner$",
			"lead_opportunitydepartment$",
			"lead_saletype$",
			"lead_countrystr$",
			"lead_regionstr$",
			"lead_citystr$",
			"lead_bpmhref$",
			"lead_bpmref$",
			"mktgactivity_channel$",
			"mktgactivity_status$",
			"mktgactivity_owner$",
			"mktgactivity_currency$",
			"mktgactivity_campaignplanner$",
			"event_type$",
			"event_owner$",
			"event_status$",
			"event_goal$",
			"event_territory$",
			"event_industry$",
			"event_actualresponse$",
			"event_actualizestatus$",
			"event_segmentsstatus$",
			"event_campaign$",
			"campaign_campaignstatus$",
			"campaign_segmentsstatus$",
			"campaign_targetdescription$",
			"campaign_owner$",
			"campaign_utmcampaign$",
			"campaign_type$",
			"bulkemail_owner$",
			"bulkemail_type$",
			"bulkemail_status$",
			"bulkemail_segmentsstatus$",
			"bulkemail_utmsource$",
			"bulkemail_utmmedium$",
			"bulkemail_utmcampaign$",
			"bulkemail_utmterm$",
			"bulkemail_utmcontent$",
			"bulkemail_domains$",
			"bulkemail_splittest$",
			"bulkemail_category$",
			"bulkemail_launchoption$",
			"bulkemail_templateconfig$",
			"bonus_currency$",
			"queue_entityschemacaption",
			"queue_processschemacaption$",
			"queue_filterdata$",
			"queue_filtereditdata$",
			"queue_queueentityschema$",
			"queue_businessprocessschema$",
			"twitterid",
			"facebookid",
			"createdby",
			"lockedby",
			"modifiedby"
		};

		#endregion

		#region Properties: Protected

		/// <summary>
		/// List of unindexable sections name.
		/// </summary>
		private List<string> _ignoredSections;
		protected virtual List<string> IgnoredSections {
			get {
				return _ignoredSections ??
						(_ignoredSections =
							new List<string> {
								"VwCampaignLog",
								"VwQueueItem",
								"VwProcessLib",
								"VwSysDcmLib",
								"SysTranslation",
								"SysProcessLog",
								"SysAdminUnit",
								"SysAdminOperation",
								"DuplicateRule",
								"Email",
								"EmailTemplate",
								"EmailTemplateFile",
								"DuplicatesRule",
								"ScoringModel",
								"SocialMessage",
								"BulkEmailSplit",
								"BulkEmailSplitFile",
								"Lookup",
								"SiteEventType",
								"SiteEventTypeFile",
								"PaymentRule",
								"PaymentRuleFile",
								"CampaignPlanner",
								"CampaignPlannerFile",
								"VwSysProcessLog",
								"SysPrcHistoryLog",
								"SysSettings"
							});
			}
			set {
				_ignoredSections = value;
			}
		}

		/// <summary>
		/// Dictionary of the ignored section and columns.
		/// </summary>
		private string[] _ignoredItemsPatterns;
		protected virtual string[] IgnoredItemsPatterns {
			get {
				return _ignoredItemsPatterns ?? (_ignoredItemsPatterns = _defaultIgnoredItemsPatterns);
			}
			set {
				_ignoredItemsPatterns = value;
			}
		}

		/// <summary>
		/// <see cref="GlobalSearchColumnUtils"/> instance.
		/// </summary>
		private GlobalSearchColumnUtils _globalSearchColumnUtils;
		protected GlobalSearchColumnUtils GlobalSearchColumnUtils {
			get {
				if (_globalSearchColumnUtils == null) {
					_globalSearchColumnUtils = ClassFactory.Get<GlobalSearchColumnUtils>();
				}
				return _globalSearchColumnUtils;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets is ignored column.
		/// </summary>
		/// <returns>True if column is ignored.</returns>
		public virtual bool GetIsIgnoredColumn(EntitySchema schema, EntitySchemaColumn column) {
			string columnAlias = GlobalSearchColumnUtils.GetAlias(column, schema);
			string columnPath = string.Format("{0}.{1}", schema.Name, column.Name);
			foreach (var ignoredItemPattern in IgnoredItemsPatterns) {
				bool isFindInPath = Regex.IsMatch(columnPath, ignoredItemPattern, RegexOptions.IgnoreCase);
				bool isFindInAlias = Regex.IsMatch(columnAlias, ignoredItemPattern, RegexOptions.IgnoreCase);
				if (isFindInPath || isFindInAlias) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Gets section is ignored to indexation.
		/// </summary>
		/// <param name="schema"></param>
		/// <returns>True if section is ignored.</returns>
		public virtual bool GetIsIgnoredSection(EntitySchema schema) {
			return schema == null 
				|| IgnoredSections.Contains(schema.Name) 
				|| schema.IsDBView;
		}

		#endregion
	}

	#endregion
}

