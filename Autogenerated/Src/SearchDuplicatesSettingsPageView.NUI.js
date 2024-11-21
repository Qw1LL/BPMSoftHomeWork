define("SearchDuplicatesSettingsPageView", ["ext-base", "BPMSoft", "SearchDuplicatesSettingsPageViewResources"],
		function(Ext, BPMSoft, resources) {

			function generate() {
				var viewConfig = {
					id: "searchDuplicatesSettingsContainer",
					selectors: {
						wrapEl: "#searchDuplicatesSettingsContainer"
					},
					items: [
						{
							className: "BPMSoft.Container",
							id: "SearchDuplicatesSettingsButtonsContainer",
							selectors: {
								wrapEl: "#SearchDuplicatesSettingsButtonsContainer"
							},
							items: [
								{
									className: "BPMSoft.Button",
									id: "acceptButton",
									caption: resources.localizableStrings.OkButtonCaption,
									style: BPMSoft.controls.ButtonEnums.style.ORANGE,
									tag: "AcceptButton",
									click: {
										bindTo: "okClick"
									}
								},
								{
									className: "BPMSoft.Button",
									caption: resources.localizableStrings.CancelButtonCaption,
									tag: "CancelButton",
									click: {
										bindTo: "cancelClick"
									}
								}
							]
						},
						{
							className: "BPMSoft.Label",
							caption: resources.localizableStrings.ByPeriodSettingsGroupCaption,
							classes: {
								labelClass: ["t-label dulpicates-settings-label"]
							}
						},
						{
							className: "BPMSoft.Container",
							id: "byPeriodSettingsControlGroup",
							selectors: {
								wrapEl: "#byPeriodSettingsControlGroup"
							},
							items: [
								{
									className: "BPMSoft.Container",
									id: "byPeriodSettingsForAllContainer1",
									items: [
										{
											className: "BPMSoft.Container",
											id: "byPeriodSettingsOnTimeContainer",
											selectors: {
												wrapEl: "#byPeriodSettingsOnTimeContainer"
											},
											items: [
												{
													className: "BPMSoft.Label",
													caption: resources.localizableStrings.DateFromCaption
												},
												{
													className: "BPMSoft.TimeEdit",
													classes: {
														wrapClass: ["datetime-timecontrol"]
													},
													value: {
														bindTo: "onTime"
													},
													markerValue: "StartTime",
													enabled: true
												},
												{
													className: "BPMSoft.Label",
													caption: resources.localizableStrings.WeekCaption
												}
											]
										},
										{
											className: "BPMSoft.Container",
											id: "byPeriodSettingsWeekContainer",
											selectors: {
												wrapEl: "#byPeriodSettingsWeekContainer"
											},
											items: [
												{
													className: "BPMSoft.Container",
													id: "byPeriodSettingsWeekLeftContainer",
													selectors: {
														wrapEl: "#byPeriodSettingsWeekLeftContainer"
													},
													classes: {
														wrapClassName: ["custom-inline"]
													},
													items: [
														{
															className: "BPMSoft.Container",
															id: "byPeriodSettingsIsMondayContainer",
															selectors: {
																wrapEl: "#byPeriodSettingsIsMondayContainer"
															},
															items: [
																{
																	className: "BPMSoft.CheckBoxEdit",
																	tag: "isMonday",
																	checked: {
																		bindTo: "isMonday"
																	},
																	markerValue: "IsMonday",
																	enabled: true
																},
																{
																	className: "BPMSoft.Label",
																	caption: resources.localizableStrings.MondayCaption
																}
															]
														},
														{
															className: "BPMSoft.Container",
															id: "byPeriodSettingsIsTuesdayContainer",
															selectors: {
																wrapEl: "#byPeriodSettingsIsTuesdayContainer"
															},
															items: [
																{
																	className: "BPMSoft.CheckBoxEdit",
																	tag: "isTuesday",
																	checked: {
																		bindTo: "isTuesday"
																	},
																	markerValue: "IsTuesday",
																	enabled: true
																},
																{
																	className: "BPMSoft.Label",
																	caption: resources.localizableStrings.TuesdayCaption
																}
															]
														},
														{
															className: "BPMSoft.Container",
															id: "byPeriodSettingsIsWednesdayContainer",
															selectors: {
																wrapEl: "#byPeriodSettingsIsWednesdayContainer"
															},
															items: [
																{
																	className: "BPMSoft.CheckBoxEdit",
																	tag: "isWednesday",
																	checked: {
																		bindTo: "isWednesday"
																	},
																	markerValue: "IsWednesday",
																	enabled: true
																},
																{
																	className: "BPMSoft.Label",
																	caption: resources.localizableStrings.WednesdayCaption
																}
															]
														},
														{
															className: "BPMSoft.Container",
															id: "byPeriodSettingsIsThursdayContainer",
															selectors: {
																wrapEl: "#byPeriodSettingsIsThursdayContainer"
															},
															items: [
																{
																	className: "BPMSoft.CheckBoxEdit",
																	tag: "isThursday",
																	checked: {
																		bindTo: "isThursday"
																	},
																	markerValue: "IsThursday",
																	enabled: true
																},
																{
																	className: "BPMSoft.Label",
																	caption: resources.localizableStrings.ThursdayCaption
																}
															]
														}
													]
												},
												{
													className: "BPMSoft.Container",
													id: "byPeriodSettingsWeekRightContainer",
													selectors: {
														wrapEl: "#byPeriodSettingsWeekRightContainer"
													},
													classes: {
														wrapClassName: ["custom-inline"]
													},
													items: [
														{
															className: "BPMSoft.Container",
															id: "byPeriodSettingsIsFridayContainer",
															selectors: {
																wrapEl: "#byPeriodSettingsIsFridayContainer"
															},
															items: [
																{
																	className: "BPMSoft.CheckBoxEdit",
																	tag: "isFriday",
																	checked: {
																		bindTo: "isFriday"
																	},
																	markerValue: "IsFriday",
																	enabled: true
																},
																{
																	className: "BPMSoft.Label",
																	caption: resources.localizableStrings.FridayCaption
																}
															]
														},
														{
															className: "BPMSoft.Container",
															id: "byPeriodSettingsIsSaturdayContainer",
															selectors: {
																wrapEl: "#byPeriodSettingsIsSaturdayContainer"
															},
															items: [
																{
																	className: "BPMSoft.CheckBoxEdit",
																	tag: "isSaturday",
																	checked: {
																		bindTo: "isSaturday"
																	},
																	markerValue: "IsSaturday",
																	enabled: true
																},
																{
																	className: "BPMSoft.Label",
																	caption: resources.localizableStrings.SaturdayCaption
																}
															]
														},
														{
															className: "BPMSoft.Container",
															id: "byPeriodSettingsIsSundayContainer",
															selectors: {
																wrapEl: "#byPeriodSettingsIsSundayContainer"
															},
															items: [
																{
																	className: "BPMSoft.CheckBoxEdit",
																	tag: "isSunday",
																	checked: {
																		bindTo: "isSunday"
																	},
																	markerValue: "IsSunday",
																	enabled: true
																},
																{
																	className: "BPMSoft.Label",
																	caption: resources.localizableStrings.SundayCaption
																}
															]
														}
													]
												}
											]
										}
									]
								}
							]
						}
					]
				};
				return viewConfig;
			}

			return {
				generate: generate
			};
		});
