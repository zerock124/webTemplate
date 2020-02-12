define(["require", "exports", "../Share/PublicFunction"], function (require, exports, PublicFunction_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var StaticPageService = (function () {
        function StaticPageService() {
        }
        StaticPageService.prototype.GetStaticPageList = function () {
            var setting = {
                url: '/StaticPage/GetStaticPageList',
                type: 'GET'
            };
            return PublicFunction_1.AjaxReturn(setting);
        };
        StaticPageService.prototype.CreateStaticPage = function (model) {
            var setting = {
                url: '/StaticPage/CreateStaticPage',
                type: 'POST',
                data: model
            };
            return PublicFunction_1.AjaxReturn(setting);
        };
        StaticPageService.prototype.EditStaticPage = function (model) {
            var setting = {
                url: '/StaticPage/EditStaticPage',
                type: 'POST',
                data: model
            };
            return PublicFunction_1.AjaxReturn(setting);
        };
        return StaticPageService;
    }());
    var fonthome_service = new StaticPageService();
    exports.default = fonthome_service;
});
//# sourceMappingURL=service.js.map