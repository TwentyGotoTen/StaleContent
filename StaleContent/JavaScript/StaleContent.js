require.config({
    paths: {
        entityService: "/sitecore/shell/client/Services/Assets/lib/entityservice"
    }
});

define(["sitecore", "entityService"], function (Sitecore, entityService) {
    var StaleContent = Sitecore.Definitions.App.extend({
        initialized: function () {
           // this.GetStaleContent();
        },

        EntityServiceConfig: function () {
            var newsService = new entityService({
                url: "/sitecore/api/ssc/StaleContent-Controllers/StaleContent"
            });


            return newsService;
        },

        GetStaleContent: function () {

            var staleContentService = this.EntityServiceConfig();

            var datasource = this.DataSource;

            var result = staleContentService.fetchEntities().execute().then(function (stateContent) {
                datasource.viewModel.items(stateContent);
            });
        },

    });

    return StaleContent;
});