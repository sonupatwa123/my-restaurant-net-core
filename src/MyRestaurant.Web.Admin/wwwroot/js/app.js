var googleApiLoaded = false;
var googleMapLoaded = true;
///Constant and keys
var services = function () {
    return {
        $scope: '$scope',
        accountService: 'accountService',
        $http: '$http',
        $q: '$q',
        $timeout: '$timeout',
        requestInterceptor: 'requestInterceptor',
        menuService: 'menuService',
        menuitemService: 'menuitemService',
        restaurantService: 'restaurantService',
        geolocation: 'geolocation',
        mapService: 'mapService',
        messageService: 'messageService',
        navigationService: 'navigationService',
        offerService: 'offerService',
        chefService:'chefService'
    }
}
var constants = function () {
    return {
        url: {
            home: '/Home/Index',
            apiurl: 'http://localhost:57646/',
            appurl: 'http://localhost:57728/',
            registerexternaltoken: 'api/account/RegisterExternalToken',
            registerurl: '/api/account/register',
            loginurl: '/Account/Login/',
            menulisturl: '/Menu/List/',
            menuimagepathurl: '/Content/UserContent/Images/Menu/',
            menudeleteurl: '/Menu/Delete/',
            menuediturl: '/Menu/Save/',
            menuaddurl: '/Menu/Save/',
            menudeleteallurl: '/Menu/DeleteMenus/',
            restaurantlisturl: '/Restaurant/List/',
            restaurantdeleteurl: '/Restaurant/Delete/',
            restaurantediturl: '/Restaurant/Save/',
            restaurantaddurl: '/Restaurant/Save/',
            restaurantdeleteallurl: '/Restaurant/DeleteMenus/',
            rstListurl: '/Scripts/app/directive/templates/rstList.html',
            restaurantsaveurl: 'Restaurant/Save/',
            restaurantgeturl: 'Restaurant/Get/',
            loadAllRestaurantApi: 'Restaurant/restaurantdropdown',
            loadcountries: 'utility/countries/',
            loadstates: 'utility/states/',
            loadcities: 'utility/cities/',
            menufileuploadurl: 'File/UploadMenuLogo/',
            restaurantlogo: 'File/UploadRestrauntLogo/',
            offerimageuploadurl:'File/UploadOfferLogo',
            rstPopup: '/Scripts/app/directive/templates/rstPopup.html',
            addEditMenu: '/Scripts/app/directive/templates/addEditMenu.html',
            addEditMenuItem: '/Scripts/app/directive/templates/addEditMenuItem.html',
            deliveryTypes: '/Menu/DeliveryTypes',
            menuCategories: '/Menu/MenuCategory',
            menuItemsUrlApi:'/Menu/menuitemdropdown/',
            savemessage: '/admin/message/save/',
            getmessage: '/admin/message/get/',
            getmessagelist: '/admin/messages/',
            editmessage: '/message/save/',
            messagelist: '/message/list/',
            getNavigations: '/admin/navigation/navigations/',
            saveNavigation: '/admin/navigation/save/',
            saveNavigationWeb:'/admin/savenavigation/',
            deleteNavigation: '/admin/navigation/delete/',
            getNavigation: '/admin/navigation/get/',
            offerlisturlApi: '/offer/offers/',
            offerDeleteUrlApi: '/offer/delete',
            offerSaveUrl: '/offer/save/',
            offerDeleteAllUrlApi: '/offer/deleteall/',
            getOfferUrlApi: '/offer/get/',
            offerlisturl:'/offer/list/',
            cuisinegetservice: 'menu/cuisinedropdown',
            chefsaveapiurl: '/chef/save/',
            cheflistapiurl: '/chef/chefs',
            chefsaveurl: '/chef/save/',
            cheflisturl: '/chef/index/',
            chefimageapiurl: 'file/uploadchefphoto',
            getchefapiurl: '/chef/get/',
            chefdeleteurl:'/chef/delete/'
        },
        restInfoOnMap:'<div id="content">'+
           '<div id="siteNotice">'+
           '</div>'+
           '<h1 id="firstHeading" class="firstHeading">{{restname}}</h1>' +
           '<div id="bodyContent">'+
           '<p><b>{{restname}}</b>, {{restaddress}}</p>'+
           '<p>{{restinfo}}</p>'+
           '</div>'+
           '</div>',
        error: {
            filesizeerror: 'File size should be lower then 10Mb',
            filevalidationerror: 'is not valid file',
            browserhtml5error: "This browser doesn't support HTML5 file uploads"
        },
        alerts: {
            deletealert: 'Are you sure you want to delete record',
            deleteall: 'Are you sure you want to delete all records'
        },
        httpmethods: {
            post: 'post',
            get: 'get',
            put: 'put'
        },

        headers: {
            authorization: 'Authorization',
            contenttype: 'Content-Type',
            accept: 'Accept'
        },
        contenttypes: {
            json: 'application/json',
            xform: 'application/x-www-form-urlencoded; charset=UTF-8'
        },
        tokenkey: 'token',
        googleprovider: 'Google',
        restaurantrole: 'Restaurant',
        googleclientid: '853380340681-arcdbeog87iqqvl910locftgqjdbcfst.apps.googleusercontent.com',
        googleapikey: 'AIzaSyDbH22W9H7_gVKet5LlYrWn-ZlQTkaYMKQ',
        bearer: 'Bearer ',
        usermodel: 'usermodel',
        deliveryTypes: {
            HomeDelivery: 'Home Delivery',
            Pickup: 'Pick Up',
            Both: 'Both'
        },
        MenuCategory: {
            BreakFast: 'Break Fast',
            Lunch: 'Lunch',
            Dinner: 'Dinner',
            Snacks: 'Snacks'
        }

    }
}
var controllers = function () {
    return {
        accountController: 'accountController',
        dashboard: 'dashboardController',
        layout: 'layoutController',
        menu: 'menuController',
        menuitem: 'menuitemController',
        restaurant: "restaurantController",
        message: 'messageController',
        navigationController: 'navigationController',
        offer: 'offerController',
        chef:'chefController'
    }
}
var controllerContant = function () {
    return {
        restaurant: {
            restaurantModel_address_countryid: 'restaurantModel.address.countryid',
            restaurantModel_address_stateid: 'restaurantModel.address.stateid',
            restaurantModel_address_countryname: 'restaurantModel.address.countryname',
            cityid: 'cityid',
            countryid: 'countryid',
            stateid: 'stateid',
            Id: 'Id',
            RestaurantName: 'RestaurantName',
            Restaurant_Name: 'Restaurant Name',
            UpdatedDate: 'UpdatedDate',
            Updated_Date: 'Last Updated',
            Logo: 'Logo',
            IsDelete: 'IsDeleted',
            IsActive: 'Is Active',
            RestaurantList: "Restaurant's List"

        },
        menu: {
            menuModal: '#menuModal_',
            toggle: 'toggle',
            menuModel_menucategoryid: 'menuModel.menucategoryid',
            menuModel_menuname: 'menuModel.menuname',
            menuItemModal: '#menuItemModal_',
            item_deliverytypeid: 'item.deliverytypeid',
            item_itemname: 'item.itemname',
            item_itemperunitprice: 'item.itemperunitprice'
        },
        message: {
            Code: 'Code',
            Id: 'Id',
            message: 'Message',
            About:'About',
            Info: 'info',
            heading: "Message's List",
            Type:'Type'
        },
        navigation: {
            Name: 'Name',
            Url: 'Url',
            ActionName: 'ActionName',
            Action_Name: 'Action Name',
            ControllerName: 'ControllerName',
            Controller_Name: 'Controller Name',
            listHeading:"Navigation's List"
        }

    }
}

