define("SmartHtmlSourceCodeEdit", ["ext-base", "CSSLint", "HTMLHint", "SourceCodeEditEnums", "AceEdit",
		"css!SourceCodeEdit", "SourceCodeEdit", "css!SmartHtmlSourceCodeEdit"], function(Ext) {
	/**
	 * @class BPMSoft.configuration.SmartHtmlSourceCodeEdit
	 * Class for editing smart HTML source codes.
	 */
	Ext.define("BPMSoft.configuration.SmartHtmlSourceCodeEdit", {
		extend: "BPMSoft.SourceCodeEdit",
		alternateClassName: "BPMSoft.SmartHtmlSourceCodeEdit",
		mixins: {
			menuMixin: "BPMSoft.MenuMixin"
		},

		/**
		 * Rules for HTMLHint and CSSLint validators.
		 * @protected
		 */
		htmlHintRules: {
			"tag-pair": true,
			"tag-self-close": true,
			"spec-char-escape": true,
			"csslint": {
				"known-properties": true
			}
		},

		/**
		 * Ace worker usage.
		 * @override
		 */
		useWorker: false,

		/**
		 * Flag that controls IntelliSense.
		 * @override
		 */
		enableLiveAutocompletion: false,

		/**
		 * Selected text from ace session.
		 * @type {String}
		 */
		selectedText: "",

		/**
		 * CSS class for selected macro.
		 * @type {String}
		 */
		selectionMarkerClass: "smart-html-macro-selected",

		/**
		 * Menu with available actions to create macro.
		 * @type {Object}
		 */
		macrosMenu: {
			items: []
		},

		/**
		 * Start position of selection marker. The same as macro start position.
		 * @type {*|{
		 *     row: Number,
		 *     column: Number
		 * }}
		 */
		selectionMarkerPos: null,

		/**
		 * Ace Range type.
		 * @private
		 */
		range: null,

		/**
		 * @private
		 */
		_replaceSelectionWithMacro: function(macroText) {
			if (!this.selectedText) {
				return;
			}
			var editor = this.aceEdit;
			editor.session.replace(editor.selection.getRange(), macroText);
			this.setValue(editor.getValue());
		},

		/**
		 * @private
		 */
		_replaceSourceText: function(config) {
			var editor = this.aceEdit;
			editor.replaceAll(config.newText, {
				needle: config.oldText,
				caseSensitive: true
			});
			this.setValue(editor.getValue());
		},

		/**
		 * @private
		 */
		_selectMacro: function(config) {
			var editor = this.aceEdit;
			if (config) {
				this._removeMarkerByClass(this.selectionMarkerClass);
				editor.find(config.Text);
				this._addSelectionMarker(editor.getSelectionRange(), true);
			}
		},

		/**
		 * @private
		 */
		_goToNextAnnotation: function() {
			var editor = this.aceEdit;
			var hints = editor.getSession().getAnnotations();
			if (hints.length > 0) {
				var cursor = editor.selection.getCursor();
				for (var i = 0; i < hints.length; i++) {
					var hint = hints[i];
					if (hint.type !== "error") {
						continue;
					}
					var hintRow = hint.row;
					var hintCol = hint.column;
					if (hintRow > cursor.row || (hintRow === cursor.row && hintCol > cursor.column)) {
						editor.moveCursorTo(hintRow, hintCol);
						editor.selection.clearSelection();
						editor.renderer.scrollToRow(hintRow);
						break;
					}
				}
			}
		},

		/**
		 * @private
		 */
		_goToPrevAnnotation: function() {
			var editor = this.aceEdit;
			var hints = editor.getSession().getAnnotations();
			if (hints.length > 0) {
				var cursor = editor.selection.getCursor();
				for (var i = hints.length - 1; i >= 0; i--) {
					var hint = hints[i];
					if (hint.type !== "error") {
						continue;
					}
					var hintRow = hint.row;
					var hintCol = hint.column;
					if (hintRow < cursor.row || (hintRow === cursor.row && hintCol < cursor.column)) {
						editor.moveCursorTo(hintRow, hintCol);
						editor.selection.clearSelection();
						editor.renderer.scrollToRow(hintRow);
						break;
					}
				}
			}
		},

		/**
		 * @private
		 */
		_addHighlightRule: function (rule) {
			var session = this.aceEdit.getSession();
			var rules = session.$mode.$highlightRules.getRules();
			var rulesChanged = false;
			for (var stateName in rules) {
				if (rules.hasOwnProperty(stateName)) {
					var existedRuleIndex = rules[stateName].findIndex(function(x) {
						return x.token === rule.token;
					});
					if (existedRuleIndex === -1) {
						rules[stateName].unshift(rule);
						rulesChanged = true;
					} else {
						return;
					}
				}
			}
			if (rulesChanged) {
				session.$mode.$tokenizer = null;
				var tokenizer = session.$mode.getTokenizer();
				session.bgTokenizer.setTokenizer(tokenizer);
				session.bgTokenizer.start(0);
			}
		},

		/**
		 * @private
		 */
		_breakEvent: function(event) {
			event.preventDefault();
			event.stopPropagation();
		},

		/**
		 * @private
		 */
		_isNumberBetween: function(number, a, b) {
			var min = Math.min(a, b);
			var max = Math.max(a, b);
			return number > min && number < max;
		},

		/**
		 * Returns true if any of args is truthy.
		 * @private
		 * @param {Array} args An array of truthy or falsy objects.
		 * @returns {Boolean}
		 */
		_isAny: function(args) {
			if (!Array.isArray(args)) {
				return false;
			}
			return args.some(function(x) { return !!x; });
		},

		/**
		 * Returns true if all of args are truthy.
		 * @private
		 * @param {Array} args An array of truthy or falsy objects.
		 * @returns {Boolean}
		 */
		_isEvery: function(args) {
			if (!Array.isArray(args)) {
				return false;
			}
			return args.every(function(x) { return !!x; });
		},

		/**
		 * Returns state of macro at the specified position.
		 * @private
		 * @param {{row: Number, column: Number}} position Position to check.
		 * @returns {{
		 *      isCursorBeforeMacro: Boolean,
		 *      isCursorIntoMacro: Boolean,
		 *      isCursorAfterMacro: Boolean
		 * }}
		 */
		_getMacroStateAtPos: function(position) {
			var editor = this.aceEdit;
			var lineText = editor.selection.doc.$lines[position.row];
			var isIntoMacro = false;
			var isBeforeMacro = false;
			var isAfterMacro = false;
			var macrosIterator = lineText.matchAll(new RegExp("{{#\\d+::.*?#}}", "g"));
			var macroStart, macroEnd = null;
			var macro = macrosIterator.next();
			while (!this._isAny([macro.done, isIntoMacro, isBeforeMacro, isAfterMacro])) {
				macroStart = macro.value.index;
				macroEnd = macroStart + macro.value[0].length;
				isIntoMacro = this._isNumberBetween(position.column, macroStart, macroEnd);
				isBeforeMacro = position.column === macroStart;
				isAfterMacro = position.column === macroEnd;
				macro = macrosIterator.next();
			}
			var result = {
				"isCursorIntoMacro": isIntoMacro,
				"isCursorBeforeMacro": isIntoMacro ? false : isBeforeMacro,
				"isCursorAfterMacro": isIntoMacro ? false : isAfterMacro
			};
			if (this._isAny([isIntoMacro, isBeforeMacro, isAfterMacro])) {
				result.macroRange = new this.range(position.row, macroStart, position.row, macroEnd);
			}
			return result;
		},

		/**
		 * Returns state of macro under cursor or selection anchor.
		 * @private
		 * @returns {{
		 *      isCursorBeforeMacro: *,
		 *      isCursorIntoMacro: (boolean|*),
		 *      isCursorAfterMacro: *,
		 *      macroRange: *,
		 *      hasSelection: boolean
		 * }}
		 */
		_getMacroState: function() {
			var editor = this.aceEdit;
			var cursorState = this._getMacroStateAtPos(editor.selection.getCursor());
			if (editor.selection.$isEmpty || !editor.getSelectedText()) {
				return cursorState;
			}
			var anchorState = this._getMacroStateAtPos(editor.selection.anchor);
			return {
				"isCursorIntoMacro": cursorState.isCursorIntoMacro || anchorState.isCursorIntoMacro,
				"isCursorBeforeMacro": cursorState.isCursorBeforeMacro || anchorState.isCursorBeforeMacro,
				"isCursorAfterMacro": cursorState.isCursorAfterMacro || anchorState.isCursorAfterMacro,
				"hasSelection": true,
				"macroRange": cursorState.macroRange
			};
		},

		/**
		 * Removes first background marker found by CSS class name.
		 * @param {String} markerClass CSS class name.
		 * @private
		 */
		_removeMarkerByClass: function(markerClass) {
			var editor = this.aceEdit;
			var markers = editor.session.getMarkers();
			for(var marker in markers) {
				if (markers.hasOwnProperty(marker) && markers[marker].clazz === markerClass) {
					editor.session.removeMarker(markers[marker].id);
				}
			}
		},

		/**
		 * Draw selection marker for macro under cursor.
		 * @private
		 */
		_addSelectionMarker: function(range, needClearSelection) {
			if (!range) {
				return;
			}
			var editor = this.aceEdit;
			editor.session.addMarker(range, this.selectionMarkerClass, "text");
			this.selectionMarkerPos = range.start;
			if (needClearSelection) {
				editor.selection.clearSelection();
			}
		},

		/**
		 * Update view under cursor, while it's position is into the macro.
		 * @private
		 */
		_onAceCursorChange: function() {
			var state = this._getMacroState();
			if (this.selectionMarkerPos) {
				var row = this.selectionMarkerPos.row;
				var column = this.selectionMarkerPos.column;
				if (state.macroRange && state.macroRange.contains(row, column)) {
					return;
				}
				this._removeMarkerByClass(this.selectionMarkerClass);
				this.selectionMarkerPos = null;
			}
			if (state.isCursorIntoMacro) {
				this._addSelectionMarker(state.macroRange);
				var macroText = this.aceEdit.session.getTextRange(state.macroRange);
				this.fireEvent("macroselected", macroText, this);
			}
		},

		/**
		 * Defines if ace command is allowed to propagate.
		 * @param cmd
		 * @returns {boolean}
		 * @private
		 */
		_isAceCommandAllowed: function(cmd) {
			var allowedCommands = [
				"selectOrFindNext",
				"selectOrFindPrevious",
				"selectall",
				"gotoline",
				"fold",
				"unfold",
				"undo",
				"redo",
				"toggleFoldWidget",
				"toggleParentFoldWidget",
				"foldOther",
				"unfoldall",
				"findnext",
				"findprevious",
				"selectOrFindNext",
				"selectOrFindPrevious",
				"find",
				"selecttostart",
				"gotostart",
				"selectup",
				"golineup",
				"selecttoend",
				"gotoend",
				"selectdown",
				"golinedown",
				"selectwordleft",
				"gotowordleft",
				"selecttolinestart",
				"gotolinestart",
				"selectleft",
				"gotoleft",
				"selectwordright",
				"gotowordright",
				"selecttolineend",
				"gotolineend",
				"selectright",
				"gotoright",
				"selectpagedown",
				"gotopagedown",
				"selectpageup",
				"gotopageup",
				"scrollup",
				"scrolldown",
				"selectlinestart",
				"selectlineend"
			];
			return allowedCommands.indexOf(cmd) !== -1;
		},

		/**
		 * Handler on ace exec event.
		 * @private
		 */
		_onAceCommandExecute: function(e) {
			var editor = this.aceEdit;
			var cmd = e.command.name;
			if (cmd === "alignCursors") {
				this._breakEvent(e);
			}
			if (editor.selection.ranges.length > 1) {
				editor.selection.toSingleRange();
				this._breakEvent(e);
				return;
			}
			var state = this._getMacroState();
			if (state.isCursorIntoMacro) {
				if (!this._isAceCommandAllowed(cmd)) {
					this._breakEvent(e);
				}
				return;
			}
			if (state.hasSelection) {
				return;
			}
			switch(true) {
				case this._isEvery([cmd === "del", state.isCursorBeforeMacro]):
				case this._isEvery([cmd === "backspace", state.isCursorAfterMacro]):
					editor.selection.setRange(state.macroRange);
					this._breakEvent(e);
					break;
				case this._isEvery([cmd === "insertstring", editor.getOverwrite(), state.isCursorBeforeMacro]):
					this._breakEvent(e);
					break;
			}
		},

		/**
		 * @inheritdoc BPMSoft.Component#init
		 * @override
		 */
		init: function(callback, scope) {
			this.callParent([function() {
				this.aceEdit.session.setUseWrapMode(true);
				Ext.callback(callback, scope);
			}, scope]);
			this.addEvents("selectedtextchanged", "macroselected", "annotationschanged");
		},

		/**
		 * @override
		 */
		initAceEdit: function(ace) {
			this.callParent(arguments);
			this.range = ace.require('ace/range').Range;
			this.aceEdit.setOptions({
				enableMultiselect: false,
				mergeUndoDeltas: false,
				useWorker: this.useWorker,
				dragEnabled: false
			});
			this._addHighlightRule({
				token: "smart-html-macro",
				regex: /{{#\d+::.*?#}}/
			});
		},

		/**
		 * @inheritdoc BPMSoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
			this.on("replacewithmacro", this._replaceSelectionWithMacro, this);
			this.on("replacemacro", this._replaceSourceText, this);
			this.on("selectmacro", this._selectMacro, this);
			this.on("nextannotation", this._goToNextAnnotation, this);
			this.on("prevannotation", this._goToPrevAnnotation, this);
		},

		/**
		 * Initializes menu with macros.
		 * @protected
		 */
		initMacrosMenu: function() {
			this.menu = BPMSoft.deepClone(this.macrosMenu);
			this.mixins.menuMixin.init.call(this);
		},

		/**
		 * @inheritdoc BPMSoft.Component#onAfterRender
		 * @override
		 */
		onAfterRender: function() {
			this.callParent(arguments);
			var editor = this.aceEdit;
			editor.container.addEventListener("contextmenu", this.onContextMenu.bind(this), false);
			editor.container.addEventListener("drop", this.onDrop.bind(this));
		},

		/**
		 * Updates list of editors annotations depends on html and css code validation results.
		 * @protected
		 */
		setAnnotations: function() {
			var editor = this.aceEdit;
			var sourceCode = editor.getValue();
			var messages = HTMLHint.verify(sourceCode, this.htmlHintRules);
			var annotations = new BPMSoft.Collection();
			for(var i = 0, l = messages.length; i < l; i++) {
				var msg = messages[i];
				var annotation = {
					"row": msg.line - 1,
					"column": msg.col - 1,
					"text": msg.message,
					"type": msg.type,
					"raw": msg.raw
				};
				annotations.add(annotation);
			}
			editor.getSession().setAnnotations(annotations.getItems());
			var errors = annotations.filterByFn(function(x) {
				return x.type === "error";
			}, this);
			this.fireEvent("annotationschanged", errors, this);
		},

		/**
		 * Handler on context menu show event.
		 * @protected
		 * @param {DOMEvent} e Context menu show event.
		 */
		onContextMenu: function(e) {
			this._breakEvent(e);
			if (!this.selectedText || this.aceEdit.selection.rangeCount > 1) {
				return false;
			}
			var macroState = this._getMacroState();
			if (macroState.isCursorIntoMacro) {
				return false;
			}
			this.fireEvent("selectedtextchanged", this.selectedText, this);
			this.initMacrosMenu();
			var textArea = Ext.get(e.target);
			this.showMenu(textArea);
		},

		/**
		 * Handler on drop event.
		 * @protected
		 * @param {DOMEvent} event Drop event info.
		 */
		onDrop: function(event) {
			var editor = this.aceEdit;
			var dropText = event.dataTransfer.getData('Text').replace(/\s/gm, "");
			var selection = editor.getSelectedText().replace(/\s/gm, "");
			if (dropText === selection) {
				editor.remove();
			}
			this._breakEvent(event);
		},

		/**
		 * @inheritdoc BPMSoft.SourceCodeEdit#intiAceEditEvents
		 * @override
		 */
		intiAceEditEvents: function() {
			this.callParent(arguments);
			var editor = this.aceEdit;
			editor.on("changeSelection", this.onAceSelectionChange.bind(this));
			editor.selection.on("changeCursor", this._onAceCursorChange.bind(this));
			editor.commands.on("exec", this._onAceCommandExecute.bind(this));
			var debounceTimer;
			editor.renderer.on('afterRender', function() {
				clearTimeout(debounceTimer);
				debounceTimer = setTimeout(this.setAnnotations.bind(this), 200);
			}.bind(this));
		},

		/**
		 * @inheritdoc BPMSoft.Component#getBindConfig
		 * @override
		 */
		getBindConfig: function() {
			var bindConfig = this.callParent(arguments);
			Ext.apply(bindConfig, {
				selectedText: {
					changeEvent: "selectedtextchanged"
				},
				macrosMenu: {
					changeMethod: "updateMacrosMenu"
				}
			});
			return bindConfig;
		},

		/**
		 * Handler on macros menu change event.
		 * @protected
		 * @param {Object} menuConfig New menu config value.
		 */
		updateMacrosMenu: function(menuConfig) {
			this.macrosMenu = menuConfig;
		},

		/**
		 * Handler on selected text change event.
		 * @protected
		 * @param {String} selectedText New selected text value.
		 */
		updateSelectedText: function(selectedText) {
			if (this.selectedText !== selectedText) {
				this.selectedText = selectedText;
			}
		},

		/**
		 * @inheritdoc BPMSoft.SourceCodeEdit#onAceSelectionChange
		 * @override
		 */
		onAceSelectionChange: function() {
			this.callParent(arguments);
			var editor = this.aceEdit;
			var selectedText = editor.getSelectedText();
			this.updateSelectedText(selectedText);
		},

		/**
		 * @inheritdoc BPMSoft.Component#clearDomListeners
		 * @override
		 */
		clearDomListeners: function() {
			var editor = this.aceEdit;
			if (this.isAceInitialized) {
				editor.off("changeSelection", this.onAceSelectionChange);
				editor.selection.off("changeCursor", this._onAceCursorChange);
				editor.commands.off("exec", this._onAceCommandExecute);
				editor.container.removeEventListener("contextmenu", this.onContextMenu, false);
				editor.container.removeEventListener("drop", this.onDrop, false);
			}
			this.un("replacewithmacro", this._replaceSelectionWithMacro, this);
			this.un("replacemacro", this._replaceSourceText, this);
			this.un("selectmacro", this._selectMacro, this);
			this.callParent(arguments);
		}
	});
});
