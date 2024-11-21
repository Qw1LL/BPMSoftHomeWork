define('EventsDashboardSection', ['ext-base', 'BPMSoft', 'sandbox', 'EventsDashboardSectionResources',
	'ConfigurationConstants', 'VwAnniversary'],
	function(Ext, BPMSoft, sandbox, resources, ConfigurationConstants, VwAnniversary) {
		var getViewModel = function() {
			return Ext.create('BPMSoft.BaseViewModel', {
				entitySchema: VwAnniversary,
				methods: {
					getChart: function(key) {
						sandbox.publish('GenerateChart', key);
					},
					load: function() {

					}
				},
				values: {
					anniversaryData: new BPMSoft.Collection(),
					activeRowId: null
				}
			});
		};

		function getAnniversaryCollection(viewModel) {
			var contactSelect = Ext.create('BPMSoft.EntitySchemaQuery', {
				rootSchema: VwAnniversary
			});
			contactSelect.addColumn('Id');
			contactSelect.addColumn('Date');
			contactSelect.addColumn('AnniversaryType');
			contactSelect.addColumn('Contact');
			contactSelect.addColumn('Account');
			Date.prototype.addDays = function(d) {
				if (d) {
					var t = this.getTime();
					t = t + (d * 86400000);
					this.setTime(t);
				}
			};
			function getYearDay(date) {
				var now = date;
				var start = new Date(now.getFullYear(), 0, 0);
				var diff = now - start;
				var oneDay = 1000 * 60 * 60 * 24;
				var day = Math.floor(diff / oneDay);
				return day;
			}
			var currentWeekStartDate = new Date(BPMSoft.startOfWeek(new Date()));
			currentWeekStartDate.addDays(7);
			var nextWeekStartDate = currentWeekStartDate;
			var startDate = new Date(nextWeekStartDate.toString());
			function getWeekNumber(date) {
				var d = date
				d.setHours(0,0,0);
				d.setDate(d.getDate() + 4 - (d.getDay()||7));
				var yearStart = new Date(d.getFullYear(),0,1);
				var weekNo = Math.ceil(( ( (d - yearStart) / 86400000) + 1)/7)
				return weekNo;
			}
			var filtersCollection = BPMSoft.createFilterGroup();
			var ownerCollection = BPMSoft.createFilterGroup();
			ownerCollection.logicalOperation = BPMSoft.LogicalOperatorType.OR;
			var dateFilter1 = Ext.create("BPMSoft.CompareFilter", {
				comparisonType: BPMSoft.ComparisonType.EQUAL,
				leftExpression: Ext.create('BPMSoft.FunctionExpression', {
					functionType: BPMSoft.FunctionType.DATE_PART,
					datePartType: BPMSoft.DatePartType.WEEK,
					functionArgument: Ext.create("BPMSoft.ColumnExpression", {
						columnPath: 'Date'
					})
				}),
				rightExpression: Ext.create('BPMSoft.ParameterExpression', {
					parameterValue: getWeekNumber(startDate) })
			});
			filtersCollection.add('DateFilter1', dateFilter1);
			ownerCollection.add('OwnerFilter1', BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL,
				'Contact.Owner', BPMSoft.SysValue.CURRENT_USER_CONTACT.value));
			ownerCollection.add('OwnerFilter2', BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL,
				'Account.Owner', BPMSoft.SysValue.CURRENT_USER_CONTACT.value));
			filtersCollection.add('ownerFilters', ownerCollection);
			contactSelect.filters = filtersCollection;
			contactSelect.getEntityCollection(function(response) {
				var collection = viewModel.get('anniversaryData');
				var entities = response.collection;
				var tempItemsCollection = {};
				BPMSoft.each(response.collection.getItems(), function(entity) {
					tempItemsCollection[entity.get('Id')] = entity;
				});
				collection.loadAll(tempItemsCollection);
			}, this);

		}

		function generateMainView() {
			var leftConfig = Ext.create('BPMSoft.Container', {
				id: 'EventsDashboardSectionContainer',
				selectors: {
					wrapEl: '#EventsDashboardSectionContainer'
				},
				items: [
					Ext.create('BPMSoft.Container', {
						id: 'EventsDashboardSectionContainer1',
						classes: {
							wrapClassName: [
								'gridcontainer'
							]
						},
						selectors: {
							wrapEl: '#EventsDashboardSectionContainer1'
						},
						items: [
							{
								className: 'BPMSoft.Label',
								classes: {
									labelClass: ['graph-header-name']
								},
								caption: resources.localizableStrings.evantCaption
							},
							{
								className: 'BPMSoft.Grid',
								type: 'listed',
								primaryColumnName: 'Id',
								activeRow: {
									bindTo: 'activeRowId'
								},
								captionsConfig: [
									{
										cols: 5,
										name: resources.localizableStrings.dateCaption
									},
									{
										cols: 6,
										name: resources.localizableStrings.AccountCaption
									},
									{
										cols: 8,
										name: resources.localizableStrings.ContactCaption
									},
									{
										cols: 5,
										name: resources.localizableStrings.AnniversaryType
									}
								],
								columnsConfig: [

									{
										cols: 5,
										key: [
											{
												name: {
													bindTo: 'Date'
												}
											}
										]
									},
									{
										cols: 6,
										key: [
											{
												name: {
													bindTo: 'Account'
												}
											}
										]
									},
									{
										cols: 8,
										key: [
											{
												name: {
													bindTo: 'Contact'
												}
											}
										]
									},
									{
										cols: 5,
										key: [
											{
												name: {
													bindTo: 'AnniversaryType'
												}
											}
										]
									}
								],
								collection: {
									bindTo: 'anniversaryData'
								},
								watchedRowInViewport: {
									bindTo: 'loadNext'
								}
							}
						]
					})
				]
			});
			var resultConfig = Ext.create('BPMSoft.Container', {
				id: 'TopEventsDashboardSectionContainer',
				selectors: {
					wrapEl: '#TopEventsDashboardSectionContainer'
				},
				items: [
					leftConfig
				]
			});
			return resultConfig;
		}

		var render = function(renderTo) {
			var viewConfig = generateMainView();
			var viewModel = getViewModel();
			getAnniversaryCollection(viewModel);
			viewConfig.bind(viewModel);
			viewConfig.render(renderTo);
		};
		return {
			init: function() {
				var state = sandbox.publish('GetHistoryState');
				var currentHash = state.hash;
				var currentState = state.state || {};
				if (currentState.moduleId === sandbox.id) {
					return;
				}
				var newState = BPMSoft.deepClone(currentState);
				newState.moduleId = sandbox.id;
				sandbox.publish('ReplaceHistoryState', {
					stateObj: newState,
					pageTitle: null,
					hash: currentHash.historyState,
					silent: true
				});
			},
			render: render
		};
	}
)
;