var modules = function () {
    return {
        account: 'account',
        dashboard: 'dashboard',
        layout: 'layout',
        menu: 'menu',
        restaurant: 'restaurant',
        message: 'message',
        navigation: 'navigation',
        offer: 'offer',
        multiselect:'multipleSelect',
        chef: 'chef',
        googlemap: 'googlemap'
    }
}

var directives = function () {
    return {
        rstList: 'rstList',
        rstUpload: 'rstUpload',
        rstPopup: 'rstPopup',
        addEditMenu: 'addEditMenu',
        addEditMenuItem: 'addEditMenuItem',
        numberValue: 'numberValue'
    }
}
///Constant and keys

///Modules
var account = angular.module(modules().account, []);
var dashboard = angular.module(modules().dashboard, []);
var layout = angular.module(modules().layout, []);
var menu = angular.module(modules().menu, []);
var restaurant = angular.module(modules().restaurant, [modules().googlemap]);
var message = angular.module(modules().message, []);
var navigation = angular.module(modules().navigation, []);
var offer = angular.module(modules().offer, [modules().restaurant, modules().multiselect]);
var chef = angular.module(modules().chef, [modules().restaurant,modules().multiselect]);
///Modules

(function () {
    var requestInterceptor = function () {
        return {
            request: function (config) {
                if (localStorage.getItem(constants().tokenkey) && config.url.indexOf(constants().url.apiurl) >= 0) {
                    config.headers[constants().headers.authorization] = constants().bearer + localStorage.getItem(constants().tokenkey);
                }
                return config;
            }
        }
    };
    var configuration = function ($httpProvider) {
        $httpProvider.defaults.headers.post[constants().headers.contenttype] = constants().contenttypes.xform;
        $httpProvider.defaults.headers.post[constants().headers.contenttype] = constants().contenttypes.json;
        $httpProvider.defaults.headers.put[constants().headers.contenttype] = constants().contenttypes.xform;
        $httpProvider.defaults.headers.common[constants().headers.contenttype] = constants().contenttypes.json;
        $httpProvider.defaults.headers.common[constants().headers.accept] = '*/*';
        $httpProvider.interceptors.push(services().requestInterceptor);
    }
    account.factory(services().requestInterceptor, requestInterceptor);
    account.config(configuration);

    dashboard.factory(services().requestInterceptor, requestInterceptor);
    dashboard.config(configuration);

    menu.config(configuration);
    menu.factory(services().requestInterceptor, requestInterceptor);

    restaurant.config(configuration);
    restaurant.factory(services().requestInterceptor, requestInterceptor);

    message.config(configuration);
    message.factory(services().requestInterceptor, requestInterceptor);

    navigation.config(configuration);
    navigation.factory(services().requestInterceptor, requestInterceptor);
})();

