define("PortalClientConstants", [], function() {

	const sysModule = {
		PortalMainPageSectionId: "199c794c-14fe-4b22-a11a-20e941e3458d",
		PortalMainSectionId: "bd15c9c5-fb2a-4b29-9b99-f6b3f9f97613"
	};

	const designerPages = {
		OrganizationPageSchemaUId: "3f258bdb-b9f3-477e-afba-f8d5aab1d4b6",
		ProfileContactPageSchemaUId: "f79c8996-d0aa-4c4d-bc2e-7803bc66d929"
	}

	const designerPagesName = {
		OrganizationPageSchema: "SspAccountProfilePage",
		ProfileContactPageSchema: "SspProfileContactPage"
	}

	return {
		SysModule: sysModule,
		DesignerPages: designerPages,
		DesignerPagesName: designerPagesName
	};
});
