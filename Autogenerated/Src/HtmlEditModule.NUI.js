define("HtmlEditModule", ["ext-base", "EmailImageMixin", "BPMSoft", "HtmlEditModuleResources", "ckeditor-base",
	"jQuery"], function(Ext, EmailImageMixin, BPMSoft, resources) {
	Ext.ns("BPMSoft.controls.HtmlEdit");

	/**
	 * Html editor control class.
	 */
	Ext.define("BPMSoft.controls.HtmlEdit", {
		extend: "BPMSoft.Container",
		alternateClassName: "BPMSoft.HtmlEdit",

		mixins: {

			/**
			 * @class BPMSoft.EmailImageMixin
			 * Mixin for inserting email images.
			 */
			EmailImageMixin: "BPMSoft.EmailImageMixin",


			/**
			 * Voice to text button.
			 */
			voiceToTextButton: "BPMSoft.VoiceToTextButton"
		},

		//region Properties: Private

		/**
		 * Control settings.
		 * @private
		 * @static
		 * @type {Object}
		 */
		tplData: {
			classes: {
				htmlEditClass: ["html-editor"],
				htmlEditToolbarClass: ["html-edit-toolbar"],
				htmlEditToolbarTopClass: ["html-edit-toolbar-top"],
				htmlEditToolbarButtonGroupClass: ["html-edit-toolbar-buttongroup"],
				htmlEditTextareaClass: ["html-edit-textarea", "onhtml-edit-textarea"]
			},
			styles: {
				htmlEditStyle: {
					width: this.width,
					height: this.height,
					margin: this.margin
				},
				htmlEditFontFamilyStyle: {width: "126px"},
				htmlEditFontSizeStyle: {
					width: "68px"
				}
			}
		},

		/**
		 * Control toolbar element.
		 * @private
		 * @static
		 * @type {Object}
		 */
		toolbar: null,

		/**
		 * Toolbar wrapper element.
		 * @private
		 * @type {Ext.Element}
		 */
		toolbarEl: null,

		/**
		 * Memo edit control.
		 * @private
		 * @static
		 * @type {Object}
		 */
		memo: null,

		/**
		 * Font sizes collection.
		 * @private
		 * @type {BPMSoft.Collection}
		 */
		fontSizesCollection: null,

		/**
		 * Font family collection.
		 * @private
		 * @type {BPMSoft.Collection}
		 */
		fontFamilyCollection: null,

		//endregion

		//region Properties: Protected

		/**
		 * Object that contains information about control validation.
		 * @protected
		 * @type {Object}
		 */
		validationInfo: null,

		/**
		 * Set value timeout. Delay in miliseconds, between user input and control value update.
		 * @protected
		 * @type {Number}
		 */
		setValueDelay: 250,

		//endregion

		//region Properties: Public

		/**
		 * CKeditor resize enabled flag.
		 * @type {Boolean}
		 */
		resizeEnabled: false,

		/**
		 * CKeditor macroses using flag.
		 * @type {Boolean}
		 */
		useMacroses: false,

		/**
		 * Resizable CKeditor initial height.
		 * @type {Integer}
		 */
		initialHeight: 50,

		/**
		 * Default font family.
		 * @type {String}
		 */
		defaultFontFamily: "Golos Regular",

		/**
		 * Determines if the value is required.
		 * @type {Boolean}
		 */
		isRequired: false,
		isFullScreenActive: false,

		/**
		 * Css-class for control when he doesn't pass validation.
		 * @type {String}
		 */
		errorClass: "base-edit-error",

		/**
		 * Font families.
		 * @type {String}
		 */
		fontFamily: "Verdana,Times New Roman,Courier New,Arial,Tahoma,Arial Black,Comic Sans MS,Golos Regular",

		/**
		 * Default font size.
		 * @type {String}
		 */
		defaultFontSize: "14",

		/**
		 * Font size.
		 * @type {String}
		 */
		fontSize: "8,9,10,11,12,13,14,16,18,20,22,24,26,28,36,48,72",

		/**
		 * Default font color.
		 * @type {String}
		 */
		defaultFontColor: "#000000",

		/**
		 * Default background.
		 * @type {String}
		 */
		defaultBackground: "#ffffff",

		/**
		 * Default highlight.
		 * @type {String}
		 */
		defaultHighlight: "#ffffff",

		/**
		 * Default button style.
		 * @type {BPMSoft.controls.ButtonEnums.style}
		 */
		defaultButtonStyle: BPMSoft.controls.ButtonEnums.style.DEFAULT,

		/**
		 * Value.
		 * @type {String}
		 */
		value: "",

		/**
		 * Plain text value without html tags.
		 * @type {String}
		 */
		plainTextValue: "",

		/**
		 * Editor object.
		 * @type {Object}
		 */
		editor: null,

		/**
		 * Prefix for control element.
		 * @type {String}
		 */
		controlElementPrefix: "html-edit",

		/**
		 * Plain text mode.
		 * @type {Boolean}
		 */
		plainTextMode: false,

		/**
		 * Confirm plain text mode enable flag.
		 * @type {Boolean}
		 */
		showChangeModeConfirmation: true,

		/**
		 * Edit mode buttons visibility.
		 * @type {Boolean}
		 */
		hideModeButtons: false,

		/**
		 * Control width.
		 * @type {String}
		 */
		width: "100%",

		/**
		 * Control height.
		 * @type {String}
		 */
		height: "350px",

		/**
		 * Control margins.
		 * @type {String}
		 */
		margin: "0",

		/**
		 * Control enable state.
		 * @type {Boolean}
		 */
		enabled: true,

		/**
		 * Images collection.
		 * @type {BPMSoft.Collection}
		 */
		images: null,

		/**
		 * Name of the CSS class for show the toolbar control.
		 * @type {String}
		 */
		visibleToolbarClass: "html-edit-toolbar-show",

		/**
		 * Parameter indicating that you want to use the voice to text button.
		 */
		enableVoiceToTextButton: BPMSoft.Features.getIsEnabled("VoiceToTextHtmlEdit"),

		/**
		 * Sanitization level.
		 * @protected
		 * @type {Integer}
		 */
		sanitizationLevel: BPMSoft.sanitizationLevel.DEFAULT,

		/**
		 * Editor mode (html | plain | html-edit)
		 * @type {String}
		 */
		editorMode: "",

		/**
		 * Html view mode value.
		 * type {String}
		 */
		htmlModeValue: "html",

		/**
		 * Plain text mode value.
		 * type {String}
		 */		
		plainModeValue: "plain",

		/**
		 * Html edit mode value.
		 * type {String}
		 */
		htmlEditModeValue: "html-edit",

		/**
		 * Html edit mode enabled.
		 * type {Boolean}
		 */
		htmlEditModeEnabled: false,

		/**
		 * Control render template.
		 * @overridden
		 * @type {Array}
		 */
		tpl: [
			//jscs:disable
			/*jshint quotmark: false */
			/*jshint maxlen:140 */
			"<div id=\"{id}-html-edit\" class=\"{htmlEditClass}\" style=\"{htmlEditStyle}\">",
			"<div style=\"display: table-row;\">",
			"<div id=\"{id}-html-edit-toolbar\" class=\"{htmlEditToolbarClass}\">",
			"<div id=\"html-edit-toolbar-undo\" class=\"{htmlEditToolbarButtonGroupClass}\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'undo' || tag == 'redo'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"<div id=\"html-edit-toolbar-font-family\" class=\"{htmlEditToolbarButtonGroupClass}\" style=\"{htmlEditFontFamilyStyle}\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'fontFamily'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"<div id=\"html-edit-toolbar-font-size\" class=\"{htmlEditToolbarButtonGroupClass}\" style=\"{htmlEditFontSizeStyle}\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'fontSize'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"<div id=\"html-edit-toolbar-font-style\" class=\"{htmlEditToolbarButtonGroupClass}\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'fontStyleBold' || tag == 'fontStyleItalic' || tag == 'fontStyleUnderline'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"<div id=\"html-edit-toolbar-font-color\" class=\"{htmlEditToolbarButtonGroupClass}\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'fontColor'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"<div id=\"html-edit-toolbar-highlight\" class=\"{htmlEditToolbarButtonGroupClass}\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'hightlightColor'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"<div id=\"html-edit-toolbar-list\" class=\"{htmlEditToolbarButtonGroupClass}\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'numberedList' || tag == 'bulletedList' || tag == 'indentList' || tag == 'outdentList'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"<div id=\"html-edit-toolbar-tools\" class=\"{htmlEditToolbarButtonGroupClass}\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'maximized'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"<div id=\"html-edit-toolbar-justify\" class=\"{htmlEditToolbarButtonGroupClass}\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'justifyLeft' || tag == 'justifyCenter' || tag == 'justifyRight'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"<div id=\"html-edit-toolbar-image\" class=\"{htmlEditToolbarButtonGroupClass}\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'image'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"<div id=\"html-edit-toolbar-link\" class=\"{htmlEditToolbarButtonGroupClass}\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'link'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"<div id=\"html-edit-toolbar-justify\" class=\"{htmlEditToolbarButtonGroupClass}\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'htmlMode' || tag == 'plainMode' || tag == 'htmlEditMode'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"<div id=\"{id}-html-edit-toolbar-table\" class=\"{htmlEditToolbarButtonGroupClass}\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'table'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"</div>",
			"</div>",
			"<div style=\"display: table-row;\">",
			"<div id=\"{id}-html-edit-htmltext\" class=\"{htmlEditTextareaClass}\"  style=\"display: none\">",
			"<textarea id=\"{id}-html-edit-textarea\" style=\"border: none\"></textarea>",
			"{%this.renderVoiceToTextButton(out, values)%}",
			"</div>",
			"<div id=\"{id}-html-edit-plaintext\" class=\"{htmlEditTextareaClass}\" style=\"margin-bottom: 24px;\">",
			"<tpl for=\"items\">",
			"<tpl if=\"tag == 'plainText'\">",
			"<@item>",
			"</tpl>",
			"</tpl>",
			"</div>",
			"</div>",
			"<span id=\"{id}-validation\" class=\"{validationClass}\" style=\"{validationStyle}\">" +
			"{validationText}</span>",
			"</div>"
			/*jshint maxlen:120 */
			/*jshint quotmark: true */
			//jscs:enable
		],

		/**
		 * Editor elements.
		 * @overridden
		 * @type {Array}
		 */
		items: null,

		/**
		 * Editor menu elements.
		 * @type {Array}
		 */
		menuItems: null,

		/**
		 * Editor elements config.
		 * @overridden
		 * @type {Array}
		 */
		itemsConfig: [
			{
				className: "BPMSoft.ComboBoxEdit",
				tag: "fontFamily"
			},
			{
				className: "BPMSoft.ComboBoxEdit",
				tag: "fontSize"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxwYXRoIGQ9Ik01IDNIMTEuNjgwOEMxMy4wMDMzIDMgMTMuOTg3NSAzLjA2MTM5IDE0LjYzMzYgMy4xODQxN0MxNS4yODcyIDMuMjk4NzcgMTUuODY4NiAzLjU0NDM0IDE2LjM3NzggMy45MjA4N0MxNi44OTQ3IDQuMjk3NDEgMTcuMzI0MSA0LjgwMDgyIDE3LjY2NjEgNS40MzExQzE4LjAwODEgNi4wNTMyMSAxOC4xNzkyIDYuNzUzMDcgMTguMTc5MiA3LjUzMDdDMTguMTc5MiA4LjM3MzgxIDE3Ljk2NjMgOS4xNDczNCAxNy41NDA3IDkuODUxM0MxNy4xMjI3IDEwLjU1NTMgMTYuNTUyNyAxMS4wODMyIDE1LjgzMDYgMTEuNDM1MkMxNi44NDkxIDExLjc1NDQgMTcuNjMxOSAxMi4yOTg4IDE4LjE3OTIgMTMuMDY4MkMxOC43MjY0IDEzLjgzNzcgMTkgMTQuNzQyMiAxOSAxNS43ODE3QzE5IDE2LjYwMDMgMTguODIxNCAxNy4zOTg0IDE4LjQ2NDIgMTguMTc2QzE4LjExNDUgMTguOTQ1NCAxNy42MzE5IDE5LjU2MzQgMTcuMDE2MyAyMC4wM0MxNi40MDgzIDIwLjQ4ODQgMTUuNjU1OCAyMC43NzA4IDE0Ljc1OSAyMC44NzcyQzE0LjE5NjUgMjAuOTQyNyAxMi44Mzk4IDIwLjk4MzYgMTAuNjg4OSAyMUg1VjNaTTguMzc0NTkgNS45OTU5MVYxMC4xNTgzSDEwLjU4NjNDMTEuOTAxMiAxMC4xNTgzIDEyLjcxODIgMTAuMTM3OCAxMy4wMzc1IDEwLjA5NjlDMTMuNjE1MSAxMC4wMjMyIDE0LjA2NzMgOS44MTAzNyAxNC4zOTQxIDkuNDU4MzlDMTQuNzI4NiA5LjA5ODIzIDE0Ljg5NTggOC42Mjc1NiAxNC44OTU4IDguMDQ2MzhDMTQuODk1OCA3LjQ4OTc3IDE0Ljc1MTQgNy4wMzk1NiAxNC40NjI1IDYuNjk1NzdDMTQuMTgxMyA2LjM0Mzc5IDEzLjc1OTUgNi4xMzA5NyAxMy4xOTcxIDYuMDU3M0MxMi44NjI2IDYuMDE2MzcgMTEuOTAxMiA1Ljk5NTkxIDEwLjMxMjcgNS45OTU5MUg4LjM3NDU5Wk04LjM3NDU5IDEzLjE1NDJWMTcuOTY3M0gxMS40OTg0QzEyLjcxNDQgMTcuOTY3MyAxMy40ODU5IDE3LjkzMDQgMTMuODEyNyAxNy44NTY4QzE0LjMxNDMgMTcuNzU4NSAxNC43MjEgMTcuNTIxMSAxNS4wMzI2IDE3LjE0NDZDMTUuMzUxOCAxNi43NTk5IDE1LjUxMTQgMTYuMjQ4MyAxNS41MTE0IDE1LjYwOThDMTUuNTExNCAxNS4wNjk2IDE1LjM4OTggMTQuNjExMiAxNS4xNDY2IDE0LjIzNDdDMTQuOTAzNCAxMy44NTgxIDE0LjU0OTkgMTMuNTgzOSAxNC4wODYzIDEzLjQxMkMxMy42MzAzIDEzLjI0MDEgMTIuNjM0NiAxMy4xNTQyIDExLjA5OTMgMTMuMTU0Mkg4LjM3NDU5WiIgZmlsbD0iIzY3NzQ4RSIvPg0KPC9zdmc+DQo="
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						editor.execCommand("bold");
					}
				},
				tag: "fontStyleBold"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxwYXRoIGQ9Ik0xMy41NTMxIDIxLjQ1NDNMMTMuNDA3MSAyMkg2TDYuMTg1ODQgMjEuNDU0M0M2LjkyOTIgMjEuNDM0NiA3LjQyMDM1IDIxLjM2NTggNy42NTkyOSAyMS4yNDc4QzguMDQ4NjcgMjEuMDgwNiA4LjMzNjI4IDIwLjg0OTYgOC41MjIxMiAyMC41NTQ2QzguODE0MTYgMjAuMDkyNCA5LjExNTA0IDE5LjI2NjUgOS40MjQ3OCAxOC4wNzY3TDEyLjU1NzUgNi4wMTE4QzEyLjgyMyA1LjAwODg1IDEyLjk1NTggNC4yNTE3MiAxMi45NTU4IDMuNzQwNDFDMTIuOTU1OCAzLjQ4NDc2IDEyLjg5ODIgMy4yNjg0NCAxMi43ODMyIDMuMDkxNDVDMTIuNjY4MSAyLjkxNDQ1IDEyLjQ5MTIgMi43ODE3MSAxMi4yNTIyIDIuNjkzMjJDMTIuMDIyMSAyLjU5NDg5IDExLjU2NjQgMi41NDU3MiAxMC44ODUgMi41NDU3MkwxMS4wNDQyIDJIMThMMTcuODU0IDIuNTQ1NzJDMTcuMjg3NiAyLjUzNTg5IDE2Ljg2NzMgMi42MDQ3MiAxNi41OTI5IDIuNzUyMjFDMTYuMTk0NyAyLjk0ODg3IDE1Ljg4OTQgMy4yMjkxMSAxNS42NzcgMy41OTI5MkMxNS40NzM1IDMuOTU2NzQgMTUuMjA4IDQuNzYzMDMgMTQuODgwNSA2LjAxMThMMTEuNzYxMSAxOC4wNzY3QzExLjQ3NzkgMTkuMTg3OCAxMS4zMzYzIDE5Ljg5NTggMTEuMzM2MyAyMC4yMDA2QzExLjMzNjMgMjAuNDQ2NCAxMS4zODk0IDIwLjY1NzggMTEuNDk1NiAyMC44MzQ4QzExLjYxMDYgMjEuMDAyIDExLjc4NzYgMjEuMTM0NyAxMi4wMjY1IDIxLjIzM0MxMi4yNzQzIDIxLjMyMTUgMTIuNzgzMiAyMS4zOTUzIDEzLjU1MzEgMjEuNDU0M1oiIGZpbGw9IiM2Nzc0OEUiLz4NCjwvc3ZnPg0K"
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						editor.execCommand("italic");
					}
				},
				tag: "fontStyleItalic"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxwYXRoIGQ9Ik0xNS42NDkyIDJIMTcuNVYxMS4wODkyQzE3LjUgMTIuNjcwMiAxNy4zNDEgMTMuOTI1OCAxNy4wMjMgMTQuODU1OEMxNi43MDUgMTUuNzg1OCAxNi4xMjk0IDE2LjU0NDIgMTUuMjk2MiAxNy4xMzA4QzE0LjQ2OTQgMTcuNzEwMyAxMy4zODE4IDE4IDEyLjAzMzQgMThDMTAuNzIzMiAxOCA5LjY1MTQ5IDE3Ljc0NiA4LjgxODMgMTcuMjM4MUM3Ljk4NTExIDE2LjczMDIgNy4zOTA0MyAxNS45OTY5IDcuMDM0MjYgMTUuMDM4MkM2LjY3ODA5IDE0LjA3MjQgNi41IDEyLjc1NjEgNi41IDExLjA4OTJWMkg4LjM1MDgyVjExLjA3ODVDOC4zNTA4MiAxMi40NDQ5IDguNDYyMTMgMTMuNDUzNiA4LjY4NDc0IDE0LjEwNDZDOC45MTM3IDE0Ljc0ODUgOS4zMDE2OCAxNS4yNDU3IDkuODQ4NjYgMTUuNTk2MkMxMC40MDIgMTUuOTQ2OCAxMS4wNzYyIDE2LjEyMjEgMTEuODcxMiAxNi4xMjIxQzEzLjIzMjMgMTYuMTIyMSAxNC4yMDIyIDE1Ljc3NTEgMTQuNzgxIDE1LjA4MTJDMTUuMzU5OCAxNC4zODcyIDE1LjY0OTIgMTMuMDUzIDE1LjY0OTIgMTEuMDc4NVYyWiIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iNCIgeT0iMjAiIHdpZHRoPSIxNiIgaGVpZ2h0PSIyIiByeD0iMSIgZmlsbD0iIzY3NzQ4RSIvPg0KPC9zdmc+DQo="
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						editor.execCommand("underline");
					}
				},
				tag: "fontStyleUnderline"
			},
			{
				className: "BPMSoft.ColorButton",
				simpleMode: false,
				defaultValue: "#000000",
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxwYXRoIGQ9Ik00LjUgMTlDNC41IDE4LjQ0NzcgNC45NDc3MiAxOCA1LjUgMThIMTguNUMxOS4wNTIzIDE4IDE5LjUgMTguNDQ3NyAxOS41IDE5VjIwQzE5LjUgMjAuNTUyMyAxOS4wNTIzIDIxIDE4LjUgMjFINS41QzQuOTQ3NzIgMjEgNC41IDIwLjU1MjMgNC41IDIwVjE5WiIgZmlsbD0iIzY3NzQ4RSIvPg0KPHBhdGggZD0iTTYgMTZMMTAuOTI0MiAySDEyLjc1MjJMMTggMTZIMTYuMDY3MUwxNC41NzE0IDExLjc1OTlIOS4yMDk5MUw3LjgwMTc1IDE2SDZaTTkuNjk5NzEgMTAuMjUxSDE0LjA0NjZMMTIuNzA4NSA2LjM3MzgxQzEyLjMwMDMgNS4xOTYgMTEuOTk3MSA0LjIyODI5IDExLjc5ODggMy40NzA2N0MxMS42MzU2IDQuMzY4MzUgMTEuNDA1MiA1LjI1OTY2IDExLjEwNzkgNi4xNDQ2MUw5LjY5OTcxIDEwLjI1MVoiIGZpbGw9IiM2Nzc0OEUiLz4NCjwvc3ZnPg0K"
				},
				tag: "fontColor"
			},
			{
				className: "BPMSoft.ColorButton",
				simpleMode: true,
				defaultValue: "#ffffff",
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxyZWN0IHg9IjMiIHk9IjMiIHdpZHRoPSIxOCIgaGVpZ2h0PSIxOCIgcng9IjMiIHN0cm9rZT0iIzY3NzQ4RSIgc3Ryb2tlLXdpZHRoPSIyIi8+DQo8cGF0aCBkPSJNNyAxNy41TDExLjEwMzUgNi41SDEyLjYyNjhMMTcgMTcuNUgxNS4zODkyTDE0LjE0MjkgMTQuMTY4NUg5LjY3NDkzTDguNTAxNDYgMTcuNUg3Wk0xMC4wODMxIDEyLjk4MjlIMTMuNzA1NUwxMi41OTA0IDkuOTM2NTZDMTIuMjUwMiA5LjAxMTE0IDExLjk5NzYgOC4yNTA4IDExLjgzMjQgNy42NTU1M0MxMS42OTYzIDguMzYwODUgMTEuNTA0NCA5LjA2MTE2IDExLjI1NjYgOS43NTY0OEwxMC4wODMxIDEyLjk4MjlaIiBmaWxsPSIjNjc3NDhFIi8+DQo8L3N2Zz4NCg=="
				},
				tag: "hightlightColor"
			},
			{
				className: "BPMSoft.Button",

				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxwYXRoIGQ9Ik0yLjU2OTUgMTcuNzk3NVYxNy4wODY1SDNDMy4zMjU1IDE3LjA4NjUgMy41NDQ1IDE2Ljg4MSAzLjU0NDUgMTYuNjExQzMuNTQ0NSAxNi4zMzM1IDMuMzA3NSAxNi4xNDYgMy4wMDMgMTYuMTQ2QzIuNjY4NSAxNi4xNDYgMi40NTI1IDE2LjM3NCAyLjQ0MzUgMTYuNjExSDEuNTU4NUMxLjU4MjUgMTUuOTEwNSAyLjExOCAxNS40MzA1IDMuMDM3NSAxNS40MzA1QzMuOTE5NSAxNS40Mjc1IDQuNDY4NSAxNS44NjcgNC40NzMgMTYuNDg1QzQuNDc1ODQgMTYuNjk2OSA0LjQwMzE0IDE2LjkwMyA0LjI2NzkyIDE3LjA2NjNDNC4xMzI3IDE3LjIyOTUgMy45NDM3OSAxNy4zMzkzIDMuNzM1IDE3LjM3NlYxNy40MjU1QzMuOTcxNzEgMTcuNDQzMSA0LjE5MjUxIDE3LjU1MTQgNC4zNTE0OCAxNy43Mjc2QzQuNTEwNDQgMTcuOTAzOSA0LjU5NTMzIDE4LjEzNDcgNC41ODg1IDE4LjM3MkM0LjU5MyAxOS4xNzE1IDMuODM1NSAxOS41NzIgMy4wMTIgMTkuNTcyQzIuMDI4IDE5LjU3MiAxLjUxMiAxOS4wMTcgMS41IDE4LjM4MUgyLjM3M0MyLjM4NSAxOC42NDggMi42NTIgMTguODQgMy4wMDYgMTguODQ0NUMzLjM4NyAxOC44NDQ1IDMuNjQyIDE4LjYyNyAzLjYzOSAxOC4zMTk1QzMuNjM2IDE4LjAyNyAzLjQwNjUgMTcuNzk3NSAzLjAxOCAxNy43OTc1SDIuNTY4SDIuNTY5NVpNMi41NjM1IDEwLjc0OUgxLjY1NzVWMTAuNjk2NUMxLjY1NzUgMTAuMDg0NSAyLjEgOS40MzA0OCAzLjA5NDUgOS40MzA0OEMzLjk2OSA5LjQzMDQ4IDQuNTM0NSA5LjkxOTQ4IDQuNTM0NSAxMC41NjQ1QzQuNTM0NSAxMS4xNDggNC4xNDkgMTEuNDkgMy44MjA1IDExLjgzNjVMMy4wMTUgMTIuNjk0NVYxMi43Mzk1SDQuNTk2VjEzLjVIMS43MTQ1VjEyLjkwNzVMMy4xNSAxMS40MjI1QzMuMzU3IDExLjIwOTUgMy41ODk1IDEwLjk2NjUgMy41ODk1IDEwLjY2MDVDMy41ODk1IDEwLjM5MDUgMy4zNjkgMTAuMTgwNSAzLjA3NjUgMTAuMTgwNUMzLjAwODk3IDEwLjE3OCAyLjk0MTY2IDEwLjE4OTQgMi44Nzg2OSAxMC4yMTM5QzIuODE1NzMgMTAuMjM4NCAyLjc1ODQ1IDEwLjI3NTYgMi43MTAzOSAxMC4zMjMxQzIuNjYyMzMgMTAuMzcwNiAyLjYyNDUxIDEwLjQyNzQgMi41OTkyNCAxMC40OTAxQzIuNTczOTggMTAuNTUyNyAyLjU2MTgyIDEwLjYxOTkgMi41NjM1IDEwLjY4NzVWMTAuNzQ5Wk0zLjg0NiA3LjQ5OTk4SDIuODkzNVY0LjM4NTk4SDIuODQ3TDEuOTUgNS4wMTU5OFY0LjE2NTQ4TDIuODkzNSAzLjUwMDk4SDMuODQ2VjcuNDk5OThaIiBmaWxsPSIjNjc3NDhFIi8+DQo8cmVjdCB4PSI2IiB5PSI0LjUiIHdpZHRoPSIxNiIgaGVpZ2h0PSIyIiByeD0iMSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iNiIgeT0iMTAuNSIgd2lkdGg9IjE2IiBoZWlnaHQ9IjIiIHJ4PSIxIiBmaWxsPSIjNjc3NDhFIi8+DQo8cmVjdCB4PSI2IiB5PSIxNi41IiB3aWR0aD0iMTYiIGhlaWdodD0iMiIgcng9IjEiIGZpbGw9IiM2Nzc0OEUiLz4NCjwvc3ZnPg0K"
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						editor.execCommand("numberedlist");
					}
				},
				tag: "numberedList"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxyZWN0IHg9IjYiIHk9IjQuNSIgd2lkdGg9IjE2IiBoZWlnaHQ9IjIiIHJ4PSIxIiBmaWxsPSIjNjc3NDhFIi8+DQo8cmVjdCB4PSI2IiB5PSIxMC41IiB3aWR0aD0iMTYiIGhlaWdodD0iMiIgcng9IjEiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjYiIHk9IjE2LjUiIHdpZHRoPSIxNiIgaGVpZ2h0PSIyIiByeD0iMSIgZmlsbD0iIzY3NzQ4RSIvPg0KPGNpcmNsZSBjeD0iMy41IiBjeT0iNS41IiByPSIxLjUiIGZpbGw9IiM2Nzc0OEUiLz4NCjxjaXJjbGUgY3g9IjMuNSIgY3k9IjExLjUiIHI9IjEuNSIgZmlsbD0iIzY3NzQ4RSIvPg0KPGNpcmNsZSBjeD0iMy41IiBjeT0iMTcuNSIgcj0iMS41IiBmaWxsPSIjNjc3NDhFIi8+DQo8L3N2Zz4NCg=="
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						editor.execCommand("bulletedlist");
					}
				},
				tag: "bulletedList"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxnIGNsaXAtcGF0aD0idXJsKCNjbGlwMF83NzFfMTA5MTg4KSI+DQo8cmVjdCB4PSIzIiB5PSI1IiB3aWR0aD0iMTgiIGhlaWdodD0iMiIgcng9IjEiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjMiIHk9IjEzIiB3aWR0aD0iMTgiIGhlaWdodD0iMiIgcng9IjEiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjMiIHk9IjkiIHdpZHRoPSIxMiIgaGVpZ2h0PSIyIiByeD0iMSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iMyIgeT0iMTciIHdpZHRoPSIxMiIgaGVpZ2h0PSIyIiByeD0iMSIgZmlsbD0iIzY3NzQ4RSIvPg0KPC9nPg0KPGRlZnM+DQo8Y2xpcFBhdGggaWQ9ImNsaXAwXzc3MV8xMDkxODgiPg0KPHJlY3Qgd2lkdGg9IjI0IiBoZWlnaHQ9IjI0IiByeD0iNCIgZmlsbD0id2hpdGUiLz4NCjwvY2xpcFBhdGg+DQo8L2RlZnM+DQo8L3N2Zz4NCg=="
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						editor.execCommand("justifyleft");
					}
				},
				tag: "justifyLeft"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxnIGNsaXAtcGF0aD0idXJsKCNjbGlwMF83NzFfMTA5MTg5KSI+DQo8cGF0aCBmaWxsLXJ1bGU9ImV2ZW5vZGQiIGNsaXAtcnVsZT0iZXZlbm9kZCIgZD0iTTQgNUMzLjQ0NzcyIDUgMyA1LjQ0NzcyIDMgNkMzIDYuNTUyMjggMy40NDc3MiA3IDQgN0gyMEMyMC41NTIzIDcgMjEgNi41NTIyOCAyMSA2QzIxIDUuNDQ3NzIgMjAuNTUyMyA1IDIwIDVINFpNNCAxM0MzLjQ0NzcyIDEzIDMgMTMuNDQ3NyAzIDE0QzMgMTQuNTUyMyAzLjQ0NzcyIDE1IDQgMTVIMjBDMjAuNTUyMyAxNSAyMSAxNC41NTIzIDIxIDE0QzIxIDEzLjQ0NzcgMjAuNTUyMyAxMyAyMCAxM0g0Wk02IDEwQzYgOS40NDc3MiA2LjQ0NzcyIDkgNyA5SDE3QzE3LjU1MjMgOSAxOCA5LjQ0NzcyIDE4IDEwQzE4IDEwLjU1MjMgMTcuNTUyMyAxMSAxNyAxMUg3QzYuNDQ3NzIgMTEgNiAxMC41NTIzIDYgMTBaTTcgMTdDNi40NDc3MiAxNyA2IDE3LjQ0NzcgNiAxOEM2IDE4LjU1MjMgNi40NDc3MiAxOSA3IDE5SDE3QzE3LjU1MjMgMTkgMTggMTguNTUyMyAxOCAxOEMxOCAxNy40NDc3IDE3LjU1MjMgMTcgMTcgMTdIN1oiIGZpbGw9IiM2Nzc0OEUiLz4NCjwvZz4NCjxkZWZzPg0KPGNsaXBQYXRoIGlkPSJjbGlwMF83NzFfMTA5MTg5Ij4NCjxyZWN0IHdpZHRoPSIyNCIgaGVpZ2h0PSIyNCIgcng9IjQiIGZpbGw9IndoaXRlIi8+DQo8L2NsaXBQYXRoPg0KPC9kZWZzPg0KPC9zdmc+DQo="
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						editor.execCommand("justifycenter");
					}
				},
				tag: "justifyCenter"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxnIGNsaXAtcGF0aD0idXJsKCNjbGlwMF83NzFfMTA5MTkwKSI+DQo8cmVjdCB4PSIzIiB5PSI1IiB3aWR0aD0iMTgiIGhlaWdodD0iMiIgcng9IjEiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjMiIHk9IjEzIiB3aWR0aD0iMTgiIGhlaWdodD0iMiIgcng9IjEiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjkiIHk9IjkiIHdpZHRoPSIxMiIgaGVpZ2h0PSIyIiByeD0iMSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iOSIgeT0iMTciIHdpZHRoPSIxMiIgaGVpZ2h0PSIyIiByeD0iMSIgZmlsbD0iIzY3NzQ4RSIvPg0KPC9nPg0KPGRlZnM+DQo8Y2xpcFBhdGggaWQ9ImNsaXAwXzc3MV8xMDkxOTAiPg0KPHJlY3Qgd2lkdGg9IjI0IiBoZWlnaHQ9IjI0IiByeD0iNCIgZmlsbD0id2hpdGUiLz4NCjwvY2xpcFBhdGg+DQo8L2RlZnM+DQo8L3N2Zz4NCg=="
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						editor.execCommand("justifyright");
					}
				},
				tag: "justifyRight"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHJlY3QgeD0iMiIgeT0iNSIgd2lkdGg9IjIwIiBoZWlnaHQ9IjIiIHJ4PSIxIiBmaWxsPSIjNjc3NDhFIi8+CjxyZWN0IHg9IjIiIHk9IjkiIHdpZHRoPSIxMiIgaGVpZ2h0PSIyIiByeD0iMSIgZmlsbD0iIzY3NzQ4RSIvPgo8cmVjdCB4PSIyIiB5PSIxMyIgd2lkdGg9IjEyIiBoZWlnaHQ9IjIiIHJ4PSIxIiBmaWxsPSIjNjc3NDhFIi8+CjxyZWN0IHg9IjIiIHk9IjE3IiB3aWR0aD0iMjAiIGhlaWdodD0iMiIgcng9IjEiIGZpbGw9IiM2Nzc0OEUiLz4KPHBhdGggZD0iTTIxIDEwTDE4IDEyTDIxIDE0IiBzdHJva2U9IiM2Nzc0OEUiIHN0cm9rZS13aWR0aD0iMiIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+Cjwvc3ZnPgo="
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						editor.execCommand("outdent");
					}
				},
				tag: "outdentList",
				markerValue: "outdent"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxyZWN0IHdpZHRoPSIyMCIgaGVpZ2h0PSIyIiByeD0iMSIgdHJhbnNmb3JtPSJtYXRyaXgoLTEgMCAwIDEgMjIgNSkiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHdpZHRoPSIxMiIgaGVpZ2h0PSIyIiByeD0iMSIgdHJhbnNmb3JtPSJtYXRyaXgoLTEgMCAwIDEgMjIgOSkiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHdpZHRoPSIxMiIgaGVpZ2h0PSIyIiByeD0iMSIgdHJhbnNmb3JtPSJtYXRyaXgoLTEgMCAwIDEgMjIgMTMpIiBmaWxsPSIjNjc3NDhFIi8+DQo8cmVjdCB3aWR0aD0iMjAiIGhlaWdodD0iMiIgcng9IjEiIHRyYW5zZm9ybT0ibWF0cml4KC0xIDAgMCAxIDIyIDE3KSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHBhdGggZD0iTTMgMTBMNiAxMkwzIDE0IiBzdHJva2U9IiM2Nzc0OEUiIHN0cm9rZS13aWR0aD0iMiIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+DQo8L3N2Zz4NCg=="
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						editor.execCommand("indent");
					}
				},
				tag: "indentList",
				markerValue: "indent"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNMiA2QzIgMy43OTA4NiAzLjc5MDg2IDIgNiAySDE4QzIwLjIwOTEgMiAyMiAzLjc5MDg2IDIyIDZWMThDMjIgMjAuMjA5MSAyMC4yMDkxIDIyIDE4IDIySDZDMy43OTA4NiAyMiAyIDIwLjIwOTEgMiAxOFY2Wk00IDZDNCA0Ljg5NTQzIDQuODk1NDMgNCA2IDRIMThDMTkuMTA0NiA0IDIwIDQuODk1NDMgMjAgNlYxOEMyMCAxOS4xMDQ2IDE5LjEwNDYgMjAgMTggMjBINkM0Ljg5NTQzIDIwIDQgMTkuMTA0NiA0IDE4VjZaTTkgMTFMMTAgMTJMMTMgOEwxOCAxNUg2TDkgMTFaIiBmaWxsPSIjNjc3NDhFIi8+DQo8L3N2Zz4NCg=="
				},
				fileUpload: true,
				tag: "image"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxwYXRoIGQ9Ik0xMy41NDM4IDEwLjQ1NkMxMi43MjQ3IDkuNjM3MiAxMS42MTQgOS4xNzcyNSAxMC40NTU4IDkuMTc3MjVDOS4yOTc2NiA5LjE3NzI1IDguMTg2OTIgOS42MzcyIDcuMzY3ODEgMTAuNDU2TDQuMjc4ODEgMTMuNTQ0QzMuNDU5NjkgMTQuMzYzMSAyLjk5OTUxIDE1LjQ3NCAyLjk5OTUxIDE2LjYzMjVDMi45OTk1MSAxNy43OTA5IDMuNDU5NjkgMTguOTAxOCA0LjI3ODgxIDE5LjcyMUM1LjA5NzkzIDIwLjU0MDEgNi4yMDg5IDIxLjAwMDMgNy4zNjczMSAyMS4wMDAzQzguNTI1NzIgMjEuMDAwMyA5LjYzNjY5IDIwLjU0MDEgMTAuNDU1OCAxOS43MjFMMTEuOTk5OCAxOC4xNzciIHN0cm9rZT0iIzY3NzQ4RSIgc3Ryb2tlLXdpZHRoPSIyIiBzdHJva2UtbGluZWNhcD0icm91bmQiIHN0cm9rZS1saW5lam9pbj0icm91bmQiLz4NCjxwYXRoIGQ9Ik0xMC40NTYxIDEzLjU0MzhDMTEuMjc1MiAxNC4zNjI2IDEyLjM4NTkgMTQuODIyNSAxMy41NDQxIDE0LjgyMjVDMTQuNzAyMiAxNC44MjI1IDE1LjgxMjkgMTQuMzYyNiAxNi42MzIxIDEzLjU0MzhMMTkuNzIxMSAxMC40NTU4QzIwLjU0MDIgOS42MzY2OSAyMS4wMDA0IDguNTI1NzIgMjEuMDAwNCA3LjM2NzMxQzIxLjAwMDQgNi4yMDg5IDIwLjU0MDIgNS4wOTc5MyAxOS43MjExIDQuMjc4ODFDMTguOTAxOSAzLjQ1OTY5IDE3Ljc5MSAyLjk5OTUxIDE2LjYzMjYgMi45OTk1MUMxNS40NzQxIDIuOTk5NTEgMTQuMzYzMiAzLjQ1OTY5IDEzLjU0NDEgNC4yNzg4MUwxMi4wMDAxIDUuODIyODEiIHN0cm9rZT0iIzY3NzQ4RSIgc3Ryb2tlLXdpZHRoPSIyIiBzdHJva2UtbGluZWNhcD0icm91bmQiIHN0cm9rZS1saW5lam9pbj0icm91bmQiLz4NCjwvc3ZnPg0K"
				},
				onClick: function() {
					var container = this.ownerCt;
					if (container) {
						container.showLinkInputBox();
					}
				},
				tag: "link"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHJlY3QgeD0iNCIgeT0iNCIgd2lkdGg9IjE2IiBoZWlnaHQ9IjIiIHJ4PSIxIiBmaWxsPSIjNjc3NDhFIi8+CjxwYXRoIGQ9Ik05LjU1NjM2IDIwQzguNzczOCAyMCA4LjA5NTc2IDE5Ljg3MTMgNy41MjIyNCAxOS42MTM5QzYuOTU0MDggMTkuMzUxNCA2LjUzNiAxOC45NjI4IDYuMjY4IDE4LjQ0NzlDNiAxNy45MzMxIDUuOTMzIDE3LjI5NDYgNi4wNjcgMTYuNTMyNUM2LjE4NDkyIDE1Ljg4NjQgNi40MDczNiAxNS4zNDY0IDYuNzM0MzIgMTQuOTEyM0M3LjA2NjY0IDE0LjQ3MzIgNy40NzEzMiAxNC4xMTk5IDcuOTQ4MzYgMTMuODUyNEM4LjQyNTQgMTMuNTg0OSA4Ljk1MzM2IDEzLjM4MDQgOS41MzIyNCAxMy4yMzkxQzEwLjExNjUgMTMuMDk3OCAxMC43MTk1IDEzLjAwMTkgMTEuMzQxMiAxMi45NTE0QzEyLjA1OTUgMTIuODgwOCAxMi42NDM3IDEyLjgxMjYgMTMuMDk0IDEyLjc0N0MxMy41NDk2IDEyLjY4MTQgMTMuODg5OSAxMi41ODggMTQuMTE1IDEyLjQ2NjlDMTQuMzQwMiAxMi4zNDA3IDE0LjQ3NjggMTIuMTUzOSAxNC41MjUxIDExLjkwNjZWMTEuODYxMkMxNC42MDU1IDExLjM4NjggMTQuNTExNyAxMS4wMTgzIDE0LjI0MzcgMTAuNzU1OEMxMy45ODEgMTAuNDg4MyAxMy41NjAzIDEwLjM1NDYgMTIuOTgxNCAxMC4zNTQ2QzEyLjM3MDQgMTAuMzU0NiAxMS44NTA0IDEwLjQ4MDggMTEuNDIxNiAxMC43MzMxQzEwLjk5ODIgMTAuOTg1NSAxMC42OTU0IDExLjMwNiAxMC41MTMxIDExLjY5NDZMNy4zOTM2IDExLjQ1MjRDNy42NzIzMiAxMC43NDU3IDguMDkzMDggMTAuMTM1IDguNjU1ODggOS42MjAxOUM5LjIyNDA0IDkuMTAwMzEgOS45MDc0NCA4LjcwMTU4IDEwLjcwNjEgOC40MjM5N0MxMS41MDQ3IDguMTQxMzIgMTIuMzk5OCA4IDEzLjM5MTQgOEMxNC4wNzc1IDggMTQuNzE4IDguMDc1NzEgMTUuMzEzIDguMjI3MTNDMTUuOTEzMyA4LjM3ODU1IDE2LjQzMDYgOC42MTMyNSAxNi44NjQ3IDguOTMxMjNDMTcuMzA0MiA5LjI0OTIxIDE3LjYyMDUgOS42NTgwNCAxNy44MTM0IDEwLjE1NzdDMTguMDExOCAxMC42NTI0IDE4LjA1MiAxMS4yNDU0IDE3LjkzNCAxMS45MzY5TDE2LjU0MzEgMTkuNzgwNEgxMy4yOTVMMTMuNTg0NCAxOC4xNjc4SDEzLjQ4NzlDMTMuMjI1MyAxOC41MzEyIDEyLjkwMzcgMTguODUxNyAxMi41MjMxIDE5LjEyOTNDMTIuMTQyNiAxOS40MDE5IDExLjcwNTcgMTkuNjE2NCAxMS4yMTI2IDE5Ljc3MjlDMTAuNzE5NSAxOS45MjQzIDEwLjE2NzQgMjAgOS41NTYzNiAyMFpNMTAuOTMxMiAxNy43NzQxQzExLjQyOTcgMTcuNzc0MSAxMS44ODggMTcuNjgwOCAxMi4zMDYgMTcuNDk0QzEyLjcyOTUgMTcuMzAyMiAxMy4wNzc5IDE3LjA0NDggMTMuMzUxMiAxNi43MjE4QzEzLjYzIDE2LjM5ODcgMTMuODA2OCAxNi4wMzI4IDEzLjg4MTkgMTUuNjI0TDE0LjA5MDkgMTQuMzg5OUMxMy45ODM3IDE0LjQ1NTUgMTMuODI4MyAxNC41MTM2IDEzLjYyNDYgMTQuNTY0QzEzLjQyNjMgMTQuNjE0NSAxMy4yMDkyIDE0LjY2MjUgMTIuOTczNCAxNC43MDc5QzEyLjc0MjkgMTQuNzQ4MyAxMi41MDk3IDE0Ljc4NjEgMTIuMjczOSAxNC44MjE1QzEyLjAzOCAxNC44NTE3IDExLjgyNjMgMTQuODgyIDExLjYzODcgMTQuOTEyM0MxMS4yMjYgMTQuOTY3OCAxMC44NTYyIDE1LjA1NjIgMTAuNTI5MiAxNS4xNzczQzEwLjIwMjIgMTUuMjk4NCA5LjkzNjkyIDE1LjQ2MjUgOS43MzMyNCAxNS42Njk0QzkuNTI5NTYgMTUuODcxMyA5LjQwMzYgMTYuMTIzNyA5LjM1NTM2IDE2LjQyNjVDOS4yODAzMiAxNi44NjU2IDkuMzkwMiAxNy4yMDEzIDkuNjg1IDE3LjQzMzRDOS45ODUxNiAxNy42NjA2IDEwLjQwMDYgMTcuNzc0MSAxMC45MzEyIDE3Ljc3NDFaIiBmaWxsPSIjRjk3NjNEIi8+Cjwvc3ZnPgo="
				},
				onClick: function() {
					var container = this.ownerCt;
					if (container) {
						container._changeEditorMode(container.htmlModeValue);
					}
				},
				tag: "htmlMode",
				markerValue: "htmlMode",
				disabledClass: ""
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHJlY3QgeD0iNCIgeT0iNCIgd2lkdGg9IjE2IiBoZWlnaHQ9IjIiIHJ4PSIxIiBmaWxsPSIjNjc3NDhFIi8+CjxwYXRoIGQ9Ik05LjU1NjM2IDIwQzguNzczOCAyMCA4LjA5NTc2IDE5Ljg3MTMgNy41MjIyNCAxOS42MTM5QzYuOTU0MDggMTkuMzUxNCA2LjUzNiAxOC45NjI4IDYuMjY4IDE4LjQ0NzlDNiAxNy45MzMxIDUuOTMzIDE3LjI5NDYgNi4wNjcgMTYuNTMyNUM2LjE4NDkyIDE1Ljg4NjQgNi40MDczNiAxNS4zNDY0IDYuNzM0MzIgMTQuOTEyM0M3LjA2NjY0IDE0LjQ3MzIgNy40NzEzMiAxNC4xMTk5IDcuOTQ4MzYgMTMuODUyNEM4LjQyNTQgMTMuNTg0OSA4Ljk1MzM2IDEzLjM4MDQgOS41MzIyNCAxMy4yMzkxQzEwLjExNjUgMTMuMDk3OCAxMC43MTk1IDEzLjAwMTkgMTEuMzQxMiAxMi45NTE0QzEyLjA1OTUgMTIuODgwOCAxMi42NDM3IDEyLjgxMjYgMTMuMDk0IDEyLjc0N0MxMy41NDk2IDEyLjY4MTQgMTMuODg5OSAxMi41ODggMTQuMTE1IDEyLjQ2NjlDMTQuMzQwMiAxMi4zNDA3IDE0LjQ3NjggMTIuMTUzOSAxNC41MjUxIDExLjkwNjZWMTEuODYxMkMxNC42MDU1IDExLjM4NjggMTQuNTExNyAxMS4wMTgzIDE0LjI0MzcgMTAuNzU1OEMxMy45ODEgMTAuNDg4MyAxMy41NjAzIDEwLjM1NDYgMTIuOTgxNCAxMC4zNTQ2QzEyLjM3MDQgMTAuMzU0NiAxMS44NTA0IDEwLjQ4MDggMTEuNDIxNiAxMC43MzMxQzEwLjk5ODIgMTAuOTg1NSAxMC42OTU0IDExLjMwNiAxMC41MTMxIDExLjY5NDZMNy4zOTM2IDExLjQ1MjRDNy42NzIzMiAxMC43NDU3IDguMDkzMDggMTAuMTM1IDguNjU1ODggOS42MjAxOUM5LjIyNDA0IDkuMTAwMzEgOS45MDc0NCA4LjcwMTU4IDEwLjcwNjEgOC40MjM5N0MxMS41MDQ3IDguMTQxMzIgMTIuMzk5OCA4IDEzLjM5MTQgOEMxNC4wNzc1IDggMTQuNzE4IDguMDc1NzEgMTUuMzEzIDguMjI3MTNDMTUuOTEzMyA4LjM3ODU1IDE2LjQzMDYgOC42MTMyNSAxNi44NjQ3IDguOTMxMjNDMTcuMzA0MiA5LjI0OTIxIDE3LjYyMDUgOS42NTgwNCAxNy44MTM0IDEwLjE1NzdDMTguMDExOCAxMC42NTI0IDE4LjA1MiAxMS4yNDU0IDE3LjkzNCAxMS45MzY5TDE2LjU0MzEgMTkuNzgwNEgxMy4yOTVMMTMuNTg0NCAxOC4xNjc4SDEzLjQ4NzlDMTMuMjI1MyAxOC41MzEyIDEyLjkwMzcgMTguODUxNyAxMi41MjMxIDE5LjEyOTNDMTIuMTQyNiAxOS40MDE5IDExLjcwNTcgMTkuNjE2NCAxMS4yMTI2IDE5Ljc3MjlDMTAuNzE5NSAxOS45MjQzIDEwLjE2NzQgMjAgOS41NTYzNiAyMFpNMTAuOTMxMiAxNy43NzQxQzExLjQyOTcgMTcuNzc0MSAxMS44ODggMTcuNjgwOCAxMi4zMDYgMTcuNDk0QzEyLjcyOTUgMTcuMzAyMiAxMy4wNzc5IDE3LjA0NDggMTMuMzUxMiAxNi43MjE4QzEzLjYzIDE2LjM5ODcgMTMuODA2OCAxNi4wMzI4IDEzLjg4MTkgMTUuNjI0TDE0LjA5MDkgMTQuMzg5OUMxMy45ODM3IDE0LjQ1NTUgMTMuODI4MyAxNC41MTM2IDEzLjYyNDYgMTQuNTY0QzEzLjQyNjMgMTQuNjE0NSAxMy4yMDkyIDE0LjY2MjUgMTIuOTczNCAxNC43MDc5QzEyLjc0MjkgMTQuNzQ4MyAxMi41MDk3IDE0Ljc4NjEgMTIuMjczOSAxNC44MjE1QzEyLjAzOCAxNC44NTE3IDExLjgyNjMgMTQuODgyIDExLjYzODcgMTQuOTEyM0MxMS4yMjYgMTQuOTY3OCAxMC44NTYyIDE1LjA1NjIgMTAuNTI5MiAxNS4xNzczQzEwLjIwMjIgMTUuMjk4NCA5LjkzNjkyIDE1LjQ2MjUgOS43MzMyNCAxNS42Njk0QzkuNTI5NTYgMTUuODcxMyA5LjQwMzYgMTYuMTIzNyA5LjM1NTM2IDE2LjQyNjVDOS4yODAzMiAxNi44NjU2IDkuMzkwMiAxNy4yMDEzIDkuNjg1IDE3LjQzMzRDOS45ODUxNiAxNy42NjA2IDEwLjQwMDYgMTcuNzc0MSAxMC45MzEyIDE3Ljc3NDFaIiBmaWxsPSIjRjk3NjNEIi8+CjxtYXNrIGlkPSJwYXRoLTMtaW5zaWRlLTFfNzM1Ml8xNTkwNSIgZmlsbD0id2hpdGUiPgo8cGF0aCBkPSJNMy43OTI4OSAzLjcwNzExQzQuMTgzNDIgMy4zMTY1OCA0LjgxNjU4IDMuMzE2NTggNS4yMDcxMSAzLjcwNzExTDIwLjc2MzUgMTkuMjYzNUMyMS4xNTQgMTkuNjU0IDIxLjE1NCAyMC4yODcxIDIwLjc2MzUgMjAuNjc3N0MyMC4zNzI5IDIxLjA2ODIgMTkuNzM5OCAyMS4wNjgyIDE5LjM0OTIgMjAuNjc3N0wzLjc5Mjg5IDUuMTIxMzJDMy40MDIzNyA0LjczMDggMy40MDIzNyA0LjA5NzYzIDMuNzkyODkgMy43MDcxMVoiLz4KPC9tYXNrPgo8cGF0aCBkPSJNMy43OTI4OSAzLjcwNzExQzQuMTgzNDIgMy4zMTY1OCA0LjgxNjU4IDMuMzE2NTggNS4yMDcxMSAzLjcwNzExTDIwLjc2MzUgMTkuMjYzNUMyMS4xNTQgMTkuNjU0IDIxLjE1NCAyMC4yODcxIDIwLjc2MzUgMjAuNjc3N0MyMC4zNzI5IDIxLjA2ODIgMTkuNzM5OCAyMS4wNjgyIDE5LjM0OTIgMjAuNjc3N0wzLjc5Mjg5IDUuMTIxMzJDMy40MDIzNyA0LjczMDggMy40MDIzNyA0LjA5NzYzIDMuNzkyODkgMy43MDcxMVoiIGZpbGw9IiM2Nzc0OEUiLz4KPHBhdGggZD0iTTMuNzkyODkgMy43MDcxMUM0LjU3Mzk0IDIuOTI2MDYgNS44NDAyNyAyLjkyNjA2IDYuNjIxMzIgMy43MDcxMUwyMC43NjM1IDE3Ljg0OTJDMjEuNTQ0NSAxOC42MzAzIDIxLjU0NDUgMTkuODk2NiAyMC43NjM1IDIwLjY3NzdDMjAuNzYzNSAyMC42Nzc3IDIwLjQ0NjkgMjAuMzYxMSAyMC4wNTYzIDE5Ljk3MDZMNC41IDQuNDE0MjFDNC4xMDk0OCA0LjAyMzY5IDMuNzkyODkgMy43MDcxMSAzLjc5Mjg5IDMuNzA3MTFaTTIwLjA1NjMgMjEuMzg0OEwzLjA4NTc5IDQuNDE0MjFMMjAuMDU2MyAyMS4zODQ4Wk0zLjA4NTc5IDQuNDE0MjFMNC41IDNMMy4wODU3OSA0LjQxNDIxWk0yMS40NzA2IDE5Ljk3MDZMMjAuMDU2MyAyMS4zODQ4TDIxLjQ3MDYgMTkuOTcwNloiIGZpbGw9IiNFNUU1RTUiIG1hc2s9InVybCgjcGF0aC0zLWluc2lkZS0xXzczNTJfMTU5MDUpIi8+Cjwvc3ZnPgo="
				},
				onClick: function() {
					var container = this.ownerCt;
					if (container) {
						if (!container.showChangeModeConfirmation) {
							container._changeEditorMode(container.plainModeValue);
						} else {
							BPMSoft.utils.showConfirmation(resources.localizableStrings.ConfirmPlainTextMode,
								function(returnCode) {
									if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
										container._changeEditorMode(container.plainModeValue);
									}
								},
								["yes", "no"], this
							);
						}
					}
				},
				tag: "plainMode",
				markerValue: "plainMode",
				disabledClass: ""
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPHN2ZyB2aWV3Qm94PSIwIDAgMjQgMjQiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxtYXNrIGlkPSJhIiBmaWxsPSJ3aGl0ZSI+CjxwYXRoIGQ9Im0yIDZjMC0yLjIwOTEgMS43OTA5LTQgNC00aDEyYzIuMjA5MSAwIDQgMS43OTA5IDQgNHYxMmMwIDIuMjA5MS0xLjc5MDkgNC00IDRoLTEyYy0yLjIwOTEgMC00LTEuNzkwOS00LTR2LTEyeiIvPgo8L21hc2s+CjxwYXRoIGQ9Im0wIDZjMC0zLjMxMzcgMi42ODYzLTYgNi02aDEyYzMuMzEzNyAwIDYgMi42ODYzIDYgNmgtNGMwLTEuMTA0Ni0wLjg5NTQtMi0yLTJoLTEyYy0xLjEwNDYgMC0yIDAuODk1NDMtMiAyaC00em0yNCAxMmMwIDMuMzEzNy0yLjY4NjMgNi02IDZoLTEyYy0zLjMxMzcgMC02LTIuNjg2My02LTZoNGMwIDEuMTA0NiAwLjg5NTQzIDIgMiAyaDEyYzEuMTA0NiAwIDItMC44OTU0IDItMmg0em0tMTggNmMtMy4zMTM3IDAtNi0yLjY4NjMtNi02di0xMmMwLTMuMzEzNyAyLjY4NjMtNiA2LTZ2NGMtMS4xMDQ2IDAtMiAwLjg5NTQzLTIgMnYxMmMwIDEuMTA0NiAwLjg5NTQzIDIgMiAydjR6bTEyLTI0YzMuMzEzNyAwIDYgMi42ODYzIDYgNnYxMmMwIDMuMzEzNy0yLjY4NjMgNi02IDZ2LTRjMS4xMDQ2IDAgMi0wLjg5NTQgMi0ydi0xMmMwLTEuMTA0Ni0wLjg5NTQtMi0yLTJ2LTR6IiBmaWxsPSIjNjc3NDhFIiBtYXNrPSJ1cmwoI2EpIi8+CjxyZWN0IHg9IjQiIHk9IjQiIHdpZHRoPSIxNiIgaGVpZ2h0PSIzIiBmaWxsPSIjNjc3NDhFIi8+CjxwYXRoIGQ9Im05LjI5MyA5LjYtMy43MDcgMy43MDcgMy43MDcgMy43MDcgMS40MTQtMS40MTQtMi4yOTMtMi4yOTMgMi4yOTMtMi4yOTMtMS40MTQtMS40MTR6bTUuNDE0IDAtMS40MTQgMS40MTQgMi4yOTMgMi4yOTMtMi4yOTMgMi4yOTMgMS40MTQgMS40MTQgMy43MDctMy43MDctMy43MDctMy43MDd6IiBmaWxsPSIjNjc3NDhFIi8+Cjwvc3ZnPgo="
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						container._changeEditorMode(container.htmlEditModeValue);
					}
				},
				tag: "htmlEditMode",
				markerValue: "htmlEditMode",
				disabledClass: ""
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxwYXRoIGQ9Ik0xOSAxMS4wMDEzSDcuMTRMMTAuNzcgNi42NDEyNUMxMC45Mzk3IDYuNDM3MDQgMTEuMDIxNCA2LjE3Mzc1IDEwLjk5NyA1LjkwOTMzQzEwLjk3MjYgNS42NDQ5IDEwLjg0NDIgNS40MDA5OSAxMC42NCA1LjIzMTI1QzEwLjQzNTggNS4wNjE1MSAxMC4xNzI1IDQuOTc5ODUgOS45MDgwOCA1LjAwNDIzQzkuNjQzNjUgNS4wMjg2MSA5LjM5OTc0IDUuMTU3MDQgOS4yMyA1LjM2MTI1TDQuMjMgMTEuMzYxM0M0LjE5NjM2IDExLjQwOSA0LjE2NjI4IDExLjQ1OTEgNC4xNCAxMS41MTEzQzQuMTQgMTEuNTYxMyA0LjE0IDExLjU5MTMgNC4wNyAxMS42NDEzQzQuMDI0NjcgMTEuNzU1OSA0LjAwMDk0IDExLjg3OCA0IDEyLjAwMTNDNC4wMDA5NCAxMi4xMjQ1IDQuMDI0NjcgMTIuMjQ2NiA0LjA3IDEyLjM2MTNDNC4wNyAxMi40MTEzIDQuMDcgMTIuNDQxMyA0LjE0IDEyLjQ5MTNDNC4xNjYyOCAxMi41NDM0IDQuMTk2MzYgMTIuNTkzNSA0LjIzIDEyLjY0MTNMOS4yMyAxOC42NDEzQzkuMzI0MDIgMTguNzU0MSA5LjQ0MTc2IDE4Ljg0NDkgOS41NzQ4NSAxOC45MDcxQzkuNzA3OTMgMTguOTY5NCA5Ljg1MzA5IDE5LjAwMTUgMTAgMTkuMDAxM0MxMC4yMzM3IDE5LjAwMTcgMTAuNDYwMSAxOC45MjAzIDEwLjY0IDE4Ljc3MTNDMTAuNzQxMyAxOC42ODczIDEwLjgyNSAxOC41ODQyIDEwLjg4NjMgMTguNDY3OUMxMC45NDc3IDE4LjM1MTUgMTAuOTg1NSAxOC4yMjQyIDEwLjk5NzUgMTguMDkzMkMxMS4wMDk2IDE3Ljk2MjIgMTAuOTk1NyAxNy44MzAyIDEwLjk1NjcgMTcuNzA0NkMxMC45MTc2IDE3LjU3OSAxMC44NTQyIDE3LjQ2MjMgMTAuNzcgMTcuMzYxM0w3LjE0IDEzLjAwMTNIMTlDMTkuMjY1MiAxMy4wMDEzIDE5LjUxOTYgMTIuODk1OSAxOS43MDcxIDEyLjcwODRDMTkuODk0NiAxMi41MjA4IDIwIDEyLjI2NjUgMjAgMTIuMDAxM0MyMCAxMS43MzYgMTkuODk0NiAxMS40ODE3IDE5LjcwNzEgMTEuMjk0MUMxOS41MTk2IDExLjEwNjYgMTkuMjY1MiAxMS4wMDEzIDE5IDExLjAwMTNaIiBmaWxsPSIjNjc3NDhFIi8+DQo8L3N2Zz4NCg=="
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						editor.execCommand("undo");
					}
				},
				tag: "undo",
				markerValue: "undo"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxwYXRoIGQ9Ik01IDExLjAwMTNIMTYuODZMMTMuMjMgNi42NDEyNUMxMy4wNjAzIDYuNDM3MDQgMTIuOTc4NiA2LjE3Mzc1IDEzLjAwMyA1LjkwOTMzQzEzLjAyNzQgNS42NDQ5IDEzLjE1NTggNS40MDA5OSAxMy4zNiA1LjIzMTI1QzEzLjU2NDIgNS4wNjE1MSAxMy44Mjc1IDQuOTc5ODUgMTQuMDkxOSA1LjAwNDIzQzE0LjM1NjMgNS4wMjg2MSAxNC42MDAzIDUuMTU3MDQgMTQuNzcgNS4zNjEyNUwxOS43NyAxMS4zNjEzQzE5LjgwMzYgMTEuNDA5IDE5LjgzMzcgMTEuNDU5MSAxOS44NiAxMS41MTEzQzE5Ljg2IDExLjU2MTMgMTkuODYgMTEuNTkxMyAxOS45MyAxMS42NDEzQzE5Ljk3NTMgMTEuNzU1OSAxOS45OTkxIDExLjg3OCAyMCAxMi4wMDEzQzE5Ljk5OTEgMTIuMTI0NSAxOS45NzUzIDEyLjI0NjYgMTkuOTMgMTIuMzYxM0MxOS45MyAxMi40MTEzIDE5LjkzIDEyLjQ0MTMgMTkuODYgMTIuNDkxM0MxOS44MzM3IDEyLjU0MzQgMTkuODAzNiAxMi41OTM1IDE5Ljc3IDEyLjY0MTNMMTQuNzcgMTguNjQxM0MxNC42NzYgMTguNzU0MSAxNC41NTgyIDE4Ljg0NDkgMTQuNDI1MiAxOC45MDcxQzE0LjI5MjEgMTguOTY5NCAxNC4xNDY5IDE5LjAwMTUgMTQgMTkuMDAxM0MxMy43NjYzIDE5LjAwMTcgMTMuNTM5OSAxOC45MjAzIDEzLjM2IDE4Ljc3MTNDMTMuMjU4NyAxOC42ODczIDEzLjE3NSAxOC41ODQyIDEzLjExMzcgMTguNDY3OUMxMy4wNTIzIDE4LjM1MTUgMTMuMDE0NSAxOC4yMjQyIDEzLjAwMjUgMTguMDkzMkMxMi45OTA0IDE3Ljk2MjIgMTMuMDA0MyAxNy44MzAyIDEzLjA0MzMgMTcuNzA0NkMxMy4wODI0IDE3LjU3OSAxMy4xNDU4IDE3LjQ2MjMgMTMuMjMgMTcuMzYxM0wxNi44NiAxMy4wMDEzSDVDNC43MzQ3OCAxMy4wMDEzIDQuNDgwNDMgMTIuODk1OSA0LjI5Mjg5IDEyLjcwODRDNC4xMDUzNiAxMi41MjA4IDQgMTIuMjY2NSA0IDEyLjAwMTNDNCAxMS43MzYgNC4xMDUzNiAxMS40ODE3IDQuMjkyODkgMTEuMjk0MUM0LjQ4MDQzIDExLjEwNjYgNC43MzQ3OCAxMS4wMDEzIDUgMTEuMDAxM1oiIGZpbGw9IiM2Nzc0OEUiLz4NCjwvc3ZnPg0K"
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						editor.execCommand("redo");
					}
				},
				tag: "redo",
				markerValue: "redo"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxwYXRoIGQ9Ik04IDRDOC41NTIyOCA0IDkgMy41NTIyOCA5IDNDOSAyLjQ0NzcyIDguNTUyMjggMiA4IDJWNFpNMiA4QzIgOC41NTIyOCAyLjQ0NzcyIDkgMyA5QzMuNTUyMjggOSA0IDguNTUyMjggNCA4SDJaTTQgNEg4VjJINFY0Wk0yIDRWOEg0VjRIMlpNNCAyQzIuODk1NDMgMiAyIDIuODk1NDMgMiA0SDRWMloiIGZpbGw9IiM2Nzc0OEUiLz4NCjxwYXRoIGQ9Ik04IDIwQzguNTUyMjggMjAgOSAyMC40NDc3IDkgMjFDOSAyMS41NTIzIDguNTUyMjggMjIgOCAyMlYyMFpNMiAxNkMyIDE1LjQ0NzcgMi40NDc3MiAxNSAzIDE1QzMuNTUyMjggMTUgNCAxNS40NDc3IDQgMTZIMlpNNCAyMEg4VjIySDRWMjBaTTIgMjBWMTZINFYyMEgyWk00IDIyQzIuODk1NDMgMjIgMiAyMS4xMDQ2IDIgMjBINFYyMloiIGZpbGw9IiM2Nzc0OEUiLz4NCjxwYXRoIGQ9Ik0xNiA0QzE1LjQ0NzcgNCAxNSAzLjU1MjI5IDE1IDNDMTUgMi40NDc3MiAxNS40NDc3IDIgMTYgMkwxNiA0Wk0yMiA4QzIyIDguNTUyMjggMjEuNTUyMyA5IDIxIDlDMjAuNDQ3NyA5IDIwIDguNTUyMjggMjAgOEwyMiA4Wk0yMCA0TDE2IDRMMTYgMkwyMCAyTDIwIDRaTTIyIDRMMjIgOEwyMCA4TDIwIDRMMjIgNFpNMjAgMkMyMS4xMDQ2IDIgMjIgMi44OTU0MyAyMiA0TDIwIDRMMjAgMloiIGZpbGw9IiM2Nzc0OEUiLz4NCjxwYXRoIGQ9Ik0xNiAyMEMxNS40NDc3IDIwIDE1IDIwLjQ0NzcgMTUgMjFDMTUgMjEuNTUyMyAxNS40NDc3IDIyIDE2IDIyTDE2IDIwWk0yMiAxNkMyMiAxNS40NDc3IDIxLjU1MjMgMTUgMjEgMTVDMjAuNDQ3NyAxNSAyMCAxNS40NDc3IDIwIDE2TDIyIDE2Wk0yMCAyMEwxNiAyMEwxNiAyMkwyMCAyMkwyMCAyMFpNMjIgMjBMMjIgMTZMMjAgMTZMMjAgMjBMMjIgMjBaTTIwIDIyQzIxLjEwNDYgMjIgMjIgMjEuMTA0NiAyMiAyMEwyMCAyMEwyMCAyMloiIGZpbGw9IiM2Nzc0OEUiLz4NCjwvc3ZnPg0K"
				},
				onClick: function() {
					var container = this.ownerCt;
					var editor = container.editor;
					if (editor) {
						container.toggleFullScreanMode();
					}
				},
				tag: "maximized",
				markerValue: "maximize"
			},
			{
				className: "BPMSoft.Button",
				iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.TOP,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxtYXNrIGlkPSJwYXRoLTEtaW5zaWRlLTFfNzcxXzEwOTE5NCIgZmlsbD0id2hpdGUiPg0KPHBhdGggZD0iTTIgNkMyIDMuNzkwODYgMy43OTA4NiAyIDYgMkgxOEMyMC4yMDkxIDIgMjIgMy43OTA4NiAyMiA2VjE4QzIyIDIwLjIwOTEgMjAuMjA5MSAyMiAxOCAyMkg2QzMuNzkwODYgMjIgMiAyMC4yMDkxIDIgMThWNloiLz4NCjwvbWFzaz4NCjxwYXRoIGQ9Ik0wIDZDMCAyLjY4NjI5IDIuNjg2MjkgMCA2IDBIMThDMjEuMzEzNyAwIDI0IDIuNjg2MjkgMjQgNkgyMEMyMCA0Ljg5NTQzIDE5LjEwNDYgNCAxOCA0SDZDNC44OTU0MyA0IDQgNC44OTU0MyA0IDZIMFpNMjQgMThDMjQgMjEuMzEzNyAyMS4zMTM3IDI0IDE4IDI0SDZDMi42ODYyOSAyNCAwIDIxLjMxMzcgMCAxOEg0QzQgMTkuMTA0NiA0Ljg5NTQzIDIwIDYgMjBIMThDMTkuMTA0NiAyMCAyMCAxOS4xMDQ2IDIwIDE4SDI0Wk02IDI0QzIuNjg2MjkgMjQgMCAyMS4zMTM3IDAgMThWNkMwIDIuNjg2MjkgMi42ODYyOSAwIDYgMFY0QzQuODk1NDMgNCA0IDQuODk1NDMgNCA2VjE4QzQgMTkuMTA0NiA0Ljg5NTQzIDIwIDYgMjBWMjRaTTE4IDBDMjEuMzEzNyAwIDI0IDIuNjg2MjkgMjQgNlYxOEMyNCAyMS4zMTM3IDIxLjMxMzcgMjQgMTggMjRWMjBDMTkuMTA0NiAyMCAyMCAxOS4xMDQ2IDIwIDE4VjZDMjAgNC44OTU0MyAxOS4xMDQ2IDQgMTggNFYwWiIgZmlsbD0iIzY3NzQ4RSIgbWFzaz0idXJsKCNwYXRoLTEtaW5zaWRlLTFfNzcxXzEwOTE5NCkiLz4NCjxyZWN0IHg9IjQiIHk9IjEwIiB3aWR0aD0iMTYiIGhlaWdodD0iMiIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iOCIgeT0iMjIiIHdpZHRoPSIxNiIgaGVpZ2h0PSIyIiB0cmFuc2Zvcm09InJvdGF0ZSgtOTAgOCAyMikiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjE0IiB5PSIyMiIgd2lkdGg9IjE2IiBoZWlnaHQ9IjIiIHRyYW5zZm9ybT0icm90YXRlKC05MCAxNCAyMikiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjQiIHk9IjQiIHdpZHRoPSIxNiIgaGVpZ2h0PSIzIiBmaWxsPSIjNjc3NDhFIi8+DQo8cmVjdCB4PSI0IiB5PSIxNSIgd2lkdGg9IjE2IiBoZWlnaHQ9IjIiIGZpbGw9IiM2Nzc0OEUiLz4NCjwvc3ZnPg0K"
				},
				visible: BPMSoft.Features.getIsEnabled("CKeditorTableEdit"),
				menu: {
					className: "BPMSoft.Menu",
					items: [{
						imageConfig: {
							source: BPMSoft.ImageSources.URL,
							url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxtYXNrIGlkPSJwYXRoLTEtaW5zaWRlLTFfNTkyN18yOTMxMCIgZmlsbD0id2hpdGUiPg0KPHBhdGggZD0iTTIgNkMyIDMuNzkwODYgMy43OTA4NiAyIDYgMkgxOEMyMC4yMDkxIDIgMjIgMy43OTA4NiAyMiA2VjE4QzIyIDIwLjIwOTEgMjAuMjA5MSAyMiAxOCAyMkg2QzMuNzkwODYgMjIgMiAyMC4yMDkxIDIgMThWNloiLz4NCjwvbWFzaz4NCjxwYXRoIGQ9Ik0wIDZDMCAyLjY4NjI5IDIuNjg2MjkgMCA2IDBIMThDMjEuMzEzNyAwIDI0IDIuNjg2MjkgMjQgNkgyMEMyMCA0Ljg5NTQzIDE5LjEwNDYgNCAxOCA0SDZDNC44OTU0MyA0IDQgNC44OTU0MyA0IDZIMFpNMjQgMThDMjQgMjEuMzEzNyAyMS4zMTM3IDI0IDE4IDI0SDZDMi42ODYyOSAyNCAwIDIxLjMxMzcgMCAxOEg0QzQgMTkuMTA0NiA0Ljg5NTQzIDIwIDYgMjBIMThDMTkuMTA0NiAyMCAyMCAxOS4xMDQ2IDIwIDE4SDI0Wk02IDI0QzIuNjg2MjkgMjQgMCAyMS4zMTM3IDAgMThWNkMwIDIuNjg2MjkgMi42ODYyOSAwIDYgMFY0QzQuODk1NDMgNCA0IDQuODk1NDMgNCA2VjE4QzQgMTkuMTA0NiA0Ljg5NTQzIDIwIDYgMjBWMjRaTTE4IDBDMjEuMzEzNyAwIDI0IDIuNjg2MjkgMjQgNlYxOEMyNCAyMS4zMTM3IDIxLjMxMzcgMjQgMTggMjRWMjBDMTkuMTA0NiAyMCAyMCAxOS4xMDQ2IDIwIDE4VjZDMjAgNC44OTU0MyAxOS4xMDQ2IDQgMTggNFYwWiIgZmlsbD0iIzY3NzQ4RSIgbWFzaz0idXJsKCNwYXRoLTEtaW5zaWRlLTFfNTkyN18yOTMxMCkiLz4NCjxyZWN0IHg9IjQiIHk9IjEwIiB3aWR0aD0iMTYiIGhlaWdodD0iMiIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iOCIgeT0iMjIiIHdpZHRoPSIxNiIgaGVpZ2h0PSIyIiB0cmFuc2Zvcm09InJvdGF0ZSgtOTAgOCAyMikiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjE0IiB5PSIyMiIgd2lkdGg9IjE2IiBoZWlnaHQ9IjIiIHRyYW5zZm9ybT0icm90YXRlKC05MCAxNCAyMikiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjQiIHk9IjQiIHdpZHRoPSIxNiIgaGVpZ2h0PSIzIiBmaWxsPSIjNjc3NDhFIi8+DQo8cmVjdCB4PSI0IiB5PSIxNSIgd2lkdGg9IjE2IiBoZWlnaHQ9IjIiIGZpbGw9IiM2Nzc0OEUiLz4NCjwvc3ZnPg0K"
						},
						handler: function(menu, menuItem) {
							var editor = menuItem.getEditor();
							if (editor) {
								editor.execCommand("table");
							}
						}.bind(this),
						caption: resources.localizableStrings.CreateTable,
						markerValue: "create_table"
					}, {
						imageConfig: {
							source: BPMSoft.ImageSources.URL,
							url: "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIH" +
								"ZpZXdCb3g9IjAgMCAxNiAxNiIgZW5hYmxlLWJhY2tncm91bmQ9Im5ldyAwIDAgMTYgMTYiPjxnIGZpbGw9IiM" +
								"5OTkiPjxwYXRoIGQ9Im0xNSA2aC0xNHYxaDE0di0xIi8+PHBhdGggZD0ibTYgM2gtMXYxMWgxdi0xMSIvPjxw" +
								"YXRoIGQ9Im0xMSAzaC0xdjRoMXYtNCIvPjwvZz48cGF0aCBkPSJtMTYgMWgtMTZ2MTRoMTZ2LTE0bS0xNSAxM" +
								"3YtMTFoMTR2MTFoLTE0IiBmaWxsPSIjNzU3NTc1Ii8+PHBhdGggZmlsbD0iIzk5OSIgZD0ibTYgMTBoLTV2MW" +
								"g1di0xIi8+PC9zdmc+"
						},
						handler: function(menu, menuItem) {
							var editor = menuItem.getEditor();
							if (editor) {
								editor.execCommand("selectedCellMerge");
							}
						}.bind(this),
						caption: resources.localizableStrings.MergeCells,
						markerValue: "merge_cells",
						visible: false
					}, {
						imageConfig: {
							source: BPMSoft.ImageSources.URL,
							url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxtYXNrIGlkPSJwYXRoLTEtaW5zaWRlLTFfNTkyN18yOTMyMyIgZmlsbD0id2hpdGUiPg0KPHBhdGggZD0iTTIgNkMyIDMuNzkwODYgMy43OTA4NiAyIDYgMkgxOEMyMC4yMDkxIDIgMjIgMy43OTA4NiAyMiA2VjE4QzIyIDIwLjIwOTEgMjAuMjA5MSAyMiAxOCAyMkg2QzMuNzkwODYgMjIgMiAyMC4yMDkxIDIgMThWNloiLz4NCjwvbWFzaz4NCjxwYXRoIGQ9Ik0wIDZDMCAyLjY4NjI5IDIuNjg2MjkgMCA2IDBIMThDMjEuMzEzNyAwIDI0IDIuNjg2MjkgMjQgNkgyMEMyMCA0Ljg5NTQzIDE5LjEwNDYgNCAxOCA0SDZDNC44OTU0MyA0IDQgNC44OTU0MyA0IDZIMFpNMjQgMThDMjQgMjEuMzEzNyAyMS4zMTM3IDI0IDE4IDI0SDZDMi42ODYyOSAyNCAwIDIxLjMxMzcgMCAxOEg0QzQgMTkuMTA0NiA0Ljg5NTQzIDIwIDYgMjBIMThDMTkuMTA0NiAyMCAyMCAxOS4xMDQ2IDIwIDE4SDI0Wk02IDI0QzIuNjg2MjkgMjQgMCAyMS4zMTM3IDAgMThWNkMwIDIuNjg2MjkgMi42ODYyOSAwIDYgMFY0QzQuODk1NDMgNCA0IDQuODk1NDMgNCA2VjE4QzQgMTkuMTA0NiA0Ljg5NTQzIDIwIDYgMjBWMjRaTTE4IDBDMjEuMzEzNyAwIDI0IDIuNjg2MjkgMjQgNlYxOEMyNCAyMS4zMTM3IDIxLjMxMzcgMjQgMTggMjRWMjBDMTkuMTA0NiAyMCAyMCAxOS4xMDQ2IDIwIDE4VjZDMjAgNC44OTU0MyAxOS4xMDQ2IDQgMTggNFYwWiIgZmlsbD0iIzY3NzQ4RSIgbWFzaz0idXJsKCNwYXRoLTEtaW5zaWRlLTFfNTkyN18yOTMyMykiLz4NCjxyZWN0IHg9IjQiIHk9IjEwIiB3aWR0aD0iMTYiIGhlaWdodD0iMiIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iOCIgeT0iMjIiIHdpZHRoPSIxNiIgaGVpZ2h0PSIyIiB0cmFuc2Zvcm09InJvdGF0ZSgtOTAgOCAyMikiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjE0IiB5PSIxMiIgd2lkdGg9IjYiIGhlaWdodD0iMiIgdHJhbnNmb3JtPSJyb3RhdGUoLTkwIDE0IDEyKSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iNCIgeT0iNCIgd2lkdGg9IjE2IiBoZWlnaHQ9IjMiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjQiIHk9IjE1IiB3aWR0aD0iNiIgaGVpZ2h0PSIyIiBmaWxsPSIjNjc3NDhFIi8+DQo8cmVjdCB4PSI5LjUiIHk9IjE3IiB3aWR0aD0iMiIgaGVpZ2h0PSIxIiB0cmFuc2Zvcm09InJvdGF0ZSgtOTAgOS41IDE3KSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iMTEuNSIgeT0iMTciIHdpZHRoPSIyIiBoZWlnaHQ9IjEiIHRyYW5zZm9ybT0icm90YXRlKC05MCAxMS41IDE3KSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iMTMuNSIgeT0iMTciIHdpZHRoPSIyIiBoZWlnaHQ9IjEiIHRyYW5zZm9ybT0icm90YXRlKC05MCAxMy41IDE3KSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iMTUuNSIgeT0iMTciIHdpZHRoPSIyIiBoZWlnaHQ9IjEiIHRyYW5zZm9ybT0icm90YXRlKC05MCAxNS41IDE3KSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iMTcuNSIgeT0iMTciIHdpZHRoPSIyIiBoZWlnaHQ9IjEiIHRyYW5zZm9ybT0icm90YXRlKC05MCAxNy41IDE3KSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iMTkuNSIgeT0iMTciIHdpZHRoPSIyIiBoZWlnaHQ9IjEiIHRyYW5zZm9ybT0icm90YXRlKC05MCAxOS41IDE3KSIgZmlsbD0iIzY3NzQ4RSIvPg0KPC9zdmc+DQo="
						},
						handler: function(menu, menuItem) {
							var editor = menuItem.getEditor();
							if (editor) {
								editor.execCommand("cellHorizontalSplit");
							}
						}.bind(this),
						caption: resources.localizableStrings.SplitHorizontally,
						markerValue: "split_horizontally"
					},{
						imageConfig: {
							source: BPMSoft.ImageSources.URL,
							url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxtYXNrIGlkPSJwYXRoLTEtaW5zaWRlLTFfNTkyN18yOTM0MyIgZmlsbD0id2hpdGUiPg0KPHBhdGggZD0iTTIgNkMyIDMuNzkwODYgMy43OTA4NiAyIDYgMkgxOEMyMC4yMDkxIDIgMjIgMy43OTA4NiAyMiA2VjE4QzIyIDIwLjIwOTEgMjAuMjA5MSAyMiAxOCAyMkg2QzMuNzkwODYgMjIgMiAyMC4yMDkxIDIgMThWNloiLz4NCjwvbWFzaz4NCjxwYXRoIGQ9Ik0wIDZDMCAyLjY4NjI5IDIuNjg2MjkgMCA2IDBIMThDMjEuMzEzNyAwIDI0IDIuNjg2MjkgMjQgNkgyMEMyMCA0Ljg5NTQzIDE5LjEwNDYgNCAxOCA0SDZDNC44OTU0MyA0IDQgNC44OTU0MyA0IDZIMFpNMjQgMThDMjQgMjEuMzEzNyAyMS4zMTM3IDI0IDE4IDI0SDZDMi42ODYyOSAyNCAwIDIxLjMxMzcgMCAxOEg0QzQgMTkuMTA0NiA0Ljg5NTQzIDIwIDYgMjBIMThDMTkuMTA0NiAyMCAyMCAxOS4xMDQ2IDIwIDE4SDI0Wk02IDI0QzIuNjg2MjkgMjQgMCAyMS4zMTM3IDAgMThWNkMwIDIuNjg2MjkgMi42ODYyOSAwIDYgMFY0QzQuODk1NDMgNCA0IDQuODk1NDMgNCA2VjE4QzQgMTkuMTA0NiA0Ljg5NTQzIDIwIDYgMjBWMjRaTTE4IDBDMjEuMzEzNyAwIDI0IDIuNjg2MjkgMjQgNlYxOEMyNCAyMS4zMTM3IDIxLjMxMzcgMjQgMTggMjRWMjBDMTkuMTA0NiAyMCAyMCAxOS4xMDQ2IDIwIDE4VjZDMjAgNC44OTU0MyAxOS4xMDQ2IDQgMTggNFYwWiIgZmlsbD0iIzY3NzQ4RSIgbWFzaz0idXJsKCNwYXRoLTEtaW5zaWRlLTFfNTkyN18yOTM0MykiLz4NCjxyZWN0IHg9IjQiIHk9IjEwIiB3aWR0aD0iMTYiIGhlaWdodD0iMiIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iOCIgeT0iMjIiIHdpZHRoPSIxNiIgaGVpZ2h0PSIyIiB0cmFuc2Zvcm09InJvdGF0ZSgtOTAgOCAyMikiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjE0IiB5PSIxMCIgd2lkdGg9IjQiIGhlaWdodD0iMiIgdHJhbnNmb3JtPSJyb3RhdGUoLTkwIDE0IDEwKSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iNCIgeT0iNCIgd2lkdGg9IjE2IiBoZWlnaHQ9IjMiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjQiIHk9IjE1IiB3aWR0aD0iNiIgaGVpZ2h0PSIyIiBmaWxsPSIjNjc3NDhFIi8+DQo8cmVjdCB4PSIxNCIgeT0iMTEuNSIgd2lkdGg9IjIiIGhlaWdodD0iMSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iMTQiIHk9IjEzLjUiIHdpZHRoPSIyIiBoZWlnaHQ9IjEiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjE0IiB5PSIxNS41IiB3aWR0aD0iMiIgaGVpZ2h0PSIxIiBmaWxsPSIjNjc3NDhFIi8+DQo8cmVjdCB4PSIxNCIgeT0iMTcuNSIgd2lkdGg9IjIiIGhlaWdodD0iMSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iMTQiIHk9IjE5LjUiIHdpZHRoPSIyIiBoZWlnaHQ9IjEiIGZpbGw9IiM2Nzc0OEUiLz4NCjwvc3ZnPg0K"
						},
						handler: function(menu, menuItem) {
							var editor = menuItem.getEditor();
							if (editor) {
								editor.execCommand("cellVerticalSplit");
							}
						}.bind(this),
						caption: resources.localizableStrings.SplitVertically,
						markerValue: "split_vertically"
					}, {
						imageConfig: {
							source: BPMSoft.ImageSources.URL,
							url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxyZWN0IHg9IjkiIHk9IjciIHdpZHRoPSIxMiIgaGVpZ2h0PSIxNCIgc3Ryb2tlPSIjNjc3NDhFIiBzdHJva2Utd2lkdGg9IjIiIHN0cm9rZS1kYXNoYXJyYXk9IjQgNCIvPg0KPHJlY3QgeD0iMyIgeT0iMyIgd2lkdGg9IjEyIiBoZWlnaHQ9IjE0IiByeD0iMyIgZmlsbD0iIzY3NzQ4RSIgc3Ryb2tlPSIjNjc3NDhFIiBzdHJva2Utd2lkdGg9IjIiLz4NCjwvc3ZnPg0K"
						},
						menu: {
							className: "BPMSoft.Menu",
							items: [{
								imageConfig: {
									source: BPMSoft.ImageSources.URL,
									url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxtYXNrIGlkPSJwYXRoLTEtaW5zaWRlLTFfNTkyN18yOTA4OCIgZmlsbD0id2hpdGUiPg0KPHBhdGggZD0iTTIgMTBIMjJWMThDMjIgMjAuMjA5MSAyMC4yMDkxIDIyIDE4IDIySDZDMy43OTA4NiAyMiAyIDIwLjIwOTEgMiAxOFYxMFoiLz4NCjwvbWFzaz4NCjxwYXRoIGQ9Ik0wIDhIMjRMMjAgMTJINEwwIDhaTTI0IDE4QzI0IDIxLjMxMzcgMjEuMzEzNyAyNCAxOCAyNEg2QzIuNjg2MjkgMjQgMCAyMS4zMTM3IDAgMThINEM0IDE5LjEwNDYgNC44OTU0MyAyMCA2IDIwSDE4QzE5LjEwNDYgMjAgMjAgMTkuMTA0NiAyMCAxOEgyNFpNNiAyNEMyLjY4NjI5IDI0IDAgMjEuMzEzNyAwIDE4VjhMNCAxMlYxOEM0IDE5LjEwNDYgNC44OTU0MyAyMCA2IDIwVjI0Wk0yNCA4VjE4QzI0IDIxLjMxMzcgMjEuMzEzNyAyNCAxOCAyNFYyMEMxOS4xMDQ2IDIwIDIwIDE5LjEwNDYgMjAgMThWMTJMMjQgOFoiIGZpbGw9IiM2Nzc0OEUiIG1hc2s9InVybCgjcGF0aC0xLWluc2lkZS0xXzU5MjdfMjkwODgpIi8+DQo8cmVjdCB4PSI4IiB5PSIyMiIgd2lkdGg9IjEwIiBoZWlnaHQ9IjIiIHRyYW5zZm9ybT0icm90YXRlKC05MCA4IDIyKSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iMTQiIHk9IjIyIiB3aWR0aD0iMTAiIGhlaWdodD0iMiIgdHJhbnNmb3JtPSJyb3RhdGUoLTkwIDE0IDIyKSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iNCIgeT0iMTUiIHdpZHRoPSIxNiIgaGVpZ2h0PSIyIiBmaWxsPSIjNjc3NDhFIi8+DQo8cmVjdCB4PSIyIiB5PSIyIiB3aWR0aD0iMjAiIGhlaWdodD0iMiIgZmlsbD0iIzY3NzQ4RSIvPg0KPHBhdGggZD0iTTEyIDVMMTUgOUw5IDlMMTIgNVoiIGZpbGw9IiM2Nzc0OEUiLz4NCjwvc3ZnPg0K"
								},
								handler: function(menu, menuItem) {
									var editor = menuItem.getEditor();
									if (editor) {
										editor.execCommand("rowInsertBefore");
									}
								}.bind(this),
								caption: resources.localizableStrings.InsertRowBefore,
								markerValue: "table_insert_row_before"
							},{
								imageConfig: {
									source: BPMSoft.ImageSources.URL,
									url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxtYXNrIGlkPSJwYXRoLTEtaW5zaWRlLTFfNTkyN18yOTEwMSIgZmlsbD0id2hpdGUiPg0KPHBhdGggZD0iTTIyIDE0TDIgMTRMMiA2QzIgMy43OTA4NiAzLjc5MDg2IDIgNiAyTDE4IDJDMjAuMjA5MSAyIDIyIDMuNzkwODYgMjIgNkwyMiAxNFoiLz4NCjwvbWFzaz4NCjxwYXRoIGQ9Ik0yNCAxNkwtMS43NDg0NmUtMDcgMTZMNCAxMkwyMCAxMkwyNCAxNlpNNi45OTM4MmUtMDcgNkM5Ljg5MDc2ZS0wNyAyLjY4NjI5IDIuNjg2MjkgLTEuNjg4NDZlLTA2IDYgLTEuMzk4NzZlLTA2TDE4IC0zLjQ5NjkxZS0wN0MyMS4zMTM3IC01Ljk5OTc1ZS0wOCAyNCAyLjY4NjI5IDI0IDZMMjAgNkMyMCA0Ljg5NTQzIDE5LjEwNDYgNCAxOCA0TDYgNEM0Ljg5NTQzIDQgNCA0Ljg5NTQzIDQgNkw2Ljk5MzgyZS0wNyA2Wk0xOCAtMy40OTY5MWUtMDdDMjEuMzEzNyAtNS45OTk3NWUtMDggMjQgMi42ODYyOSAyNCA2TDI0IDE2TDIwIDEyTDIwIDZDMjAgNC44OTU0MyAxOS4xMDQ2IDQgMTggNEwxOCAtMy40OTY5MWUtMDdaTS0xLjc0ODQ2ZS0wNyAxNkw2Ljk5MzgyZS0wNyA2QzkuODkwNzZlLTA3IDIuNjg2MjkgMi42ODYyOSAtMS42ODg0NmUtMDYgNiAtMS4zOTg3NmUtMDZMNiA0QzQuODk1NDMgNCA0IDQuODk1NDMgNCA2TDQgMTJMLTEuNzQ4NDZlLTA3IDE2WiIgZmlsbD0iIzY3NzQ4RSIgbWFzaz0idXJsKCNwYXRoLTEtaW5zaWRlLTFfNTkyN18yOTEwMSkiLz4NCjxyZWN0IHg9IjE2IiB5PSIyIiB3aWR0aD0iMTAiIGhlaWdodD0iMiIgdHJhbnNmb3JtPSJyb3RhdGUoOTAgMTYgMikiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjEwIiB5PSIyIiB3aWR0aD0iMTAiIGhlaWdodD0iMiIgdHJhbnNmb3JtPSJyb3RhdGUoOTAgMTAgMikiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjIwIiB5PSI5IiB3aWR0aD0iMTYiIGhlaWdodD0iMiIgdHJhbnNmb3JtPSJyb3RhdGUoLTE4MCAyMCA5KSIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iMjIiIHk9IjIyIiB3aWR0aD0iMjAiIGhlaWdodD0iMiIgdHJhbnNmb3JtPSJyb3RhdGUoLTE4MCAyMiAyMikiIGZpbGw9IiM2Nzc0OEUiLz4NCjxwYXRoIGQ9Ik0xMiAxOUw5IDE1TDE1IDE1TDEyIDE5WiIgZmlsbD0iIzY3NzQ4RSIvPg0KPC9zdmc+DQo="
								},
								handler: function(menu, menuItem) {
									var editor = menuItem.getEditor();
									if (editor) {
										editor.execCommand("rowInsertAfter");
									}
								}.bind(this),
								caption: resources.localizableStrings.InsertRowAfter,
								markerValue: "table_insert_row_after"
							},{
								imageConfig: {
									source: BPMSoft.ImageSources.URL,
									url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxtYXNrIGlkPSJwYXRoLTEtaW5zaWRlLTFfNTkyN18yOTExNCIgZmlsbD0id2hpdGUiPg0KPHBhdGggZD0iTTggNkM4IDMuNzkwODYgOS43OTA4NiAyIDEyIDJIMThDMjAuMjA5MSAyIDIyIDMuNzkwODYgMjIgNlYxOEMyMiAyMC4yMDkxIDIwLjIwOTEgMjIgMTggMjJIMTJDOS43OTA4NiAyMiA4IDIwLjIwOTEgOCAxOFY2WiIvPg0KPC9tYXNrPg0KPHBhdGggZD0iTTYgNkM2IDIuNjg2MjkgOC42ODYyOSAwIDEyIDBIMThDMjEuMzEzNyAwIDI0IDIuNjg2MjkgMjQgNkgyMEMyMCA0Ljg5NTQzIDE5LjEwNDYgNCAxOCA0SDEyQzEwLjg5NTQgNCAxMCA0Ljg5NTQzIDEwIDZINlpNMjQgMThDMjQgMjEuMzEzNyAyMS4zMTM3IDI0IDE4IDI0SDEyQzguNjg2MjkgMjQgNiAyMS4zMTM3IDYgMThIMTBDMTAgMTkuMTA0NiAxMC44OTU0IDIwIDEyIDIwSDE4QzE5LjEwNDYgMjAgMjAgMTkuMTA0NiAyMCAxOEgyNFpNMTIgMjRDOC42ODYyOSAyNCA2IDIxLjMxMzcgNiAxOFY2QzYgMi42ODYyOSA4LjY4NjI5IDAgMTIgMFY0QzEwLjg5NTQgNCAxMCA0Ljg5NTQzIDEwIDZWMThDMTAgMTkuMTA0NiAxMC44OTU0IDIwIDEyIDIwVjI0Wk0xOCAwQzIxLjMxMzcgMCAyNCAyLjY4NjI5IDI0IDZWMThDMjQgMjEuMzEzNyAyMS4zMTM3IDI0IDE4IDI0VjIwQzE5LjEwNDYgMjAgMjAgMTkuMTA0NiAyMCAxOFY2QzIwIDQuODk1NDMgMTkuMTA0NiA0IDE4IDRWMFoiIGZpbGw9IiM2Nzc0OEUiIG1hc2s9InVybCgjcGF0aC0xLWluc2lkZS0xXzU5MjdfMjkxMTQpIi8+DQo8cmVjdCB4PSIxMCIgeT0iMTAiIHdpZHRoPSIxMiIgaGVpZ2h0PSIyIiBmaWxsPSIjNjc3NDhFIi8+DQo8cmVjdCB4PSIxNCIgeT0iMjIiIHdpZHRoPSIxNiIgaGVpZ2h0PSIyIiB0cmFuc2Zvcm09InJvdGF0ZSgtOTAgMTQgMjIpIiBmaWxsPSIjNjc3NDhFIi8+DQo8cmVjdCB4PSIxMCIgeT0iNCIgd2lkdGg9IjEwIiBoZWlnaHQ9IjMiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjEwIiB5PSIxNSIgd2lkdGg9IjEyIiBoZWlnaHQ9IjIiIGZpbGw9IiM2Nzc0OEUiLz4NCjxwYXRoIGQ9Ik0yIDEyTDYgOUw2IDE1TDIgMTJaIiBmaWxsPSIjNjc3NDhFIi8+DQo8L3N2Zz4NCg=="
								},
								handler: function(menu, menuItem) {
									var editor = menuItem.getEditor();
									if (editor) {
										editor.execCommand("columnInsertBefore");
									}
								}.bind(this),
								caption: resources.localizableStrings.InsertColumnBefore,
								markerValue: "table_insert_column_before"
							},{
								imageConfig: {
									source: BPMSoft.ImageSources.URL,
									url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxtYXNrIGlkPSJwYXRoLTEtaW5zaWRlLTFfNTkyN18yOTEyNyIgZmlsbD0id2hpdGUiPg0KPHBhdGggZD0iTTIgNkMyIDMuNzkwODYgMy43OTA4NiAyIDYgMkgxMkMxNC4yMDkxIDIgMTYgMy43OTA4NiAxNiA2VjE4QzE2IDIwLjIwOTEgMTQuMjA5MSAyMiAxMiAyMkg2QzMuNzkwODYgMjIgMiAyMC4yMDkxIDIgMThWNloiLz4NCjwvbWFzaz4NCjxwYXRoIGQ9Ik0wIDZDMCAyLjY4NjI5IDIuNjg2MjkgMCA2IDBIMTJDMTUuMzEzNyAwIDE4IDIuNjg2MjkgMTggNkgxNEMxNCA0Ljg5NTQzIDEzLjEwNDYgNCAxMiA0SDZDNC44OTU0MyA0IDQgNC44OTU0MyA0IDZIMFpNMTggMThDMTggMjEuMzEzNyAxNS4zMTM3IDI0IDEyIDI0SDZDMi42ODYyOSAyNCAwIDIxLjMxMzcgMCAxOEg0QzQgMTkuMTA0NiA0Ljg5NTQzIDIwIDYgMjBIMTJDMTMuMTA0NiAyMCAxNCAxOS4xMDQ2IDE0IDE4SDE4Wk02IDI0QzIuNjg2MjkgMjQgMCAyMS4zMTM3IDAgMThWNkMwIDIuNjg2MjkgMi42ODYyOSAwIDYgMFY0QzQuODk1NDMgNCA0IDQuODk1NDMgNCA2VjE4QzQgMTkuMTA0NiA0Ljg5NTQzIDIwIDYgMjBWMjRaTTEyIDBDMTUuMzEzNyAwIDE4IDIuNjg2MjkgMTggNlYxOEMxOCAyMS4zMTM3IDE1LjMxMzcgMjQgMTIgMjRWMjBDMTMuMTA0NiAyMCAxNCAxOS4xMDQ2IDE0IDE4VjZDMTQgNC44OTU0MyAxMy4xMDQ2IDQgMTIgNFYwWiIgZmlsbD0iIzY3NzQ4RSIgbWFzaz0idXJsKCNwYXRoLTEtaW5zaWRlLTFfNTkyN18yOTEyNykiLz4NCjxyZWN0IHg9IjQiIHk9IjEwIiB3aWR0aD0iMTIiIGhlaWdodD0iMiIgZmlsbD0iIzY3NzQ4RSIvPg0KPHJlY3QgeD0iOCIgeT0iMjIiIHdpZHRoPSIxNiIgaGVpZ2h0PSIyIiB0cmFuc2Zvcm09InJvdGF0ZSgtOTAgOCAyMikiIGZpbGw9IiM2Nzc0OEUiLz4NCjxyZWN0IHg9IjQiIHk9IjQiIHdpZHRoPSIxMCIgaGVpZ2h0PSIzIiBmaWxsPSIjNjc3NDhFIi8+DQo8cmVjdCB4PSI0IiB5PSIxNSIgd2lkdGg9IjEyIiBoZWlnaHQ9IjIiIGZpbGw9IiM2Nzc0OEUiLz4NCjxwYXRoIGQ9Ik0yMiAxMkwxOCAxNUwxOCA5TDIyIDEyWiIgZmlsbD0iIzY3NzQ4RSIvPg0KPC9zdmc+DQo="
								},
								handler: function(menu, menuItem) {
									var editor = menuItem.getEditor();
									if (editor) {
										editor.execCommand("columnInsertAfter");
									}
								}.bind(this),
								caption: resources.localizableStrings.InsertColumnAfter,
								markerValue: "table_insert_column_after"
							}]
						},
						caption: resources.localizableStrings.Insert,
						markerValue: "table_insert"
					}, {
						imageConfig: {
							source: BPMSoft.ImageSources.URL,
							url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNNi43MDcxMSA1LjI5Mjg5QzYuMzE2NTggNC45MDIzNyA1LjY4MzQyIDQuOTAyMzcgNS4yOTI4OSA1LjI5Mjg5QzQuOTAyMzcgNS42ODM0MiA0LjkwMjM3IDYuMzE2NTggNS4yOTI4OSA2LjcwNzExTDEwLjU4NTggMTJMNS4yOTI4OSAxNy4yOTI5QzQuOTAyMzcgMTcuNjgzNCA0LjkwMjM3IDE4LjMxNjYgNS4yOTI4OSAxOC43MDcxQzUuNjgzNDIgMTkuMDk3NiA2LjMxNjU4IDE5LjA5NzYgNi43MDcxMSAxOC43MDcxTDEyIDEzLjQxNDJMMTcuMjkyOSAxOC43MDcxQzE3LjY4MzQgMTkuMDk3NiAxOC4zMTY2IDE5LjA5NzYgMTguNzA3MSAxOC43MDcxQzE5LjA5NzYgMTguMzE2NiAxOS4wOTc2IDE3LjY4MzQgMTguNzA3MSAxNy4yOTI5TDEzLjQxNDIgMTJMMTguNzA3MSA2LjcwNzExQzE5LjA5NzYgNi4zMTY1OCAxOS4wOTc2IDUuNjgzNDIgMTguNzA3MSA1LjI5Mjg5QzE4LjMxNjYgNC45MDIzNyAxNy42ODM0IDQuOTAyMzcgMTcuMjkyOSA1LjI5Mjg5TDEyIDEwLjU4NThMNi43MDcxMSA1LjI5Mjg5WiIgZmlsbD0iIzY3NzQ4RSIvPg0KPC9zdmc+DQo="
						},
						menu: {
							className: "BPMSoft.Menu",
							items: [{
								imageConfig: {
									source: BPMSoft.ImageSources.URL,
									url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPG1hc2sgaWQ9InBhdGgtMS1pbnNpZGUtMV8yOTFfMzEyMyIgZmlsbD0id2hpdGUiPgo8cGF0aCBkPSJNOCA2QzggMy43OTA4NiA5Ljc5MDg2IDIgMTIgMkgxOEMyMC4yMDkxIDIgMjIgMy43OTA4NiAyMiA2VjE4QzIyIDIwLjIwOTEgMjAuMjA5MSAyMiAxOCAyMkgxMkM5Ljc5MDg2IDIyIDggMjAuMjA5MSA4IDE4VjZaIi8+CjwvbWFzaz4KPHBhdGggZD0iTTYgNkM2IDIuNjg2MjkgOC42ODYyOSAwIDEyIDBIMThDMjEuMzEzNyAwIDI0IDIuNjg2MjkgMjQgNkgyMEMyMCA0Ljg5NTQzIDE5LjEwNDYgNCAxOCA0SDEyQzEwLjg5NTQgNCAxMCA0Ljg5NTQzIDEwIDZINlpNMjQgMThDMjQgMjEuMzEzNyAyMS4zMTM3IDI0IDE4IDI0SDEyQzguNjg2MjkgMjQgNiAyMS4zMTM3IDYgMThIMTBDMTAgMTkuMTA0NiAxMC44OTU0IDIwIDEyIDIwSDE4QzE5LjEwNDYgMjAgMjAgMTkuMTA0NiAyMCAxOEgyNFpNMTIgMjRDOC42ODYyOSAyNCA2IDIxLjMxMzcgNiAxOFY2QzYgMi42ODYyOSA4LjY4NjI5IDAgMTIgMFY0QzEwLjg5NTQgNCAxMCA0Ljg5NTQzIDEwIDZWMThDMTAgMTkuMTA0NiAxMC44OTU0IDIwIDEyIDIwVjI0Wk0xOCAwQzIxLjMxMzcgMCAyNCAyLjY4NjI5IDI0IDZWMThDMjQgMjEuMzEzNyAyMS4zMTM3IDI0IDE4IDI0VjIwQzE5LjEwNDYgMjAgMjAgMTkuMTA0NiAyMCAxOFY2QzIwIDQuODk1NDMgMTkuMTA0NiA0IDE4IDRWMFoiIGZpbGw9IiM2Nzc0OEUiIG1hc2s9InVybCgjcGF0aC0xLWluc2lkZS0xXzI5MV8zMTIzKSIvPgo8cmVjdCB4PSIxMCIgeT0iMTAiIHdpZHRoPSIxMiIgaGVpZ2h0PSIyIiBmaWxsPSIjNjc3NDhFIi8+CjxyZWN0IHg9IjE0IiB5PSIyMiIgd2lkdGg9IjE2IiBoZWlnaHQ9IjIiIHRyYW5zZm9ybT0icm90YXRlKC05MCAxNCAyMikiIGZpbGw9IiM2Nzc0OEUiLz4KPHJlY3QgeD0iMTAiIHk9IjQiIHdpZHRoPSIxMCIgaGVpZ2h0PSIzIiBmaWxsPSIjNjc3NDhFIi8+CjxyZWN0IHg9IjEwIiB5PSIxNSIgd2lkdGg9IjEyIiBoZWlnaHQ9IjIiIGZpbGw9IiM2Nzc0OEUiLz4KPHBhdGggZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGQ9Ik0yLjg1NzczIDkuNDQzNzFDMi40NjcyMSA5LjA1MzE5IDEuODM0MDQgOS4wNTMxOSAxLjQ0MzUyIDkuNDQzNzFDMS4wNTI5OSA5LjgzNDI0IDEuMDUyOTkgMTAuNDY3NCAxLjQ0MzUyIDEwLjg1NzlMMi41ODU2MyAxMkwxLjQ0MzUyIDEzLjE0MjFDMS4wNTI5OSAxMy41MzI3IDEuMDUyOTkgMTQuMTY1OCAxLjQ0MzUyIDE0LjU1NjRDMS44MzQwNCAxNC45NDY5IDIuNDY3MjEgMTQuOTQ2OSAyLjg1NzczIDE0LjU1NjRMMy45OTk4NCAxMy40MTQyTDUuMTQxOTUgMTQuNTU2NEM1LjUzMjQ4IDE0Ljk0NjkgNi4xNjU2NCAxNC45NDY5IDYuNTU2MTcgMTQuNTU2NEM2Ljk0NjY5IDE0LjE2NTggNi45NDY2OSAxMy41MzI3IDYuNTU2MTcgMTMuMTQyMUw1LjQxNDA2IDEyTDYuNTU2MTcgMTAuODU3OUM2Ljk0NjY5IDEwLjQ2NzQgNi45NDY2OSA5LjgzNDI0IDYuNTU2MTcgOS40NDM3MUM2LjE2NTY0IDkuMDUzMTkgNS41MzI0OCA5LjA1MzE5IDUuMTQxOTUgOS40NDM3MUwzLjk5OTg0IDEwLjU4NThMMi44NTc3MyA5LjQ0MzcxWiIgZmlsbD0iIzY3NzQ4RSIvPgo8L3N2Zz4K"
								},
								handler: function(menu, menuItem) {
									var editor = menuItem.getEditor();
									if (editor) {
										editor.execCommand("columnDelete");
									}
								}.bind(this),
								caption: resources.localizableStrings.DeleteColumn,
								markerValue: "table_delete_column"
							}, {
								imageConfig: {
									source: BPMSoft.ImageSources.URL,
									url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPG1hc2sgaWQ9InBhdGgtMS1pbnNpZGUtMV8yOTFfMzEyNCIgZmlsbD0id2hpdGUiPgo8cGF0aCBkPSJNMjIgMTRMMiAxNEwyIDZDMiAzLjc5MDg2IDMuNzkwODYgMiA2IDJMMTggMkMyMC4yMDkxIDIgMjIgMy43OTA4NiAyMiA2TDIyIDE0WiIvPgo8L21hc2s+CjxwYXRoIGQ9Ik0yNCAxNkwtMS43NDg0NmUtMDcgMTZMNCAxMkwyMCAxMkwyNCAxNlpNNi45OTM4MmUtMDcgNkM5Ljg5MDc2ZS0wNyAyLjY4NjI5IDIuNjg2MjkgLTEuNjg4NDZlLTA2IDYgLTEuMzk4NzZlLTA2TDE4IC0zLjQ5NjkxZS0wN0MyMS4zMTM3IC01Ljk5OTc1ZS0wOCAyNCAyLjY4NjI5IDI0IDZMMjAgNkMyMCA0Ljg5NTQzIDE5LjEwNDYgNCAxOCA0TDYgNEM0Ljg5NTQzIDQgNCA0Ljg5NTQzIDQgNkw2Ljk5MzgyZS0wNyA2Wk0xOCAtMy40OTY5MWUtMDdDMjEuMzEzNyAtNS45OTk3NWUtMDggMjQgMi42ODYyOSAyNCA2TDI0IDE2TDIwIDEyTDIwIDZDMjAgNC44OTU0MyAxOS4xMDQ2IDQgMTggNEwxOCAtMy40OTY5MWUtMDdaTS0xLjc0ODQ2ZS0wNyAxNkw2Ljk5MzgyZS0wNyA2QzkuODkwNzZlLTA3IDIuNjg2MjkgMi42ODYyOSAtMS42ODg0NmUtMDYgNiAtMS4zOTg3NmUtMDZMNiA0QzQuODk1NDMgNCA0IDQuODk1NDMgNCA2TDQgMTJMLTEuNzQ4NDZlLTA3IDE2WiIgZmlsbD0iIzY3NzQ4RSIgbWFzaz0idXJsKCNwYXRoLTEtaW5zaWRlLTFfMjkxXzMxMjQpIi8+CjxyZWN0IHg9IjE2IiB5PSIyIiB3aWR0aD0iMTAiIGhlaWdodD0iMiIgdHJhbnNmb3JtPSJyb3RhdGUoOTAgMTYgMikiIGZpbGw9IiM2Nzc0OEUiLz4KPHJlY3QgeD0iMTAiIHk9IjIiIHdpZHRoPSIxMCIgaGVpZ2h0PSIyIiB0cmFuc2Zvcm09InJvdGF0ZSg5MCAxMCAyKSIgZmlsbD0iIzY3NzQ4RSIvPgo8cmVjdCB4PSIyMCIgeT0iOSIgd2lkdGg9IjE2IiBoZWlnaHQ9IjIiIHRyYW5zZm9ybT0icm90YXRlKC0xODAgMjAgOSkiIGZpbGw9IiM2Nzc0OEUiLz4KPHBhdGggZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGQ9Ik0xMC43MDcxIDE2LjI5MjlDMTAuMzE2NiAxNS45MDI0IDkuNjgzNDIgMTUuOTAyNCA5LjI5Mjg5IDE2LjI5MjlDOC45MDIzNyAxNi42ODM0IDguOTAyMzcgMTcuMzE2NiA5LjI5Mjg5IDE3LjcwNzFMMTAuNzI4NiAxOS4xNDI5TDkuMjkyODkgMjAuNTc4NkM4LjkwMjM3IDIwLjk2OTEgOC45MDIzNyAyMS42MDIzIDkuMjkyODkgMjEuOTkyOEM5LjY4MzQyIDIyLjM4MzMgMTAuMzE2NiAyMi4zODMzIDEwLjcwNzEgMjEuOTkyOEwxMi4xNDI5IDIwLjU1NzFMMTMuNTc4NiAyMS45OTI4QzEzLjk2OTEgMjIuMzgzMyAxNC42MDIzIDIyLjM4MzMgMTQuOTkyOCAyMS45OTI4QzE1LjM4MzMgMjEuNjAyMyAxNS4zODMzIDIwLjk2OTEgMTQuOTkyOCAyMC41Nzg2TDEzLjU1NzEgMTkuMTQyOUwxNC45OTI4IDE3LjcwNzFDMTUuMzgzMyAxNy4zMTY2IDE1LjM4MzMgMTYuNjgzNCAxNC45OTI4IDE2LjI5MjlDMTQuNjAyMyAxNS45MDI0IDEzLjk2OTEgMTUuOTAyNCAxMy41Nzg2IDE2LjI5MjlMMTIuMTQyOSAxNy43Mjg2TDEwLjcwNzEgMTYuMjkyOVoiIGZpbGw9IiM2Nzc0OEUiLz4KPC9zdmc+Cg=="
								},
								handler: function(menu, menuItem) {
									var editor = menuItem.getEditor();
									if (editor) {
										editor.execCommand("rowDelete");
									}
								}.bind(this),
								caption: resources.localizableStrings.DeleteRow,
								markerValue: "table_delete_row"
							},{
								imageConfig: {
									source: BPMSoft.ImageSources.URL,
									url: "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHZpZXdCb3g9IjAgMCAyNCAyNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHBhdGggZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGQ9Ik0xNiA3VjEwSDIwVjdIMTZaTTE0IDdIMTBWMTBIMTRWN1pNOCA3SDRWMTBIOFY3Wk0xMCAxMkgxMkgxNEgxNkgyMEgyMlY2QzIyIDMuNzkwODYgMjAuMjA5MSAyIDE4IDJINkMzLjc5MDg2IDIgMiAzLjc5MDg2IDIgNlYxOEMyIDIwLjIwOTEgMy43OTA4NiAyMiA2IDIySDhIMTBIMTJWMjBIMTBWMTdIMTJWMTVIMTBWMTJaTTggMTJWMTVINFYxMkg4Wk00IDE4VjE3SDhWMjBINkM0Ljg5NTQzIDIwIDQgMTkuMTA0NiA0IDE4WiIgZmlsbD0iIzY3NzQ4RSIvPgo8cGF0aCBmaWxsLXJ1bGU9ImV2ZW5vZGQiIGNsaXAtcnVsZT0iZXZlbm9kZCIgZD0iTTE0LjI5NDcgMTQuMzUxNUMxMy45MDQyIDE0Ljc0MjEgMTMuOTA0MiAxNS4zNzUzIDE0LjI5NDcgMTUuNzY1OUwxNi41MjkzIDE4LjAwMDlMMTQuMjk0NyAyMC4yMzZDMTMuOTA0MyAyMC42MjY1IDEzLjkwNDMgMjEuMjU5OCAxNC4yOTQ3IDIxLjY1MDRMMTQuMzUxNSAyMS43MDcxQzE0Ljc0MTkgMjIuMDk3NyAxNS4zNzUgMjIuMDk3NyAxNS43NjU1IDIxLjcwNzFMMTggMTkuNDcyTDIwLjIzNDUgMjEuNzA3QzIwLjYyNSAyMi4wOTc2IDIxLjI1ODEgMjIuMDk3NiAyMS42NDg1IDIxLjcwN0wyMS43MDUzIDIxLjY1MDNDMjIuMDk1NyAyMS4yNTk3IDIyLjA5NTcgMjAuNjI2NSAyMS43MDUzIDIwLjIzNTlMMTkuNDcwOCAxOC4wMDA5TDIxLjcwNTMgMTUuNzY1OUMyMi4wOTU4IDE1LjM3NTMgMjIuMDk1OCAxNC43NDIxIDIxLjcwNTMgMTQuMzUxNUwyMS42NDg2IDE0LjI5NDhDMjEuMjU4MSAxMy45MDQyIDIwLjYyNSAxMy45MDQyIDIwLjIzNDUgMTQuMjk0OEwxOCAxNi41Mjk4TDE1Ljc2NTUgMTQuMjk0OEMxNS4zNzUgMTMuOTA0MiAxNC43NDE5IDEzLjkwNDIgMTQuMzUxNCAxNC4yOTQ4TDE0LjI5NDcgMTQuMzUxNVoiIGZpbGw9IiM2Nzc0OEUiLz4KPC9zdmc+Cg=="
								},
								handler: function(menu, menuItem) {
									var editor = menuItem.getEditor();
									if (editor) {
										editor.execCommand("tableDelete");
									}
								}.bind(this),
								caption: resources.localizableStrings.DeleteTable,
								markerValue: "table_delete"
							}]
						},
						caption: resources.localizableStrings.Delete,
						markerValue: "table_delete_menu"
					}]
				},
				tag: "table",
				markerValue: "table"
			},
			{
				className: "BPMSoft.MemoEdit",
				width: "100%",
				height: "100%",
				tag: "plainText"
			}
		],

		/**
		 * CKeditor fit content enabled flag.
		 * @type {Boolean}
		 */
		fitContent: false,

		/**
		 * Timeout before editor size will be changed to fit content (in miliseconds).
		 * @type {Integer}
		 */
		fitContentDelay: 400,

		/**
		 * Editor size.
		 * @type {Integer}
		 */
		editorHeight: 0,

		//endregion

		//region Constructors: Public

		constructor: function() {
			this.callParent(arguments);
			this.setValueDebounce = new Ext.util.DelayedTask(BPMSoft.emptyFn, this);
		},

		//endregion

		//region Methods: Private

		/**
		 * Sets cursor position at the begining of document.
		 * @private
		 */
		fixCursorInitPosition: function() {
			if (this.value) {
				return;
			}
			var editor = this.editor;
			var editorDocument = editor.document;
			var target = editorDocument.getBody().$;
			var range = new CKEDITOR.dom.range(editorDocument);
			range.setStart(new CKEDITOR.dom.node(target), 0);
			range.collapse();
			var selection = editor.getSelection();
			selection.selectRanges([range]);
			editor.focus();
		},

		/**
		 * Sets Value parameter.
		 * @private
		 * @param {String} value Paramter value.
		 */
		setValue: function(value) {
			const memo = this.memo;
			const editor = this.editor;
			if (editor && memo) {
				if (this.plainTextMode || this.getIsHtmlEditMode()) {
					this.setValueDebounce.delay(this.setValueDelay, this._setMemoValue, this, [value]);
				} else if (value !== this._getEditorValue(editor) || !this.initialValueSet) {
					this.setValueDebounce.delay(this.setValueDelay, this.setEditorValue, this, [value]);
				}
			}
			if (this.value !== value) {
				this.value = value;
				this.fireEvent("changeValue", this.value, this);
				this.plainTextValue = this.value && this.removeHtmlTags(this.value);
				this.fireEvent("changePlainTextValue", this.plainTextValue, this);
			}
			this._updateEditorHeight();
		},

		/**
		 * Gets editor data.
		 * @private
		 * @param editor Editor object.
		 * @return {String} editor data.
		 */
		_getEditorValue: function(editor) {
			let editorData;
			try {
				editorData = editor.getData();
			} catch (e) {
				const editorDocument = editor.document;
				const editorDocumentBody = editorDocument.getBody();
				const dollar = editorDocumentBody.$;
				editorData = dollar && dollar.innerHTML;
			}
			return editorData;
		},

		/**
		 * Sets value to memo.
		 * @private
		 * @param {Object} memo Action.
		 * @param {Object} value Action.
		 */
		_setMemoValue: function(value) {
			const memo = this.memo;
			memo.setValue(value);
			memo.updateScrollHeight();
		},

		/**
		 * Event handler for control mouseDown event.
		 * @private
		 */
		onDocumentMouseDown: function(e) {
			var wrapEl = this.getWrapEl();
			var isInControl = e.within(wrapEl.dom);
			if (!isInControl) {
				this.hideToolbar();
			}
			if (this.plainTextMode || this.getIsHtmlEditMode() || isInControl || !this.focused) {
				return;
			}
			this.setValue(this.getEditorValue());
		},

		/**
		 * CKEDITOR initialization.
		 * @private
		 */
		initCKEDITOR: function() {
			var id = this.id + "-";
			var textArea = Ext.get(id + this.controlElementPrefix + "-textarea");
			var editor = this.editor = CKEDITOR.replace(textArea.dom, this.getEditorConfig());
			editor.setMode("wysiwyg");
			editor.on("selectionChange", this.onSelectionChange, this);
			editor.on("focus", this.onFocus, this);
			editor.on("blur", this.onBlur, this);
			editor.on("instanceReady", this.onInstanceReady, this);
			editor.on("contentDom", this.onContentDom, this);
			editor.on("doubleclick", this.onDoubleClick, this);
			editor.on("openlinkmodalwindow", this.showLinkInputBox, this);
			this.editorMode = this.editorMode || this.htmlModeValue;
			if (this.plainTextMode) {
				this._changeEditorMode(this.plainModeValue);
				if (this.value) {
					this.setValue(this.value);
				}
			}
		},

		/**
		 * Updates controls state by text style.
		 * @private
		 * @param {Object} controlState Control configuration.
		 */
		updateControlsStateByTextStyle: function(controlState) {
			var controls = this.toolbar;
			BPMSoft.each(controls, function(control) {
				var controlClassName = control.className;
				var controlStateValue = controlState[control.tag];
				if (controlClassName === "BPMSoft.Button") {
					this.updateButtonState(control, controlStateValue);
				} else if (controlClassName === "BPMSoft.ComboBoxEdit") {
					this.updateComboBoxState(control, controlStateValue);
				} else if (controlClassName === "BPMSoft.ColorButton") {
					this.updateColorButtonState(control, controlStateValue);
				}
			}, this);
		},

		/**
		 * Updates button state.
		 * @private
		 * @param {Object} control Control.
		 * @param {Object} state Control configuration.
		 */
		updateButtonState: function(control, state) {
			var controlTag = control.tag;
			if (controlTag !== "htmlMode" && controlTag !== "plainMode" && controlTag !== "htmlEditMode") {
				control.setPressed(state);
			}
		},

		/**
		 * Updates color button state.
		 * @private
		 * @param {Object} control Control.
		 * @param {Object} state Control configuration.
		 */
		updateColorButtonState: function(control, state) {
			var controlTag = control.tag;
			if (controlTag === "fontColor" || controlTag === "hightlightColor") {
				control.setValue(state);
			}
		},

		/**
		 * Updates combobox state.
		 * @private
		 * @param {Object} control Control.
		 * @param {Object} state Control configuration.
		 */
		updateComboBoxState: function(control, state) {
			var firstLetter = new RegExp("[a-z][A-Z]+", "ig");
			var replaceSymbol = new RegExp("\'", "ig");
			var replaceQuotSymbol = new RegExp("\"", "ig");
			state = state.replace(replaceSymbol, "");
			state = state.replace(replaceQuotSymbol, "");
			var displayValue = state.replace(firstLetter, function(match) {
				return (match[0].toUpperCase() + match.slice(1));
			});
			var itemValue = control.getValue();
			var newItemValue = {
				value: state.toLowerCase(),
				displayValue: displayValue
			};
			if (!Ext.Object.equals(itemValue, newItemValue)) {
				control.setValue(newItemValue);
			}
		},

		/**
		 * Gets controls state by selected text style.
		 * @private
		 * @param {Object[]} elements Selected text elements.
		 * @return {Object} controlState Controls state.
		 */
		getControlsStateByTextStyle: function(elements) {
			var controlState = {
				fontFamily: "",
				fontSize: "",
				fontStyleBold: false,
				fontStyleItalic: false,
				fontStyleUnderline: false,
				numberedList: false,
				bulletedList: false,
				indentList: false,
				outdentList: false,
				maximized: false,
				justifyLeft: true,
				justifyCenter: false,
				justifyRight: false
			};
			elements.forEach(function(element) {
				var elementName = element.getName();
				var elementStyle = element.$.style;
				if (elementStyle) {
					if (!controlState.fontFamily) {
						controlState.fontFamily = elementStyle.fontFamily;
					}
					if (!controlState.fontSize) {
						controlState.fontSize = elementStyle.fontSize.replace("px", "");
					}
					if (!controlState.fontColor) {
						controlState.fontColor = elementStyle.color;
					}
					if (!controlState.hightlightColor) {
						controlState.hightlightColor = elementStyle.background;
					}
					if (!controlState.bulletColor) {
						controlState.bulletColor = elementStyle.background;
					}
					if (!Ext.isEmpty(elementStyle.textAlign)) {
						if (!controlState.justifyCenter && !controlState.justifyRight) {
							controlState.justifyLeft = (elementStyle.textAlign === "left");
							controlState.justifyCenter = (elementStyle.textAlign === "center");
							controlState.justifyRight = (elementStyle.textAlign === "right");
						}
					}
				}
				if (!controlState.bulletedList) {
					controlState.bulletedList = (elementName === "ul");
				}
				if (!controlState.numberedList) {
					controlState.numberedList = (elementName === "ol");
				}
				if (!controlState.fontStyleBold) {
					controlState.fontStyleBold = (elementName === "strong");
				}
				if (!controlState.fontStyleItalic) {
					controlState.fontStyleItalic = (elementName === "em");
				}
				if (!controlState.fontStyleUnderline) {
					controlState.fontStyleUnderline = (elementName === "u");
				}
			}, this);
			if (!controlState.fontFamily) {
				controlState.fontFamily = "Golos Regular";
			}
			if (!controlState.fontSize) {
				controlState.fontSize = "14";
			}
			if(this.toolbar && this.toolbar.maximized) {
				controlState.maximized = this.toolbar.maximized.pressed;
			}
			return controlState;
		},

		/**
		 * Ckeditor contentDom event handler.
		 * Subscribes editor on contextmenu, click and keydows events.
		 * @private
		 */
		onContentDom: function() {
			var editor = this.editor;
			var editable = editor.editable();
			editable.on("contextmenu", function(event) {
				event.stop();
			}, this);
			editable.on("click", this.onClick, this);
			editable.on("keydown", this.onHtmlEditKeyDown, this);
			editable.on("keyup", this.onHtmlEditKeyUp, this);
			var editableElement = editable || editor.document;
			editableElement.on("paste", this.onPaste.bind(this), null, {editor: editor});
			this.setupBodyDrop();
			this.setAdditionalContentStyles();
		},

		/**
		 * Sets body drop.
		 * @private
		 */
		setupBodyDrop: function() {
			var iframeContentDocument = this.editor.document.$;
			var iframeHtml = iframeContentDocument.querySelector("html");
			if (!this.resizeEnabled && BPMSoft.Features.getIsDisabled("CKeditorSignatureSpace")) {
				iframeHtml.style.height = "100%";
			}
			iframeHtml.style.width = "100%";
			iframeHtml.style.overflowX = this.fitContent ? "auto" : "hidden";
			var iframeBody = iframeHtml.querySelector("body");
			iframeBody.ondrop = this.onBodyDrop.bind(this);
			if (!this.resizeEnabled) {
				iframeBody.style.height = "100%";
			}
			iframeBody.style.margin = "0";
		},

		/**
		 * Ckeditor instanceReady event handler.
		 * @private
		 */
		onInstanceReady: function() {
			this.initialValueSet = !Ext.isEmpty(this.value)
			this.setValue(this.value || "");
			this.updateToolbar();
			this.applyFontStyle();
			this.setInstanceReadyMarkOut();
			this._updateEditorHeight();
		},

		/**
		 * Drop image on email body.
		 * @param {Object} e Ckeditor drag event.
		 * @private
		 */
		onBodyDrop: function(e) {
			e.preventDefault();
			this.onFilesSelected(e.dataTransfer.files);
		},

		/**
		 * Sets wrap element classes which indicate that ckeditor is initialized.
		 * @private
		 */
		setInstanceReadyMarkOut: function() {
			var wrapEl = this.getWrapEl();
			if (!wrapEl) {
				return;
			}
			wrapEl.addCls("instance-ready");
		},

		/**
		 * Initializes toolbar controls.
		 * @private
		 */
		initControls: function() {
			var toolbar = {};
			var memo = null;
			var items = this.items;
			if (items) {
				items.each(function(item) {
					if (item.tag === "plainText") {
						memo = item;
					} else {
						toolbar[item.tag] = item;
					}
				});
			}
			this.initToolbarItems(toolbar);
			this.initMemo(memo);
			this.initFonts();
		},

		/**
		 * Memo blur event handler.
		 * @private
		 */
		onMemoBlur: function() {
			this.setValue(this.memo.getValue());
		},

		/**
		 * Changes editor text edit mode.
		 * @private
		 * @param {String} mode New editor mode.
		 */
		_changeEditorMode: function(mode) {
			if (this.editorMode === mode || this.editorMode === '') {
				return;
			}
			const oldMode = this.editorMode;
			this.editorMode = mode;
			this.plainTextMode = mode === this.plainModeValue;
			this.updateToolbar();
			let value = this.getEditorValueByMode(mode, oldMode);
			this.setValue(value);
			this.fireEvent("changePlainTextMode", this.value, this);
		},

		/**
		 * Get editor formatted value by mode.
		 * @param {String} mode New mode value.
		 * @param {String} oldMode Old mode value.
		 * @returns {String} Formatted value by mode.
		 */
		getEditorValueByMode: function(mode, oldMode) {
			let value;
			const memo = this.memo;
			switch (mode) {
				case this.plainModeValue:
					value = this.getEditorValue();
					break;
				case this.htmlModeValue:
					value = memo ? memo.getValue() : "";
					if (value && !value.startsWith("<") && oldMode === this.plainModeValue) {
						value = "<p>" + value.replace(/\n*$/, "").replace(/\n/g, "</p><p>") + "</p>";
					}
					break;
				case this.htmlEditModeValue:
					value = this.getEditorValueWithHtmlTags();
					break;
			}
			return value;
		},

		/**
		 * Get is current mode is plain text.
		 * @return {Boolean} Is current mode is plain text.
		 */
		getIsPlainMode: function() {
			return this.editorMode === this.plainModeValue;
		},

		/**
		 * Get is current mode is html view.
		 * @return {Boolean} Is current mode is is html view.
		 */
		getIsHtmlMode: function() {
			return this.editorMode === this.htmlModeValue;
		},

		/**
		 * Get is current mode is html edit.
		 * @return {Boolean} Is current mode is html edit.
		 */
		getIsHtmlEditMode: function() {
			return this.editorMode === this.htmlEditModeValue;
		},

		/**
		 * @obsolete
		 * Changes editor text edit mode.
		 * @private
		 * @param {Boolean} plainTextMode Use plain text mode flag.
		 */
		changeEditorMode: function(plainTextMode) {
			if (this.plainTextMode === plainTextMode) {
				return;
			}
			this._changeEditorMode(this.plainTextMode && this.plainModeValue || this.htmlModeValue);
		},

		/**
		 * Sets toolbar controls enabled.
		 * @private
		 */
		updateToolbar: function() {
			var id = this.id;
			var toolbar = this.toolbar;
			var memo = this.memo;
			var editor = this.editor;
			var enabled = this.enabled;
			if (editor) {
				try {
					editor.setReadOnly(!enabled);
				} catch (e) {
					if (editor.document) {
						editor.document.getBody().$.contentEditable = enabled;
					}
				}
				if (extHtmlEdit) {
					extHtmlEdit.dom.style.backgroundColor = enabled ? "#ffffff" : "#f9f9f9";
				}
			}
			if (!toolbar || !memo) {
				return;
			}
			var enabledInRichTextMode = this.getIsHtmlMode() && enabled;
			var enabledInPlainTextMode = (this.getIsPlainMode() || this.getIsHtmlEditMode()) && enabled;
			var hideModeButtons = this.hideModeButtons;
			toolbar.fontFamily.setEnabled(enabledInRichTextMode);
			toolbar.fontSize.setEnabled(enabledInRichTextMode);
			toolbar.fontStyleBold.setEnabled(enabledInRichTextMode);
			toolbar.fontStyleItalic.setEnabled(enabledInRichTextMode);
			toolbar.fontStyleUnderline.setEnabled(enabledInRichTextMode);
			toolbar.fontColor.setEnabled(enabledInRichTextMode);
			toolbar.hightlightColor.setEnabled(enabledInRichTextMode);
			toolbar.numberedList.setEnabled(enabledInRichTextMode);
			toolbar.bulletedList.setEnabled(enabledInRichTextMode);
			toolbar.maximized.setEnabled(enabledInRichTextMode);
			toolbar.indentList.setEnabled(enabledInRichTextMode);
			toolbar.outdentList.setEnabled(enabledInRichTextMode);
			toolbar.justifyLeft.setEnabled(enabledInRichTextMode);
			toolbar.justifyCenter.setEnabled(enabledInRichTextMode);
			toolbar.justifyRight.setEnabled(enabledInRichTextMode);
			toolbar.image.setEnabled(enabledInRichTextMode);
			toolbar.link.setEnabled(enabledInRichTextMode);
			toolbar.htmlMode.setEnabled(enabledInPlainTextMode);
			toolbar.plainMode.setEnabled(enabledInRichTextMode);
			toolbar.htmlEditMode.setEnabled(enabledInPlainTextMode);
			toolbar.htmlMode.setPressed(enabled && this.getIsHtmlMode());
			toolbar.plainMode.setPressed(enabled && this.getIsPlainMode());
			toolbar.htmlEditMode.setPressed(enabled && this.getIsHtmlEditMode());
			toolbar.htmlMode.setVisible(!hideModeButtons);
			toolbar.plainMode.setVisible(!hideModeButtons);
			toolbar.htmlEditMode.setVisible(!hideModeButtons && this.htmlEditModeEnabled);
			memo.setReadonly(!enabled);
			var extToolbar = Ext.get(id + "-" + this.controlElementPrefix + "-toolbar");
			if (extToolbar) {
				extToolbar.dom.style.display = !enabled ? "none" : "table-cell";
			}
			var extHtmlEdit = Ext.get(id + "-" + this.controlElementPrefix + "-htmltext");
			if (extHtmlEdit) {
				extHtmlEdit.dom.style.display = enabledInPlainTextMode ? "none" : "table-cell";
			}
			var extPlainText = Ext.get(id + "-" + this.controlElementPrefix + "-plaintext");
			if (extPlainText) {
				extPlainText.dom.style.display = !enabledInPlainTextMode ? "none" : "table-cell";
			}
		},

		/**
		 * Removes html tags from string.
		 * @private
		 * @param {String} value Html text.
		 * @return {String} Plain text string.
		 */
		removeHtmlTags: function(value) {
			/*jshint nonbsp: false*/
			value = value.replace(/\t/gi, "");
			value = value.replace(/>\s+</gi, "><");
			if (Ext.isWebKit) {
				value = value.replace(/<div>(<div>)+/gi, "<div>");
				value = value.replace(/<\/div>(<\/div>)+/gi, "<\/div>");
			}
			value = value.replace(/<div>\n <\/div>/gi, "\n");
			value = value.replace(/<p>\n/gi, "");
			value = value.replace(/<div>\n/gi, "");
			value = value.replace(/<div><br[\s\/]*>/gi, "");
			value = value.replace(/<br[\s\/]*>\n?|<\/p>|<\/div>/gi, "\n");
			value = value.replace(/<[^>]+>|<\/\w+>/gi, "");
			value = value.replace(/ /gi, " ");
			value = value.replace(/&/gi, "&");
			value = value.replace(/•/gi, " * ");
			value = value.replace(/–/gi, "-");
			value = value.replace(/"/gi, "\"");
			value = value.replace(/«/gi, "\"");
			value = value.replace(/»/gi, "\"");
			value = value.replace(/‹/gi, "<");
			value = value.replace(/›/gi, ">");
			value = value.replace(/™/gi, "(tm)");
			value = value.replace(/</gi, "<");
			value = value.replace(/>/gi, ">");
			value = value.replace(/©/gi, "(c)");
			value = value.replace(/®/gi, "(r)");
			value = value.replace(/\n*$/, "");
			value = value.replace(/(\n)( )+/, "\n");
			value = value.replace(/(\n)+$/, "");
			return value;
			/*jshint nonbsp: true*/
		},

		/**
		 * Initializes fonts.
		 * @private
		 */
		initFonts: function() {
			var toolbar = this.toolbar;
			var fontFamilyList = toolbar.fontFamily;
			var fontSizeList = toolbar.fontSize;
			fontFamilyList.on("prepareList", this.onFontFamilyPrepareList, this);
			fontFamilyList.on("change", this.onFontFamilyChange, this);
			fontSizeList.on("prepareList", this.onFontSizePrepareList, this);
			fontSizeList.on("change", this.onFontSizeChange, this);
		},

		/**
		 * Creates font family expandable list collection.
		 * @private
		 * @return {BPMSoft.Collection} Font family expandable list collection.
		 */
		createFontSizesList: function() {
			if (!Ext.isEmpty(this.fontSizesCollection)) {
				return this.fontSizesCollection;
			}
			var fontSizes = this.fontSize;
			var fontSizesArr = fontSizes.split(",");
			var fontSizesColl = this.fontSizesCollection = Ext.create("BPMSoft.Collection");
			for (var i = 0; i < fontSizesArr.length; i++) {
				var fontSize = fontSizesArr[i];
				fontSizesColl.add(i, {
					value: fontSize + "px",
					displayValue: fontSize
				});
			}
			return fontSizesColl;
		},

		/**
		 * Creates font size expandable list collection.
		 * @private
		 * @return {BPMSoft.Collection} Font size expandable list collection.
		 */
		createFontFamiliesList: function() {
			if (!Ext.isEmpty(this.fontFamilyCollection)) {
				return this.fontFamilyCollection;
			}
			var fontFamilies = this.fontFamily;
			var fontFamiliesArr = fontFamilies.split(",");
			var fontFamiliesColl = this.fontFamilyCollection = Ext.create("BPMSoft.Collection");
			for (var i = 0; i < fontFamiliesArr.length; i++) {
				var fontFamily = fontFamiliesArr[i];
				fontFamiliesColl.add(i, {
					value: fontFamily,
					displayValue: fontFamily
				});
			}
			fontFamiliesColl.sortByFn(function(elA, elB) {
				var valueA = elA.value;
				var valueB = elB.value;
				if (valueA === valueB) {
					return 0;
				}
				return (valueA < valueB) ? -1 : 1;
			});
			return fontFamiliesColl;
		},

		/**
		 * Fills font family expandable list.
		 * @private
		 */
		onFontFamilyPrepareList: function() {
			var toolbar = this.toolbar;
			var fontFamilyList = toolbar.fontFamily;
			var fontFamiliesColl = this.createFontFamiliesList();
			fontFamilyList.loadList(fontFamiliesColl);
		},

		/**
		 * Fills font size expandable list.
		 * @private
		 */
		onFontSizePrepareList: function() {
			var toolbar = this.toolbar;
			var fontSizeList = toolbar.fontSize;
			var fontSizesColl = this.createFontSizesList();
			fontSizeList.loadList(fontSizesColl);
		},

		/**
		 * Applies selected font family to editor value.
		 * @private
		 * @param {Object} fontFamilyValue Selected font family.
		 */
		onFontFamilyChange: function(fontFamilyValue) {
			if (fontFamilyValue && fontFamilyValue.customHtml && this.enabled) {
				this.defaultFontFamily = fontFamilyValue.value;
				this.applyFontStyleFamily();
			}
		},

		/**
		 * Applies selected font size to editor value.
		 * @private
		 * @param {Object} fontSizeValue Selected font size.
		 */
		onFontSizeChange: function(fontSizeValue) {
			if (fontSizeValue && fontSizeValue.customHtml && this.enabled) {
				this.defaultFontSize = fontSizeValue.value.replace("px", "");
				this.applyFontStyleSize();
			}
		},

		/**
		 * Applies font styles.
		 * @private
		 */
		applyFontStyle: function() {
			this.applyFontStyleFamily();
			this.applyFontStyleSize();
			this.applyFontStyleColor();
			this.applyFontStyleBackgroundColor();
		},

		/**
		 * Applies font family.
		 * @private
		 */
		applyFontStyleFamily: function() {
			var StyleConstructor = CKEDITOR.style;
			this.setStyle(new StyleConstructor({
				element: "span",
				styles: {
					"font-family": "#(family)"
				},
				overrides: [
					{
						element: "font",
						attributes: {
							face: null
						}
					}
				]
			}, {family: this.defaultFontFamily}));
		},

		/**
		 * Applies font size.
		 * @private
		 */
		applyFontStyleSize: function() {
			var StyleConstructor = CKEDITOR.style;
			this.setStyle(new StyleConstructor({
				element: "span",
				styles: {
					"font-size": "#(size)"
				},
				overrides: [
					{
						element: "font",
						attributes: {
							size: null
						}
					}
				]
			}, {size: this.defaultFontSize + "px"}));
		},

		/**
		 * Applies font color.
		 * @private
		 * @param {Boolean} [needFocus] Is need focus flag.
		 */
		applyFontStyleColor: function(needFocus) {
			var StyleConstructor = CKEDITOR.style;
			this.setStyle(new StyleConstructor({
				element: "span",
				styles: {
					color: "#(color)"
				},
				overrides: [
					{
						element: "font",
						attributes: {
							color: null
						}
					}
				]
			}, {color: this.defaultFontColor}), needFocus);
		},

		/**
		 * Applies font background color.
		 * @private
		 * @param {Boolean} [needFocus] Is need focus flag.
		 */
		applyFontStyleBackgroundColor: function(needFocus) {
			var StyleConstructor = CKEDITOR.style;
			this.setStyle(new StyleConstructor({
				element: "span",
				styles: {"background-color": "#(color)"},
				overrides: [
					{
						element: "font",
						attributes: {"background": null}
					}
				]
			}, {color: this.defaultHighlight}), needFocus);
		},

		/**
		 * Applies color styles.
		 * @private
		 * @param {String} color Color.
		 * @param {Boolean} [isForBackground] If true, used for background color, otherwise - for font color.
		 */
		applyColorStyles: function(color, isForBackground) {
			var useFor = (isForBackground) ? "defaultHighlight" : "defaultFontColor";
			if (color) {
				this[useFor] = color;
			}
			var needFocus = true;
			if (isForBackground) {
				this.applyFontStyleBackgroundColor(needFocus);
			} else {
				this.applyFontStyleColor(needFocus);
			}
		},

		/**
		 * Sets editor style.
		 * @private
		 * @param {Object} style Style.
		 * @param {Boolean} [needFocus] Is need focus flag.
		 */
		setStyle: function(style, needFocus) {
			var editor = this.editor;
			if (!editor.document) {
				return;
			}
			if (needFocus) {
				editor.focus();
			}
			editor.fire("saveSnapshot");
			editor.applyStyle(style);
			style.apply(editor.document);
			editor.fire("saveSnapshot");
		},

		/**
		 * Returns CKEDITOR default settings.
		 * @private
		 * @return {Object} CKEDITOR default settings.
		 */
		getEditorConfig: function() {
			/*jshint camelcase: false*/
			return {
				blockedKeystrokes: [
					0x110000 + 66, // CTRL + B
					0x110000 + 73, // CTRL + I
					0x110000 + 85 // CTRL + U
				],
				keystrokes: this.getKeyStrokes(),
				linkShowAdvancedTab: true,
				linkShowTargetTab: true,
				width: "100%",
				height: this.resizeEnabled ? this.initialHeight : "100%",
				resize_enabled: this.resizeEnabled,
				removePlugins: "magicline,elementspath,link,unlink,liststyle,scayt",
				allowedContent: true,
				pasteFromWordRemoveFontStyles: false,
				pasteFromWordRemoveStyles: false,
				enterMode: 3,
				forceEnterMode: true,
				autoUpdateElement: true,
				fillEmptyBlocks: true,
				resize_minHeight: 30,
				resize_maxHeight: 500,
				toolbar: [],
				placeholder: resources.localizableStrings.DescriptionPlaceholderCaption
			};
			/*jshint camelcase: true*/
		},

		/**
		 * Changes toolbar visibility.
		 * @private
		 * @param {Boolean} show If true, shows toolbar else hides.
		 */
		changeToolbarVisibility: function(show) {
			if (!this.rendered || !this.toolbarEl) {
				return;
			}
			var wrapElClassList = this.toolbarEl.dom.classList;
			if (show) {
				wrapElClassList.add(this.visibleToolbarClass);
			} else {
				wrapElClassList.remove(this.visibleToolbarClass);
			}
		},

		/**
		 * Checks visibility toolbar.
		 * @private
		 * @return {Boolean} Returns true, if toolbar visible.
		 */
		getVisibleToolbar: function() {
			if (this.toolbarEl) {
				var wrapElClassList = this.toolbarEl.dom.classList;
				return wrapElClassList.contains(this.visibleToolbarClass);
			} else {
				return false;
			}
		},

		/**
		 * Checks whether toolbar has expanded elements.
		 * @private
		 * @return {Boolean} Returns true, if toolbar has expanded elements.
		 */
		isToolbarHasExpandedElements: function() {
			if (!this.rendered) {
				return false;
			}
			var fontFamily = this.toolbar.fontFamily;
			var isFontFamilyVisible = fontFamily.listView ? fontFamily.listView.isVisible() : false;
			var fontSize = this.toolbar.fontSize;
			var isFontSizeVisible = fontSize.listView ? fontSize.listView.isVisible() : false;
			var fontColor = this.toolbar.fontColor;
			var isFontColorVisible = fontColor.button.menu ? fontColor.button.menu.isVisible() : false;
			var highlightColor = this.toolbar.hightlightColor;
			var isHighlightColorVisible = highlightColor.button.menu ?
				highlightColor.button.menu.isVisible() : false;
			return (isFontFamilyVisible || isFontSizeVisible || isFontColorVisible || isHighlightColorVisible);
		},

		/**
		 * Updates editor size to fit content size.
		 * @private
		 */
		_updateEditorHeight: function() {
			var maximized = this.toolbar && this.toolbar.maximized;
			if (this.editor && this.fitContent && !(maximized && maximized.pressed) && !this.destroyed) {
				var updateSizeTask = new Ext.util.DelayedTask(function() {
					var editor = this.editor;
					var memo = this.memo;
					var element = this.plainTextMode || this.getIsHtmlEditMode() ? memo.getEl() : editor && editor.editable();
					if (!element) {
						this._updateEditorHeight();
						return;
					}
					var scrollHeight = this.plainTextMode || this.getIsHtmlEditMode() ? element.dom.scrollHeight : element.$.scrollHeight;
					if (scrollHeight > 0 && scrollHeight > this.editorHeight) {
						this.editorHeight = scrollHeight;
						editor.resize("100%", scrollHeight);
					}
				}.bind(this));
				updateSizeTask.delay(this.fitContentDelay);
			}
		},

		//endregion

		//region Methods: Protected

		/**
		 * Sets value to editor.
		 * @protected
		 * @param {Object} editor Editor object.
		 * @param {String} value Editor Value value.
		 */
		setEditorValue: function(value) {
			const editor = this.editor;
			if (editor.status !== "ready") {
				return;
			}
			const editorValue = this.sanitizeValue(value);
			editor.setData(editorValue);
			this.initialValueSet = true;
			const textarea = Ext.get(editor.name);
			if (textarea) {
				textarea.set({"dataset": "true"});
			}
		},

		/**
		 * Sanitizes passed html value.
		 * @protected
		 * @param {String} value Raw html value.
		 * @return {String} Sanitized html value.
		 */
		sanitizeValue: function(value) {
			return BPMSoft.sanitizeHTML(value, this.sanitizationLevel);
		},

		/**
		 * Creates an instance of the CKEDITOR.dom.element class based on the HTML representation of an element.
		 * @protected
		 * @param {String} html The element HTML. It should define only one element in the "root" level.
		 * The "root" element can have child nodes, but not siblings.
		 * @return {CKEDITOR.dom.element} The element instance.
		 */
		createCkeditorDomElement: function(html) {
			const htmlValue = this.sanitizeValue(html);
			return CKEDITOR.dom.element.createFromHtml(htmlValue);
		},

		/**
		 * Task allowed to make debounce when using a setValue function.
		 * @protected
		 */
		setValueDebounce: null,

		/**
		 * Sets getEditor function into menu items.
		 * @protected
		 * @param {BPMSoft.Menu} menu Menu instance.
		 */
		setGetEditorFunction: function(menu) {
			menu.items.each(function(menuitem) {
				menuitem.getEditor = this.getEditor.bind(this);
				if (menuitem.menu) {
					this.setGetEditorFunction(menuitem.menu);
				}
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.controls.AbstractContainer#prepareItem
		 * @protected
		 * @overridden
		 */
		prepareItem: function(item) {
			var itemEl = this.callParent(arguments);
			if (itemEl && itemEl.menu) {
				this.setGetEditorFunction(itemEl.menu);
				this.menuItems.push(itemEl.menu);
			}
			return itemEl;
		},

		/**
		 * Returns current control ckeditor instance.
		 * @protected
		 * @return {Object} Ckeditor instance.
		 */
		getEditor: function() {
			return this.editor;
		},

		/**
		 * @inheritdoc BPMSoft.controls.Component#init
		 * @protected
		 * @overridden
		 */
		init: function() {
			this.menuItems = [];
			if (!this.validationInfo) {
				this.validationInfo = {
					isValid: true,
					invalidMessage: ""
				};
			}
			this.items = BPMSoft.deepClone(this.itemsConfig);
			this.callParent(arguments);
			this.selectors = {
				wrapEl: ""
			};
			this.images = Ext.create("BPMSoft.Collection");
			this.addEvents(
				/*
                 * @event imageLoaded
                 * Handles loading image.
                 * @param {Object} fileNames Loading file names.
                 */
				"imageLoaded",

				/*
                 * @event imagePasted
                 * Handles pasting image from buffer.
                 * @param {Object} item Pasted image.
                 */
				"imagePasted",

				/**
				 * @event focus
				 */
				"focus",
				/**
				 * @event blur
				 */
				"blur"
			);
			if (this.useVoiceToTextButton()) {
				this.mixins.voiceToTextButton.init.call(this);
			}
		},

		/**
		 * @inheritdoc BPMSoft.controls.Component#initDomEvents
		 * @protected
		 * @overridden
		 */
		initDomEvents: function() {
			this.callParent(arguments);
			var items = this.items.items;
			var fontColorButton = items[5];
			var backgroundColorButton = items[6];
			var htmlEditor = this;
			fontColorButton.on("change", function(color) {
				htmlEditor.applyColorStyles(color);
			});
			fontColorButton.button.on("click", function() {
				htmlEditor.applyColorStyles(null);
			});
			backgroundColorButton.on("change", function(color) {
				htmlEditor.applyColorStyles(color, true);
			});
			backgroundColorButton.button.on("click", function() {
				htmlEditor.applyColorStyles(null, true);
			});
			var validationInfo = this.validationInfo;
			if (!validationInfo.isValid) {
				this.showValidationMessage(validationInfo.invalidMessage);
			}
			var doc = Ext.getDoc();
			doc.on("mousedown", this.onDocumentMouseDown, this);
			if (this.useVoiceToTextButton()) {
				this.on("speechRecognitionFinished", this.voiceToTextRecognitionFinished, this);
				this.mixins.voiceToTextButton.initVoiceToTextButtonEvents.call(this);
			}

			window.addEventListener('popstate', () => {
				if (this.isFullScreenActive) {
					this.toggleFullScreanMode();
				};
			});
		},

		/**
		 * Handles voice to text recognition result.
		 * @param {String} text Recognized text.
		 * @param {Object} scope Scope.
		 */
		voiceToTextRecognitionFinished: function(text, scope) {
			let value = this.value;
			const newValue = this.formatVoiceValue(value, text);
			this.setValue(newValue);
		},

		/**
		 * Event handler for control keyDown event.
		 * @protected
		 * @param {Object} event Event keyDown.
		 */
		onHtmlEditKeyDown: function(event) {
			var data = event.data;
			if (data && data.getKey() === Ext.EventObject.TAB) {
				this.hideToolbar();
			}
		},

		/**
		 * Event handler for html edit keyUp event.
		 * @protected
		 */
		onHtmlEditKeyUp: function() {
			this._updateEditorHeight();
		},

		/**
		 * Event handler for control keyDown event.
		 * @protected
		 * @param {BPMSoft.MemoEdit} control MemoEdit.
		 * @param {Ext.EventObjectImpl} event Event keyDown.
		 */
		onMemoEditKeyDown: function(control, event) {
			if (event.getKey() === event.TAB) {
				this.hideToolbar();
			}
		},

		/**
		 * Event handler for memoedit keyUp event.
		 * @protected
		 */
		onMemoEditKeyUp: function() {
			this._updateEditorHeight();
		},

		/**
		 * Hides toolbar.
		 * @protected
		 */
		hideToolbar: function() {
			if (!this.getVisibleToolbar()) {
				return;
			}
			var isExpandedElements = this.isToolbarHasExpandedElements();
			if (!isExpandedElements) {
				this.changeToolbarVisibility(false);
			}
		},

		/**
		 * Creates combined control classes.
		 * @protected
		 * @return {Object} Combined control CSS classes.
		 */
		combineClasses: function() {
			var classes = {
				wrapClass: [],
				validationClass: ["html-edit-validation"]
			};
			var wrapClass = classes.wrapClass;
			if (!this.validationInfo.isValid) {
				wrapClass.push("html-edit-error");
			}
			return classes;
		},

		/**
		 * Creates combined control styles.
		 * @protected
		 * @return {Object} Combined control styles object.
		 */
		combineStyles: function() {
			var styles = {
				wrapStyle: {},
				inputStyle: {},
				validationStyle: {}
			};
			var validationStyle = styles.validationStyle;
			if (!this.validationInfo.isValid) {
				validationStyle.display = "block";
			}
			return styles;
		},

		/**
		 * Returns control selectors.
		 * @protected
		 * @return {Object} ###### ##########.
		 */
		combineSelectors: function() {
			var id = "#" + this.id + "-";
			var selectors = {
				wrapEl: id + this.controlElementPrefix,
				el: id + this.controlElementPrefix + "-el",
				toolbarEl: id + this.controlElementPrefix + "-toolbar",
				validationEl: id + "validation"
			};
			if (this.useVoiceToTextButton()) {
				this.mixins.voiceToTextButton.combineSelectors.call(this, selectors);
			}
			return selectors;
		},

		/**
		 * ######### CSS ##### ######## ########## # ########### ## ##### isValid:
		 * #### isValid ########## # true, ## ######### ##### ############### # ######,
		 * #### isValid ########## # false, ## ########### ##### ############### # ######.
		 * @protected
		 */
		setMarkOut: function() {
			if (!this.rendered) {
				return;
			}
			var validationEl = this.getValidationEl();
			if (!validationEl) {
				return;
			}
			var wrap = this.getWrapEl();
			var errorClass = this.errorClass;
			var validationInfo = this.validationInfo;
			validationEl.setStyle("width", "");
			if (!validationInfo.isValid) {
				wrap.addCls(errorClass);
				this.showValidationMessage(validationInfo.invalidMessage);
			} else {
				wrap.removeCls(errorClass);
				this.showValidationMessage("");
			}
			var wrapWidth = wrap.getWidth();
			var wrapHeight = wrap.getHeight();
			var validationElWidth = validationEl.getWidth();
			if (validationElWidth > wrapWidth) {
				validationEl.setWidth(wrapWidth);
			}
			validationEl.setTop(wrapHeight);
			validationEl.setVisible(!validationInfo.isValid);
		},

		/**
		 * Sets validation information for control.
		 * @protected
		 * @virtual
		 */
		setValidationInfo: function(info) {
			if (this.validationInfo === info) {
				return;
			}
			this.validationInfo = info;
			this.setMarkOut();
		},

		/**
		 * Control destroy event handler.
		 * @protected
		 * @overridden
		 */
		destroy: function() {
			if (this.editor) {
				//TODO refactor try - catch block
				try {
					this.editor.destroy();
				} catch (e) {
					delete CKEDITOR.instances[this.editor.name];
					delete this.editor;
				}
			}
			if (this.images) {
				this.images.un("dataLoaded", this.onImagesLoaded, this);
				this.images.un("add", this.onAddImage, this);
			}
			if (this.memo) {
				this.memo.un("blur", this.onMemoBlur, this);
				this.memo.un("focus", this.onFocus, this);
				this.memo.un("keydown", this.onMemoEditKeyDown, this);
				this.memo.un("keyup", this.onMemoEditKeyUp, this);
				delete this.demo;
			}
			if (this.toolbar) {
				delete this.toolbar;
			}
			this.callParent(arguments);
		},

		/**
		 * ############ ###### ### #########.
		 * @protected
		 * @overridden
		 * throws {BPMSoft.ItemNotFoundException}
		 * ### #######, #### ##### ############ ## ##### ####### ########## ############, ##
		 * ##### ############# ######, ####### ##### ########## # XTemplate, ####### ########### ###### ##########
		 * ### ###### - ########## # #####.
		 */
		getTplData: function() {
			var tplData = this.callParent(arguments);
			var controlTplData = this.tplData;
			var classes = controlTplData.classes;
			var styles = controlTplData.styles;
			var htmlEditStyle = styles.htmlEditStyle;
			if (this.height) {
				htmlEditStyle.height = this.height;
			}
			if (this.resizeEnabled) {
				delete htmlEditStyle.height;
			}
			if (this.width) {
				htmlEditStyle.width = this.width;
			}
			if (this.margin) {
				htmlEditStyle.margin = this.margin;
			}
			tplData.htmlEditClass = classes.htmlEditClass;
			tplData.htmlEditToolbarClass = classes.htmlEditToolbarClass;
			tplData.htmlEditToolbarTopClass = classes.htmlEditToolbarTopClass;
			tplData.htmlEditToolbarButtonGroupClass = classes.htmlEditToolbarButtonGroupClass;
			tplData.htmlEditTextareaClass = classes.htmlEditTextareaClass;
			tplData.htmlEditStyle = styles.htmlEditStyle;
			tplData.htmlEditFontFamilyStyle = styles.htmlEditFontFamilyStyle;
			tplData.htmlEditFontSizeStyle = styles.htmlEditFontSizeStyle;
			tplData.renderVoiceToTextButton = this.renderVoiceToTextButton || Ext.emptyFn;
			Ext.apply(tplData, this.combineClasses(), {});
			this.styles = this.combineStyles();
			this.selectors = this.combineSelectors();
			return tplData;
		},

		/**
		 * Event handler "afterrender".
		 * @protected
		 * @overridden
		 */
		onAfterRender: function() {
			this.callParent(arguments);
			this.initControls();
			this.initCKEDITOR();
		},

		/**
		 * Event handler "afterrerender".
		 * @protected
		 * @overridden
		 */
		onAfterReRender: function() {
			this.callParent(arguments);
			this.initControls();
			this.initCKEDITOR();
		},

		/**
		 * ########## ############ ######## # ######. ######### ######### ####### {@link BPMSoft.Bindable}.
		 * @protected
		 * @overridden
		 */
		getBindConfig: function() {
			var bindConfig = this.callParent(arguments);
			var editorBindConfig = {
				value: {
					changeMethod: "onChangeValue",
					changeEvent: "changeValue",
					validationMethod: "setValidationInfo"
				},
				plainTextValue: {
					changeEvent: "changePlainTextValue"
				},
				plainTextMode: {
					changeMethod: "onChangePlainTextMode",
					changeEvent: "changePlainTextMode"
				},
				enabled: {
					changeMethod: "onChangeEnabled",
					changeEvent: "changeEnabled"
				},
				focused: {
					changeEvent: "focusChanged"
				},
				initialHeight: {
					changeMethod: "onGetInitialHeight"
				},
				images: {
					changeMethod: "onImagesLoaded"
				},
				sanitizationLevel: {
					changeMethod: "sanitizationLevelChanged"
				},
				htmlEditEnabled: {
					changeMethod: "onHtmlEditEnabledChanged"
				}
			};
			Ext.apply(editorBindConfig, bindConfig);
			return editorBindConfig;
		},

		/**
		 * Handles html edit mode enabled.
		 * @param {Boolean} enabled Is html edit mode enabled.
		 */
		onHtmlEditEnabledChanged: function(enabled) {
			this.htmlEditModeEnabled = Boolean(enabled);
		},

		/**
		 * ########## ####### "onChangeValue".
		 * @protected
		 * @param {String} value ############### ########.
		 */
		onChangeValue: function(value) {
			this.setValue(value);
		},

		/**
		 * ########## ####### "onChangePlainTextMode".
		 * @protected
		 * @param {Boolean} value ############### ########.
		 */
		onChangeEnabled: function(value) {
			this.setEnabled(value);
		},

		/**
		 * "initialHeight" property change event handler.
		 * @protected
		 * @param {Boolean} value New property value.
		 */
		onGetInitialHeight: function(value) {
			this.initialHeight = value;
		},

		/**
		 * "sanitizationLevel" property change event handler.
		 * @protected
		 * @param {Boolean} value New property value.
		 */
		sanitizationLevelChanged: function(value) {
			this.sanitizationLevel = value;
		},

		/**
		 * ########## ####### "onChangePlainTextMode".
		 * @protected
		 * @param {Boolean} value ############### ########.
		 */
		onChangePlainTextMode: function(value) {
			this.changeEditorMode(value);
		},

		/**
		 * ######## ######## ######## ##########.
		 * @protected
		 */
		getEditorValue: function() {
			var editor = this.editor;
			if (!this.editor) {
				return this.value;
			}
			if (this.plainTextMode) {
				var plainText = editor.getData();
				return this.removeHtmlTags(plainText);
			} else {
				return editor.getData();
			}
		},

		/**
		 * Get editor value with html tags.
		 * @protected
		 * @return {String} Editor with html tags.
		 */
		getEditorValueWithHtmlTags: function() {
			var editor = this.editor;
			if (!this.editor) {
				return this.value;
			}
			return editor.getData();
		},

		/**
		 * Open modal window for insert link.
		 * @protected
		 */
		showLinkInputBox: function() {
			var me = this;
			var editor = this.editor;
			var selection = editor.getSelection();
			let saveCaption = resources.localizableStrings.PopupSaveButton;
			let cancelCaption = resources.localizableStrings.PopupCancelButton;
			var inputBoxConfig = {
				link: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					caption: resources.localizableStrings.HyperlinkAddress
				}
			};
			var selectedElement = selection.getSelectedElement();
			var isImageElement = selectedElement && selectedElement.$ && selectedElement.$.nodeName === "IMG";
			if (!isImageElement) {
				var selectedText = selection.getSelectedText() || "";
				Ext.apply(inputBoxConfig, {
					linkText: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						caption: resources.localizableStrings.HyperlinkText,
						value: selectedText,
						customConfig: {
							markerValue: "linktextedit"
						}
					},
					linkColor: {
						dataValueType: BPMSoft.DataValueType.COLOR,
						caption: resources.localizableStrings.HyperlinkColor,
						customConfig: {
							className: "BPMSoft.ColorButton",
							markerValue: "linkcoloredit",
							menuItemClassName: BPMSoft.MenuItemType.COLOR_PICKER,
							defaultValue: "#0000EE"
						}
					}
				});
			}
			BPMSoft.utils.inputBox(
				resources.localizableStrings.HyperlinkDialogCaption,
				me.insertHyperLink,
				[{
					className: "BPMSoft.Button",
					returnCode: "ok",
					caption: saveCaption,
					classes: {
						textClass: ["html-button-save"]
					},
				}, {
					className: "BPMSoft.Button",
					returnCode: "cancel",
					style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
					caption: cancelCaption,
					classes: {
						textClass: ["html-button-cancel"]
					},
				},],
				this,
				inputBoxConfig,
				{
					defaultButton: 0,
					customWrapClass: isImageElement ? "" : "html-link-popup"
				}
			);
		},

		/**
		 * Maximaze CKEditor to full screen mode.
		 * @protected
		 */
		toggleFullScreanMode: function() {
			this.isFullScreenActive = !this.isFullScreenActive;

			var editor = this.editor;
			if (!editor) {
				return;
			}
			editor.execCommand("maximize");
			var body = editor.editable();
			var bodyDom = body.$;
			var document = editor.document;
			var head = document.getHead();
			var toolbarEl = this.toolbarEl;
			var hasCls = toolbarEl.hasCls("html-edit-toolbar-maximized");
			if (hasCls) {
				toolbarEl.removeCls("html-edit-toolbar-maximized");
				body.removeClass("cke_editable_maximized");
			} else {
				toolbarEl.addCls("html-edit-toolbar-maximized");
				body.addClass("cke_editable_maximized");
				toolbarEl.setWidth(bodyDom.clientWidth);
				var styleTpl = "body.cke_editable_maximized { padding-top: {0}px; max-height: {1}px;}";
				var toolbarHeight = toolbarEl.getHeight();
				var style = head.append("style");
				style.appendText(Ext.String.format(styleTpl, toolbarHeight, bodyDom.parentElement.clientHeight - toolbarHeight));
			}
			this.toolbar.maximized.setPressed(!hasCls);
		},

		/**
		 * Inserts hyperlink in editor.
		 * @protected
		 */
		insertHyperLink: function(returnCode, controlData) {
			if (returnCode === "ok") {
				var link = controlData.link.value;
				var linkText = controlData.linkText && controlData.linkText.value || link;
				var linkColor = controlData.linkColor && controlData.linkColor.value || "#0000EE";
				var editor = this.editor;
				this.fixCursorInitPosition();
				if (link) {
					var attributes = {};
					link = BPMSoft.addProtocolPrefix(link);
					attributes.href = link;
					attributes.title = link;
					attributes.target = "_blank";
					attributes["data-cke-saved-href"] = linkText ? linkText : link;
					var selection = editor.getSelection();
					var element = selection.getStartElement();
					if (element.$.tagName === "A") {
						element.setAttributes(attributes);
					} else {
						var ranges = selection.getRanges(true);
						if (ranges.length === 1) {
							var selectedElement = selection.getSelectedElement() && selection.getSelectedElement().$;
							var isImageElement = selectedElement && selectedElement.nodeName === "IMG";
							var linkHtmlTpl = isImageElement
								? "<a target=\"_blank\" href=\"{0}\" title=\"{1}\">{2}</a>"
								: "<a target=\"_blank\" href=\"{0}\" title=\"{1}\" style=\"color: {3}\"><span>{2}</span></a>";
							if (isImageElement) {
								linkText = selectedElement.outerHTML;
							}
							var linkHtml = Ext.String.format(linkHtmlTpl, link, link, linkText, linkColor);
							var linkNode = this.createCkeditorDomElement(linkHtml);
							var range = ranges[0];
							if (!range.collapsed) {
								range.deleteContents();
							}
							range.insertNode(linkNode);
							range.selectNodeContents(linkNode);
							selection.selectRanges(ranges);
						}
					}
					editor.updateElement();
					editor.focus();
				}
			}
		},

		/**
		 * Event handler for control selectionchange event.
		 * @protected
		 * @param {Object} event Event object.
		 */
		onSelectionChange: function(event) {
			var elementPath = event.data.path;
			var elements = elementPath.elements;
			var selectionStyles = this.getControlsStateByTextStyle(elements);
			this.updateControlsStateByTextStyle(selectionStyles);
		},

		/**
		 * Event handler for control focus event.
		 * @protected
		 */
		onFocus: function() {
			if (!this.enabled || !this.rendered) {
				return;
			}
			this.focused = true;
			this.fireEvent("focus", this);
			this.fireEvent("focusChanged", this);
			this.changeToolbarVisibility(true);
			BPMSoft.each(this.menuItems, function(menu) {
				menu.hide();
			});
		},

		/**
		 * Event handler for control blur event.
		 * @protected
		 */
		onBlur: function() {
			if (!this.enabled || !this.rendered) {
				return;
			}
			this.focused = false;
			this.fireEvent("blur", this);
			this.fireEvent("focusChanged", this);
			this.setValue(this.getEditorValue());
		},

		/**
		 * Event handler for control click event.
		 * @protected
		 * @param {Object} event Event object.
		 */
		onClick: function(event) {
			var eventData = event.data;
			var target = eventData.getTarget();
			var targetPath = new CKEDITOR.dom.elementPath(target, this.editor);
			var link = targetPath.contains("a");
			if (eventData.$.ctrlKey && link && link.hasAttribute("href")) {
				eventData.preventDefault();
				var href = link.getAttribute("href");
				window.open(href, "_blank");
			}
		},

		/**
		 * Event handler for control doubleclick event.
		 * @protected
		 * @param {Object} event Event object.
		 */
		onDoubleClick: function(event) {
			var eventData = event.data;
			var target = eventData.element;
			var targetPath = new CKEDITOR.dom.elementPath(target, this.editor);
			var link = targetPath.contains("a");
			if (link && link.hasAttribute("href")) {
				event.cancel();
			}
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
		 * ######### ######## ######## ####### ####### {@link BPMSoft.Bindable} ####### # ######## ####
		 * ##########.
		 * @protected
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
		 * Initializes toolbar panel tools.
		 * @protected
		 * @virtual
		 * @param {Object} toolbar Toolbar panel tools.
		 */
		initToolbarItems: function(toolbar) {
			var image = toolbar.image;
			if (!BPMSoft.isEmptyObject(image)) {
				image.un("filesSelected", this.onFilesSelected);
				image.on("filesSelected", this.onFilesSelected, this);
			}
			this.toolbar = toolbar;
		},

		/**
		 * Initialize memo edit instance.
		 * @protected
		 * @virtual
		 * @param {Object} memo Memo edit instance.
		 */
		initMemo: function(memo) {
			memo.height = this.fitContent ? undefined : memo.height;
			memo.on("blur", this.onMemoBlur, this);
			memo.on("focus", this.onFocus, this);
			memo.on("keydown", this.onMemoEditKeyDown, this);
			memo.on("keyup", this.onMemoEditKeyUp, this);
			this.memo = memo;
		},

		/**
		 * ######### ######## ########## ######## ##########.
		 * @protected
		 * @overridden
		 * @param {Boolean} enabled #######.
		 */
		setEnabled: function(enabled) {
			if (enabled !== this.enabled) {
				this.enabled = enabled;
				this.fireEvent("changeEnabled", enabled, this);
				var editor = this.editor;
				if (editor && editor.loaded) {
					this.updateToolbar();
				}
			}
		},

		/**
		 * ########## ########## ###### ### CKEDITOR.
		 * @protected
		 * @return {Array} ########## ###### ### CKEDITOR.
		 */
		getKeyStrokes: function() {
			return [
				[CKEDITOR.CTRL + 75, "openlinkmodalwindow"] // CTRL + K
			];
		},

		/**
		 * @inheritdoc BPMSoft.Component#clearDomListeners
		 * @overridden
		 */
		clearDomListeners: function() {
			this.callParent(arguments);
			var doc = Ext.getDoc();
			doc.un("mousedown", this.onDocumentMouseDown, this);
		},

		/**
		 * Updates  editor size after image pasted.
		 * @protected
		 */
		afterImageInserted: function() {
			this._updateEditorHeight();
		},

		/**
		 * Sets content styles that applied not for all rich text editor controls, and need to be overriten in some cases.
		 * @protected
		 * @virtual
		 */
		setAdditionalContentStyles: function() {
			const iframe = this.editor.document.$;
			iframe.head.querySelector(".email-styles")?.remove();
			const style = iframe.createElement('style');
			style.type = 'text/css';
			style.innerHTML = 'body.cke_editable p { margin: revert; }';
			style.classList =['email-styles'];
			iframe.head.appendChild(style);
		},

		//endregion

		//region Methods: Public

		/**
		 * Returns component validation DOM element reference (see {@link #el el}).
		 * @return {Ext.Element}
		 */
		getValidationEl: function() {
			return this.validationEl;
		},

		/**
		 * Inserts validation text into validation DOM-element {@link #el}.
		 * @param message Validation text.
		 * @return {Ext.Element}
		 */
		showValidationMessage: function(message) {
			this.validationEl.dom.innerHTML = message;
		},

		/**
		 * Loads images to html edit.
		 * @param {Array} files Files array.
		 */
		onFilesSelected: function(files) {
			var invalidFilesType = false;
			for (var i = 0; i < files.length; i++) {
				if (!this.imageRegexPattern.test(files[i].type)) {
					invalidFilesType = true;
				}
			}
			if (!invalidFilesType) {
				this.fireEvent("imageLoaded", files);
			} else {
				BPMSoft.showInformation(resources.localizableStrings.InvalidFileTypeMessage);
			}
		},

		//endregion

	});

	return BPMSoft.HtmlEdit;
});
