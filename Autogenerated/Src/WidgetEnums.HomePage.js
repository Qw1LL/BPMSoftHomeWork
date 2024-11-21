  define("WidgetEnums", ["WidgetEnumsResources"], function(resources) {

	Ext.ns("BPMSoft.WidgetEnums");

	BPMSoft.WidgetEnums.WidgetColorSet = [
		"orange",
		"yellow",
		"celestial-blue",
		"light-blue",
		"light-green",
		"purple",
		"dark-green",
		"green",
		"orange-red",
		"red",
		"coral",
		"mango",
		"dark-turquoise",
		"turquoise",
		"blue",
		"violet",
	];

	BPMSoft.WidgetEnums.WidgetColor = {
		"orange": {
			value: "orange",
			displayValue: resources.localizableStrings.StyleOrange,
			imageConfig: resources.localizableImages.ImageOrange
		},
		"yellow": {
			value: "yellow",
			displayValue: resources.localizableStrings.StyleYellow,
			imageConfig: resources.localizableImages.ImageYellow
		},
		"celestial-blue": {
			value: "celestial-blue",
			displayValue: resources.localizableStrings.StyleCelestialBlue,
			imageConfig: resources.localizableImages.ImageCelestialBlue
		},
		"light-blue": {
			value: "light-blue",
			displayValue: resources.localizableStrings.StyleLightBlue,
			imageConfig: resources.localizableImages.ImageLightBlue
		},
		"light-green": {
			value: "light-green",
			displayValue: resources.localizableStrings.StyleLightGreen,
			imageConfig: resources.localizableImages.ImageLightGreen
		},
		"purple": {
			value: "purple",
			displayValue: resources.localizableStrings.StylePurple,
			imageConfig: resources.localizableImages.ImagePurple
		},
		"dark-green": {
			value: "dark-green",
			displayValue: resources.localizableStrings.StyleDarkGreen,
			imageConfig: resources.localizableImages.ImageDarkGreen
		},
		"green": {
			value: "green",
			displayValue: resources.localizableStrings.StyleGreen,
			imageConfig: resources.localizableImages.ImageGreen
		},
		"orange-red": {
			value: "orange-red",
			displayValue: resources.localizableStrings.StyleOrangeRed,
			imageConfig: resources.localizableImages.ImageOrangeRed
		},
		"red": {
			value: "red",
			displayValue: resources.localizableStrings.StyleRed,
			imageConfig: resources.localizableImages.ImageRed
		},
		"coral": {
			value: "coral",
			displayValue: resources.localizableStrings.StyleCoral,
			imageConfig: resources.localizableImages.ImageCoral
		},		
		"mango": {
			value: "mango",
			displayValue: resources.localizableStrings.StyleMango,
			imageConfig: resources.localizableImages.ImageMango
		},
		"dark-turquoise": {
			value: "dark-turquoise",
			displayValue: resources.localizableStrings.StyleDarkTurquoise,
			imageConfig: resources.localizableImages.ImageDarkTurquoise
		},
		"turquoise": {
			value: "turquoise",
			displayValue: resources.localizableStrings.StyleTurquoise,
			imageConfig: resources.localizableImages.ImageTurquoise
		},
		"blue": {
			value: "blue",
			displayValue: resources.localizableStrings.StyleBlue,
			imageConfig: resources.localizableImages.ImageBlue
		},
		"violet": {
			value: "violet",
			displayValue: resources.localizableStrings.StyleViolet,
			imageConfig: resources.localizableImages.ImageViolet
		},
	};

	BPMSoft.WidgetEnums.WidgetTheme = {
		"full-fill": {
			value: "full-fill",
			displayValue: resources.localizableStrings.FullFillTheme
		},
		"without-fill": {
			value: "without-fill",
			displayValue: resources.localizableStrings.WithoutFillTheme
		},
		"partial-fill": {
			value: "partial-fill",
			displayValue: resources.localizableStrings.PartialFillTheme
		},
	};

	BPMSoft.WidgetEnums.WidgetColorFullSet = [
		'black',
		'grey',
		'orange',
		'red',
		'brilliant yellowish green',
		'green',
		'white',
		'light-gray',
		'purplish-white',
		'brown',
		'green tea',
		'gentle-olive',
		'heavenly',
		'celestial-blue',
		'periwinkle',
		'violet',
		'persian green',
		'dark-turquoise',
		'pale light blue',
		'navy blue',
		'light violet',
		'dark purpl',
		'pale blue',
		'emerald',
		'yellow',
		'golden-birch',
		'red-sand',
		'carrot',
		'manatee',
		'pigeon blue',
		'peach',
		'taupe',
		'orange-peach',
		'sandy-brown',
		'timber wolf',
		'purplish-blue',
	];

	BPMSoft.WidgetEnums.WidgetColorFull = {
		"black": {
			value: "black",
			displayValue: resources.localizableStrings.StyleBlack,
			imageConfig: resources.localizableImages.ImageBlack
		},
		"grey": {
			value: "grey",
			displayValue: resources.localizableStrings.StyleGrey,
			imageConfig: resources.localizableImages.ImageGrey
		},
		"orange": {
			value: "orange",
			displayValue: resources.localizableStrings.StyleOrange,
			imageConfig: resources.localizableImages.ImageOrange
		},
		"red": {
			value: "red",
			displayValue: resources.localizableStrings.StyleRed,
			imageConfig: resources.localizableImages.ImageRed
		},
		"brilliant yellowish green": {
			value: "brilliant yellowish green",
			displayValue: resources.localizableStrings.StyleBrilliantYellowishGreen,
			imageConfig: resources.localizableImages.ImageBrilliantYellowishGreen
		},
		"green": {
			value: "green",
			displayValue: resources.localizableStrings.StyleGreen,
			imageConfig: resources.localizableImages.ImageGreen
		},
		"white": {
			value: "white",
			displayValue: resources.localizableStrings.StyleWhite,
			imageConfig: resources.localizableImages.ImageWhite
		},
		"light-gray": {
			value: "light-gray",
			displayValue: resources.localizableStrings.StyleLightGray,
			imageConfig: resources.localizableImages.ImageLightGray
		},
		"purplish-white": {
			value: "purplish-white",
			displayValue: resources.localizableStrings.StylePurplishWhite,
			imageConfig: resources.localizableImages.ImagePurplishWhite
		},
		"brown": {
			value: "brown",
			displayValue: resources.localizableStrings.StyleBrown,
			imageConfig: resources.localizableImages.ImageBrown
		},
		"green tea": {
			value: "green tea",
			displayValue: resources.localizableStrings.StyleGreenTea,
			imageConfig: resources.localizableImages.ImageGreenTea
		},
		"gentle-olive": {
			value: "gentle-olive",
			displayValue: resources.localizableStrings.StyleGentleOlive,
			imageConfig: resources.localizableImages.ImageGentleOlive
		},
		"heavenly": {
			value: "heavenly",
			displayValue: resources.localizableStrings.StyleHeavenly,
			imageConfig: resources.localizableImages.ImageHeavenly
		},
		"celestial-blue": {
			value: "celestial-blue",
			displayValue: resources.localizableStrings.StyleCelestialBlue,
			imageConfig: resources.localizableImages.ImageCelestialBlue
		},
		"periwinkle": {
			value: "periwinkle",
			displayValue: resources.localizableStrings.StylePeriwinkle,
			imageConfig: resources.localizableImages.ImagePeriwinkle
		},
		"violet": {
			value: "violet",
			displayValue: resources.localizableStrings.StyleViolet,
			imageConfig: resources.localizableImages.ImageViolet
		},
		"persian green": {
			value: "persian green",
			displayValue: resources.localizableStrings.StylePersianGreen,
			imageConfig: resources.localizableImages.ImagePersianGreen
		},
		"dark-turquoise": {
			value: "dark-turquoise",
			displayValue: resources.localizableStrings.StyleDarkTurquoise,
			imageConfig: resources.localizableImages.ImageDarkTurquoise
		},
		"pale light blue": {
			value: "pale light blue",
			displayValue: resources.localizableStrings.StylePaleLightBlue,
			imageConfig: resources.localizableImages.ImagePaleLightBlue
		},
		"navy blue": {
			value: "navy blue",
			displayValue: resources.localizableStrings.StyleNavyBlue,
			imageConfig: resources.localizableImages.ImageNavyBlue
		},
		"light violet": {
			value: "light violet",
			displayValue: resources.localizableStrings.StyleLightViolet,
			imageConfig: resources.localizableImages.ImageLightViolet
		},
		"dark purpl": {
			value: "dark purpl",
			displayValue: resources.localizableStrings.StyleDarkPurple,
			imageConfig: resources.localizableImages.ImageDarkPurple
		},
		"pale blue": {
			value: "pale blue",
			displayValue: resources.localizableStrings.StylePaleBlue,
			imageConfig: resources.localizableImages.ImagePaleBlue
		},
		"emerald": {
			value: "emerald",
			displayValue: resources.localizableStrings.StyleEmerald,
			imageConfig: resources.localizableImages.ImageEmerald
		},
		"yellow": {
			value: "yellow",
			displayValue: resources.localizableStrings.StyleYellow,
			imageConfig: resources.localizableImages.ImageYellow
		},
		"golden-birch": {
			value: "golden-birch",
			displayValue: resources.localizableStrings.StyleGoldenBirch,
			imageConfig: resources.localizableImages.ImageGoldenBirch
		},
		"red-sand": {
			value: "red-sand",
			displayValue: resources.localizableStrings.StyleRedSand,
			imageConfig: resources.localizableImages.ImageRedSand
		},
		"carrot": {
			value: "carrot",
			displayValue: resources.localizableStrings.StyleCarrot,
			imageConfig: resources.localizableImages.ImageCarrot
		},
		"manatee": {
			value: "manatee",
			displayValue: resources.localizableStrings.StyleManatee,
			imageConfig: resources.localizableImages.ImageManatee
		},
		"pigeon blue": {
			value: "pigeon blue",
			displayValue: resources.localizableStrings.StylePigeonBlue,
			imageConfig: resources.localizableImages.ImagePigeonBlue
		},
		"peach": {
			value: "peach",
			displayValue: resources.localizableStrings.StylePeach,
			imageConfig: resources.localizableImages.ImagePeach
		},
		"taupe": {
			value: "taupe",
			displayValue: resources.localizableStrings.StyleTaupe,
			imageConfig: resources.localizableImages.ImageTaupe
		},
		"orange-peach": {
			value: "orange-peach",
			displayValue: resources.localizableStrings.StyleOrangePeach,
			imageConfig: resources.localizableImages.ImageOrangePeach
		},
		"sandy-brown": {
			value: "sandy-brown",
			displayValue: resources.localizableStrings.StyleSandyBrown,
			imageConfig: resources.localizableImages.ImageSandyBrown
		},
		"timber wolf": {
			value: "timber wolf",
			displayValue: resources.localizableStrings.StyleTimberWolf,
			imageConfig: resources.localizableImages.ImageTimberWolf
		},
		"purplish-blue": {
			value: "purplish-blue",
			displayValue: resources.localizableStrings.StylePurplishBlue,
			imageConfig: resources.localizableImages.ImagePurplishBlue
		},
	};
});
