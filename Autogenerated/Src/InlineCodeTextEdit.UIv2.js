define("InlineCodeTextEdit", ["SourceCodeEditMixin", "EmailImageMixin"],
	function() {

		/**
		 * Class of inline code text edit.
		 */
		Ext.define("BPMSoft.controls.InlineCodeTextEdit", {
			extend: "BPMSoft.controls.InlineTextEdit",
			alternateClassName: "BPMSoft.InlineCodeTextEdit",

			/**
			 * Images collection.
			 * @private
			 * @type {BPMSoft.Collection}
			 */
			images: null,

			showEmailTemplateLinkButton: BPMSoft.Features.getIsEnabled("IsObjectLinkEnabled"),

			mixins: {
				SourceCodeEditMixin: "BPMSoft.SourceCodeEditMixin",

				/**
				 * @class BPMSoft.EmailImageMixin
				 * Mixin for inserting email images.
				 */
				EmailImageMixin: "BPMSoft.EmailImageMixin"
			},

			/**
			 * @overridden
			 * @inheritdoc BPMSoft.Component#init
			 */
			init: function() {
				this.addEvents(

					/*
					 * @event imagePasted
					 * Handles pasting image from buffer.
					 * @param {Object} item Pasted image.
					 */
					"imagePasted"
				);
				this.images = Ext.create("BPMSoft.Collection");
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.Component#destroy
			 * @overridden
			 */
			destroy: function() {
				if (this.images) {
					this.images.un("dataLoaded", this.onImagesLoaded, this);
					this.images.un("add", this.onAddImage, this);
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.Bindable#subscribeForCollectionEvents
			 * @overridden
			 */
			subscribeForCollectionEvents: function(binding, property, model) {
				this.callParent(arguments);
				var collection = model.get(binding.modelItem);
				collection.on("dataLoaded", this.onImagesLoaded, this);
				collection.on("add", this.onAddImage, this);
			},

			/**
			 * @inheritdoc BPMSoft.Bindable#subscribeForEvents
			 * @overridden
			 */
			subscribeForEvents: function(binding, property, model) {
				this.callParent(arguments);
				if (property !== "value") {
					return;
				}
				var validationMethodName = binding.config.validationMethod;
				if (validationMethodName) {
					var validationMethod = this[validationMethodName];
					model.validationInfo.on("change:" + binding.modelItem,
						function(collection, value) {
							validationMethod.call(this, value);
						},
						this
					);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseEdit#getBindConfig
			 * @overridden
			 */
			getBindConfig: function() {
				var bindConfig = this.callParent(arguments);
				Ext.apply(bindConfig, {
					images: {
						changeMethod: "onImagesLoaded"
					}
				});
				return bindConfig;
			},

			/**
			 * @inheritdoc BPMSoft.InlineTextEdit#onContentDom
			 * @overridden
			 */
			onContentDom: function() {
				this.callParent(arguments);
				var editor = this.editor;
				var editableElement = editor.editable() || editor.document;
				editableElement.on("paste", this.mixins.EmailImageMixin.onPaste.bind(this), null, {editor: editor});
			},

			/**
			 * @inheritdoc BPMSoft.InlineTextEdit#initExtraPluginsToolbar
			 * @overridden
			 */
			initExtraPluginsToolbar: function() {
				this.callParent(arguments);
				this.createButton("bpmcrmsource", this.onSourceButtonClick);
			},

			/**
			 * Handles source button click.
			 * @protected
			 * @virtual
			 */
			onSourceButtonClick: function() {
				this.setFocused(false);
				this.mixins.SourceCodeEditMixin.openSourceCodeEditModalBox.call(this);
			},

			/**
			 * Reutns source value.
			 * @protected
			 * @virtual
			 * @return {String} Source code.
			 */
			loadSourceCodeValue: function() {
				return this.getValue();
			},

			/**
			 * Set source code to editor.
			 * @protected
			 * @virtual
			 * @param {String} Source code.
			 */
			saveSourceCodeValue: function(value) {
				this.setValue(value);
			},

			/**
			 * @inheritdoc BPMSoft.Component#onDestroy
			 * @overridden
			 */
			onDestroy: function() {
				this.mixins.SourceCodeEditMixin.destroySourceCodeEdit.apply(this, arguments);
				this.callParent(arguments);
			}
		});
		return BPMSoft.SourceCodeEditMixin;
	});
