Ext.ns("BPMSoft.ContentBuilder.enums");
Ext.ns("BPMSoft.ContentBuilder.constants");

/**
 * Represents string representation of drop group name for element.
 * @type {string}
 */
BPMSoft.ContentBuilder.constants.ElementDropGroup = "ContentColumn";

/**
 * Contains all content builder body types with string representation and name for mapping in mjml config.
 */
BPMSoft.ContentBuilder.enums.BodyItemType = {
	sheet: {
		value: "sheet",
		mjmlValue: "mj-body"
	},
	mjblock: {
		value: "mjblock",
		mjmlValue: "mj-wrapper"
	},
	section: {
		value: "section",
		mjmlValue: "mj-section"
	},
	mjgroup: {
		value: "mjgroup",
		mjmlValue: "mj-group"
	},
	column: {
		value: "column",
		mjmlValue: "mj-column"
	},
	mjraw: {
		value: "mjraw",
		mjmlValue: "mj-raw"
	},
	text: {
		value: "text",
		mjmlValue: "mj-text"
	},
	image: {
		value: "image",
		mjmlValue: "mj-image"
	},
	mjbutton: {
		value: "mjbutton",
		mjmlValue: "mj-button"
	},
	mjhero: {
		value: "mjhero",
		mjmlValue: "mj-hero"
	},
	mjimage: {
		value: "mjimage",
		mjmlValue: "mj-image"
	},
	separator: {
		value: "separator",
		mjmlValue: "mj-divider"
	},
	mjdivider: {
		value: "mjdivider",
		mjmlValue: "mj-divider"
	},
	table: {
		value: "table",
		mjmlValue: "mj-table"
	},
	spacer: {
		value: "spacer",
		mjmlValue: "mj-spacer"
	},
	navbar: {
		value: "navbar",
		mjmlValue: "mj-navbar"
	},
	navbarlink: {
		value: "navbarlink",
		mjmlValue: "mj-navbar-link"
	},
	carousel: {
		value: "carousel",
		mjmlValue: "mj-carousel"
	},
	carouselImage: {
		value: "carouselImage",
		mjmlValue: "mj-carousel-image"
	},
	accordion: {
		value: "accordion",
		mjmlValue: "mj-accordion"
	},
	accordionElement: {
		value: "accordionElement",
		mjmlValue: "mj-accordion-element"
	},
	accordionTitle: {
		value: "accordionTitle",
		mjmlValue: "mj-accordion-title"
	},
	accordionText: {
		value: "accordionText",
		mjmlValue: "mj-accordion-text"
	},
	social: {
		value: "social",
		mjmlValue: "mj-social"
	},
	socialElement: {
		value: "socialElement",
		mjmlValue: "mj-social-element"
	}
};

/**
 * Contains all content builder head types with string representation and name for mapping in mjml config.
 */
BPMSoft.ContentBuilder.enums.HeadItemType = {
	head: {
		value: "head",
		mjmlValue: "mj-head"
	},
	attributes: {
		value: "attributes",
		mjmlValue: "mj-attributes"
	},
	breakpoint: {
		value: "breakpoint",
		mjmlValue: "mj-breakpoint"
	},
	font: {
		value: "font",
		mjmlValue: "mj-font"
	},
	preview: {
		value: "preview",
		mjmlValue: "mj-preview"
	},
	style: {
		value: "style",
		mjmlValue: "mj-style"
	},
	title: {
		value: "title",
		mjmlValue: "mj-title"
	}
};

/**
 * Parameters which are defined the content builder working state.
 */
BPMSoft.ContentBuilder.enums.Params = {
	config: {
		GRID: 1,
		MJML: 2,
		HTML: 4
	},
	mjmlFeature: {
		OFF: 8,
		ON: 16
	}
};

/**
 * Working state of content builder based on config type and MJML feature state.
 */
BPMSoft.ContentBuilder.enums.State = {
	GRID: BPMSoft.ContentBuilder.enums.Params.config.GRID
		| BPMSoft.ContentBuilder.enums.Params.mjmlFeature.OFF,
	MIGRATE: BPMSoft.ContentBuilder.enums.Params.config.GRID
		| BPMSoft.ContentBuilder.enums.Params.mjmlFeature.ON,
	MJML: BPMSoft.ContentBuilder.enums.Params.config.MJML
		| BPMSoft.ContentBuilder.enums.Params.mjmlFeature.ON,
	ERROR: BPMSoft.ContentBuilder.enums.Params.config.MJML
		| BPMSoft.ContentBuilder.enums.Params.mjmlFeature.OFF,
	HTML: BPMSoft.ContentBuilder.enums.Params.config.HTML
		| BPMSoft.ContentBuilder.enums.Params.mjmlFeature.ON
};

