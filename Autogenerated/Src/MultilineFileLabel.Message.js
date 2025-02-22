﻿define("MultilineFileLabel", ["ext-base", "BPMSoft", "MultilineFileLabelResources",
			"MultilineLabel", "css!MultilineFileLabel"],
		function(Ext, BPMSoft, resources) {
			return Ext.define("BPMSoft.controls.MultilineFileLabel", {
				extend: "BPMSoft.MultilineLabel",
				alternateClassName: "BPMSoft.MultilineFileLabel",

				/**
				 * Count of files.
				 * @private
				 * @type {Integer}
				 */
				filesCount: "",

				/**
				 * Template to display count of files.
				 * @private
				 * @type {String}
				 */
				countTemplate: "({0})",

				/**
				 * @inheritDoc BPMSoft.MultilineLabel#tpl
				 * @overridden
				 */
				tpl: [
					// jscs:disable
					/*jshint quotmark:true */
					'<div id="{id}" class="{multilineLabelClass}">',
					'<div id="{id}_content" class="{labelContentContainer}">',
					'<div id="{id}_label" class="{labelClass}">',
					'{%this.renderContent(out, values)%}',
					'</div>',
					'</div>',
					'<div id="{id}_showMoreFilesContainer" class="{readMoreClass}">',
					'<img id="{id}_fileImage" src="{fileImageSrc}">',
					'<span id="{id}_readMore">{showMoreCaption}</span>',
					'<label id="{id}_filesCount" class="{filesCountClass}">{filesCount}</label>',
					'</div>',
					'</div>'
					/*jshint quotmark:false */
					// jscs:enable
				],

				/**
				 * @inheritDoc BPMSoft.MultilineLabel#getTplData
				 * @overridden
				 */
				getTplData: function() {
					var tplData = this.callParent(arguments);
					var showMoreButtonCaption = resources.localizableStrings.showMoreButtonCpation;
					var fileImageSrc =  BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.FileImageSrc);
					Ext.apply(tplData, {
						fileImageSrc: fileImageSrc,
						filesCount: this.filesCount,
						filesCountClass: ["filesCount"],
						showMoreCaption: BPMSoft.utils.string.encodeHtml(showMoreButtonCaption)
					});
					return tplData;
				},

				/**
				 * @inheritDoc BPMSoft.Label#getBindConfig
				 * @overridden
				 */
				getBindConfig: function() {
					var bindConfig = this.callParent(arguments);
					var config = {
						filesCount: {
							changeMethod: "setFilesCount"
						},
						countTemplate: {
							changeMethod: "setCountTemplate"
						}
					};
					Ext.apply(config, bindConfig);
					return config;
				},

				/**
				 * Sets template to display count of files.
				 * @protected
				 * @virtual
				 * @param {String} template Template to display count of files.
				 */
				setCountTemplate: function(template) {
					this.countTemplate = template;
				},

				/**
				 * Sets count of files.
				 * @protected
				 * @virtual
				 * @param {Integer} filesCount Count of files.
				 */
				setFilesCount: function(filesCount) {
					if (!filesCount || this.filesCount === filesCount) {
						return;
					}
					this.filesCount = Ext.String.format(this.countTemplate, filesCount);
				}
			});
		}
);
