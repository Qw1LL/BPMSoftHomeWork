define('GeneratedWebFormLeadColumns', ['ext-base', 'BPMSoft', 'sandbox',
    'Lead', 'GeneratedWebFormLeadColumnsStructure', 'GeneratedWebFormLeadColumnsResources'],
    function(Ext, BPMSoft, sandbox, Lead, structure, resources) {
        structure.userCode = function() {
            this.entitySchema = Lead;
            this.name = 'GeneratedWebFormLeadColumnsCardViewModel';
            this.schema.leftPanel = [];
            this.methods.getHeader = function() {
                return resources.localizableStrings.PageHeader;
            };
        };
        return structure;
    });