/**
 * Code of columns grouping action based on item types to group.
 */
BPMSoft.ContentBuilder.enums.GroupingCode = {
	COLUMN_COLUMN: "column-column",
	COLUMN_GROUP: "column-mjgroup",
	GROUP_COLUMN: "mjgroup-column",
	GROUP_GROUP: "mjgroup-mjgroup"
};

/**
 * Code of columns ungrouping action based on initial action elements position in group.
 */
BPMSoft.ContentBuilder.enums.UngroupingCode = {
	SPLIT: 0,
	FIRST: 1,
	LAST: 2,
	ALL: 3
};

/**
 * Config type option for template entity.
 */
BPMSoft.ContentBuilder.enums.ConfigType = {
	GRID: 0,
	MJML: 1
};

/**
 * Abbreviation for {@link BPMSoft.ContentBuilder.enums.BodyItemType}.
 * @member BPMSoft
 * @inheritdoc BPMSoft.ContentBuilder.enums.BodyItemType
 */
BPMSoft.ContentBuilderBodyItemType = BPMSoft.ContentBuilder.enums.BodyItemType;

/**
 * Abbreviation for {@link BPMSoft.ContentBuilder.enums.HeadItemType}.
 * @member BPMSoft
 * @inheritdoc BPMSoft.ContentBuilder.enums.HeadItemType
 */
BPMSoft.ContentBuilderHeadItemType = BPMSoft.ContentBuilder.enums.HeadItemType;

/**
 * Abbreviation for {@link BPMSoft.ContentBuilder.enums.State}.
 * @member BPMSoft
 * @inheritdoc BPMSoft.ContentBuilder.enums.State
 */
BPMSoft.ContentBuilderState = BPMSoft.ContentBuilder.enums.State;

/**
 * Abbreviation for {@link BPMSoft.ContentBuilder.enums.Params}.
 * @member BPMSoft
 * @inheritdoc BPMSoft.ContentBuilder.enums.Params
 */
BPMSoft.ContentBuilderParams = BPMSoft.ContentBuilder.enums.Params;

/**
 * Abbreviation for {@link BPMSoft.ContentBuilder.enums.GroupingCode}.
 * @member BPMSoft
 * @inheritdoc BPMSoft.ContentBuilder.enums.GroupingCode
 */
BPMSoft.ContentBuilderGroupingCode = BPMSoft.ContentBuilder.enums.GroupingCode;

/**
 * Abbreviation for {@link BPMSoft.ContentBuilder.enums.UngroupingCode}.
 * @member BPMSoft
 * @inheritdoc BPMSoft.ContentBuilder.enums.UngroupingCode
 */
BPMSoft.ContentBuilderUngroupingCode = BPMSoft.ContentBuilder.enums.UngroupingCode;

/**
 * Abbreviation for {@link BPMSoft.ContentBuilder.enums.ConfigType}.
 * @member BPMSoft
 * @inheritdoc BPMSoft.ContentBuilder.enums.ConfigType
 */
BPMSoft.ContentBuilderConfigType = BPMSoft.ContentBuilder.enums.ConfigType;

/**
 * @enum [BPMSoft.enums.TextAlign]
 * Text alignment type.
 */
BPMSoft.enums.TextAlign = {
	LEFT: "left",
	CENTER: "center",
	RIGHT: "right",
	JUSTIFY: "justify"
};

/**
 * Alias for {@link BPMSoft.TextAlign}.
 */
BPMSoft.TextAlign = BPMSoft.enums.TextAlign;

/**
 * @enum [BPMSoft.enums.TextAlign]
 * Text alignment type.
 */
BPMSoft.enums.FontSet = {
	ARIAL: "Arial, Helvetica, sans-serif",
	VERDANA: "Verdana, Geneva, sans-serif"
};

/**
 * Alias for {@link BPMSoft.FontSet}.
 */
BPMSoft.FontSet = BPMSoft.enums.FontSet;

/**
 * Defines constants module for ContentBuilder.
 */
define("ContentBuilderConstants", [],
	function () {
		Ext.define("BPMSoft.configuration.ContentBuilderConstants", {
			alternateClassName: "BPMSoft.ContentBuilderConstants"
		});
	});
