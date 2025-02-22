﻿/**
 * ################ ###### ######### ###### ##.
 * ### ######## ###### ########## ######## id ###### ##### url
 * ########
 * #KnowledgeBaseArticleViewModule/KnowledgeBase/view/CDA67AD8-F65C-4F9D-B357-0E42585F4D12
 */
define('KnowledgeBaseArticleViewModule',
	['ext-base', 'BPMSoft', 'sandbox', 'KnowledgeBase', 'KnowledgeBaseHtmlEditModule', 'css!HtmlEditModule'],
	function(Ext, BPMSoft, sandbox, entitySchema) {
		var inputKnowledgeBaseId = null;
		var viewModel = null;
		/**
		 * ######### ViewModel ######
		 * @protected
		 * @returns {BPMSoft.BaseViewModel}
		 */
		var getViewModel = function() {
			var notesColumn = entitySchema.columns.Notes;
			var viewModelColumns = {
				Notes: {
					caption: notesColumn.caption,
					columnPath: notesColumn.name,
					name: notesColumn.name,
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN
				}
			};
			return Ext.create('BPMSoft.BaseViewModel', {
				entitySchema: entitySchema,
				columns: viewModelColumns,
				methods: {
					/**
					 * ########## ######## ######## # ########
					 * ########### #####-####### ########## #######
					 * @protected
					 */
					afterHtmlEditorDataReady: function() {
						var htmlEdit = Ext.getCmp('email-body-html-knowbase-view');
						if (Ext.isEmpty(htmlEdit)) {
							return;
						}
						var html = htmlEdit.editor.document.$.body;
						var links = html.getElementsByTagName('a');
						if (!links.length) {
							return;
						}
						BPMSoft.each(links, function(link) {
							link.onclick = viewModel.linkClickHandler;
						});
					},
					/**
					 * ########## ####### ## #####-######
					 * @param evn ######### #######
					 * @returns {boolean} - ###### false
					 */
					linkClickHandler : function(evn) {
						var target = evn.target;
						if (Ext.isEmpty(target) || Ext.isEmpty(target.href)) {
							return false;
						}
						viewModel.htmlEditHyperlinkClicked(target.href);
						return false;
					},
					/**
					 * ########## ####### ## #####-###### # ######## #########
					 * @param {String} href ##### #####-######
					 */
					htmlEditHyperlinkClicked: function(href) {
						// ######### ## ##### ###### ######### ######
						if (Ext.isEmpty(href)) {
							return;
						}
						var linkParts = href.split('KnowledgeBasePage/view/').reverse();
						if (linkParts.length <= 1) {
							return;
						}
						var linkGuid = linkParts[0];
						if (!BPMSoft.utils.isGUID(linkGuid)) {
							return;
						}
						this.loadEntity(linkGuid);
					}
				}
			});
		};

		/**
		 * ######### View ######
		 * @protected
		 * @returns {BPMSoft.Container}
		 */
		var generateMainView = function() {
			var resultConfig = Ext.create('BPMSoft.Container', {
				id: 'KnowledgeBaseArticleContainer',
				selectors: {
					wrapEl: '#KnowledgeBaseArticleContainer'
				},
				items: [{
					className: 'BPMSoft.controls.KnowledgeBaseHtmlEdit',
					id: 'email-body-html-knowbase-view',
					selectors: {
						wrapEl: '#email-body-html-knowbase-view'
					},
					enabled: false,
					value: {
						bindTo: 'Notes'
					},
					afterDataReady: {
						bindTo: 'afterHtmlEditorDataReady'
					},
					classes: {
						wrapClassName: ['html-edit-wrapClass']
					}
				}]
			});
			return resultConfig;
		};

		/**
		 * #####-######
		 * @param renderTo - ############ #########
		 */
		var render = function(renderTo) {
			var viewConfig = generateMainView();
			viewModel = getViewModel();
			if (!Ext.isEmpty(inputKnowledgeBaseId) && BPMSoft.isGUID(inputKnowledgeBaseId)) {
				viewModel.loadEntity(inputKnowledgeBaseId, function() {
					viewConfig.bind(viewModel);
					viewConfig.render(renderTo);
				}, this);
			} else {
				viewConfig.render(renderTo);
			}
		};

		/**
		 * ############# inputKnowledgeBaseId. ########## ######### id ###### ##
		 * @protected
		 */
		var initInputKnowledgeBaseId = function() {
			var state = sandbox.publish('GetHistoryState');
			var currentHash = state.hash;
			inputKnowledgeBaseId = currentHash.recordId;
		};

		return {
			init: function() {
				initInputKnowledgeBaseId();
			},
			render: render
		};
	});