function onLoadGapi() {
    googleApiLoaded = true;
}
function initMap() {
    googleMapLoaded = true;
    var map;

    // Create the map with no initial style specified.
    // It therefore has default styling.
    //map = new google.maps.Map(document.getElementById('map'), {
        //center: { lat: -33.86, lng: 151.209 },
        //zoom: 13,
        //mapTypeControl: false
    //});

    // Add a style-selector control to the map.
    //var styleControl = document.getElementById('style-selector-control');
    //map.controls[google.maps.ControlPosition.TOP_BOTTOM].push(styleControl);

    //// Set the map's style to the initial value of the selector.
    //var styleSelector = document.getElementById('style-selector');
    //map.setOptions({ styles: styles[styleSelector.value] });

    // Apply new JSON when the user selects a different style.
    //styleSelector.addEventListener('change', function () {
    //    map.setOptions({ styles: styles[styleSelector.value] });
    //});

   
}

Array.prototype.First = function (callback) {
    var returnObj = {};
    for (var i = 0; i < this.length; i++) {
        if (callback(this[i])) {
            returnObj = this[i];
            break;
        }
    }
    return returnObj;
}
Array.prototype.Any = function (callback) {
    var exists = this.First(callback);
    if (exists) {
        return true;
    } else {
        return false;
    }
}
Array.prototype.Filter = function (condition) {
    var returnArray = [];
    this.forEach(function (obj) {
        if (condition(obj)) {
            returnArray.push(obj);
        }
    });
    return returnArray;
}
Array.prototype.Remove = function (callback) {
    var itemToRemove = this.First(callback);
    if (itemToRemove) {
        var index = this.indexOf(itemToRemove);
        if (index >= 0) {
            this.splice(index, 1);
        }
    }
}
var formatDate = function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [month, day, year].join('-');
}
function guid() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
          .toString(16)
          .substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
      s4() + '-' + s4() + s4() + s4();
}